using ConsultaAlumnoEnClaseTarde.Entities;
using ConsultaAlumnoEnClaseTarde.Services.Interfaces;
using ConsultaAlumnos2TUP4.Data.Models;
using ConsultaAlumnos2TUP4.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();

            if (role == "Professor")
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
            return Forbid();
        }


        [HttpPut]
        public IActionResult UpdateProfessor([FromBody] ProfessorToUpdateDto updateProfessor)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;

            if (role == "Professor")
            {
                Professor professorToUpdate = new Professor()
                {
                    Id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    UserName = User.Claims.FirstOrDefault(c => c.Type.Contains("username")).Value,
                    LastName = updateProfessor.LastName,
                    Name = updateProfessor.Name,
                    Password = updateProfessor.Password,
                    UserType = "Professor",
                };
                _userService.UpdateUser(professorToUpdate);
                return Ok();
            }
            return Forbid();
        }

        [HttpDelete]
        public IActionResult DeleteProfessor()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _userService.DeleteUser(id);
            return NoContent();
        }


        [HttpGet]
        public IActionResult GetProfessors()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            User userLogged = _userService.GetUserByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value);
            if (role == "Professor" && userLogged.State)
            {
                return Ok(_professorService.GetProfessors());
            }
            return Forbid();
        }


    }
}
