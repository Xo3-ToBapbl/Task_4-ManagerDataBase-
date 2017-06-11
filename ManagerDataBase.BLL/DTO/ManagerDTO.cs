using System.Collections.Generic;

namespace ManagerDataBase.BLL.DTO
{
    public class ManagerDTO
    {
        public int Id { get; set; }
        public string SecondName { get; set; }

        public virtual ICollection<SaleDTO> Sales { get; set; }
    }
}
