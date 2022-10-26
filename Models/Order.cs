using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        
        public ICollection<OrderItem> OrderItems { get; set; }
        
    }
}
