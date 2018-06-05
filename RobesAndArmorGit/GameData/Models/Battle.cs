using System;
using System.Collections.Generic;
using System.Text;

namespace GameData.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public int enemyId { get; set; }
        public int characterID { get; set; }
        public int enemyHealth { get; set; }


    }
}
