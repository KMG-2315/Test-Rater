using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quotes.BusinessLayer.Interfaces;
using Quotes.BusinessLayer.Modal;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Quotes.Api.Controllers
{
    [ApiController]
    [Route("quotes")]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        private readonly ILogger<QuoteController> _logger;

        public QuoteController(IQuoteService quoteService, ILogger<QuoteController> logger)
        {
            _quoteService = quoteService;
            _logger = logger;
        }

        [HttpGet("premstatbatch")]
        public async Task<ActionResult<BatchResponse>> GetPremStatBatch()
        {
            try
            {
                _logger.LogInformation("Started: GetPremStatBatch");
                var response = await _quoteService.GetPremStatBatchAsync();
                _logger.LogInformation("Completed: GetPremStatBatch");
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetPremStatBatch");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetQuoteByControlNo([FromQuery] int controlNo)
        {
            try
            {
                _logger.LogInformation("Getting quote for ControlNo: {ControlNo}", controlNo);
                var quote = await _quoteService.GetQuoteByControlNoAsync(controlNo);
                if (quote == null)
                {
                    _logger.LogWarning("No quote found for ControlNo: {ControlNo}", controlNo);
                    return NotFound();
                }
                return Ok(quote);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQuoteByControlNo");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetIMSToken")]
        public async Task<IActionResult> GenerateIMSToken()
        {
            try
            {
                _logger.LogInformation("Generating IMS token...");
                var token = await _quoteService.GetIMSToken();
                _logger.LogInformation("Token generated successfully.");
                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while generating IMS token.");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetQuoteData")]
        public async Task<IActionResult> GetQuoteData(
                    [FromQuery] int controlNo)
                   
        {
            try
            {
                

                var quote = await _quoteService.GetQuoteByControlNoAsync(controlNo);
                if (quote == null)
                {
                    _logger.LogWarning("Quote not found for ControlNo: {ControlNo}", controlNo);
                    return NotFound("Quote not found.");
                }

                return Ok(quote);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQuoteData");
                return StatusCode(500, "Internal Server Error");
            }
        }

        //[HttpGet("GetPolicyInfo/{quoteGuid}")]
        //public async Task<IActionResult> GetPolicyInfo(Guid quoteGuid)
        //{
        //    try
        //    {
        //        _logger.LogInformation("Starting to retrieve policy details for QuoteGuid: {QuoteGuid}", quoteGuid);

        //        var policyData = await _quoteService.GetPolicyInformation(quoteGuid);

        //        if (policyData?.GetPolicyInformationResult == null)
        //        {
        //            _logger.LogWarning("No policy data found corresponding to QuoteGuid: {QuoteGuid}", quoteGuid);
        //            return NotFound("Policy information not available.");
        //        }

        //        // Deserialize XML to Policy object
        //        //var xmlString = policyData.GetPolicyInformationResult;
        //        //var policyObject = ConvertXmlToPolicy(xmlString);

        //        _logger.LogInformation("Successfully retrieved policy information for QuoteGuid: {QuoteGuid}");
        //        return Ok(policyObject);  // ✅ JSON output
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Exception occurred while retrieving policy info for QuoteGuid: {QuoteGuid}", quoteGuid);
        //        return StatusCode(500, "Something went wrong while fetching policy data.");
        //    }
        //}

        // Helper method to convert XML to Policy object
        //private Policy ConvertXmlToPolicy(string xml)
        //{
        //    var serializer = new XmlSerializer(typeof(Policy));
        //    using (var reader = new StringReader(xml))
        //    {
        //        return (Policy)serializer.Deserialize(reader);
        //    }
        //}
    }
}
