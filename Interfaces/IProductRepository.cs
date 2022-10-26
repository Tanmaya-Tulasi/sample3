
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProduct();
        Product GetProduct(int id);
        Product GetCountryByOwner(int customerId);
        ICollection<Customer> GetOwnersFromACountry(int productId);
        bool CountryExists(int id);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        bool Save();
    }
}
