using CRUD_Core.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CrudAPIContext _context;
        private Hashtable _repositories;

        public UnitOfWork(CrudAPIContext context)
        {
            _context = context;
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); ;
        }

        public IGenericRepository<TEntity> Repository<TEntity>()
        {
            //check if we have any repo in our Hashtable or if our Hashtable has been instantiated
            if (_repositories == null) _repositories = new Hashtable();

            //get the type of TEntity
            var type = typeof(TEntity).Name;

            //check if our hashtable contains an entry for the repository type of TEntity
            if (!_repositories.ContainsKey(type))
            {
                //if our hashtable does not have the needed repo, we create an instance of the needed repo and add to our hastable
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            //return the needed repository from our Hastable
            return (IGenericRepository<TEntity>)_repositories[type];
        }
    }
}
