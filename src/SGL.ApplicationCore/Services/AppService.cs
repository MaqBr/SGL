using SGL.ApplicationCore.Interfaces;
using SGL.ApplicationCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SGL.ApplicationCore.Services
{
    public class AppService<TEntity> : ApplicationService, IAppService<TEntity> where TEntity : class
    {

        private readonly IRepository<TEntity> _repository;

        public AppService(IRepository<TEntity> repository, IUnitOfWork uow) : base(uow)
        {
            _repository = repository;
        }

        public TEntity Adicionar(TEntity entity)
        {
            BeginTransaction();
            var result = _repository.Adicionar(entity);
            Commit();
            return result;
        }

        public void Atualizar(TEntity entity)
        {
            BeginTransaction();
            _repository.Atualizar(entity);
            Commit();
        }

        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicado)
        {
            return _repository.Buscar(predicado);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public TEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Remover(TEntity entity)
        {
            BeginTransaction();
            _repository.Remover(entity);
            Commit();
        }
    }
}
