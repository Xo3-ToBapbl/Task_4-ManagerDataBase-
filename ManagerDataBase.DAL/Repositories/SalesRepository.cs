using ManagerDataBase.DAL.EFContext;
using ManagerDataBase.DAL.Entities;
using ManagerDataBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ManagerDataBase.DAL.Repositories
{
    class SalesRepository : IRepository<SaleEntity>
    {
        private ManagersDBContext _dbContext;

        public SalesRepository(ManagersDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public SaleEntity Get(int id)
        {
            return _dbContext.Sales.Find(id);
        }

        public int? GetId(Func<SaleEntity, bool> predicate)
        {
            var sale = _dbContext.Sales.FirstOrDefault(predicate);
            if (sale != null)
            {
                return sale.Id;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<SaleEntity> GetAll()
        {
            return _dbContext.Sales.Include(x => x.Manager);
        }

        public void Create(SaleEntity item)
        {
            _dbContext.Sales.Add(item);
        }

        public void Delete(int id)
        {
            SaleEntity sale = _dbContext.Sales.Find(id);
            if (sale != null)
            {
                _dbContext.Sales.Remove(sale);
            }
        }

        public IEnumerable<SaleEntity> FindAll(Func<SaleEntity, bool> predicate)
        {
            return _dbContext.Sales.Include(x => x.Manager).Where(predicate).ToList();
        }

        public SaleEntity Find(Func<SaleEntity, bool> predicate)
        {
            return _dbContext.Sales.FirstOrDefault(predicate);
        }

        public void Update(SaleEntity item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
