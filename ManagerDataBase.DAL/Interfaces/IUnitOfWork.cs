using ManagerDataBase.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDataBase.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<ManagerEntity> Managers { get; }
        IRepository<SaleEntity> Sales { get; }
        void SaveChanges();
        void CreateDataBase();
    }
}
