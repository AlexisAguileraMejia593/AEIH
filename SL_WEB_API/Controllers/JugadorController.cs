using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<object> jugdores = BL.Jugador.GetAll();
            return Ok(jugdores);
        }
        [Route("{idJugador}")]
        [HttpGet]
        public IActionResult GetById(int idJugador)
        {
            ML.Jugador jugador = BL.Jugador.GetById(idJugador);
            if(jugador.Nacionalidad != null)
            {
                return Ok(jugador);
            }
            else
            {
                return BadRequest();
            }
        }
        [Route("")]
        [HttpPost]
        public IActionResult Add(ML.JugadorEquipo jugador)
        {
            bool result = BL.Jugador.Add(jugador);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [Route("{idJugador}")]
        [HttpPut]
        public IActionResult Update(int idJugador, [FromBody]ML.JugadorEquipo jugador)
        {
            jugador.Jugador.IdJugador = idJugador;
            bool result = BL.Jugador.Update(jugador);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [Route("{idJugador}")]
        [HttpDelete]
        public IActionResult Delete(int idJugador)
        {
            bool result = BL.Jugador.Delete(idJugador);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
