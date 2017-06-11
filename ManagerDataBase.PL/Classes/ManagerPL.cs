using System.Collections.Generic;

namespace ManagerDataBase.PL.Classes
{
    public class ManagerPL
    {
        public string SecondName { get; set; }
        public string PathToFile { get; set; }

        public virtual ICollection<SalePL> Sales { get; set; }
    }
}
