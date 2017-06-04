using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDataBase.BLL.DTO
{
    public class ManagerDTO
    {
        public int Id { get; set; }
        public string SecondName { get; set; }

        public virtual ICollection<SaleDTO> Sales { get; set; }
    }
}
