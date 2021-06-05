using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Rest_Matias_Benitez.Moledo;
using Api_Rest_Matias_Benitez.Repositorios;

namespace Api_Rest_Matias_Benitez
{
    [Route("api/[controller]")]
    [ApiController]
    public class Apis : ControllerBase
    {
        

        [HttpGet]
        public IActionResult Get()
        {
            RPAlumnos rpAlum = new RPAlumnos();
            return Ok(rpAlum.ObtenerAlumnos());
        }

        [HttpGet ("{DNI}")]
        public IActionResult Get(int DNI)
        {
            RPAlumnos rpAlum = new RPAlumnos();

            var AlumRet = rpAlum.ObtenerAlumnos(DNI);
            if (AlumRet == null)
            {
                var nf = NotFound("El cliente " + DNI.ToString() + " no existe.");
                return nf;
            }
            return Ok(AlumRet);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarCliente(Alumnos nuevoAlumno)
        {
            RPAlumnos rpCli = new RPAlumnos();
            rpCli.Agregar(nuevoAlumno);
            return CreatedAtAction(nameof(AgregarCliente), nuevoAlumno);
        }
    }
}
