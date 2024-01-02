﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadioController : ControllerBase
    {
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
    }
}
