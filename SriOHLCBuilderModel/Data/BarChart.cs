using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
    public class BarChart
    {
        public double Close { get; set; }
        public int DownTicks { get; set; }
        public int DownVolume { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public int Status { get; set; }
        public DateTime TimeStamp { get; set; }
        public int TotalTicks { get; set; }
        public int TotalVolume { get; set; }
        public int UnchangedTicks { get; set; }
        public int UnchangedVolume { get; set; }
        public int UpTicks { get; set; }
        public int UpVolume { get; set; }
        public int OpenInterest { get; set; }
    }

    public class TickBar
    {
        public DateTime TimeStamp { get; set; }
        public int Status { get; set; }
        public double Close { get; set; }
        public int TotalVolume { get; set; }
    }

}
