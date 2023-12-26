using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<object> jugadores = new List<object>();
            jugadores = BL.Jugador.GetAll();
            return Ok(jugadores);
        }
    }
}
