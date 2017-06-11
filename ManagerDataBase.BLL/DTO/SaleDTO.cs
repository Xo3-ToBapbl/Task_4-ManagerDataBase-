using System;

namespace ManagerDataBase.BLL.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public int Cost { get; set; }

        public int ManagerId { get; set; }
    }
}
