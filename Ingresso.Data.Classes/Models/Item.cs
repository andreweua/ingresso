using System;

namespace Ingresso.Data.Classes
{
    public class Item
    {
        public Item()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string Image { get; set; }
    }
}
