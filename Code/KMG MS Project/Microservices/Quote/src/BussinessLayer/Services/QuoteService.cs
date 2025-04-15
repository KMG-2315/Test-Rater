using DataAccessLayer.Utilities;
using LoginService;
using Quotes.BusinessLayer.Interfaces;
using Quotes.BusinessLayer.Modal;
using Quotes.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quotes.BusinessLayer.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly IDataAccess _dataAccess;
        private readonly BaseUtility _utility;

        public QuoteService(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _utility = new BaseUtility();   
        }

        public async Task<IEnumerable<QuoteModel>> GetAllQuotesAsync()
        {
            string sql = "SELECT * FROM tblQuotes";
            return await _dataAccess.QueryAsync<QuoteModel>(sql);
        }

        public async Task<QuoteModel> GetQuoteByControlNoAsync(int controlNo)
        {
            string sql = "SELECT * FROM tblQuotes WHERE ControlNo = @ControlNo";
            var parameters = new { ControlNo = controlNo };
            return await _dataAccess.QuerySingleAsync<QuoteModel>(sql, parameters);
        }

        public async Task<BatchResponse> GetPremStatBatchAsync()
        {
            string sql = "SELECT QuoteGUID, ControlNo, QuoteStatusID AS Status, DateCreated AS LastUpdated FROM tblQuotes";
            var quotes = await _dataAccess.QueryAsync<QuoteStatus>(sql);

            return new BatchResponse
            {
                QuoteStatuses = quotes.ToList()
            };
        }

        public async Task<LoginReturn>  GetIMSToken()
        {
            return await _utility.GenerateIMSToken();
        }

    }
}
