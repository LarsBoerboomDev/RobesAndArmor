using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GameData.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string imageUrl { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int str { get; set; }
        public int Agility { get; set; }
        public int gold { get; set; }

        [ForeignKey("Class")]
        public int classId { get; set; }
        
        [ForeignKey("Inventory")]
        public int inventoryId { get; set; }

    }
}
