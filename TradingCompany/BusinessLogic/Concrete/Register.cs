using BusinessLogic.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Interfaces;
using Dal.Concrete;
using Dal;

namespace BusinessLogic.Concrete
{
    public class Register : IRegister
    {
        private readonly IAccountDal _accountDal;
        private readonly IUserInfoDal _userInfoDal;
        private readonly IAdressDal _adressDal;
        private readonly ICardInfoDal _cardinfoDal;
        public Register(IAccountDal accountDal, IUserInfoDal userInfoDal, IAdressDal adressDal, ICardInfoDal cardinfoDal)
        {
            this._accountDal = accountDal;
            this._userInfoDal = userInfoDal;
            this._adressDal = adressDal;
            this._cardinfoDal = cardinfoDal;
        }
        public bool Register(string username,string password, UserInfoDTO userinfo, CardInfoDTO cardInfo,AdressDTO addres)
        {
            try
            {
                var acc = this._accountDal.CreateAccount(username, password);

                addres = _adressDal.CreateAdress(addres);
                cardInfo = _cardinfoDal.CreateBankCardInfo(cardInfo);

                userinfo.UserID = acc.UserID;
                userinfo.BankCardInfoID = (int)cardInfo.CardInfoID;
                userinfo.AdressID = (int)addres.AdressID;

                this._userInfoDal.CreateUserInfo(userinfo);
                // transaction?
            }
            catch(Exception exp)
            {
                if(exp.Message == "User already exists!")
                {
                    return false;
                }
                throw exp;
            }
            return true;
        }
    }
}
