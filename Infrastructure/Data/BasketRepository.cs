using System;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId) => await _database.KeyDeleteAsync(basketId);

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var fetchedData = await _database.StringGetAsync(basketId);

            return fetchedData.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(fetchedData);
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket customerBasket)
        {
            var createdData = await _database.StringSetAsync(customerBasket.Id, JsonSerializer.Serialize(customerBasket),
            TimeSpan.FromDays(30));

            if(!createdData) return null;

            return await GetBasketAsync(customerBasket.Id);
        }
    }
}