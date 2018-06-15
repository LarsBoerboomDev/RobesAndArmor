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
            

            //add x empty items to create an harder drop system
            for (int i = 0; i < 10; i++)
            {
                GameData.Models.Item item = new GameData.Models.Item();
                dropItems.Add(item);
            }
            int index = rnd.Next(dropItems.Count);
            return dropItems[index];

        }
    }
}
