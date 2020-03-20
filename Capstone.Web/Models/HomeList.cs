using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class HomeList
    {
        public string parkName { get; set; }
        public string parkDescription { get; set; }

        public IList<Park> parkList { get; set; } = new List<Park>();
    }
}
