using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameData.Models
{
   public  class test : DbContext
    {
        GameContext _context;

        public test(GameContext context)
        {
            _context = context;
        }
    }
}
