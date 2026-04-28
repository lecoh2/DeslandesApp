using AutoMapper;
using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Interfaces.Services;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Requests.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoCliente;
using DeslandesApp.Domain.Models.Dtos.Responses.GrupoCasoEnvolvidos;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public class GrupoCasoEnvolvidoService(IUnitOfWork unitOfWork, IMapper mapper) : IGrupoCasoEnvovidoService
    {
        public Task<GrupoCasoEnvolvidosResponse> AdicionarAsync(GrupoCasoEnvolvidosRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoCasoEnvolvidosResponse> AdicionarGrupoCasoEnvolvidoAsync(Guid idPessoa, Guid idCaso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var pessoa = await unitOfWork.PessoaRepository.GetByIdAsync(idPessoa);
                if (pessoa is null)
                    throw new ApplicationException("Pessoa não encontrada.");

                var caso = await unitOfWork.CasoRepository.GetByIdAsync(idCaso);
                if (caso is null)
                    throw new ApplicationException("Caso não encontrado.");
                var qualificacao = await unitOfWork.QualificacaoRepository.GetByIdAsync(idCaso);
                if (caso is null)
                    throw new ApplicationException("Caso não encontrado.");

                var existeVinculo = await unitOfWork.GrupoCasoEnvolvidosRepository
                    .ExistCasoEnvolvidoAsync(idPessoa, idCaso);

                if (existeVinculo != null)
                    throw new ApplicationException("Este envovido já está vinculado a esse caso.");

                var grupoCasoEnvolvido = new GrupoCasoEnvolvido
                {
                    PessoaId = idPessoa,
                    CasoId = idCaso
                };

                await unitOfWork.GrupoCasoEnvolvidosRepository.AddAsync(grupoCasoEnvolvido);

                await unitOfWork.CommitAsync();

                return new GrupoCasoEnvolvidosResponse
                {
                    PessoaId = pessoa.Id,
                    Nome = pessoa.Nome,
                    QualificacaoId = qualificacao.Id,
                    NomeQualificacao = qualificacao.NomeQualificacao
                };
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw;
            }
        }

        public Task<PageResult<GrupoCasoEnvolvidosResponse>> ConsultarAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }

        public Task<GrupoCasoEnvolvidosResponse> ExcluirAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoCasoEnvolvidosResponse> ModificarAsync(Guid id, GrupoCasoEnvolvidoUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GrupoCasoEnvolvidosResponse?> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<GrupoCasoEnvolvidosResponse> RemoverGrupoCasoEnvolvidoAsync(Guid idPessoa, Guid idCaso)
        {
            await unitOfWork.BeginTransactionAsync();

            try
            {
                var entidade = await unitOfWork.GrupoCasoEnvolvidosRepository
                    .GetByIdEnvolvidoAsync(idPessoa, idCaso);

                if (entidade is null)
                    throw new Exception("Vínculo entre caso e envolvido não encontrado.");

                await unitOfWork.GrupoCasoEnvolvidosRepository.DeleteAsync(entidade);

                await unitOfWork.CommitAsync();
                return new GrupoCasoEnvolvidosResponse
                {
                    PessoaId = entidade.PessoaId,
                    Nome = entidade.Pessoa?.Nome,
                    QualificacaoId = entidade.QualificacaoId,
                    NomeQualificacao = entidade.Qualificacao?.NomeQualificacao
                };
            }
            catch
            {
                await unitOfWork.RollbackAsync();
                throw; // 🔥 ESSENCIAL pro middleware funcionar
            }
        }
    }
}
