namespace PokemonReviewApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Whatsupno { get; set; }
        public Product Product { get; set; }
        public ICollection<OrderItem> OrderItems{ get; set; }
    }
}
