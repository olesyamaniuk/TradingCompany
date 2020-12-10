using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface IOrderStatus
    {
        List<OrderStatusDTO> GetAllOrderStatuses();
        OrderStatusDTO GetOrderStatusById(int id);
    }
}
