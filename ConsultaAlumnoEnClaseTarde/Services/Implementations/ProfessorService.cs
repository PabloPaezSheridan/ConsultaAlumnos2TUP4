using ConsultaAlumnoEnClaseTarde.Data;
using ConsultaAlumnoEnClaseTarde.Entities;
using ConsultaAlumnoEnClaseTarde.Services.Interfaces;

namespace ConsultaAlumnoEnClaseTarde.Services.Implementations
{
    public class ProfessorService : IProfessorService
    {
        private readonly ConsultaContext _context;

        public ProfessorService(ConsultaContext context)
        {
            _context = context;
        }

        public List<User> GetProfessors()
        {
            return _context.Users.Where(p => p.UserType == "Professor").ToList();
        }


    }
}
