using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameData.Models
{
    public class Item
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Def { get; set; }
        public int Atk { get; set; }       
        
        public Type Type { get; set; }

        public ICollection<Inventory_has_Item> Inventory_Has_Item { get; } = new List<Inventory_has_Item>();

        /*
        [ForeignKey("Type")]
        public int typeId { get; set; }
        */
    }
}
