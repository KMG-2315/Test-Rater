using System;
using System.Collections.Generic;

namespace BusinessLayer.Modal
{
    public class RenewalQuotes
    {
        public string PolicyNumber { get; set; }
        public string InsuredName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CoverageType { get; set; }
        public string State { get; set; }
        public decimal PremiumAmount { get; set; }
        public string ProducerCode { get; set; }
        public string CarrierName { get; set; }
    }
}
