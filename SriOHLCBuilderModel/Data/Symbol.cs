using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel.Data
{
    public class Symbol
    {
        public string Category { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public object Error { get; set; }
        public string Exchange { get; set; }
        public int ExchangeID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ExpirationType { get; set; }
        public string FutureType { get; set; }
        public string IndustryCode { get; set; }
        public string IndustryName { get; set; }
        public int LotSize { get; set; }
        public double MinMove { get; set; }
        public string Name { get; set; }
        public string OptionType { get; set; }
        public int PointValue { get; set; }
        public string Root { get; set; }
        public string SectorName { get; set; }
        public double StrikePrice { get; set; }
    }
}
