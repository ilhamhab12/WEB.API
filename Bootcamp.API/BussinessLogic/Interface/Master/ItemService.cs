using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Param;
using Common.Interface.Master;
using Common.Interface;

namespace BussinessLogic.Interface.Master
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        bool status = false;
        public bool Delete(int? Id)
        {
            var idDel = Get(Id);
            if (idDel != null)
            {
                status = _itemRepository.Delete(Id);
            }
            return status;
        }

        public List<Item> Get()
        {
            return _itemRepository.Get().ToList();
        }

        public Item Get(int? Id)
        {
            return _itemRepository.Get(Id);
        }

        public bool Insert(ItemParam itemParam)
        {
            if (itemParam != null)
            {
                status = _itemRepository.Insert(itemParam);
            }
            return status;
        }

        public bool Update(int? Id, ItemParam itemParam)
        {
            if (Id != null && itemParam != null)
            {
                status = _itemRepository.Update(Id, itemParam);
            }
            return status;
        }
    }
}
