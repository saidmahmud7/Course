using Dapper;
using Library.DataContext;
using Library.Model;
using Npgsql;

namespace Library.Service;

public class StudentService
{
    DapperContext dapperContext;
    public StudentService()
    {
        dapperContext = new DapperContext();
    }
    public bool Insert(Student student)
    {

        var sql = @"insert into students (Name,age,phone,GroupId,CourseId) values
            (@Name,@age,@phone,@GroupId,@CourseId)";
        var effect = dapperContext.Connection().Execute(sql, student);
        return effect > 0;

    }
    public bool Update(Student student)
    {
        var sql = @"update students set Name = @Name, age = @Age,phone = @Phone, groupId = @GroupId, CourseId = @CourseId
            where Id = @Id";
        var effect = dapperContext.Connection().Execute(sql, student);
        return effect > 0;

    }
    public bool Delete(int id)
    {

        var sql = "delete from students where Id = @Id";
        var effect = dapperContext.Connection().Execute(sql, new { Id = id });
        return effect > 0;

    }
    public List<Student> GetStudents()
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
        List<Student> students = dapperContext.Connection().Query<Student>(sql).ToList();
        return students;

    }
    public Student GetStudentById(int id)
    {

        var sql = "select * from students where id=@Id;";
        var students = dapperContext.Connection().QuerySingle<Student>(sql, new { Id = id });
        return students;

    }

}
