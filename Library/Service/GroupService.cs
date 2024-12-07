using Dapper;
using Npgsql;
using Library.Model;

namespace Library.Service;

public class GroupService
{
    string connectionString = "Server=127.0.0.1;Port=5432;Database=DapperCrudDB;User Id=postgres;Password=280806;";
    public bool Insert(Group group)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"insert into groups (groupname,courseid) values
            (@groupname,@courseid)";
            var effect = connection.Execute(sql, group);
            return effect > 0;
        }
    }
    public bool Update(Group group)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = @"update groups set groupname = @groupname, courseid = @courseid
            where Id = @Id";
            var effect = connection.Execute(sql, group);
            return effect > 0;
        }
    }
    public bool Delete(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "delete from groups where Id = @Id";
            var effect = connection.Execute(sql, new { Id = id });
            return effect > 0;
        }
    }
    public List<Group> GetGroups()
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "select * from groups";
            return connection.Query<Group>(sql).ToList();
        }
    }
}
