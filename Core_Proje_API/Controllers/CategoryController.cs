using Core_Proje_API.DAL.ApiContext;
using Core_Proje_API.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Core_Proje_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            var c = new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("id")]
        public IActionResult Get(int id) 
        {
            using var context = new Context();
            var value=context.Categories.Find(id);
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category) 
        {
            using var context=new Context();
            context.Add(category);
            context.SaveChanges();
            return Created("", category);
        }
        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            using var context = new Context();
            var value=context.Categories.Find(id);
            if (value==null) 
            {
                return NotFound();
            }
            else
            {
                context.Remove(value);
                context.SaveChanges();
                return NoContent();
            }
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            using var context = new Context();
            var value = context.Categories.Find(category.CategoryID);

            //var value1=context.Find<Category>(category.CategoryID);
            
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName= category.CategoryName;
                context.Update(value);
                context.SaveChanges();
                return NoContent();
            }
        }
    }
}
