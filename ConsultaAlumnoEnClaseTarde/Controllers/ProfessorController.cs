using ConsultaAlumnoEnClaseTarde.Entities;
using ConsultaAlumnoEnClaseTarde.Services.Interfaces;
using ConsultaAlumnos2TUP4.Data.Models;
using ConsultaAlumnos2TUP4.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnoEnClaseTarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        private readonly IUserService _userService;
        public ProfessorController(IProfessorService professorService, IUserService userService)
        {
            _professorService = professorService;
            _userService = userService;
        }


        [HttpPost]
        public IActionResult CreateProfessor([FromBody] ProfessorPostDto dto)
        {
            var profesor = new Professor()
            {
                Email = dto.Email,
                LastName = dto.LastName,
                Name = dto.Name,
                Password = dto.Password,
                UserName = dto.UserName,
                UserType = "Professor"
            };
            int id = _userService.CreateUser(profesor);
            return Ok(id);
        }


        [HttpGet]
        public IActionResult GetProfessors()
        {
            return Ok(_professorService.GetProfessors());
        }


    }
}
