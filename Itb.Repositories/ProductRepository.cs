using System;
using Itb.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using System.Threading.Tasks;

namespace Itb.Repositories
{
    public class ProductRepository : IProductRepository
    {
       private readonly IDbConnection _conn;

       public ProductRepository(IDbConnection conn)
       {
           _conn = conn;
       }

       public Task<int> AddProduct(Product prod)
       {
           using (var conn = _conn)
           {
               conn.Open();
               return conn.ExecuteAsync("INSERT INTO product (Name) VALUES (@Name)", prod);
           }
       } 

       public Task<int> DeleteProduct(int id)
       {
           using (var conn = _conn)
           {
               conn.Open();
               return conn.ExecuteAsync("DELETE FROM product WHERE ProductId = @Id", new { id } );
           }
       }

       public Product GetProduct(int id)
       {
           using (var conn = _conn)
           {
               conn.Open();
               return conn.Query<Product>("SELECT *, ProductId as Id FROM product WHERE ProductId = @Id", new {id}).FirstOrDefault();
            }
       }

       public Task<IEnumerable<Product>> GetProducts()
       {
           using (var conn = _conn)
           {
               conn.Open();
               
               return conn.QueryAsync<Product>("SELECT *, ProductId as Id FROM product");
           }
       }

       public Task<int> UpdateProduct(Product prod)
       {
          using (var conn = _conn)
           {
               conn.Open();
               return conn.ExecuteAsync("UPDATE product set Name = @Name WHERE ProductId = @Id", prod);
           } 
       }
    }
}