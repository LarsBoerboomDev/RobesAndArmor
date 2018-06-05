using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobesAndArmorGit.Logic
{
    public class EnemyDropCalc
    {
        public GameData.Models.Item calcDrop(List<GameData.Models.Item> dropItems)
        {
            Random rnd = new Random();
            int index = rnd.Next(dropItems.Count);


            return dropItems[index];

        }
    }
}
