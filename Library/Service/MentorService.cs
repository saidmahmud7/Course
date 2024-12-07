using Dapper;
using Library.Model;
using Npgsql;

namespace Library.Service;

public class MentorService
{
    string connectionString = "Server=127.0.0.1;Port=5432;Database=DapperCrudDB;User Id=postgres;Password=280806;";
    public bool Insert(Mentor mentor)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"insert into Mentors (Name,Email,phone) values
            (@Name,@email,@phone)";
            var effect = connection.Execute(sql, mentor);
            return effect > 0;
        }
    }
    public bool Update(Mentor mentor)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"update Mentors set Name = @Name, Email = @Email,phone = @Phone
            where Id = @Id";
            var effect = connection.Execute(sql, mentor);
            return effect > 0;
        }
    }
    public bool Delete(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from Mentors where Id = @Id";
            var effect = connection.Execute(sql, new { Id = id });
            return effect > 0;
        }
    }
    public List<Mentor> GetMentors()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"select * from Mentors";
            return connection.Query<Mentor>(sql).ToList();
        }
    }
    public Student GetMentorById(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from Mentors where id=@Id;";
            var students = connection.QuerySingle<Student>(sql, new { Id = id });
            return students;
        }
    }
}
