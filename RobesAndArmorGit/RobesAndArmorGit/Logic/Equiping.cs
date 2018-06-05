using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameData.Models;

namespace RobesAndArmorGit.Logic
{
    public  class Equiping
    {
        public  Equipment CheckType(Item item, Equipment equipment)
        {
            if (item.Type.Name == "head")
            {
                equipment.headId = item.Id;
            }else if(item.Type.Name == "body")
            {
                equipment.bodyId = item.Id;
            }
            else if (item.Type.Name == "legs")
            {
                equipment.legsId = item.Id;
            }
            else if (item.Type.Name == "feet")
            {
                equipment.feetId = item.Id;
            }
            else if (item.Type.Name == "glove")
            {
                equipment.gloveId = item.Id;
            }
            else if (item.Type.Name == "weapon")
            {
                equipment.weaponId = item.Id;
            }
            else if (item.Type.Name == "shield")
            {
                equipment.shieldId = item.Id;
            }
            return equipment;
        }
    }
}
