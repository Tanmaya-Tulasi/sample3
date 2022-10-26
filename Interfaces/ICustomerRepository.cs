using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICustomerRepository
    {
        ICollection<Customer> GetCustomer();
        Customer GetCustomer(int customerId);
        ICollection<Customer> GetOwnerOfAPokemon(int orderId);
        ICollection<Order> GetPokemonByOwner(int customerId);
        bool OwnerExists(int customerId);
        bool CreateCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        bool Save();
    }
}
