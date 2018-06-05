using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GameData;
using GameData.Models;
using Microsoft.EntityFrameworkCore;

namespace TheLogic
{
    public class Types
    {
        private readonly GameContext _context;

        public Types(GameContext context)
        {
            _context = context;
        }

        public async Task<List<GameData.Models.Type>> getAllTypes()
        {
            List<GameData.Models.Type> types;
            types = await _context.Types.ToListAsync();
            return types;
        } 

        public async Task<GameData.Models.Type> getType(int id)
        {
            GameData.Models.Type type = await _context.Types.SingleOrDefaultAsync(m => m.Id == id);
            return type;
        }

        public void createType(GameData.Models.Type type)
        {
            _context.Add(type);
            _context.SaveChangesAsync();
        }

        public void updateType(GameData.Models.Type type)
        {

        }


        public async Task<GameData.Models.Type> edit(int id)
        {
          GameData.Models.Type type = await _context.Types.SingleOrDefaultAsync(m => m.Id == id);
            return type;
        }
    }
}
