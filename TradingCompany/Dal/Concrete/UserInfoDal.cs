﻿using AutoMapper;
using DAL.Interfaces;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete
{
    public class UserInfoDal:IUserInfoDal
    {
        private readonly IMapper _mapper;
        public UserInfoDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserInfoDTO CreateUserInfo(UserInfoDTO info)
        {
            using (var e = new EntityTC())
            {
                UserInfo user = _mapper.Map<UserInfo>(info);
                e.UserInfo.Add(user);
                e.SaveChanges();
                return _mapper.Map<UserInfoDTO>(user);
            }
        }

        public bool DeleteUserInfoById(int id)
        {
            using (var e = new EntityTC())
            {
                UserInfo user = e.UserInfo.SingleOrDefault(p => p.UserID == id);
                if (user == null)
                {
                    return false;
                }
                e.UserInfo.Remove(user);
                e.SaveChanges();
                return true;
            }
        }

        public List<UserInfoDTO> GetAllUserInfo()
        {
            using (var e = new EntityTC())
            {
                return _mapper.Map<List<UserInfoDTO>>(e.UserInfo.ToList());

            }
        }

        public UserInfoDTO GetUserInfoById(int id)
        {
            using (var e = new EntityTC())
            {
                return _mapper.Map<UserInfoDTO>(e.UserInfo.SingleOrDefault(p => p.UserID == id));
            }
        }

        public UserInfoDTO UpdateUserInfo(UserInfoDTO info)
        {
            using (var e = new EntityTC())
            {
                e.UserInfo.AddOrUpdate(_mapper.Map<UserInfo>(info));
                e.SaveChanges();
                return _mapper.Map<UserInfoDTO>(e.UserInfo.Single(p=> p.UserID == info.UserID));
            }
        }
    }
}
