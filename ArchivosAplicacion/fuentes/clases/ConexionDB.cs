using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public class ConexionDB
{
	private static SqlConnection cnx; //Conexión
	private string dataSource; 
	private string initialCatalog;
	
	
	public ConexionDB(){}
    
	public void initialize()
	{
        FileInfo  fileCfg = new FileInfo(@"..\otros\bd.cfg");
        StreamReader fileReader = fileCfg.OpenText();
		dataSource = fileReader.ReadLine();
		initialCatalog =fileReader.ReadLine();
		fileReader.Close();
		if (dataSource     == null || dataSource.Equals("")     ||
			initialCatalog == null || initialCatalog.Equals("") 		     
			
		   ) 
		{
			throw new FileNotFoundException("Archivo de configuración incompleto");
		}
	}

	public void openConnection()
	{
		
		#region cuando se requiera validar puerto, password y usuario
		/*using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public class ConexionDB
{
	private static SqlConnection cnx; //Conexión
	private string dataSource; 
	private string initialCatalog;
	private string user;
	private string password;
	private string port;
		
	public ConexionDB(){}
    
	public void initialize()
	{
		FileInfo  fileCfg = new FileInfo(@"..\otros\bd.cfg");
		StreamReader fileReader = fileCfg.OpenText();
		dataSource = fileReader.ReadLine();
		initialCatalog =fileReader.ReadLine();
		user=fileReader.ReadLine();
		password = fileReader.ReadLine();
		port= fileReader.ReadLine();
		fileReader.Close();
		if (dataSource     == null || dataSource.Equals("")     ||
			initialCatalog == null || initialCatalog.Equals("") ||
			user           == null || user.Equals("")           ||
			password       == null || password.Equals("")		||
			port           == null || port.Equals("")
		   ) 
		{
			throw new FileNotFoundException("Archivo de configuración incompleto");
		}
	}

	public void openConnection()
	{
		string strConnection;
		strConnection = @"Data Source=" + dataSource + "," + port +";";
		strConnection +=  "Network Library=DBMSSOCN;";
		strConnection += "Initial Catalog=" + initialCatalog + ";";
		strConnection += "User ID=" + user + ";" + "Password=" + password + ";";

		try
		{
			cnx=new SqlConnection(strConnection);
			cnx.Open();
		}
		catch(Exception e)
		{
			throw e;
		}
	}

	public static SqlConnection getConnection()
	{
		return cnx;
	}
}
		*/		
		# endregion
		string strConnection;
		strConnection = @"Initial Catalog="+ initialCatalog +";Data Source= "+ dataSource +";Integrated Security=SSPI;";

		try
		{
			cnx=new SqlConnection(strConnection);
			cnx.Open();
		}
		catch(Exception e)
		{
			throw e;
		}
	}

	public static SqlConnection getConnection()
	{
		return cnx;
	}
}

