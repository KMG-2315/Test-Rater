using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.BusinessLayer.Models
{
    public class GetQuoteDocumentRequest
    {
        public Guid QuoteGuid { get; set; }
        public Guid EventGuid { get; set; }
        public int PrintTypeId { get; set; }
    }
}
