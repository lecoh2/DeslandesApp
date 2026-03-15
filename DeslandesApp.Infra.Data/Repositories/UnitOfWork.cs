using DeslandesApp.Domain.Interfaces.Repositories;
using DeslandesApp.Domain.Models.Entities;
using DeslandesApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if(transaction !=null)
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
