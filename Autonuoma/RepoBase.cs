namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;



public class RepoBase 
{
	protected static Sql Sql {
        get {
            return Sql.LocalInstance.Value;
        }
    }
}



