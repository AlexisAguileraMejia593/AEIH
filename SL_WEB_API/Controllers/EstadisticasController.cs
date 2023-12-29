using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticasController : ControllerBase
    {
        [Route("/{IdEquipo")]
        [HttpGet]
        public IActionResult GetById(int IdEquipo)
        {
            List<object> result = BL.EstadisticaEquipo.GetById(IdEquipo);
            if (result == null)
            {
                return Ok(result);
            }
            else
            {
                return StatusCode(400, result);
            }
        }
        [Route("/{IdEquipo}")]
        [HttpPut]
        public IActionResult Update(int IdEquipo, [FromBody] ML.EstadisticaEquipo estadisticaEquipo)
        {
            bool correct = BL.EstadisticaEquipo.Update(estadisticaEquipo);
            if (correct)
            {
                return Ok(correct);
            }
            else
            {
                return StatusCode(400, correct);
            }
        }
    }
}
