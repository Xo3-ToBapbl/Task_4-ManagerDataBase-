using ManagerDataBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerDataBase.DAL.Entities;
using ManagerDataBase.DAL.EFContext;
using ManagerDataBase.DAL.Repositories;

namespace ManagerDataBase.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ManagersDBContext _dbContext;
        private ManagersRepository _managersRepository;
        private SalesRepository _salesRepository;
        private bool _disposed = false;

        public EFUnitOfWork()
        {
            _dbContext = new ManagersDBContext();
        }


        public IRepository<Manager> Managers
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

        public IRepository<Sale> Sales
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
