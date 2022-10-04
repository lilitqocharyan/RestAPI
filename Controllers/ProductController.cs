using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
           new Product {ID=1,Name="SSS",Description="SSSS", Type=ProductType.Digital,Price=12.5,Category=new Category {ID=1,Name="SSS",Description="SSSS"}},
           new Product {ID=2,Name="SSS",Description="SSSS", Type=ProductType.Pyshical,Price=12.5,Category=new Category {ID=1,Name="SSS",Description="SSSS"}},
           new Product {ID=3,Name="SSS",Description="SSSS", Type=ProductType.Digital,Price=12.5,Category=new Category {ID=1,Name="SSS",Description="SSSS"}},
        };

        // Get all products / api/Product/GetAll
        [HttpGet]
        public List<Product> GetAll()
        {
            return products.ToList();
        }

        // Get products by ID / api/Product/ID
        [HttpGet("{id}")]
        public Product GetBy(int id)
        {
            return products.Where(p => p.ID == id).FirstOrDefault();
        }

        // add new product / api/Product/Add
        [HttpPost]
        public void Add([FromBody] Product product)
        {
            products.Append(product);
        }

        // update product  / api/Product/Update
        [HttpPut()]
        public void Update([FromBody] Product product)
        {
            var oldProduct = products.Where(p => p.ID == product.ID).FirstOrDefault();
            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;
            oldProduct.Type = product.Type;
            oldProduct.Price = product.Price;
            oldProduct.Category = product.Category;
        }

        // delete product by ID / api/Product/Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = products.Where(p => p.ID == id).FirstOrDefault();
            products.Remove(product);
        }
    }
}
