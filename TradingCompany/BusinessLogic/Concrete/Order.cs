using BusinessLogic.Interfaces;
using Dal.Interfaces;
using Dal;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class Order : IOrder
    {
        private readonly IOrderDal _orderDal;
        public Order(IOrderDal orderDal)
        {
            this._orderDal = orderDal;
        }
        public List<OrderDTO> GetAllOrders()
        {
            return this._orderDal.GetAllOrders();
        }

        public List<OrderDTO> GetAllOrdersByUserId(int id)
        {
            var ord_list= this._orderDal.GetAllOrders();
            return ord_list.Where<OrderDTO>(o => o.UserID == id).ToList();
        }

        public OrderDTO GetOrderById(int id)
        {
            return this._orderDal.GetOrderByID(id);
        }

        public void SetOrderStatus(int OrderStatusId, int OrderId)
        {
            var order = this._orderDal.GetOrderByID(OrderId);
            order.StatusID = OrderStatusId;
            this._orderDal.UpdateOrder(order);
        }
    }
}
