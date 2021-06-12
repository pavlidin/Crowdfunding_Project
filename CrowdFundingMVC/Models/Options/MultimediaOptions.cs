using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundingMVC.Models.Options
{
    public class MultimediaOptions
    {
        public MultimediaTypes MediaTypes { get; set; }
        public string MultimediaURL { get; set; }
        public int MultimediaId { get; set; }
        public string ProjectPhotoProfile { get; set; }
    }
}
