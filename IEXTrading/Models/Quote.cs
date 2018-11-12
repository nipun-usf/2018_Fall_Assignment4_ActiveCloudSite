using System.ComponentModel.DataAnnotations;

namespace IEXTrading.Models
{
    public class Quote
    {
        [Key]
        public string symbol { get; set; }
        public string companyName { get; set; }
        public string primaryExchange { get; set; }
        public string sector { get; set; }
        public string calculationPrice { get; set; }
        public float open { get; set; }
        public string openTime { get; set; }
        public float close { get; set; }
        public string closeTime { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float latestPrice { get; set; }
        public string latestSource { get; set; }
        public string latestTime { get; set; }
        public string latestUpdate { get; set; }
        public int latestVolume { get; set; }
        public string iexRealtimePrice { get; set; }
        public string iexRealtimeSize { get; set; }
        public string iexLastUpdated { get; set; }
        public float delayedPrice { get; set; }
        public string delayedPriceTime { get; set; }
        public float extendedPrice { get; set; }
        public float extendedChange { get; set; }
        public float extendedChangePercent { get; set; }
        public string extendedPriceTime { get; set; }
        public float previousClose { get; set; }
        public float change { get; set; }
        public float changePercent { get; set; }
        public string iexMarketPercent { get; set; }
        public int iexVolume { get; set; }
        public long avgTotalVolume { get; set; }
        public string iexBidPrice { get; set; }
        public string iexBidSize { get; set; }
        public string iexAskPrice { get; set; }
        public string iexAskSize { get; set; }
        public long marketCap { get; set; }
        public string peRatio { get; set; }
        public float week52High { get; set; }
        public float week52Low { get; set; }
        public float ytdChange { get; set; }
    }
}
