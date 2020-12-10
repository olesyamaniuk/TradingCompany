using BusinessLogic.Interfaces;
using Dal.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class OrderStatus: IOrderStatus
    {
        private readonly IOrderStatusDal _orderStatusDal;
        public OrderStatus(IOrderStatusDal orderStatusDal)
        {
            this._orderStatusDal = orderStatusDal;
        }

        public List<OrderStatusDTO> GetAllOrderStatuses()
        {
            return this._orderStatusDal.GetAllOrderStatuses();
        }

        public OrderStatusDTO GetOrderStatusById(int id)
        {
            return this._orderStatusDal.GetOrderStatusByID(id);
        }
    }
}
