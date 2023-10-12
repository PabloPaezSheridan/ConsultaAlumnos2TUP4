using ConsultaAlumnoEnClaseTarde.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ConsultaAlumnoEnClaseTarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet("{idMateria}")]
        public IActionResult GetProfessorxMateria([FromRoute] int idMateria)
        {
            return Ok();
        }


    }
}
