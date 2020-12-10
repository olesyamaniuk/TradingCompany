using System;
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
    public class CardInfoDal : ICardInfoDal
    {
        private readonly IMapper _mapper;
        public CardInfoDal(IMapper mapper)
        {
            this._mapper = mapper;
        }
        public CardInfoDTO CreateCardInfo(CardInfoDTO card)
        {

            using (var e = new EntityTC())
            {
                CardInfo info = _mapper.Map<CardInfo>(card);
                e.CardInfo.Add(info);
                e.SaveChanges();
                return _mapper.Map<CardInfoDTO>(info);
            }
        }

        public bool DeleteCardInfoById(int id)
        {

            using (var e = new EntityTC())
            {
                var info  = e.CardInfo.SingleOrDefault(a => a.CardInfoID == id);
                if (info == null)
                {
                    return false;
                }
                e.CardInfo.Remove(info);
                e.SaveChanges();
                return true;
            }
        }

        public List<CardInfoDTO> GetAllCardInfo()
        {
            using (var e = new EntityTC())
            {
                return _mapper.Map<List<CardInfoDTO>>(e.CardInfo);
            }
        }

        public CardInfoDTO GetCardInfoById(int id)
        {
            using (var e = new EntityTC())
            {
                var info = e.CardInfo.SingleOrDefault(a => a.CardInfoID == id);
                if (info == null)
                {
                    return null;
                }
                return _mapper.Map<CardInfoDTO>(info);
            }
        }

        public CardInfoDTO UpdateCardInfo(CardInfoDTO card)
        {
            using (var e = new EntityTC())
            {
                e.CardInfo.AddOrUpdate(_mapper.Map<CardInfo>(card));
                var res = e.CardInfo.Single(p => p.CardInfoID == card.CardInfoID);
                return _mapper.Map<CardInfoDTO>(res);
            }
        }
    }
}
