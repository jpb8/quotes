using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IQuoteInProgRepository
    {
        Task<QuoteInProg> GetQuoteInProgAsync(string quoteId);
        Task<QuoteInProg> UpdateQuoteInProgAsync(QuoteInProg quote);
        Task<bool> DeleteQuoteInProjAsync(string quoteId);
    }
}
