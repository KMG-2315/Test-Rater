using System;

namespace BusinessLayer.Modal
{
    public class QuoteStatusRequest
    {
        public Guid QuoteGuid { get; set; }       
        public string Status { get; set; }        
        public string UpdatedBy { get; set; }     
        public DateTime UpdatedDate { get; set; } 
    }
}
