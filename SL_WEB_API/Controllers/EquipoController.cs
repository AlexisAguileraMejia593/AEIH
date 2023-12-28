using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var list = BL.Equipo.GetAll();
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }

        }
        [Route("GetById/{idEquipo?}")]
        [HttpGet]
        public IActionResult GetById(int idEquipo)
        {
            var list = BL.Equipo.GetById(idEquipo);
            if (list != null)
            {
                return Ok(list);

            }
            else
            {
                return NotFound();
            }
        }
        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromBody] ML.Equipo equipo)
        {
            var result = BL.Equipo.Add(equipo.Nombre, equipo.Pais, equipo.Logo, equipo.Estadio);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [Route("Delete/{idEquipo?}")]
        [HttpDelete]
        public IActionResult Delete(int idEquipo)
        {
            var result = BL.Equipo.Delete(idEquipo);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [Route("Update/{idEquipo?}")]
        [HttpPut]
        public IActionResult Update(int idEquipo, [FromBody] ML.Equipo equipo)
        {
            idEquipo = equipo.IdEquipo;
            var result = BL.Equipo.Update(equipo.Nombre, equipo.Logo, equipo.Pais, equipo.Estadio);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
