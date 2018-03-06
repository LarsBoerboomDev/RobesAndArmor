using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobesAndArmorGit.Models.ViewModels
{
    public class EnemyItem
    {           
        public GameData.Models.Enemy Enemy { get; set; }
        public List<GameData.Models.Type> Type { get; set; }
        public List<GameData.Models.Item> AllItems{ get; set; }        
    }
}
