﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dal.Interfaces;
using DTO;

namespace Dal.Concrete
{
   public  class OrderDal : IOrderDal
    {
        private readonly IMapper _mapper;
        public OrderDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public OrderDTO CreateOrder(OrderDTO order)
        {
            using (var e = new EntityTC())
            {
                Order o = _mapper.Map<Order>(order);
                e.Order.Add(o);
                e.SaveChanges();
                return _mapper.Map<OrderDTO>(o);
            }
        }

        public bool DeleteOrder(int id)
        {
            using (var e = new EntityTC())
            {
                var o = e.Order.SingleOrDefault(a => a.OrderID == id);
                if (o == null)
                {
                    return false;
                }
                e.Order.Remove(o);
                e.SaveChanges();
                return true;
            }
        }

        public List<OrderDTO> GetAllOrders()
        {
            using (var e = new EntityTC())
            {
                return _mapper.Map<List<OrderDTO>>(e.Order.ToList());
            }
        }

        public OrderDTO GetOrderByID(int id)
        {
            using (var e = new EntityTC())
            {
                var o = e.Order.SingleOrDefault(a => a.OrderID == id);
                if (o == null)
                {
                    return null;
                }
                return _mapper.Map<OrderDTO>(o);
            }
        }

        public OrderDTO UpdateOrder(OrderDTO order)
        {
            using (var e = new EntityTC())
            {
                e.Order.AddOrUpdate(_mapper.Map<Order>(order));
                e.SaveChanges();
                var o = e.Order.Single(p => p.OrderID == order.OrderID);
                return _mapper.Map<OrderDTO>(o);
            }
        }
    }
}
