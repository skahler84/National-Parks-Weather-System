using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class FindSurveys
    {
        public string ParkName { get; set; }

        public int Count { get; set; }

        public string ParkCode { get; set; }

        public List<Survey> survey { get; set; } = new List<Survey>();
    }
}
