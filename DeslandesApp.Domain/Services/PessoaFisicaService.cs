using AutoMapper;
using DeslandesApp.Domain.Helpers;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.InformacoesComplementares;
using DeslandesApp.Domain.Models.Dtos.Requests.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Pessoas;
using DeslandesApp.Domain.Models.Dtos.Responses.Usuarios;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Models.Enum;
using DeslandesApp.Domain.Utils;
using DeslandesApp.Domain.Validators;
using DeslandesApp.Domain.ValueObjects;
using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class PessoaFisicaService : IPessoaFisicaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PessoaFisicaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PessoaFisicaResponse> AdicionarAsync(PessoaFisicaRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();

            var cpf = FunctionsHelper.RemovePontosTracos(request.Cpf);
            var rg = FunctionsHelper.RemovePontosTracos(request.Rg);

            if (!FunctionsHelper.ValidadorCPF(cpf))
                throw new ApplicationException("CPF inválido.");

            if (await _unitOfWork.PessoaRepository.CpfInUseAsync(cpf))
                throw new InvalidOperationException("CPF já cadastrado.");

            if (!string.IsNullOrWhiteSpace(rg) &&
                await _unitOfWork.PessoaRepository.RgInUseAsync(rg))
                throw new InvalidOperationException("RG já cadastrado.");

            var pessoa = _mapper.Map<PessoaFisica>(request);

            var validator = new PessoaFisicaValidator();
            var result = validator.Validate(pessoa);

            if (!result.IsValid)
                throw new ValidationException(result.Errors);

            pessoa.CPF = cpf;
            pessoa.RG = rg;
            pessoa.Telefone = FunctionsHelper.RemovePontosTracosTelefone(pessoa.Telefone);
            pessoa.DataCadastro = DateTime.Now;
            pessoa.IdSexo = request.IdSexo;

            pessoa.ValorEmail = string.IsNullOrWhiteSpace(pessoa.ValorEmail?.EnderecoEmail)
                ? new ValorEmail($"nadaconsta{cpf}@email.com")
                : pessoa.ValorEmail;

            if (await _unitOfWork.PessoaRepository.EmailInUseAsync(pessoa.ValorEmail.EnderecoEmail))
                throw new InvalidOperationException("Email já cadastrado.");

            // ENDEREÇO
            if (request.Endereco != null)
            {
                pessoa.Endereco = _mapper.Map<Endereco>(request.Endereco);
                pessoa.Endereco.Cep = FunctionsHelper.RemovePontosTracos(pessoa.Endereco.Cep);
                pessoa.Endereco.Complemento ??= "";
            }

            // INFORMAÇÕES COMPLEMENTARES
            // INFORMAÇÕES COMPLEMENTARES
            if (TemAlgumValor(request.InformacoesComplementares))
            {
                pessoa.InformacoesComplementares =
                    _mapper.Map<InformacoesComplementaresPessoaFisica>(request.InformacoesComplementares);
            }

            // SALVA TUDO JUNTO
            await _unitOfWork.PessoaRepository.AddAsync(pessoa);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PessoaFisicaResponse>(pessoa);
        }


        public Task<PageResult<PessoaFisicaResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }



        public async Task<PageResult<PessoaFisicaPaginacaoResponse>> ConsultarPessoaFisicaPaginacaoAsync(int pageNumber, int pageSize, string? searchTerm = null)
        {
            var paged = await _unitOfWork.PessoaRepository.PessoaFisicaComPaginacaoAsync
                (pageNumber, pageSize, searchTerm);

            if (paged == null || !paged.Items.Any())
            {
                return new PageResult<PessoaFisicaPaginacaoResponse>
                {
                    Items = new List<PessoaFisicaPaginacaoResponse>(),
                    TotalCount = 0,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }

            return paged;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public Task<PessoaFisicaResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<PessoaFisicaResponse> ModificarAsync(Guid id, PessoaFisicaUpdateRequest request)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                // Recuperar a pessoa
                var pessoa = await _unitOfWork.PessoaRepository.GetByIdAsync(id);
                if (pessoa == null)
                    throw new ApplicationException("Pessoa não encontrada para edição.");

                // Buscar dados antes da alteração
                var pessoaAntes = await _unitOfWork.PessoaRepository.ConsultarPessoasFisicasComIdRelacionamentosAsync(id);

                var dadosAntes = new
                {
                    pessoaAntes.Nome,
                    pessoaAntes.Apelido,
                    pessoaAntes.Telefone,
                    pessoaAntes.ValorEmail,
                    pessoaAntes.Site,
                    pessoaAntes.CPF,
                    pessoaAntes.RG,
                    pessoaAntes.TituloEleitor,
                    pessoaAntes.CarteiraTrabalho,
                    pessoaAntes.PisPasep,
                    pessoaAntes.CNH,
                    pessoaAntes.Passaporte,
                    pessoaAntes.CertidaoReservista,
                    
                    Sexo = pessoaAntes.Sexo?.NomeSexo,
                    Usuario = pessoaAntes.Usuario != null ? new
                    {
                        pessoaAntes.Usuario.Id,
                        pessoaAntes.Usuario.Login,
                        pessoaAntes.Usuario.NomeUsuario,
                    } : null,
                    Endereco = pessoaAntes.Endereco != null ? new
                    {
                        pessoaAntes.Endereco.Logradouro,
                        pessoaAntes.Endereco.Numero,
                        pessoaAntes.Endereco.Bairro,
                        pessoaAntes.Endereco.Localidade,
                        pessoaAntes.Endereco.Uf,
                        pessoaAntes.Endereco.Cep
                    } : null,
                    InformacoesComplementares = pessoaAntes.InformacoesComplementares != null ? new
                    {
                        pessoaAntes.InformacoesComplementares.Codigo,
                        pessoaAntes.InformacoesComplementares.Comentario,

                        DataNascimento = ((InformacoesComplementaresPessoaFisica)pessoaAntes.InformacoesComplementares).DataNascimento,
                        NomeEmpresa = ((InformacoesComplementaresPessoaFisica)pessoaAntes.InformacoesComplementares).NomeEmpresa,
                        Profissao = ((InformacoesComplementaresPessoaFisica)pessoaAntes.InformacoesComplementares).Profissao,
                        AtividadeEconomica = ((InformacoesComplementaresPessoaFisica)pessoaAntes.InformacoesComplementares).AtividadeEconomica,
                        EstadoCivil = ((InformacoesComplementaresPessoaFisica)pessoaAntes.InformacoesComplementares).EstadoCivil,
                        NomePai = ((InformacoesComplementaresPessoaFisica)pessoaAntes.InformacoesComplementares).NomePai,
                        NomeMae = ((InformacoesComplementaresPessoaFisica)pessoaAntes.InformacoesComplementares).NomeMae,
                        Naturalidade = ((InformacoesComplementaresPessoaFisica)pessoaAntes.InformacoesComplementares).Naturalidade,
                        Nacionalidade = ((InformacoesComplementaresPessoaFisica)pessoaAntes.InformacoesComplementares).Nacionalidade
                    } : null,
                    pessoaAntes.DataAtualizacao,
                };

                pessoa.DataAtualizacao = DateTime.Now;

                // Aplicar alterações
                _mapper.Map(request, pessoa);
                await _unitOfWork.PessoaRepository.UpdateAsync(pessoa);

                // Atualizar endereço (se necessário)
                if (request.Endereco != null)
                {
                    var enderecoExistente = await _unitOfWork.EnderecoRepository.GetByIdAsync(pessoa.Id);
                    if (enderecoExistente != null)
                    {
                        _mapper.Map(request.Endereco, enderecoExistente);
                        await _unitOfWork.EnderecoRepository.UpdateAsync(enderecoExistente);
                    }
                }
                if (request.InformacoesComplementares != null)
                {
                    var informacoesExistente = await _unitOfWork.InformacoesComplementaresRepository.GetByIdAsync(pessoa.Id);
                    if (informacoesExistente != null)
                    {
                        _mapper.Map(request.InformacoesComplementares, informacoesExistente);
                        await _unitOfWork.InformacoesComplementaresRepository.UpdateAsync(informacoesExistente);
                    }
                }
                // Buscar novamente para montar os dados depois
                var pessoaDepois = await _unitOfWork.PessoaRepository.ConsultarPessoasFisicasComIdRelacionamentosAsync(id);

                var dadosDepois = new
                {
                    pessoaDepois.Nome,
                    pessoaDepois.Apelido,
                    pessoaDepois.Telefone,
                    pessoaDepois.ValorEmail,
                    pessoaDepois.Site,
                    pessoaDepois.CPF,
                    pessoaDepois.RG,
                    pessoaDepois.TituloEleitor,
                    pessoaDepois.CarteiraTrabalho,
                    pessoaDepois.PisPasep,
                    pessoaDepois.CNH,
                    pessoaDepois.Passaporte,
                    pessoaDepois.CertidaoReservista,
                    Sexo = pessoaDepois.Sexo?.NomeSexo,
                    Usuario = pessoaDepois.Usuario != null ? new
                    {
                        pessoaDepois.Usuario.Id,
                        pessoaDepois.Usuario.Login,
                        pessoaDepois.Usuario.NomeUsuario,
                    } : null,
                    Endereco = pessoaDepois.Endereco != null ? new
                    {
                        pessoaDepois.Endereco.Logradouro,
                        pessoaDepois.Endereco.Numero,
                        pessoaDepois.Endereco.Bairro,
                        pessoaDepois.Endereco.Localidade,
                        pessoaDepois.Endereco.Uf,
                        pessoaDepois.Endereco.Cep
                    } : null,
                    pessoaDepois.DataAtualizacao
                };
                if (pessoa.Id== null)
                    throw new ApplicationException("Id da pessoa está nulo. Verifique se a pessoa foi carregada corretamente.");

                if (request.IdUsuario == null)
                    throw new ApplicationException("Id do usuário está nulo. Verifique se está sendo enviado corretamente.");

                // Criar histórico
                var historico = new PessoaHistorico
                {
                   
                    IdPessoa = pessoa.Id!,
                    IdUsuario = request.IdUsuario!.Value,// Você pode incluir isso no DTO ou recuperar do contexto
                    DataAlteracao = DateTime.Now,
                    Observacoes = request.Observacoes,
                    DadosAntes = JsonConvert.SerializeObject(dadosAntes),
                    DadosDepois = JsonConvert.SerializeObject(dadosDepois)
                };

                await _unitOfWork.PessoaHistoricoRepository.AddAsync(historico);
                await _unitOfWork.CommitAsync();

                var response = _mapper.Map<PessoaFisicaResponse>(pessoaDepois);
                return response;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<PessoaFisicaResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        private bool TemAlgumValor(InformacoesComplementaresRequest info)
        {
            if (info == null) return false;

            return !string.IsNullOrWhiteSpace(info.DataNascimento)
                || !string.IsNullOrWhiteSpace(info.NomeEmpresa)
                || !string.IsNullOrWhiteSpace(info.Profissao)
                || !string.IsNullOrWhiteSpace(info.AtividadeEconomica)
                || !string.IsNullOrWhiteSpace(info.EstadoCivil)
                || !string.IsNullOrWhiteSpace(info.Codigo)
                || !string.IsNullOrWhiteSpace(info.NomePai)
                || !string.IsNullOrWhiteSpace(info.NomeMae)
                || !string.IsNullOrWhiteSpace(info.Naturalidade)
                || !string.IsNullOrWhiteSpace(info.Nacionalidade)
                || !string.IsNullOrWhiteSpace(info.Comentario);
        }
    }
}
