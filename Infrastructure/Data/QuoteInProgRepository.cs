using Core.Entities;
using Core.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class QuoteInProgRepository : IQuoteInProgRepository
    {
        private readonly IDatabase _database;
        public QuoteInProgRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteQuoteInProjAsync(string quoteId)
        {
            return await _database.KeyDeleteAsync(quoteId);
        }

        public async Task<QuoteInProg> GetQuoteInProgAsync(string quoteId)
        {
            var data = await _database.StringGetAsync(quoteId);

            return data.IsNullOrEmpty ? null : JsonConvert.DeserializeObject<QuoteInProg>(data);
        }

        public async Task<QuoteInProg> UpdateQuoteInProgAsync(QuoteInProg quote)
        {
            var created = await _database.StringSetAsync(
                quote.Id, 
                JsonConvert.SerializeObject(quote),
                TimeSpan.FromDays(30)
                );
            if (!created) return null;
            return await GetQuoteInProgAsync(quote.Id);
        }
    }
}
