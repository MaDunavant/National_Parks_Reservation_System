﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class CampsiteModel
    {
        public int Site_Id { get; set; }
        public int Campground_Id { get; set; }
        public int Site_Number { get; set; }
        public int Max_Occupancy { get; set; }
        public bool Accessible { get; set; }
        public int Max_RV_Length { get; set; }
        public bool Utilities { get; set; }
    }
}
