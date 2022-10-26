using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IOrderRepository
    {
        ICollection<Order> GetOrders();
        Order GetOrders(int id);
        Order GetOrders(string name);
        Order GetPokemonTrimToUpper(OrderDto pokemonCreate);
       
        bool PokemonExists(int orderId);
        bool CreateOrders(int orderId,  Order order);
        bool UpdateOrders(int customerId,  Order order);
        bool DeleteOrders(Order order);
        bool Save();
    }
}
