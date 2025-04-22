using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Document.BusinessLayer.Interfaces;
using Document.BusinessLayer.Models;
using System;
using System.Threading.Tasks;
using DocumentWCFService;

namespace Document.Api.Controllers
{
    [ApiController]
    [Route("document")]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly ILogger<DocumentController> _logger;

        public DocumentController(IDocumentService documentService, ILogger<DocumentController> logger)
        {
            _documentService = documentService;
            _logger = logger;
        }

        [HttpGet("GetQuoteDocument")]
        public async Task<IActionResult> GetQuoteDocument(
            [FromHeader(Name = "TokenHeader")] string token,
            [FromQuery] Guid quoteGuid,
            [FromQuery] Guid eventGuid,
            [FromQuery] int printTypeId)
        {
            try
            {
                _logger.LogInformation("Starting GetQuoteDocument API");

                if (string.IsNullOrWhiteSpace(token))
                    return BadRequest("TokenHeader is required.");

                var isValid = await _documentService.ValidateTokenAsync(token);
                if (!isValid)
                    return Unauthorized("Invalid token.");

                var request = new GetQuoteDocumentRequest
                {
                    TokenHeader = token,
                    QuoteGuid = quoteGuid,
                    EventGuid = eventGuid,
                    PrintTypeId = printTypeId
                };

                var document = await _documentService.GetQuoteDocumentAsync(request);

                if (document == null)
                {
                    _logger.LogWarning("Document not found for QuoteGuid: {QuoteGuid}", quoteGuid);
                    return NotFound("Quote document not found.");
                }

                _logger.LogInformation("GetQuoteDocument API completed successfully.");
                return Ok(document);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQuoteDocument");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetIMSToken")]
        public async Task<IActionResult> GenerateIMSToken()
        {
            try
            {
                _logger.LogInformation("Generating IMS token for Document...");
                var token = await _documentService.GenerateTokenAsync();
                _logger.LogInformation("Token generated successfully.");
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while generating IMS token.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
