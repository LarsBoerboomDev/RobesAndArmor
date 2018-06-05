using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobesAndArmorGit.Models.ViewModels
{
    public class Battle
    {
        public GameData.Models.Character character { get; set; }
        public GameData.Models.Enemy enemy { get; set; }
        public GameData.Models.Battle battle { get; set; }
    }
}
