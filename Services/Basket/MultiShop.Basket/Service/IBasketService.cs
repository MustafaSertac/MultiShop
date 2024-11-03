using MultiShop.Basket.Dtos;

namespace MultiShop.Basket.Service
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketAsync(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task  DeleteBasket(string userId);
    }
}
