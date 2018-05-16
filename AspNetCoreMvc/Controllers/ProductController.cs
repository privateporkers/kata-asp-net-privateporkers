using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using AspNetCoreMvc.Models;
using Itb.Shared;
using Itb.Repositories;

namespace AspNetCoreMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _prodRepo;
        public ProductController(IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }
        // GET: Product

        public async Task<ActionResult> Index()
        {
            var productCollect = await _prodRepo.GetProducts();
            return View(productCollect);
        }

    // GET: Product/Details/5

        public ActionResult Details(int id)

        {
            var getProduct = _prodRepo.GetProduct(id);
            return View(getProduct);

        }

    // GET: Product/Create

        public ActionResult  Create()

        {
           
            return View();
        }

        // POST: Product/Create

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(IFormCollection collection)
        {

            try
            {
                // TODO: Add insert logic here
                var prod = new Product();
                prod.Name = collection["Name"];
               await _prodRepo.AddProduct(prod);
                return RedirectToAction(nameof(Index));
            }

            catch
            {

                return View();

            }
        }

        // GET: Product/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5

        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {

                // TODO: Add update logic here
                var prod = new Product() { Id = id, Name = collection["Name"]};
                await _prodRepo.UpdateProduct(prod);
                return RedirectToAction(nameof(Index));

            }

            catch
            {
                return View();
            }

        }

        // GET: Product/Delete/5

        public async Task<ActionResult> Delete(int id)
        {
            var getProd = _prodRepo.GetProduct(id);
            return View(getProd);
        }

        // POST: Product/Delete/5

        [HttpPost]

        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var delete = await _prodRepo.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }

            catch
            {
                return View();
            }
        }

    }
}