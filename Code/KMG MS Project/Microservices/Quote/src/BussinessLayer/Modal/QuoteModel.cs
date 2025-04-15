namespace Quotes.BusinessLayer.Modal
{
    public class QuoteModel
    {
        public int QuoteID { get; set; }
        public string QuoteGUID { get; set; }
        public string ControlNo { get; set; }
        public string PolicyNumber { get; set; }
        public decimal Premium { get; set; }
        public string ProducerName { get; set; }
    }
}
