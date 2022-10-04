using Microsoft.AspNetCore.Mvc;
using RestAPI.Models;
using System.Collections.Generic;
using System.Linq;


namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>
        {
           new Category {ID=1,Name="SSS",Description="SSSS"},
           new Category {ID=2,Name="SSS",Description="SSSS"},
           new Category {ID=3,Name="SSS",Description="SSSS"},
           new Category {ID=4,Name="SSS",Description="SSSS"},
           new Category {ID=5,Name="SSS",Description="SSSS"},
        };

        // Get all categories / api/Category/GetAll
        [HttpGet]
        public List<Category> GetAll()
        {
            return categories.ToList();
        }

        // Get category by ID / api/Category/ID
        [HttpGet("{id}")]
        public Category GetBy(int id)
        {
            return categories.Where(c => c.ID == id).FirstOrDefault();
        }

        // add new category / api/Category/Add
        [HttpPost]
        public void Add([FromBody] Category category)
        {
            categories.Append(category);
        }

        // update category  / api/Category/Update
        [HttpPut()]
        public void Update([FromBody] Category category)
        {
            var oldCategory = categories.Where(c => c.ID == category.ID).FirstOrDefault();
            oldCategory.Name = category.Name;
            oldCategory.Description = category.Description;
        }

        // delete category by ID / api/Category/Delete
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = categories.Where(c => c.ID == id).FirstOrDefault();
            categories.Remove(category);
        }
    }
}
