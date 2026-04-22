namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;



public class RepoBase 
{
	protected static Sql Sql {
        get {
            return Sql.LocalInstance.Value;
        }
    }

    protected static int NextId(string tableName)
    {
        var query = $@"SELECT COALESCE(MAX(id), 0) + 1 AS next_id FROM `{Config.TblPrefix}{tableName}`";
        var rows = Sql.Query(query);
        return Convert.ToInt32(rows[0]["next_id"]);
    }
}



