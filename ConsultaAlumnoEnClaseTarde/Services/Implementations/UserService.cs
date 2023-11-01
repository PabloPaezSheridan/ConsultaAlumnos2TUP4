using ConsultaAlumnoEnClaseTarde.Data;
using ConsultaAlumnoEnClaseTarde.Entities;
using ConsultaAlumnos2TUP4.Data.Models;
using ConsultaAlumnos2TUP4.Services.Interfaces;

namespace ConsultaAlumnos2TUP4.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ConsultaContext _context;

        public UserService(ConsultaContext context)
        {
            _context = context;
        }

        public User? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        public BaseResponse ValidarUsuario(string email, string password)
        {
            BaseResponse response = new BaseResponse();
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null)
            {
                if (userForLogin.Password == password)
                {
                    response.Result = true;
                    response.Message = "loging Succesfull";
                }
                else
                {
                    response.Result = false;
                    response.Message = "wrong password";
                }
            }
            else
            {
                response.Result = false;
                response.Message = "wrong email";
            }
            return response;
        }

        public int CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void UpdateUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            User userToBeDeleted = _context.Users.FirstOrDefault(u => u.Id == userId);
            userToBeDeleted.State = false;
            _context.Update(userToBeDeleted);
            _context.SaveChanges();
        }

    }
}
