﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SL_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        [Route("/{IdPartido}")]
        [HttpGet]
        public IActionResult GetAll(int IdPartido)
        {
            List<object> result = BL.Resultado.GetByIdPartido(IdPartido);
            if (result != null)
            {
                return Ok(result);

            }
            else
            {
                return StatusCode(400);
            }

        }
    }
}
