using Dapper;
using Npgsql;
using Library.Model;
using Library.DataContext;

namespace Library.Service;

public class GroupService
{
    DapperContext dapperContext;
    public GroupService()
    {
        dapperContext = new DapperContext();
    }
    public bool Insert(Group group)
    {

        var sql = @"insert into groups (groupname,courseid) values
            (@groupname,@courseid)";
        var effect = dapperContext.Connection().Execute(sql, group);
        return effect > 0;

    }
    public bool Update(Group group)
    {

        var sql = @"update groups set groupname = @groupname, courseid = @courseid
            where Id = @Id";
        var effect = dapperContext.Connection().Execute(sql, group);
        return effect > 0;

    }
    public bool Delete(int id)
    {

        var sql = "delete from groups where Id = @Id";
        var effect = dapperContext.Connection().Execute(sql, new { Id = id });
        return effect > 0;

    }
    public List<Group> GetGroups()
    {
        var sql = "select * from groups";
        return dapperContext.Connection().Query<Group>(sql).ToList();

    }
}
