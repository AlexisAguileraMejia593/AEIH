using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        [EnableCors("API")]
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
                return BadRequest();
            }

        }

        [EnableCors("API")]
        [Route("GetById/{idEquipo}")]
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
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromBody] ML.Equipo equipo)
        {
            bool result = BL.Equipo.Add(equipo);
            if (result)
            {
                return Ok("Se ha agregado correctamente");
            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [Route("Delete/{idEquipo?}")]
        [HttpDelete]
        public IActionResult Delete(int idEquipo)
        {
            bool result = BL.Equipo.Delete(idEquipo);
            if (result)
            {
                return Ok("Se ha eliminado correctamente");
            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [Route("Update/{idEquipo}")]
        [HttpPut]
        public IActionResult Update(int idEquipo, [FromBody] ML.Equipo equipo)
        {
            equipo.IdEquipo = idEquipo;
            bool result = BL.Equipo.Update(equipo);

            if (result)
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
