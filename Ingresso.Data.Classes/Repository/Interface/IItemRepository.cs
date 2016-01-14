using System;
using System.Collections.Generic;

namespace Ingresso.Data.Classes
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItem(Guid id);
    }
}
