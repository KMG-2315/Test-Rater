using System;
using System.Xml.Serialization;

namespace Quotes.BusinessLayer.Modal
{
    [XmlRoot("Policy")]
    public class Policy
    {
        [XmlElement("Transaction")]
        public Transaction Transaction { get; set; }
    }

    public class Transaction
    {
        public int ControlNo { get; set; }
        public Guid ControlGuid { get; set; }
        public string PolicyType { get; set; }
        public Guid CurrentQuoteGuid { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int QuoteStatusID { get; set; }
        public string DisplayStatus { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal CurrentPremium { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
