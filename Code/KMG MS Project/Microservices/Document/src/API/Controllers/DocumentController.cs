using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Document.BusinessLayer.Interfaces;
using Document.BusinessLayer.Models;
using System;
using System.Threading.Tasks;
using DocumentWCFService;
using Azure.Core;

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
        public async Task<IActionResult> GetQuoteDocumentAsync([FromBody] GenerateAutomationDocumentResultRequest request)
        {
            try
            {
                _logger.LogInformation("Starting GetQuoteDocument API");

                var response = await _documentService.GetQuoteDocument(request);

                return Ok(response); // ✅ Return the response properly
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
                var token = await _documentService.GetIMSToken();
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

