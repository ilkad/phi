using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phiPartners.Models
{
    public class StoryItem
    {
        public string By { get; set; }
        public string Title { get; set; }
        public int Score { get; set; }
        public long Time { get; set; }
        public string Url { get; set; }
    }
}
