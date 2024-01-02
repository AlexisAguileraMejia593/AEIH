using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcadorController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IActionResult GetAlll()
        {
            
            List <object> result = BL.Marcador.GetAll();
            
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(400,result);
            } 
        }
    }
}
