using System;
using System.Collections.Generic;
using System.Linq;

namespace Ingresso.Data.Classes
{
    public class ItemRepository : RepositoryBase, IItemRepository
    {
        public IEnumerable<Item> GetAllItems()
        {
            var ret = Db.Items.ToList();

            return ret;
        }

        public Item GetItem(Guid id)
        {
            var ret = Db.Items.Find(id.ToString());

            return ret;
        }
    }
}
