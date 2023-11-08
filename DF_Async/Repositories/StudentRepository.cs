using Dapper;
using DF_Async.Data;
using DF_Async.Models;

namespace DF_Async.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext context;

        public StudentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddStudent(Student student)
        {
            int result = 0;
            var query = "insert into Student values(@name,@percentage,@city)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", student.Name);
            parameters.Add("@percentage", student.Percentage);
            parameters.Add("@city", student.City);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }

        public async Task<int> DeleteStudent(int id)
        {
            int result = 0;
            var query = "delete from Student where rollno=@rollno";

            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id });
            }
            return result;
        }

        public async Task<Student> GetStudentById(int id)
        {
            var qry = "select * from Student where rollno=@id";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Student>(qry, new { id });
                return result;
            }
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var qry = "select * from Student";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<Student>(qry);
                return result.ToList();
            }
        }

        public async Task<int> UpdateStudent(Student student)
        {
            int result = 0;
            var query = "update Student set name=@name,percentage=@percentage,city=@city where rollno=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", student.Name);
            parameters.Add("@percentage", student.Percentage);
            parameters.Add("@city", student.City);
            parameters.Add("@rollno", student.Rollno);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }
    }
}
