using System;
using System.Collections.Generic;

namespace Quotes.BusinessLayer.Modal
{
    public class IMSRenewalData
    {
        public string QuoteGuid { get; set; }
        public string ControlNo { get; set; }
        public string PolicyNumber { get; set; }
        public string CoverageType { get; set; }
        public DateTime RenewalEffectiveDate { get; set; }
        public DateTime RenewalExpiryDate { get; set; }
        public decimal RenewalPremium { get; set; }
        public string Carrier { get; set; }
        public string State { get; set; }

        public List<string> Notes { get; set; } = new();
    }
}
