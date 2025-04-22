using BussinessLayer.Interfaces;
using Document.BusinessLayer.Interfaces;
using Document.BusinessLayer.Models;
using DocumentWCFService;
using LoginService;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Utilities;

namespace Document.BusinessLayer.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly BaseUtility utility;
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(ILogger<DocumentService> logger)
        {
            _logger = logger;
            utility = new BaseUtility();
        }

        public async Task<LoginReturn> GetIMSToken()
        {
            try
            {
                _logger.LogInformation("Calling BaseUtility.GenerateIMSToken()");
                return await utility.GenerateIMSToken();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while generating IMS token");
                throw;
            }
        }

        public async Task<bool> ValidateTokenAsync(string token, string userGuid)
        {
            try
            {
                _logger.LogInformation("Validating token and userGuid...");
                var loginResult = await utility.GenerateIMSToken();

                bool isValid = loginResult != null &&
                    string.Equals(loginResult.Token.ToString(), token, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(loginResult.UserGuid.ToString(), userGuid, StringComparison.OrdinalIgnoreCase);

                _logger.LogInformation("Token valid status: {IsValid}", isValid);
                return isValid;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ValidateTokenAsync");
                throw;
            }
        }

        public async Task<GetQuoteDocumentResponse> GetQuoteDocumentAsync(string token, string userGuid, GetQuoteDocumentRequest request)
        {
            try
            {
                _logger.LogInformation("Getting IMS token for GetQuoteDocument...");

                var loginResult = await GetIMSToken();
                if (loginResult == null)
                {
                    _logger.LogWarning("LoginResult was null in GetQuoteDocument");
                    return null;
                }

                // Prepare SOAP TokenHeader
                var header = new DocumentWCFService.TokenHeader
                {
                    Token = loginResult.Token,
                    Context = loginResult.UserGuid.ToString()
                };

                _logger.LogInformation("Calling SOAP GetQuoteDocument with QuoteGuid: {QuoteGuid}, EventGuid: {EventGuid}, PrintTypeId: {PrintTypeId}",
                    request.QuoteGuid, request.EventGuid, request.PrintTypeId);

                var client = new QuoteFunctionsSoapClient(QuoteFunctionsSoapClient.EndpointConfiguration.QuoteFunctionsSoap);
                var result = await client.GetQuoteDocumentAsync(header, request.QuoteGuid, request.EventGuid, request.PrintTypeId);

                _logger.LogInformation("SOAP response received successfully.");

                return new GetQuoteDocumentResponse
                {
                    DocumentName = result.DocumentName,
                    DocumentUrl = result.DocumentUrl,
                    Status = "Success"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQuoteDocumentAsync");
                throw;
            }
        }
    }
}
