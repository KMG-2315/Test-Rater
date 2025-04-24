using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Document.Models
{
    public class GenerateAutomationDocumentResultRequest
    {
        public string Token { get; set; }
        public string UserGuid { get; set; }
        public Guid QuoteGuid { get; set; }
        public Guid EventGuid { get; set; }
        public int PrintTypeId { get; set; }
    }
}
