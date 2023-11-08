using ConsultaAlumnoEnClaseTarde.Entities;

namespace ConsultaAlumnos2TUP4.Services.Interfaces
{
    public interface IResponseService
    {
        public Response GetOne(int Id);
        public List<Response> GetAllByQuestion(int QuestionId);
    }
}
