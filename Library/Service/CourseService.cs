using Dapper;
using Library.Model;
using Npgsql;

namespace Library.Service;

public class CourseService
{
    string connectionString = "Server=127.0.0.1;Port=5432;Database=DapperCrudDB;User Id=postgres;Password=280806;";
    public bool Insert(Course course)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "insert into courses (Name,description) values (@name,@description)";
            var effect = connection.Execute(sql,course);
            return effect > 0;
        }
    }
    public bool Update(Course course)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"update courses set Name = @Name, description = @description
            where Id = @Id";
            var effect = connection.Execute(sql, course);
            return effect > 0;
        }
    }
    public bool Delete(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from courses where Id = @Id";
            var effect = connection.Execute(sql, new { Id = id });
            return effect > 0;
        }
    }
    public List<Course> GetCourses()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from courses";
            List<Course> courses = connection.Query<Course>(sql).ToList();
            return courses;
        }
    }
}
