using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginService;
using MultiShop.Basket.Service;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            // Retrieve user ID from claims
            var userId = _loginService.GetUserId;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is not set.");
            }

            // Fetch the basket details
            var basketDetails = await _basketService.GetBasketAsync(userId);
            if (basketDetails == null)
            {
                return NotFound("Basket not found.");
            }

            return Ok(basketDetails);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            // Set UserId from claims
            basketTotalDto.UserId = _loginService.GetUserId;

            // Check if UserId is valid
            if (string.IsNullOrEmpty(basketTotalDto.UserId))
            {
                return Unauthorized("User ID is not set.");
            }

            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Basket changes have been saved.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            // Retrieve user ID from claims
            var userId = _loginService.GetUserId;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID is not set.");
            }

            await _basketService.DeleteBasket(userId);
            return Ok("Basket successfully deleted.");
        }
    }
}
