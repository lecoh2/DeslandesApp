using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork //(DataContext dataContext) : IUnitOfWork
    {
        //atributo para armazenar o contexto 
        private readonly DataContext dataContext;

        //construtor para injeção de dependência 
        public UnitOfWork(DataContext _dataContext)
        {
            dataContext = _dataContext;
        }

        #region Repositórios
        private IUsuarioRepository? _usuarioRepository;
        private INivelRepository? _nivelRepository;
        private ISetorRepository? _setorRepository;
        private IGrupoNiveisRepository? _grupoNiveisRepository;
        private IGrupoSetoresRepository? _grupoSetoresRepository;
        private IFailedLoginAttemptRepository? _failedLoginAttemptRepository;
        private ILoginHistoryRepository? _loginHistoryRepository;
        private IPessoaRepository? _pessoaRepository;
        private IEnderecoRepository? _enderecoRepository;
        private IInformacoesComplementaresRepository? _informacoesComplementaresRepository;
        private IPessoaHistoricoRepository? _pessoaHistoricoRepository;
        private IProcessoRepository? _processoRepository;
        private IGrupoClientesRepository? _grupoClientesRepository;
        private IGrupoEnvolvidosRepository? _grupoEnvolvidosRepository;
        private IVaraRepository? _varaRepository;
        private ITarefaRepository? _tarefaRepository;
        private IListaTarefaRepository? _listaTarefaRepository;
        private IGrupoTarefaEnvolvidoRepository? _grupoTarefaEnvolvidoRepository;
        private ICasoRepository? _casoRepository;
        private IAtendimentoRepository? _atendimentoRepository;
        private IGrupoCasoClienteRepository? _grupoCasoClienteRepository;
        private IGrupoCasoEnvolvidosRepository? _grupoCasoEnvolvidosRepository;
        private IEtiquetaRepository? _etiquetaRepository;
        private IGrupoAtendimentoClienteRepository? _atendimentoClienteRepository;
        private IGrupoAtendimentoEtiquetaRepository? _grupoAtendimentoEtiquetaRepository;

        public IGrupoAtendimentoEtiquetaRepository GrupoAtendimentoEtiquetaRepository
        {
            get
            {
                if (_grupoAtendimentoEtiquetaRepository == null)
                    _grupoAtendimentoEtiquetaRepository = new GrupoAtendimentoEtiquetaRepository(dataContext);

                return _grupoAtendimentoEtiquetaRepository;
            }
        }
        public IGrupoAtendimentoClienteRepository GrupoAtendimentoClienteRepository
        {
            get
            {
                if (_atendimentoClienteRepository == null)
                    _atendimentoClienteRepository = new GrupoAtendimentoClienteRepository(dataContext);

                return _atendimentoClienteRepository;
            }
        }
        public IEtiquetaRepository EtiquetaRepository
        {
            get
            {
                if (_etiquetaRepository == null)
                    _etiquetaRepository = new EtiquetaRepository(dataContext);

                return _etiquetaRepository;
            }
        }
        public IGrupoCasoEnvolvidosRepository GrupoCasoEnvolvidosRepository
        {
            get
            {
                if (_grupoCasoEnvolvidosRepository == null)
                    _grupoCasoEnvolvidosRepository = new GrupoCasoEnvolvidosRepository(dataContext);

                return _grupoCasoEnvolvidosRepository;
            }
        }
        public IGrupoCasoClienteRepository GrupoCasoClienteRepository
        {
            get
            {
                if (_grupoCasoClienteRepository == null)
                    _grupoCasoClienteRepository = new GrupoCasoClienteRepository(dataContext);

                return _grupoCasoClienteRepository;
            }
        }
        public IAtendimentoRepository AtendimentoRepository
        {
            get
            {
                if (_atendimentoRepository == null)
                    _atendimentoRepository = new AtendimentoRepository(dataContext);

                return _atendimentoRepository;
            }
        }
        public ICasoRepository CasoRepository
        {
            get
            {
                if (_casoRepository == null)
                    _casoRepository = new CasoRepository(dataContext);

                return _casoRepository;
            }
        }
        public IGrupoTarefaEnvolvidoRepository GrupoTarefaEnvolvidoRepository
        {
            get
            {
                if (_grupoTarefaEnvolvidoRepository == null)
                    _grupoTarefaEnvolvidoRepository = new GrupoTarefaEnvolvidoRepository(dataContext);

                return _grupoTarefaEnvolvidoRepository;
            }
        }
        public IListaTarefaRepository ListaTarefaRepository
        {
            get
            {
                if (_listaTarefaRepository == null)
                    _listaTarefaRepository = new ListaTarefaRepository(dataContext);

                return _listaTarefaRepository;
            }
        }
        public ITarefaRepository TarefaRepository
        {
            get
            {
                if (_tarefaRepository == null)
                    _tarefaRepository = new TarefaRepository(dataContext);

                return _tarefaRepository;
            }
        }
        public IVaraRepository VaraRepository
        {
            get
            {
                if (_varaRepository == null)
                    _varaRepository = new VaraRepository(dataContext);

                return _varaRepository;
            }
        }
        public IGrupoEnvolvidosRepository GrupoEnvolvidosRepository
        {
            get
            {
                if (_grupoEnvolvidosRepository == null)
                    _grupoEnvolvidosRepository = new GrupoEnvolvidosRepository(dataContext);

                return _grupoEnvolvidosRepository;
            }
        }
        public IGrupoClientesRepository GrupoClientesRepository

        {
            get
            {
                if (_grupoClientesRepository == null)
                    _grupoClientesRepository = new GrupoClientesRepository(dataContext);

                return _grupoClientesRepository;
            }
        }
        public IProcessoRepository ProcessoRepository

        {
            get
            {
                if (_processoRepository == null)
                    _processoRepository = new ProcessoRepository(dataContext);

                return _processoRepository;
            }
        }
        public IPessoaHistoricoRepository PessoaHistoricoRepository

        {
            get
            {
                if (_pessoaHistoricoRepository == null)
                    _pessoaHistoricoRepository = new PessoaHistoricoRepository(dataContext);

                return _pessoaHistoricoRepository;
            }
        }
        public IInformacoesComplementaresRepository InformacoesComplementaresRepository

        {
            get
            {
                if (_informacoesComplementaresRepository == null)
                    _informacoesComplementaresRepository = new InformacoesComplementaresRepository(dataContext);

                return _informacoesComplementaresRepository;
            }
        }
        public IEnderecoRepository EnderecoRepository

        {
            get
            {
                if (_enderecoRepository == null)
                    _enderecoRepository = new EnderecoRepository(dataContext);

                return _enderecoRepository;
            }
        }
        public IPessoaRepository PessoaRepository

        {
            get
            {
                if (_pessoaRepository == null)
                    _pessoaRepository = new PessoaRepository(dataContext);

                return _pessoaRepository;
            }
        }
        public ILoginHistoryRepository LoginHistoryRepository
        {
            get
            {
                if (_loginHistoryRepository == null)
                    _loginHistoryRepository = new LoginHistoryRepository(dataContext);

                return _loginHistoryRepository;
            }
        }
        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (_usuarioRepository == null)
                    _usuarioRepository = new UsuarioRepository(dataContext);

                return _usuarioRepository;
            }
        }
        public INivelRepository NivelRepository
        {
            get
            {
                if (_nivelRepository == null)
                    _nivelRepository = new NivelRepository(dataContext);

                return _nivelRepository;
            }
        }
        public ISetorRepository SetorRepository
        {
            get
            {
                if (_setorRepository == null)
                    _setorRepository = new SetorRepository(dataContext);

                return _setorRepository;
            }
        }
        public IGrupoSetoresRepository GrupoSetoresRepository
        {
            get
            {
                if (_grupoSetoresRepository == null)
                    _grupoSetoresRepository = new GrupoSetorRepository(dataContext);

                return _grupoSetoresRepository;
            }
        }
        public IFailedLoginAttemptRepository FailedLoginAttemptRepository
        {
            get
            {
                if (_failedLoginAttemptRepository == null)
                    _failedLoginAttemptRepository = new FailedLoginAttemptRepository(dataContext);

                return _failedLoginAttemptRepository;
            }
        }
        public IGrupoNiveisRepository GrupoNiveisRepository
        {
            get
            {
                if (_grupoNiveisRepository == null)
                    _grupoNiveisRepository = new GrupoNivelRepository(dataContext);

                return _grupoNiveisRepository;
            }
        }



        #endregion
        #region Transaçoes
        //construtor para injeção de dependência 
        private IDbContextTransaction? transaction;
        public async Task BeginTransactionAsync()
        {
            if (transaction == null)

                transaction = await dataContext.Database.BeginTransactionAsync();
        }
        public async Task CommitAsync()
        {
            try
            {
                await dataContext.SaveChangesAsync();

                if (transaction != null)
                    await transaction.CommitAsync();
            }
            catch
            {
                if (transaction != null)
                    await transaction.RollbackAsync();

                throw;
            }
        }
        public async Task RollbackAsync()
        {
            if (transaction != null)
                await transaction.RollbackAsync();
        }
        public void Dispose()
        {
            dataContext.Dispose();
            if (transaction != null)
                transaction.Dispose();

        }
        #endregion

    }
}
