using Dapper;
using Library.Model;
using Npgsql;

namespace Library.Service;

public class StudentService
{
    string connectionString = "Server=127.0.0.1;Port=5432;Database=DapperCrudDB;User Id=postgres;Password=280806;";
    public bool Insert(Student student)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"insert into students (Name,age,phone,GroupId,CourseId) values
            (@Name,@age,@phone,@GroupId,@CourseId)";
            var effect = connection.Execute(sql, student);
            return effect > 0;
        }
    }
    public bool Update(Student student)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"update students set Name = @Name, age = @Age,phone = @Phone, groupId = @GroupId, CourseId = @CourseId
            where Id = @Id";
            var effect = connection.Execute(sql, student);
            return effect > 0;
        }
    }
    public bool Delete(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from students where Id = @Id";
            var effect = connection.Execute(sql, new { Id = id });
            return effect > 0;
        }
    }
    public List<Student> GetStudents()
    {
       using (var connection = new NpgsqlConnection(connectionString))
       {
          var sql = @"
          select 
          students.name,
          students.age,
          Groups.GroupName,
          Courses.name
          from students
          join Groups on Groups.GroupId = students.GroupId
          join Courses on Courses.CourseId = students.CourseId
          ";
          List<Student> students = connection.Query<Student>(sql).ToList();
          return students;
       }
    }
     public Student GetStudentById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from students where id=@Id;";
            var students = connection.QuerySingle<Student>(sql, new { Id = id });
            return students;
        }
    }

}
