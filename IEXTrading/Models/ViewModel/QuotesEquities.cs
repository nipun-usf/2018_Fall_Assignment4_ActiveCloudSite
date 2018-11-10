namespace IEXTrading.Models.ViewModel
{
    public class QuotesEquities
    {
        public Quote Quote { get; set; }
        public string Dates { get; set; }
        public string Prices { get; set; }
        public string Volumes { get; set; }
        public float AvgPrice { get; set; }
        public double AvgVolume { get; set; }

        public QuotesEquities(Quote quote, string dates, string prices, string volumes, float avgprice, double avgvolume)
        {
            Quote = quote;
            Dates = dates;
            Prices = prices;
            Volumes = volumes;
            AvgPrice = avgprice;
            AvgVolume = avgvolume;
        }
    }
}
