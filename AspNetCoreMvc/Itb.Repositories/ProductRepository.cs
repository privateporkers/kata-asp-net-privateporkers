using System;
using Itb.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;

namespace Itb.Repositories
{
    public class ProductRepository : IProductRepository
    {
       private readonly IDbConnection _conn;

       public ProductRepository(IDbConnection conn)
       {
           _conn = conn;
       }

       public int AddProduct(Product prod)
       {
           using (var conn = _conn)
           {
               conn.Open();
               return conn.Execute("INSERT INTO product (Name) VALUES (@Name)", prod);
           }
       } 

       public int DeleteProduct(int id)
       {
           using (var conn = _conn)
           {
               conn.Open();
               return conn.Execute("DELETE FROM product WHERE ProductId = @Id", new { id } );
           }
       }

       public Product GetProduct(int id)
       {
           using (var conn = _conn)
           {
               conn.Open();
               return conn.Query<Product>("SELECT *, ProductId as Id WHERE ProductId = @Id").FirstOrDefault();
           }
       }

       public IEnumerable<Product> GetProducts()
       {
           using (var conn = _conn)
           {
               conn.Open();
               
               return conn.Query<Product>("SELECT *, ProductId as Id FROM product");
           }
       }

       public int UpdateProduct(Product prod)
       {
          using (var conn = _conn)
           {
               conn.Open();
               return conn.Execute("UPDATE product set Name = @Name WHERE ProductId = @Id", prod);
           } 
       }
    }
}