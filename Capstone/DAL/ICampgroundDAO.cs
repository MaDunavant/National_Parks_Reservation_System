﻿using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;

namespace Capstone.DAL
{
    public interface ICampgroundDAO
    {
        IList<CampgroundModel> GetCampgrounds(ParkModel park);
    }
}
