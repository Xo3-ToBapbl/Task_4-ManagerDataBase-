using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDataBase.PL.Classes
{
    public class ManagerPL
    {
        public string SecondName { get; set; }
        public string PathToFile { get; set; }

        public virtual ICollection<SalePL> Sales { get; set; }
    }
}
