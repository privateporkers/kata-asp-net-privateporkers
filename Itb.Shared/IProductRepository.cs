using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itb.Shared
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Product GetProduct(int id);
        Task<int> DeleteProduct(int id);
        Task<int> UpdateProduct(Product prod);
        Task<int> AddProduct(Product prod);
    }
}