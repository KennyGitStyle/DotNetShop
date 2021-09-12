using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketByIdAsync(string id){
            var basket =  await _basketRepository.GetBasketAsync(id);

            return Ok(basket ?? new CustomerBasket(id));
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> UpdateBasketByCustomerAsync(CustomerBasket customerBasket) => await _basketRepository.UpdateBasketAsync(customerBasket);

        [HttpDelete]
        public async Task DeleteBasketAsync(string id) => await _basketRepository.DeleteBasketAsync(id);
    }
}