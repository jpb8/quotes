using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class QuoteInProgController : BaseApiController
    {
        private readonly IQuoteInProgRepository _quoteInProgRepository;

        public QuoteInProgController(IQuoteInProgRepository quoteInProgRepository)
        {
            _quoteInProgRepository = quoteInProgRepository;
        }

        [HttpGet]
        public async Task<ActionResult<QuoteInProg>> GetQuoteInProgById(string id)
        {
            var quote = await _quoteInProgRepository.GetQuoteInProgAsync(id);

            return Ok(quote ?? new QuoteInProg(id));
        }

        [HttpPost]
        public async Task<ActionResult<QuoteInProg>> UpdateQuoteInProg(QuoteInProg quote)
        {
            var updatedQuote = await _quoteInProgRepository.UpdateQuoteInProgAsync(quote);

            return Ok(updatedQuote);
        }

        [HttpDelete]
        public async Task DeleteQuoteInProg(string id)
        {
            await _quoteInProgRepository.DeleteQuoteInProjAsync(id);
        }
    }
}
