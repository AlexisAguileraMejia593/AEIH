using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LigaController : ControllerBase
    {
        [EnableCors("API")]
        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            List<object> result = BL.Liga.GetAll();
            if(result.Count >= 0)
            {
                return Ok(result);

            }else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [Route("GetById/{IdLiga}")]
        [HttpGet]
        public IActionResult GetById(int IdLiga)
        {
            List<object> result = BL.Liga.GetById(IdLiga);
            if (result.Count >= 0)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [Route("Delete/{IdLiga}")]
        [HttpDelete]

        public IActionResult Delete(int IdLiga)
        {
            bool result = BL.Liga.Delete(IdLiga);
            if (result)
            {
                return Ok(result);

            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [Route("Update/{IdLiga}")]
        [HttpPut]
        public IActionResult Update(int IdLiga, [FromBody] ML.Liga liga)
        {
            liga.IdLiga = IdLiga;
            bool correct = BL.Liga.Update(liga);
            if (correct)
            {
                return Ok(correct);
            }
            else
            {
                return BadRequest();
            }
        }

        [EnableCors("API")]
        [Route("")]
        [HttpPost]
        public IActionResult Add(ML.Liga liga)
        {
            
            bool correct = BL.Liga.Add(liga);
            if (correct)
            {
                return Ok(correct);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

