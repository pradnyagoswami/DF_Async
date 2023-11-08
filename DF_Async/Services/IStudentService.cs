using DF_Async.Models;

namespace DF_Async.Services
{
    public interface IStudentService
    {

        Task<IEnumerable<Student>> GetStudents();
        Task<Student> GetStudentById(int id);

        Task<int> AddStudent(Student student);
        Task<int> UpdateStudent(Student student);
        Task<int> DeleteStudent(int id);
    }
}
