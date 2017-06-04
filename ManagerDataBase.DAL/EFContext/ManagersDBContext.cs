using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ManagerDataBase.DAL.Entities;
using ManagerDataBase.DAL.Interfaces;

namespace ManagerDataBase.DAL.EFContext
{
    public class ManagersDBContext : DbContext
    {
        public ManagersDBContext() : base("ManagersDataBaseConnection")
        {

        }

        public DbSet<Manager> Managers { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
