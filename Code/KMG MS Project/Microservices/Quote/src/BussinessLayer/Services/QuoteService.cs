using DataAccessLayer.Utilities;
using LoginService;
using Microsoft.Extensions.Logging;
using Quotes.BusinessLayer.Interfaces;
using Quotes.BusinessLayer.Modal;
using Quotes.DataAccessLayer;
using QuoteWCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.BusinessLayer.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IDataAccess dataAccess;
        private readonly BaseUtility utility;
        private readonly ILogger<QuoteService> _logger;

        public QuoteService(IDataAccess dataAccess, ILogger<QuoteService> logger)
        {
            this.dataAccess = dataAccess;
            utility = new BaseUtility();
            _logger = logger;
        }

        public async Task<IEnumerable<QuoteModel>> GetAllQuotesAsync()
        {
            string sql = "SELECT * FROM tblQuotes";
            return await dataAccess.QueryAsync<QuoteModel>(sql);
        }

        public async Task<QuoteModel> GetQuoteByControlNoAsync(int controlNo)
        {
            string sql = "SELECT * FROM tblQuotes WHERE ControlNo = @ControlNo";
            var parameters = new { ControlNo = controlNo };
            return await dataAccess.QuerySingleAsync<QuoteModel>(sql, parameters);
        }

        public async Task<BatchResponse> GetPremStatBatchAsync()
        {
            try
            {
                _logger.LogInformation("Fetching PremStatBatch from DB...");
                string sql = "SELECT QuoteGUID, ControlNo, QuoteStatusID AS Status, DateCreated AS LastUpdated FROM tblQuotes";
                var quotes = await dataAccess.QueryAsync<QuoteStatus>(sql);
                _logger.LogInformation("Successfully fetched {Count} rows", quotes.Count());
                return new BatchResponse { QuoteStatuses = quotes.ToList() };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetPremStatBatchAsync");
                throw;
            }
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

        public async Task<GetPolicyInformationResponse> GetPolicyInformation(Guid quoteGuid)
        {
            try
            {
                _logger.LogInformation("Getting IMS token for GetPolicyInformation...");
                var loginResult = await GetIMSToken();

                if (loginResult == null)
                {
                    _logger.LogWarning("LoginResult was null in GetPolicyInformation");
                    return null;
                }

                QuoteWCFService.TokenHeader header = new QuoteWCFService.TokenHeader
                {
                    Token = loginResult.Token,
                    Context = loginResult.UserGuid.ToString()
                };

                _logger.LogInformation("Calling SOAP service for QuoteGuid: {QuoteGuid}", quoteGuid);
                QuoteFunctionsSoapClient qsoapClient = new QuoteFunctionsSoapClient(QuoteFunctionsSoapClient.EndpointConfiguration.QuoteFunctionsSoap);
                var response = await qsoapClient.GetPolicyInformationAsync(header, quoteGuid);

                _logger.LogInformation("SOAP response received for QuoteGuid: {QuoteGuid}", quoteGuid);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetPolicyInformation");
                throw;
            }
        }
    }
}
