using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Itb.Shared;

namespace AspNetCoreMvc.Controllers
{
    [Produces("application/json")]
    [Route("api/ProductApi")]
    public class ProductApiController : Controller
    {
        private readonly IProductRepository _prodRepo;
        public ProductApiController(IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        // GET: api/ProductApi
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var get = await _prodRepo.GetProducts();
            return get;
        }

        // GET: api/ProductApi/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return _prodRepo.GetProduct(id);
        }
        
        // POST: api/ProductApi
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var prod = new Product() { Name = value };
            _prodRepo.AddProduct(prod);
        }
        
        // PUT: api/ProductApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            var prod = new Product() { Name = value, Id = id };
            _prodRepo.UpdateProduct(prod);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _prodRepo.DeleteProduct(id);
        }
    }
}
