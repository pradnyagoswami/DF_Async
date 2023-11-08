using Dapper;
using DF_Async.Data;
using DF_Async.Models;

namespace DF_Async.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<int> AddEmployee(Employee employee)
        {
            int result = 0;
            var query = "insert into Employe values(@name,@email,@age,@salary)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", employee.Name);
            parameters.Add("@email", employee.Email);
            parameters.Add("@age", employee.Age);
            parameters.Add("@salary", employee.Salary);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            int result = 0;
            var query = "delete from Employe where id=@id";

            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, new { id });
            }
            return result;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var qry = "select * from Employe where id=@id";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<Employee>(qry, new { id });
                return result;
            }
        }

            public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var qry = "select * from Employe";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QueryAsync<Employee>(qry);
                return result.ToList();
            }
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            int result = 0;
            var query = "update Employe set name=@name,email=@email,age=@age,salary=@salary where id=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@name", employee.Name);
            parameters.Add("@email", employee.Email);
            parameters.Add("@age", employee.Age);
            parameters.Add("@salary", employee.Salary);
            using (var connection = context.CreateConnection())
            {
                result = await connection.ExecuteAsync(query, parameters);
            }
            return result;
        }
    }
}
