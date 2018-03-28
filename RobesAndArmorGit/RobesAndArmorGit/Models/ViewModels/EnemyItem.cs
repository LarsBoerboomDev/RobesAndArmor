using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobesAndArmorGit.Models.ViewModels
{
    public class EnemyItem
    {
        public GameData.Models.Enemy Enemy { get; set; }
        public string enemyImageChosen { get; set; }
        public List<GameData.Models.Enemy_has_Item>  Enemy_Has_Item { get; set; }
        public List<string> enemyImages { get; set; }
        public List<GameData.Models.Type> Type { get; set; }
        public List<GameData.Models.Item> AllItems{ get; set; }        
    }
}
