using PokemonReviewApp.Data;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateOrders(int customerId, Order order)
        {
            var pokemonOwnerEntity = _context.Customers.Where(a => a.Id == customerId).FirstOrDefault();
           

            var pokemonOwner = new OrderItem()
            {
                Customer = pokemonOwnerEntity,
                Order= order,
            };

            _context.Add(pokemonOwner);

          

            

            _context.Add(order);

            return Save();
        }

        public bool DeleteOrders(Order order)
        {
            _context.Remove(order);
            return Save();
        }

        public Order GetOrders(int id)
        {
            return _context.Orders.Where(p => p.Id == id).FirstOrDefault();
        }

        public Order GetOrders(string name)
        {
            return _context.Orders.Where(p => p.OrderName == name).FirstOrDefault();
        }

      

        public ICollection<Order> GetOrders()
        {
            return _context.Orders.OrderBy(p => p.Id).ToList();
        }

        public Order GetPokemonTrimToUpper(OrderDto pokemonCreate)
        {
            return GetOrders().Where(c => c.OrderName.Trim().ToUpper() == pokemonCreate.OrderName.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool PokemonExists(int orderId)
        {
            return _context.Orders.Any(p => p.Id == orderId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOrders(int customerId,  Order order)
        {
            _context.Update(order);
            return Save();
        }
    }
}
