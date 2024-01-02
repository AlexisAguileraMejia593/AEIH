using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosicionController : ControllerBase
    {
        [EnableCors("API")]
        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ML.Posicion> posiciones = BL.Posicion.GetAll();
            if(posiciones!= null)
            {
                return Ok(posiciones);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
