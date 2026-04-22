namespace Lab_2_DB.Repositories;

using Lab_2_DB.Models;



/// <summary>
/// Base class for repository classes. Used to simplify retrieval of proper instance of SQL helper.
/// </summary>
public class RepoBase 
{
    /// <summary>
	/// SQL helper.
	/// </summary>
	protected static Sql Sql {
        get {
            return Sql.LocalInstance.Value;
        }
    }
}
