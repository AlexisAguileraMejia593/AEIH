using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        [EnableCors("API")]
        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ML.Pais> paises = BL.Pais.GetAll();
            if(paises != null)
            {
                return Ok(paises);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
