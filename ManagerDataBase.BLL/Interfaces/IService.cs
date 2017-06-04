using ManagerDataBase.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerDataBase.BLL.Interfaces
{
    public interface IService
    {
        ManagerDTO GetManagerDTO(int id);
        void Dispose();
    }
}
