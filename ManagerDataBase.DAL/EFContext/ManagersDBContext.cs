using System.Data.Entity;
using ManagerDataBase.DAL.Entities;

namespace ManagerDataBase.DAL.EFContext
{
    public class ManagersDBContext : DbContext
    {
        public ManagersDBContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<ManagerEntity> Managers { get; set; }
        public DbSet<SaleEntity> Sales { get; set; }
    }
}
