﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO;
using DAL.Interfaces;
using Dal.Profiles;
using System.Security.Cryptography;
using System.Data.Entity;


namespace Dal.Concrete
{
    public class ItemDal : IItemDal
    {
        private readonly IMapper _mapper;
        public ItemDal(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ItemDTO CreateItem(ItemDTO item)
        {
            using (var e = new EntityTC())
            {
                Item i = _mapper.Map<Item>(item);
                e.Item.Add(i);
                e.SaveChanges();
                return _mapper.Map<ItemDTO>(i);
            }
        }

        public bool DeleteItem(int id)
        {
            using (var e = new EntityTC())
            {
                var i = e.Item.SingleOrDefault(a => a.ItemID == id);
                if (i == null)
                {
                    return false;
                }
                e.Item.Remove(i);
                e.SaveChanges();
                return true;
            }
        }

        public List<ItemDTO> GetAllItems()
        {
            using (var e = new EntityTC())
            {
                return _mapper.Map<List<ItemDTO>>(e.Item.ToList());
            }
        }

        public ItemDTO GetItemByID(int id)
        {
            using (var e = new EntityTC())
            {
                var i = e.Item.SingleOrDefault(a => a.ItemID == id);
                if (i == null)
                {
                    return null;
                }
                return _mapper.Map<ItemDTO>(i);
            }
        }

        public ItemDTO UpdateItem(ItemDTO item)
        {
            using (var e = new EntityTC())
            {
                e.Item.AddOrUpdate(_mapper.Map<Item>(item));
                e.SaveChanges();
                var c = e.Item.Single(p => p.ItemID == item.ItemID);
                return _mapper.Map<ItemDTO>(c);
            }
        }
    }
}
