using Core_Proje_API.DAL.ApiContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        [HttpGet]
        public IActionResult SkillList()
        {
            var context=new Context();
            return Ok(context.Skills.ToList());
        }
    }
}
