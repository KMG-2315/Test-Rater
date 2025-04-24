using Document.BusinessLayer.Models;
using DocumentWCFService;
using DocumentLoginService;
using System;
using System.Threading.Tasks;

namespace Document.BusinessLayer.Interfaces
{
    public interface IDocumentService
    {
        Task<GenerateAutomationDocumentResponse> GetQuoteDocument(GenerateAutomationDocumentResultRequest request);
        Task<bool> ValidateTokenAsync(string token, string userGuid);
        Task<LoginReturn> GetIMSToken();
    }
}
