using Microsoft.AspNetCore.Http;
using RobesAndArmorGit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RobesAndArmorGit.Logic
{
    public  class getCurrentUser
    {

        private string _user;
        private readonly GameData.GameContext _context;
        public getCurrentUser(UserResolverService userService, GameData.GameContext context)
        {
            _context = context;
            _user = userService.getUserAsync();                        
        }
        public bool checkifUserExists()
        {
            GameData.Models.Character Charater =  _context.Characters.SingleOrDefault(m => m.UserID == _user);
            if(Charater ==null)
            {
                return false;
            }
            return true;
        }

    }
}
