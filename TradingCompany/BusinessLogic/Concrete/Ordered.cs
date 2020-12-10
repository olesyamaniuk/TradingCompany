using BusinessLogic.Interfaces;
using Dal;
using Dal.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class Ordered : IOrdered
    {
        private readonly IOrderedDal _orderedDal;
        public Ordered(IOrderedDal orderedDal)
        {
            this._orderedDal = orderedDal;
        }
        public List<OrderedDTO> GetAllOrderedItems()
        {
            return this._orderedDal.GetAllOrdered();
        }

        public OrderedDTO GetOrderedById(int id)
        {
            return this._orderedDal.GetOrderedByID(id);
        }

        public List<OrderedDTO> GetOrderedListById(int id)
        {
            return this._orderedDal.GetOrderedListByID(id);
        }
    }
}
