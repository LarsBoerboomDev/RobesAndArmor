using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameData.Models;

namespace RobesAndArmorGit.Models.ViewModels
{
    public class viewCharacter
    {
        public Character character { get; set; }
        public Inventory inventory { get; set; }
        public int inventorySize { get; set; }
        public List<Item> items { get; set; }
        public Equipment equipment { get; set; }
        public List<Inventory_has_Item> inventoryItems { get; set; }
    }
}
