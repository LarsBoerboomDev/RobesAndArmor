using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobesAndArmorGit.Logic
{
    public class CharacterDeadCalc
    {
        public GameData.Models.Character calcOnDeadMoney(GameData.Models.Character character)
        {
            character.gold = character.gold - (int)(character.gold * 0.10);
            if(character.gold <= 0)
            {
                character.gold = 0;
            }
            return character;
        }
    }
}
