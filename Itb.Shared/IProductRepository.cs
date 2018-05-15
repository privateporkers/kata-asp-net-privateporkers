using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Itb.Shared
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Product GetProduct(int id);
        int DeleteProduct(int id);
        int UpdateProduct(Product prod);
        int AddProduct(Product prod);
    }
}