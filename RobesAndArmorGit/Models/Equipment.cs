﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameData.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public int headId { get; set; }
        public Models.Item headItem { get; set; }

        public int bodyId { get; set; }
        public Models.Item bodyItem { get; set; }

        public int legsId { get; set; }
        public Models.Item legsItem { get; set; }

        public int feetId { get; set; }
        public Models.Item feetItem { get; set; }

        public int gloveId { get; set; }
        public Models.Item gloveItem { get; set; }

        public int weaponId { get; set; }
        public Models.Item weaponItem { get; set; }

        public int shieldId { get; set; }
        public Models.Item shieldItem { get; set; }


    }
}
