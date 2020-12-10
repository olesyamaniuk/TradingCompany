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
    public class CardInfo : ICardInfo
    {
        private readonly ICardInfoDal _cardInfoDal;
        public CardInfo(ICardInfoDal cardInfoDal)
        {
            this._cardInfoDal = cardInfoDal;
        }
        public CardInfoDTO GetCardInfoById(int id)
        {
            return this._cardInfoDal.GetCardInfoById(id);
        }
    }
}
