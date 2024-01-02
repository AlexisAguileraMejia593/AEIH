using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidoController : ControllerBase
    {
        [EnableCors("API")]
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            List<object> list = BL.Partido.GetAll();

            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [HttpPost]
        [Route("")]
        public IActionResult Add(ML.Partido partido)
        {
            bool correct = BL.Partido.Add(partido);

            if (correct)
            {
                return Ok("Se ha agregado correctamente");
            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [HttpDelete]
        [Route("{idPartido}")]
        public IActionResult Delete(int idPartido)
        {
            bool correct = BL.Partido.Delete(idPartido);

            if (correct)
            {
                return Ok("Se ha eliminado de manera correcta");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
