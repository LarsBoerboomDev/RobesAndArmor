using System;
using System.Collections.Generic;
using System.Text;
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
