using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobesAndArmorGit.Models.ViewModels
{
    public class Damage
    {
        public int characterDamage { get; set; }
        public int EnemyDamage { get; set; }

        public GameData.Models.Enemy enemy { get; set; }
        public GameData.Models.Character character { get; set; }


    }
}
