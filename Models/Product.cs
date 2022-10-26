namespace PokemonReviewApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCategory { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }   
        public ICollection<Customer> Customers { get; set; }
    }
}
