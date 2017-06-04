using ManagerDataBase.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ManagerDataBase.DAL.Entities
{
    public class Manager
    { 
        public int Id { get; set; }
        public string SecondName { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
