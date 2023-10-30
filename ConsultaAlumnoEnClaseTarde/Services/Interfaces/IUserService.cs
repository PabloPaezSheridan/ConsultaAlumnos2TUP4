using ConsultaAlumnoEnClaseTarde.Entities;
using ConsultaAlumnos2TUP4.Data.Models;

namespace ConsultaAlumnos2TUP4.Services.Interfaces
{
    public interface IUserService
    {
        public BaseResponse ValidarUsuario(string username, string password);
        public User? GetUserByEmail(string username);
        public int CreateUser(User user);
    }
}
