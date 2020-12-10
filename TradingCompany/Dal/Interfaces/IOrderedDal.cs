using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Dal.Interfaces
{
    public interface IOrderedDal
    {
        OrderedDTO GetOrderedByID(int id);

        List<OrderedDTO> GetOrderedListByID(int id);
        List<OrderedDTO> GetAllOrdered();
        OrderedDTO CreateOrdered(OrderedDTO order);
        OrderedDTO UpdateOrdered(OrderedDTO order);
        bool DeleteOrdered(int id);
    }
}
