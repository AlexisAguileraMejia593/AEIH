using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadorEquipo : ControllerBase
    {
        [HttpGet]
        [Route("{idJugador}")]
        public IActionResult GetById(int idJugador)
        {
            ML.JugadorEquipo jugadorEquipo = new ML.JugadorEquipo();
            jugadorEquipo.Jugador = new ML.Jugador();   
            jugadorEquipo.Jugador.IdJugador = idJugador;
            ML.JugadorEquipo jugadorEquipoGet = BL.JugadorEquipo.GetById(jugadorEquipo);

            if (jugadorEquipoGet != null)
            {
                return Ok(jugadorEquipoGet);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{idJugador}")]
        public IActionResult Delete(int idJugador)
        {
            bool correct = BL.JugadorEquipo.Delete(idJugador);

            if (correct)
            {
                return Ok("Se ha eliminado correctamente");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add(ML.JugadorEquipo jugadorEquipo)
        {
            bool correct = BL.JugadorEquipo.Add(jugadorEquipo);

            if (correct)
            {
                return Ok("Se ha agregado correctamente");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("{idJugador}")]
        public IActionResult Update(int idJugador, [FromBody]ML.JugadorEquipo jugadorEquipo)
        {
            jugadorEquipo.Jugador = new ML.Jugador();
            jugadorEquipo.Jugador.IdJugador = idJugador;

            bool correct = BL.JugadorEquipo.Update(jugadorEquipo);

            if (correct)
            {
                return Ok("Se ha actualizado correctamente");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
