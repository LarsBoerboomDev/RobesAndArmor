using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobesAndArmorGit.Models.ViewModels
{
    public class CharacterRegistration
    {
       
        public GameData.Models.Character Character { get; set; }
        public List<GameData.Models.Class> Classses { get; set; }
        public List<string> faceImages { get; set; }

        
    }
}
