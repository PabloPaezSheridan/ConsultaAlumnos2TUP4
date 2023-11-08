using ConsultaAlumnos2TUP4.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnos2TUP4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ResponseController : ControllerBase
    {
        public readonly IResponseService _responseService;

        public ResponseController(IResponseService responseService)
        {
            _responseService = responseService;
        }

        [HttpGet("{id}")]
        public IActionResult GetOne([FromRoute] int id)
        {
            return Ok(_responseService.GetOne(id));
        }

        [HttpGet("question/{questionId}")]
        public IActionResult GetAllByQuestion([FromRoute] int questionId)
        {
            return Ok(_responseService.GetAllByQuestion(questionId));
        }
    }
}
