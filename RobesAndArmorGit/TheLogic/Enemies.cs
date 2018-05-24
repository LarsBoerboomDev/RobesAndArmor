using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameData;
using GameData.Models;
using Microsoft.EntityFrameworkCore;

namespace TheLogic
{
   public class Enemies
    {

        private readonly GameContext _context;
       

        public Enemies(GameContext context)
        {
             _context = context;
       
            
        }
       
        public async Task<List<GameData.Models.Enemy>> getAllEnemies()
        {

            List<GameData.Models.Enemy> enemies;
       
            
            enemies = await _context.Enemies.ToListAsync();
            return enemies;
        }


        public async Task<Enemy> getEnemyDetails(int id)
        {
            Enemy enemy = await _context.Enemies.SingleOrDefaultAsync(m => m.Id == id);
            return enemy;
        }

        

       


        public async void create(Enemy enemy, Enemy_has_Item enemyItem, List<string> drops)
        {
            
            _context.Add(enemy);
            await _context.SaveChangesAsync();


            foreach (string item in drops)
            {
                enemyItem.Enemy = enemy;
                GameData.Models.Item Item = await _context.Items.SingleOrDefaultAsync(m => m.Id == Convert.ToInt32(item));
                enemyItem.Item = Item;
                _context.Add(enemyItem);
                await _context.SaveChangesAsync();
            }

    

        }
        
    }
}
