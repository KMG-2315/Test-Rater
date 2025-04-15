using System;

namespace Quotes.BusinessLayer.Modal
{
    public class QuoteRequest
    {
        public string ControlNo { get; set; }
        public string ProducerName { get; set; }
        public string CoverageType { get; set; }
        public decimal PremiumAmount { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string State { get; set; }
        public string Carrier { get; set; }
    }
}
