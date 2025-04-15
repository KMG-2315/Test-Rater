namespace Quotes.BusinessLayer.Modal
{
    public class PremStatBatchModel
    {
        public string ControlNo { get; set; }
        public string PolicyNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Premium { get; set; }
    }
}
