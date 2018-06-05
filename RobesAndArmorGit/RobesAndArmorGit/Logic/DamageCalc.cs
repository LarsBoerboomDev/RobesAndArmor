using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobesAndArmorGit.Logic
{
    public class DamageCalc
    {

        public Models.ViewModels.Damage calcDamage(GameData.Models.Character character, GameData.Models.Enemy enemy)
        {
            //dammage calcs
            Models.ViewModels.Damage damage = new Models.ViewModels.Damage();
            character.Health = character.Health - enemy.Atk;
            enemy.Health = enemy.Health - character.str;

            damage.character = character;
            damage.enemy = enemy;



            return damage;

        }
        
        public bool checkIfCharDead(GameData.Models.Character character)
        {
            if(character.Health <= 0)
            {
                return true;
            }
            return false;
        }

        public bool checkIfEnemyDead(GameData.Models.Battle battle)
        {
            if(battle.enemyHealth <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
