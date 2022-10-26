namespace PokemonReviewApp.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}
