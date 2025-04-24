using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Document.BusinessLayer.Interfaces;
using Document.BusinessLayer.Models;
using Document.DataAccessLayer;
using DocumentWCFService;
using DataAccessLayer.Utilities;
using DocumentLoginService;
using Azure.Core;


namespace Document.BusinessLayer.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDataAccess _dataAccess;
        private readonly BaseUtility _utility;
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(IDataAccess dataAccess, ILogger<DocumentService> logger)
        {
            _dataAccess = dataAccess;
            _utility = new BaseUtility();
            _logger = logger;
        }


        public async Task<LoginReturn> GetIMSToken()
        {
            try
            {
                _logger.LogInformation("Calling BaseUtility.GenerateIMSToken()");
                return await _utility.GenerateIMSToken();
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
                var loginResult = await _utility.GenerateIMSToken();

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

        public async Task<GenerateAutomationDocumentResponse> GetQuoteDocument(GenerateAutomationDocumentResultRequest request)

        {
            try
            {
                var loginResult = await GetIMSToken(); // This returns LoginReturn

                string message = "Invalid Operation";
                GenerateAutomationDocumentResponse response = null;
                if (loginResult != null)
                {
                    DocumentWCFService.TokenHeader header = new DocumentWCFService.TokenHeader();
                    header.Token = loginResult.Token;
                    header.Context = loginResult.UserGuid.ToString();
                    DocumentFunctionsSoapClient qsoapClient = new DocumentFunctionsSoapClient(DocumentFunctionsSoapClient.EndpointConfiguration.DocumentFunctionsSoap);
                    response = await qsoapClient.GenerateAutomationDocumentAsync(header, request.quoteGuid);
                }
                else
                {
                    _logger.LogWarning("Login token is null in GetInsured for InsuredGuid: {InsuredGuid}", request);
                }
                return response;
            }
            //try
            //{
            //    _logger.LogInformation("Getting IMS token for GetPolicyInformation...");
            //    var loginResult = await GetIMSToken();

            //    if (loginResult == null)
            //    {
            //        _logger.LogWarning("LoginResult was null in GetPolicyInformation");
            //        return null;
            //    }

            //    DocumentWCFService.TokenHeader header = new DocumentWCFService.TokenHeader
            //    {
            //        Token = loginResult.Token,
            //        Context = loginResult.UserGuid.ToString()
            //    };

            //    _logger.LogInformation("Calling SOAP service for QuoteGuid: {QuoteGuid}", quoteGuid, eventGuid, printTypeId);
            //    QuoteFunctionsSoapClient qsoapClient = new QuoteFunctionsSoapClient(QuoteFunctionsSoapClient.EndpointConfiguration.QuoteFunctionsSoap);
            //    var response = await qsoapClient.GetControlNumberAsync(header, quoteGuid);

            //    _logger.LogInformation("SOAP response received for QuoteGuid: {QuoteGuid}", quoteGuid, eventGuid, printTypeId);
            //    return response;
            //}
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetQuoteDocumentAsync");
                throw;
            }
        }
    }
}
