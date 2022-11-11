namespace Restaurant.Services.ShoppingCartApi.Models.Dtos
{
    public class CartDto
    {
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetail> CartDetails { get; set; }
    }
}
