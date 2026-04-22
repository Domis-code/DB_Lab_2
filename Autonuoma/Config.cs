namespace Lab_2_DB;


public class Config
{
	private static readonly object mInstanceLock = new Object();

	private static Config mInstance = null;

	private IConfiguration Configuration { get; init; }


	private Config(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public static void CreateSingletonInstance(IConfiguration configuration)
	{
		if( configuration == null )
			throw new ArgumentException("Argument 'configuration' is null.");

		lock( mInstanceLock )
		{
			mInstance = new Config(configuration);
		}
	}

	public static string DBConnStr 
	{
		get 
		{
			lock( mInstanceLock )
			{
				return mInstance.Configuration.GetValue<string>("DbConnStr", "N/A");
			}
		}
	}

	public static string TblPrefix 
	{
		get
		{
			lock( mInstanceLock )
			{
				return mInstance.Configuration.GetValue<string>("TblPrefix", "");
			}
		}
	}
}




