﻿using BusinessLogic.Interfaces;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class Account: IAccount
    {
        private readonly IAccountDal _accountDal;
        public Account(IAccountDal accountDal)
        {
            _accountDal = accountDal;
        }

        public AccountDTO GetAccountByID(int id)
        {
            return _accountDal.GetAccountByID(id);
        }

        public AccountDTO GetAccountByLogin(string login)
        {
            return this._accountDal.GetAccountByLogin(login);
        }
    }
}
