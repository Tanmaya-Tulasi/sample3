using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;

        public CustomerRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCustomer(Customer customer)
        {
            _context.Add(customer);
            return Save();
        }

        public bool DeleteCustomer(Customer customer)
        {
            _context.Remove(customer);
            return Save();
        }

        public Customer GetCustomer(int customerId)
        {
            return _context.Customers.Where(o => o.Id == customerId).FirstOrDefault();
        }

        public ICollection<Customer> GetOwnerOfAPokemon(int orderId)
        {
            return _context.OrderItems.Where(p => p.Order.Id == orderId).Select(o => o.Customer).ToList();
        }

        public ICollection<Customer> GetCustomer()
        {
            return _context.Customers.ToList();
        }

        public ICollection<Order> GetPokemonByOwner(int customerId)
        {
            return _context.OrderItems.Where(p => p.Customer.Id == customerId).Select(p => p.Order).ToList();
        }

        public bool OwnerExists(int customerId)
        {
            return _context.Customers.Any(o => o.Id == customerId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCustomer(Customer customer)
        {
            _context.Update(customer);
            return Save();
        }
    }
}
