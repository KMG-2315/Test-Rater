using Quotes.BusinessLayer.Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quotes.BusinessLayer.Interfaces
{
    public interface IQuoteService
    {
        Task<IEnumerable<QuoteModel>> GetAllQuotesAsync();
        Task<QuoteModel> GetQuoteByControlNoAsync(int controlNo);
        Task<BatchResponse> GetPremStatBatchAsync();
    }
}
