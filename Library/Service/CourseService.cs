using Dapper;
using Library.DataContext;
using Library.Model;
using Npgsql;

namespace Library.Service;

public class CourseService
{
    DapperContext dapperContext;
    public CourseService()
    {
        dapperContext = new DapperContext();
    }
    public bool Insert(Course course)
    {
        var sql = "insert into courses (Name,description) values (@name,@description)";
        var effect = dapperContext.Connection().Execute(sql, course);
        return effect > 0;
    }
    public bool Update(Course course)
    {
        var sql = @"update courses set Name = @Name, description = @description
            where Id = @Id";
        var effect = dapperContext.Connection().Execute(sql, course);
        return effect > 0;
    }

    public bool Delete(int id)
    {

        var sql = "delete from courses where Id = @Id";
        var effect = dapperContext.Connection().Execute(sql, new { Id = id });
        return effect > 0;

    }
    public List<Course> GetCourses()
    {
        var sql = "select * from courses";
        List<Course> courses = dapperContext.Connection().Query<Course>(sql).ToList();
        return courses;

    }
}
