using ManagerDataBase.DAL.EFContext;
using ManagerDataBase.DAL.Entities;
using ManagerDataBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDataBase.DAL.Repositories
{
    class SalesRepository : IRepository<Sale>
    {
        private ManagersDBContext _dbContext;

        public SalesRepository(ManagersDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Sale Get(int id)
        {
            return _dbContext.Sales.Find(id);
        }

        public IEnumerable<Sale> GetAll()
        {
            return _dbContext.Sales.Include(x => x.Manager);
        }

        public void Create(Sale item)
        {
            _dbContext.Sales.Add(item);
        }

        public void Delete(int id)
        {
            Sale sale = _dbContext.Sales.Find(id);
            if (sale != null)
            {
                _dbContext.Sales.Remove(sale);
            }
        }

        public IEnumerable<Sale> FindAll(Func<Sale, bool> predicate)
        {
            return _dbContext.Sales.Include(x => x.Manager).Where(predicate).ToList();
        }

        public Sale Find(Func<Sale, bool> predicate)
        {
            return _dbContext.Sales.FirstOrDefault(predicate);
        }

        public void Update(Sale item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
