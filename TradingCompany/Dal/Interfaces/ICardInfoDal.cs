using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace Dal.Interfaces
{
    public interface ICardInfoDal
    {
        CardInfoDTO CreateCardInfo(CardInfoDTO card);

        CardInfoDTO GetCardInfoById(int id);
        bool DeleteCardInfoById(int id);
        List<CardInfoDTO> GetAllCardInfo();
        CardInfoDTO UpdateCardInfo(CardInfoDTO card);
    }
}
