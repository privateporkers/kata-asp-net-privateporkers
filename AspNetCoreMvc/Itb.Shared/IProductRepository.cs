using System;
using System.Collections.Generic;

namespace Itb.Shared
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProducts(int id);
        int DeleteProduct(Product prod);
        int UpdateProduct(Product prod);
        int AddProduct(Product prod);
    }
}