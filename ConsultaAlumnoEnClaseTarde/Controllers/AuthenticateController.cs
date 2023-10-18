using ConsultaAlumnos2TUP4.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnos2TUP4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        [HttpPost]
        public IActionResult Authenticate(Credentials credentials)
        {
            //valido usuario
            //generacion del token
            string token = "";

            return Ok(token);
        }
    }
}
