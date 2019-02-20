using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Models;
namespace Capstone.DAL
{
    public interface ICampsiteDAO
    {
         IList<CampsiteModel> GetCampsites(int campground_id);
    }
}
