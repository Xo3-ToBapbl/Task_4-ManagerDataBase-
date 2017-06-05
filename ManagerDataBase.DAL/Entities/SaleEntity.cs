using ManagerDataBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ManagerDataBase.DAL.Entities
{
    public class SaleEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public int Cost { get; set; }

        public int ManagerId { get; set; }
        public ManagerEntity Manager { get; set; }
    }
}
