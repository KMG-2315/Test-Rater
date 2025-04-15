using Microsoft.AspNetCore.Mvc;
using Quotes.BusinessLayer.Interfaces;
using Quotes.BusinessLayer.Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.Api.Controllers
{
    [ApiController]
    [Route("quotes")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        // GET /quotes/premstatbatch
        [HttpGet("premstatbatch")]
        public async Task<ActionResult<BatchResponse>> GetPremStatBatch()
        {
            var response = await _quoteService.GetPremStatBatchAsync();
            return Ok(response);
        }

        // GET /quotes?controlNo=XYZ123
        [HttpGet]
        public async Task<ActionResult> GetQuoteByControlNo([FromQuery] int controlNo)
        {
            //if (string.IsNullOrWhiteSpace(controlNo.ToString()))
            //    return BadRequest("controlNo is required.");

            var quote = await _quoteService.GetQuoteByControlNoAsync(controlNo);

            if (quote == null)
                return NotFound();

            return Ok(quote);
        }
    }
}
