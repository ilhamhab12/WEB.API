using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using DataAccess.Context;

namespace Common.Interface.Master
{
    public class ItemRepository : IItemRepository
    {
        MyContext myContext = new MyContext();
        Item item = new Item();

        bool status = false;
        public bool Delete(int? Id)
        {
            var result = 0;
            var ItemId = Get(Id);
            ItemId.IsDelete = true;
            ItemId.DeleteDate = DateTimeOffset.UtcNow.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }

            return status;
        }

        public List<Item> Get()
        {
            return myContext.Items.Where(x => x.IsDelete == false).ToList();
        }

        public Item Get(int? Id)
        {
            return myContext.Items.Find(Id);
        }

        public bool Insert(ItemParam itemParam)
        {
            var result = 0;
            item.Name = itemParam.Name;
            item.Price = itemParam.Price;
            item.Stock = itemParam.Stock;
            item.Suppliers = myContext.Suppliers.Find(itemParam.Suppliers);
            item.CreateDate = DateTimeOffset.UtcNow.LocalDateTime;
            myContext.Items.Add(item);
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }

        public bool Update(int? Id, ItemParam itemParam)
        {
            var result = 0;
            var item = Get(Id);
            item.Name = itemParam.Name;
            item.Price = itemParam.Price;
            item.Stock = itemParam.Stock;
            item.Suppliers = myContext.Suppliers.Find(itemParam.Suppliers);
            item.UpdateDate = DateTimeOffset.UtcNow.LocalDateTime;
            result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
            }
            return status;
        }
    }
}
