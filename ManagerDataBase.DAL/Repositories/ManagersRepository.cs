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
    class ManagersRepository : IRepository<Manager>
    {
        private ManagersDBContext _dbContext;

        public ManagersRepository(ManagersDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public Manager Get(int id)
        {
            return _dbContext.Managers.Find(id);
        }

        public int? GetId(Func<Manager, bool> predicate)
        {
            var manager = _dbContext.Managers.FirstOrDefault(predicate);
            if (manager != null)
            {
                return manager.Id;
            }
            else
            {
                return null;
            }      
        }

        public IEnumerable<Manager> GetAll()
        {
            return _dbContext.Managers;
        }

        public void Create(Manager manager)
        {
            _dbContext.Managers.Add(manager);
        }

        public void Delete(int id)
        {
            Manager manager = _dbContext.Managers.Find(id);
            if (manager != null)
            {
                _dbContext.Managers.Remove(manager);
            }
        }

        public IEnumerable<Manager> FindAll(Func<Manager, bool> predicate)
        {
            return _dbContext.Managers.Where(predicate).ToList();
        }        

        public Manager Find(Func<Manager, bool> predicate)
        {
            return _dbContext.Managers.FirstOrDefault(predicate);
        }

        public void Update(Manager item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
