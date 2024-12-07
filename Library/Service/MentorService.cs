using Dapper;
using Library.DataContext;
using Library.Model;
using Npgsql;

namespace Library.Service;

public class MentorService
{
    DapperContext dapperContext;
    public MentorService()
    {
        dapperContext = new DapperContext();
    }
    public bool Insert(Mentor mentor)
    {

        var sql = @"insert into Mentors (Name,Email,phone) values
            (@Name,@email,@phone)";
        var effect = dapperContext.Connection().Execute(sql, mentor);
        return effect > 0;

    }
    public bool Update(Mentor mentor)
    {

        var sql = @"update Mentors set Name = @Name, Email = @Email,phone = @Phone
            where Id = @Id";
        var effect = dapperContext.Connection().Execute(sql, mentor);
        return effect > 0;

    }
    public bool Delete(int id)
    {

        var sql = "delete from Mentors where Id = @Id";
        var effect = dapperContext.Connection().Execute(sql, new { Id = id });
        return effect > 0;

    }
    public List<Mentor> GetMentors()
    {

        var sql = @"select * from Mentors";
        return dapperContext.Connection().Query<Mentor>(sql).ToList();

    }
    public Student GetMentorById(int id)
    {
        var sql = "select * from Mentors where id=@Id;";
        var students = dapperContext.Connection().QuerySingle<Student>(sql, new { Id = id });
        return students;

    }
}
