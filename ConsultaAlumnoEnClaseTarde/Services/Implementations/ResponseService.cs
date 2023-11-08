using ConsultaAlumnoEnClaseTarde.Data;
using ConsultaAlumnoEnClaseTarde.Entities;
using ConsultaAlumnos2TUP4.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsultaAlumnos2TUP4.Services.Implementations
{

    public class ResponseService: IResponseService
    {
        private readonly ConsultaContext _context;

        public ResponseService(ConsultaContext context)
        {
            _context = context;
        }

        public List<Response> GetAllByQuestion(int QuestionId)
        {
            return _context.Responses
                .Include(r => r.Creator)
                .Where(r => r.QuestionId == QuestionId)
                .ToList();
        }

        public Response? GetOne(int Id)
        {
            return _context.Responses
                .Include(r => r.Creator)
                .Include(r => r.Question)
                .SingleOrDefault(x => x.Id == Id);
        }

    }
}
