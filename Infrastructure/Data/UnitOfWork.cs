using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private Hashtable _repostories;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }
        public Task<int> Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repostories == null) _repostories = new Hashtable();

            var type = typeof(TEntity).Name;
            if (!_repostories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repostories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>) _repostories[type];
        }
    }
}
