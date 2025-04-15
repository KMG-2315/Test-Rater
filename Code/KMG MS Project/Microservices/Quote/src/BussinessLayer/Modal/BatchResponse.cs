using System;
using System.Collections.Generic;

namespace Quotes.BusinessLayer.Modal
{
    public class BatchResponse
    {
       public BatchResponse()
        {
            this.QuoteStatuses = new List<QuoteStatus>();
        }
        public List<QuoteStatus> QuoteStatuses { get; set; } = new();
    }

    public class QuoteStatus
    {
        public Guid QuoteGuid { get; set; }
        public int ControlNo { get; set; }
        public string Status { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
