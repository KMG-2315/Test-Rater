using LoginService;
using Quotes.BusinessLayer.Modal;
using QuoteWCFService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.BusinessLayer.Interfaces
{
    public interface IQuoteService
    {
        Task<IEnumerable<QuoteModel>> GetAllQuotesAsync();
        Task<QuoteModel> GetQuoteByControlNoAsync(int controlNo);
        Task<BatchResponse> GetPremStatBatchAsync();
        Task<LoginReturn> GetIMSToken();
        Task<bool> ValidateTokenAsync(string token, string userGuid);
        Task<GetPolicyInformationResponse> GetPolicyInformation(Guid quoteGuid);


    }
}