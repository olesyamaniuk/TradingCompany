using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Dal.Interfaces;
using Dal;
using DTO;

namespace BusinessLogic.Concrete
{
    public class Item:IItem
    {
        private readonly IItemDal _itemDal;
        public Item(IItemDal itemDal)
        {
            _itemDal = itemDal;
        }

        public ItemDTO AddItem(ItemDTO item)
        {
            return this._itemDal.CreateItem(item);
        }

        public bool DeleteItemById(int id)
        {
            return this._itemDal.DeleteItem(id);
        }

        public List<ItemDTO> GetAllItems()
        {
            return this._itemDal.GetAllItems();
        }

        public ItemDTO GetItemById(int id)
        {
            return this._itemDal.GetItemByID(id);
        }

        public ItemDTO UpdateItem(ItemDTO item)
        {
            return this._itemDal.UpdateItem(item);
        }
    }
}
