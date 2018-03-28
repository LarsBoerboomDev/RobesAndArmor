using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobesAndArmorGit.Models.ViewModels
{
    public class itemEdit
    {
        public GameData.Models.Item item;
        public List<string> images;
        public string choosenImage;
        public List<GameData.Models.Type> type;
        public string choosenType;
        
    }
}
