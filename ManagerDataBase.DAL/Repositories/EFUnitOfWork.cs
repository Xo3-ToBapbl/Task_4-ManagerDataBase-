using ManagerDataBase.DAL.Interfaces;
using System;
using ManagerDataBase.DAL.Entities;
using ManagerDataBase.DAL.EFContext;

namespace ManagerDataBase.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ManagersDBContext _dbContext;
        private ManagersRepository _managersRepository;
        private SalesRepository _salesRepository;
        private bool _disposed = false;

        public EFUnitOfWork(string connectionString)
        {
            _dbContext = new ManagersDBContext(connectionString);
        }


        public IRepository<ManagerEntity> Managers
        {
            get
            {
                if(_managersRepository == null)
                {
                    _managersRepository = new ManagersRepository(_dbContext);
                }
                return _managersRepository;
            }
        }

        public IRepository<SaleEntity> Sales
        {
            get
            {
                if (_salesRepository == null)
                {
                    _salesRepository = new SalesRepository(_dbContext);
                }
                return _salesRepository;
            }
        }

        public void CreateDataBase()
        {
            _dbContext.Database.CreateIfNotExists();
            Console.WriteLine("Database is ready to work.");
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        #region Disposing
        protected virtual void Dispose(bool disposing)
        {
            if(!this._disposed)
            {
                if(disposing)
                {
                    _dbContext.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
