using System;
using System.Collections.Generic;
using Xunit;

namespace RobesAndArmorUnitTestings
{
    public class UnitTest1
    {
        [Fact]
        public void testEnemyDamage()
        {


            RobesAndArmorGit.Logic.DamageCalc damageCalc = new RobesAndArmorGit.Logic.DamageCalc();
            GameData.Models.Character character = new GameData.Models.Character();
            character.str = 50;
            character.Health = 200;

            GameData.Models.Enemy enemy = new GameData.Models.Enemy();
            enemy.Atk = 50;
            enemy.Health = 100;


            RobesAndArmorGit.Models.ViewModels.Damage damageView = damageCalc.calcDamage(character, enemy);

       //     Assert.Equals(150, damageCalc.calcDamage(character, enemy));
            Assert.Equal(150, damageView.character.Health);


        }

        [Fact]
        public void testCharacterDamage()
        {
            RobesAndArmorGit.Logic.DamageCalc damageCalc = new RobesAndArmorGit.Logic.DamageCalc();
            GameData.Models.Character character = new GameData.Models.Character();
            character.str = 50;
            character.Health = 200;

            GameData.Models.Enemy enemy = new GameData.Models.Enemy();
            enemy.Atk = 50;
            enemy.Health = 100;

            RobesAndArmorGit.Models.ViewModels.Damage damageView = damageCalc.calcDamage(character, enemy);

            Assert.Equal(50, damageView.enemy.Health);
        }

        [Fact]
        public void testCheckEquipemnt()
        {
            GameData.Models.Item item = new GameData.Models.Item();
            GameData.Models.Type type = new GameData.Models.Type();
            type.Name = "head";
            type.Id = 1;


            item.Type = type;
            item.Id = 1;

            GameData.Models.Equipment equipment = new GameData.Models.Equipment();            

            RobesAndArmorGit.Logic.Equiping equiping = new RobesAndArmorGit.Logic.Equiping();

            Assert.Equal(1, equiping.CheckType(item, equipment).headId);            
        }
        

        [Fact]
        public void checkIfCharDead()
        {
            GameData.Models.Character character = new GameData.Models.Character();
            character.Health = 0;


            RobesAndArmorGit.Logic.DamageCalc damageCalc = new RobesAndArmorGit.Logic.DamageCalc();

            Assert.True(damageCalc.checkIfCharDead(character));
        }

        [Fact]
        public void checkIfEnemyDead()
        {
            GameData.Models.Battle enemy = new GameData.Models.Battle();
            enemy.enemyHealth = 200;
            RobesAndArmorGit.Logic.DamageCalc damageCalc = new RobesAndArmorGit.Logic.DamageCalc();

            Assert.False(damageCalc.checkIfEnemyDead(enemy));
        }
        
        [Fact]
        public void checkEnemyDrop()
        {
            GameData.Models.Item item1 = new GameData.Models.Item();
            GameData.Models.Item item2 = new GameData.Models.Item();

            List<GameData.Models.Item> items = new List<GameData.Models.Item>();
            items.Add(item1);
            items.Add(item2);

            RobesAndArmorGit.Logic.EnemyDropCalc enemyDropCalc = new RobesAndArmorGit.Logic.EnemyDropCalc();


            Assert.Equal(item1, enemyDropCalc.calcDrop(items));


        }

    }
}
