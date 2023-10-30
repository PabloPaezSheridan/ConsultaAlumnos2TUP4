using System.ComponentModel.DataAnnotations;

namespace ConsultaAlumnos2TUP4.Data.Models
{
    public class ProfessorPostDto
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        [Required]
        //[RegularExpression("^(?=\\w*d)(?=\\w*[A-Z])(?=\\w*[a-z])\\S{8,16}$")]
        public string Password { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
    }
}
