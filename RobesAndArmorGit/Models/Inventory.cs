using System;
using System.Collections.Generic;
using System.Text;

namespace GameData.Models
{
   public class Inventory
    {
        public int Id { get; set; }
        public int Size { get; set; }

        public ICollection<Inventory_has_Item> Inventory_Has_Item { get; } = new List<Inventory_has_Item>();
    }
}
