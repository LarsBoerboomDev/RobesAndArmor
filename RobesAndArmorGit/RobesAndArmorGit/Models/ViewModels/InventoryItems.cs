using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobesAndArmorGit.Models.ViewModels
{
    public class InventoryItems
    {
        public List<GameData.Models.Item> Items { get; set; }
        public GameData.Models.Inventory Inventory { get; set; }
        public int minimumSize { get; set; }
        

    }
}
