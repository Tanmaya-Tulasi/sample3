using PokemonReviewApp.Data;
using PokemonReviewApp.Models;

namespace PokemonReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.OrderItems.Any())
            {
                var pokemonOwners = new List<OrderItem>()
                {
                    new OrderItem()
                    {
                        Order = new Order()
                        {
                            OrderName = "Pikachu",
                            OrderDate = new DateTime(1903,1,1),
                           
                           
                        },
                        Customer = new Customer()
                        {
                            CustomerName = "Jack",
                            Address = "London",
                             Whatsupno = "Brocks Gym",
                            Product = new Product()
                            {
                                ProductName = "Kanto"
                            }
                        }
                    },
                    new OrderItem()
                    {
                        Order = new Order()
                        {
                            OrderName = "Squirtle",
                            OrderDate = new DateTime(1903,1,1),
                          
                           
                        },
                        Customer = new Customer()
                        {
                            CustomerName = "Harry",
                            Address = "Potter",
                            Whatsupno= "Mistys Gym",
                            Product = new Product()
                            {
                                ProductName = "Saffron City"
                            }
                        }
                    },
                                    new OrderItem()
                    {
                        Order = new Order()
                        {
                            OrderName = "Venasuar",
                             OrderDate = new DateTime(1903,1,1),
                           
                           
                        },
                        Customer = new Customer()
                        {
                            CustomerName = "Ash",
                            Address = "Ketchum",
                            Whatsupno = "Ashs Gym",
                            Product = new Product()
                            {
                                ProductName = "Millet Town"
                            }
                        }
                    }
                };
                dataContext.OrderItems.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
