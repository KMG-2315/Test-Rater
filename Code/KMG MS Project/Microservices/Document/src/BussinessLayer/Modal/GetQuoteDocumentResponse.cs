using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.BusinessLayer.Models
{
    public class GetQuoteDocumentResponse
    {
        public string DocumentName { get; set; }
        public string DocumentUrl { get; set; }
        public string Status { get; set; }
    }
}