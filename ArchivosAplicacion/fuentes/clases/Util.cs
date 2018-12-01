using System;
using System.Data;
using System.Data.SqlClient;

namespace EPM.clases
{
	public class Util
	{
		private static DataSet ds;
		private static SqlDataAdapter daDir = null;
		private static SqlDataAdapter daFuentes = null;
		private static SqlDataAdapter daProcesos = null;
		private static SqlDataAdapter daFormaA = null;
		private static SqlDataAdapter daVariante = null;
		private static SqlDataAdapter daGroup = null;
		private static SqlDataAdapter daVar = null;
		private static SqlDataAdapter daDatVar = null;
		private static SqlDataAdapter daRecurso = null;
		private static SqlDataAdapter daArchivo = null;
		private static SqlDataAdapter daUsuario = null;
		

		private static SqlConnection cnx;

		//Refresca el dataset con cambios externos que hayan sido realizados.
		public static void refreshDB()
		{
			ds.Clear();
			initializeDataset();
		}
		
		public static void initializeDataset()
		{
			ds = new DataSet();
			cnx = ConexionDB.getConnection(); 			
			
			//Directorio
			initializeAdapter(ref daDir, "SELECT * FROM DIRECTORIO", "Directorio");
			initializeDirectorio();

			//Fuente
			initializeAdapter(ref daFuentes, "SELECT * FROM FUENTE ORDER BY nombre", "Fuente");
			initializeFuente();

			//Proceso
			initializeAdapter(ref daProcesos, "SELECT * FROM PROCESO ORDER BY nombre", "Proceso");
			initializeProceso();
			
			//Forma de Aprovechamiento
			initializeAdapter(ref daFormaA, "SELECT * FROM FORMA_APROVECHAMIENTO ORDER BY nombre", "Forma Aprovech");
			initializeFA();
			
			//Variante Tecnológica.
			initializeAdapter(ref daVariante, "SELECT * FROM VARIANTE_TECNOLOGICA ORDER BY nombre", "Variante Tecn");
			initializeVT();
						
			//Grupo
			initializeAdapter(ref daGroup, "SELECT * FROM GRUPO ORDER BY nombre", "Grupo");
			initializeGrupo();

			//Variable Característica
			initializeAdapter(ref daVar, "SELECT * FROM VARIABLE_CARACTERISTICA ORDER BY nombre", "Variables");
			initializeVariables();

			//Datos Variable
			initializeAdapter(ref daDatVar , "SELECT g.nombre nombreg, v.nombre nombrev, v.unidad, d.* FROM  GRUPO g, VARIABLE_CARACTERISTICA v, DATOS_VARIABLE d WHERE g.id = v.grupo_id AND  v.id = d.var_car_id", "Datos");			
			initializeDatosVariables();

			//Archivo
			initializeAdapter(ref daArchivo , "SELECT * FROM  ARCHIVO", "Archivo");			
			initializeArchivo();

			//Recurso
			initializeAdapter(ref daRecurso, "SELECT * FROM Recurso ORDER BY nombre", "Recurso");
			initializeRecurso();

			//Usuarios
			initializeAdapter (ref daUsuario, "SELECT * FROM USUARIO ORDER BY login", "Usuario" );
			
			
			//Relación Fuente-Procesos.
			addRelation(ds.Tables["Fuente"].Columns["id"], ds.Tables["Proceso"].Columns["fuente_id"], "Procesos");

			//Relación Procesos-Forma de Aprovechamiento.
			addRelation(ds.Tables["Proceso"].Columns["id"], ds.Tables["Forma Aprovech"].Columns["proceso_id"], "Formas de Aprovechamiento");
			
			//Relación Forma de Aprovechamiento - Variante Tecnológica.
			addRelation(ds.Tables["Forma Aprovech"].Columns["id"], ds.Tables["Variante Tecn"].Columns["form_aprov_id"], "Variantes Tecnológicas");

			//Relación Grupo-Variable Característica.
			addRelation(ds.Tables["Grupo"].Columns["id"], ds.Tables["Variables"].Columns["grupo_id"], "Variables");	

			
					
		}

		public static DataSet getDataSet()
		{
			return ds;
		}
		
		public static void initializeAdapter(ref SqlDataAdapter da, string selectCommand, string table)
		{
			
			da = new SqlDataAdapter(selectCommand, cnx);
			da.TableMappings.Add("Table", table);
			da.Fill(ds);
		}
		
		public static void initializeInsertCommand( ref SqlDataAdapter da, string insertCommand, string []paramName, 
			SqlDbType []paramType, int []size)
		{
			da.InsertCommand = cnx.CreateCommand();
			da.InsertCommand.CommandText = insertCommand;
			da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
			da.RowUpdated += new SqlRowUpdatedEventHandler(myHandler);			
			addParams(da.InsertCommand, paramName, paramType, size);
		}

		public static void initializeUpdateCommand( ref SqlDataAdapter da, string updateCommand, string []paramName, 
			SqlDbType []paramType, int []size)
		{
			da.UpdateCommand = cnx.CreateCommand();
			da.UpdateCommand.CommandText = updateCommand;
			addParams(da.UpdateCommand, paramName, paramType, size);
			
		}	

		public static void myHandler(object adapter, SqlRowUpdatedEventArgs e)
		{
			// Don't call AcceptChanges
			e.Status = UpdateStatus.SkipCurrentRow;
		}

		public static void addRelation(DataColumn dParent, DataColumn dChild, string name)
		{
			DataRelation dr;
			dr = new DataRelation(name, dParent, dChild);				
			ds.Relations.Add(dr);
		}
		
		public static void addParams(SqlCommand cmd, string []paramName, 
			SqlDbType []paramType, int []size)
		{
			for(int i=0; i<paramName.Length; i++)
			{
				cmd.Parameters.Add("@" + paramName[i], paramType[i], size[i], paramName[i]);
			}
		}

		public static string getDirectorio()
		{
			return(ds.Tables["Directorio"].Rows[0][1].ToString());
		}

	

		public static void updateGrupoVariablesEnDV()
		{
			ds.Tables.Remove("Datos");
			initializeAdapter(ref daDatVar , "SELECT g.nombre, v.nombre, v.unidad, d.* FROM  GRUPO g, VARIABLE_CARACTERISTICA v, DATOS_VARIABLE d WHERE g.id = v.grupo_id AND  v.id = d.var_car_id", "Datos");			
			initializeDatosVariables();
		}

		public static void Insert(SqlDataAdapter da, string table, string []headers, params string []values)
		{
			DataTable dt = ds.Tables[table];
			DataRow newRow = dt.NewRow();
			DataRowCollection rc = dt.Rows;
			
			dt.Columns[0].AutoIncrementStep = -1;
			dt.Columns[0].AutoIncrementSeed = 0;
			
			for(int i=0; i<values.Length; i++)
			{
				newRow[headers[i]] = values[i];
			}
			dt.Rows.Add(newRow);
			try
			{	
				da.Update(ds, table);
				System.Windows.Forms.Application.DoEvents();				
				ds.AcceptChanges();
			}
			catch (SqlException ex)
			{
				ds.RejectChanges();
				throw ex;
			}		
		}

		public static void Update(SqlDataAdapter da, string table, int pk, string []headers, params string []values)
		{
			int index = 0;
			DataTable dt = ds.Tables[table];
			foreach (DataRow dr in dt.Rows)
			{
				object o = dr["id"];
				if (int.Parse(o.ToString())== pk) break;		
				index++;
			}
			DataRow targetRow = dt.Rows[index];
			System.Windows.Forms.Application.DoEvents();
			targetRow.BeginEdit( );
			for(int i=0; i<values.Length; i++)
			{
				targetRow[headers[i]] = values[i];
			}
			targetRow.EndEdit();			
			DataSet dsChanged = ds.GetChanges(DataRowState.Modified);
			try
			{
				da.Update(dsChanged, table);
				System.Windows.Forms.Application.DoEvents();
				ds.AcceptChanges( );				
			}
			catch (SqlException ex)
			{
				ds.RejectChanges();
				throw ex;
			}		
		}

		public static bool buscar(string table, string colum, string val, string condition2)
		{
			string sqlStatement;
			SqlDataReader rdr;
			SqlCommand sql;
			int result = 0;
			sqlStatement = "SELECT COUNT(*) FROM " + table + " WHERE ";
			sqlStatement += "UPPER(" + colum + ") = UPPER('" + val + "')";
			if (!(condition2.Equals("")))
			{
				sqlStatement +=  " AND " + condition2;
			}

			sql = new SqlCommand(sqlStatement, cnx);
			rdr = sql.ExecuteReader();
			while (rdr.Read())
			{
				result = rdr.GetInt32(0);
			}
			rdr.Close();
			rdr = null;
			if (result > 0) return true;
			else return false;			
		}

		public DataRow buscar(int id, string table)
		{
			int index = 0;
			DataTable dt = ds.Tables[table];
			foreach ( DataRow dr in dt.Rows)
			{
				object o = dr["id"];
				if (int.Parse(o.ToString())==id) break;								
				index++;
			}
			return dt.Rows[index];
		}
		
		public static SqlDataAdapter getDAFuente()
		{
			return daFuentes;
		}

		public static SqlDataAdapter getDAProceso()
		{
			return daProcesos;
		}

		public static SqlDataAdapter getDAFA()
		{
			return daFormaA;
		}

		public static SqlDataAdapter getDAVT()
		{
			return daVariante;
		}

		public static SqlDataAdapter getDAGrupo()
		{
			return daGroup;
		}
		
		public static SqlDataAdapter getDAVar()
		{
			return daVar;
		}

		public static SqlDataAdapter getDADatVar()
		{
			return daDatVar;
		}

		public static SqlDataAdapter getDADirectorio()
		{
			return daDir;
		}

		public static SqlDataAdapter getDAArchivo()
		{
			return daArchivo;
		}

		public static SqlDataAdapter getDARec()
		{
			return daRecurso;
		}

		public static SqlDataAdapter getDAU()
		{
		return daUsuario;
		}


		private static void initializeFuente()
		{
			string Insert, Update;
			Insert = "INSERT INTO FUENTE (nombre, descripcion) VALUES";
			Insert += "(@nombre, @descripcion); SELECT * FROM FUENTE WHERE (id = @@IDENTITY)";
			Update = "UPDATE FUENTE SET nombre = @nombre, descripcion = @descripcion";
			Update +=" WHERE id = @id";
			string[] paramNameI = {"nombre", "descripcion"};
			string []paramNameU = {"nombre", "descripcion", "id"};
			SqlDbType[] paramTypeI = {SqlDbType.VarChar, SqlDbType.VarChar};
			SqlDbType[] paramTypeU = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			int[] sizeI = {100, 7000};				
			int[] sizeU = {100, 7000, 4};	
			initializeInsertCommand(ref daFuentes,Insert, paramNameI, paramTypeI, sizeI);
			initializeUpdateCommand(ref daFuentes,Update, paramNameU, paramTypeU, sizeU);
		}

		private static void initializeProceso()
		{
			string Insert, Update;
			Insert = "INSERT INTO PROCESO (nombre, descripcion, fuente_id) VALUES";
			Insert += "(@nombre, @descripcion, @fuente_id); SELECT * FROM PROCESO WHERE (id = @@IDENTITY)";
			Update = "UPDATE PROCESO SET nombre = @nombre, descripcion = @descripcion";
			Update +=" WHERE id = @id";
			string[] paramNameI = {"nombre", "descripcion", "fuente_id"};
			string []paramNameU = {"nombre", "descripcion", "id"};
			SqlDbType[] paramTypeI = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			SqlDbType[] paramTypeU = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			int[] sizeI = {100, 7000, 4};				
			int[] sizeU = {100, 7000, 4};	
			initializeInsertCommand(ref daProcesos, Insert, paramNameI, paramTypeI, sizeI);
			initializeUpdateCommand(ref daProcesos, Update, paramNameU, paramTypeU, sizeU);			
		}

		private static void initializeFA()
		{
			string Insert, Update;
			Insert = "INSERT INTO FORMA_APROVECHAMIENTO (nombre, descripcion, proceso_id) VALUES";
			Insert += "(@nombre, @descripcion, @proceso_id); SELECT * FROM FORMA_APROVECHAMIENTO WHERE (id = @@IDENTITY)";
			Update = "UPDATE FORMA_APROVECHAMIENTO SET nombre = @nombre, descripcion = @descripcion";
			Update +=" WHERE id = @id";
			string[] paramNameI = {"nombre", "descripcion", "proceso_id"};
			string []paramNameU = {"nombre", "descripcion", "id"};
			SqlDbType[] paramTypeI = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			SqlDbType[] paramTypeU = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			int[] sizeI = {100, 7000, 4};				
			int[] sizeU = {100, 7000, 4};	
			initializeInsertCommand(ref daFormaA, Insert, paramNameI, paramTypeI, sizeI);
			initializeUpdateCommand(ref daFormaA, Update, paramNameU, paramTypeU, sizeU);			
		}

		private static void initializeVT()
		{
			string Insert, Update;
			Insert = "INSERT INTO VARIANTE_TECNOLOGICA (nombre, descripcion, form_aprov_id) VALUES";
			Insert += "(@nombre, @descripcion, @form_aprov_id); SELECT * FROM VARIANTE_TECNOLOGICA WHERE (id = @@IDENTITY)";
			Update = "UPDATE VARIANTE_TECNOLOGICA SET nombre = @nombre, descripcion = @descripcion";
			Update +=" WHERE id = @id";
			string[] paramNameI = {"nombre", "descripcion", "form_aprov_id"};
			string []paramNameU = {"nombre", "descripcion", "id"};
			SqlDbType[] paramTypeI = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			SqlDbType[] paramTypeU = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			int[] sizeI = {100, 7000, 4};				
			int[] sizeU = {100, 7000, 4};	
			initializeInsertCommand(ref daVariante, Insert, paramNameI, paramTypeI, sizeI);
			initializeUpdateCommand(ref daVariante, Update, paramNameU, paramTypeU, sizeU);			
		}

		private static void initializeGrupo()
		{
			string Insert, Update;
			Insert = "INSERT INTO GRUPO (nombre, descripcion) VALUES";
			Insert += "(@nombre, @descripcion); SELECT * FROM GRUPO WHERE (id = @@IDENTITY)";
			Update = "UPDATE GRUPO SET nombre = @nombre, descripcion = @descripcion";
			Update +=" WHERE id = @id";
			string[] paramNameI = {"nombre", "descripcion"};
			string []paramNameU = {"nombre", "descripcion", "id"};
			SqlDbType[] paramTypeI = {SqlDbType.VarChar, SqlDbType.VarChar};
			SqlDbType[] paramTypeU = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			int[] sizeI = {100, 7000};				
			int[] sizeU = {100, 7000, 4};	
			initializeInsertCommand(ref daGroup, Insert, paramNameI, paramTypeI, sizeI);
			initializeUpdateCommand(ref daGroup, Update, paramNameU, paramTypeU, sizeU);
		}

		private static void initializeVariables()
		{
			string Insert, Update;
			Insert = "INSERT INTO VARIABLE_CARACTERISTICA (nombre, unidad, grupo_id) VALUES";
			Insert += "(@nombre, @unidad, @grupo_id); SELECT * FROM VARIABLE_CARACTERISTICA WHERE (id = @@IDENTITY)";
			Update = "UPDATE VARIABLE_CARACTERISTICA SET nombre = @nombre, unidad = @unidad";
			Update +=" WHERE id = @id";
			string[] paramNameI = {"nombre", "unidad", "grupo_id"};
			string []paramNameU = {"nombre", "unidad", "id"};
			SqlDbType[] paramTypeI = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			SqlDbType[] paramTypeU = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			int[] sizeI = {100, 7000, 4};				
			int[] sizeU = {100, 7000, 4};	
			initializeInsertCommand(ref daVar, Insert, paramNameI, paramTypeI, sizeI);
			initializeUpdateCommand(ref daVar, Update, paramNameU, paramTypeU, sizeU);			
		}

		private static void initializeDatosVariables()
		{
			string Insert, Update;
			Insert = "INSERT INTO DATOS_VARIABLE (fecha, responsable, valor, criterio, descripcion, fuente, var_tecn_id, recurso_id, form_aprov_id, fuente_id, proceso_id, var_car_id) VALUES";
			Insert += "(@fecha, @responsable, @valor, @criterio, @descripcion, @fuente, @var_tecn_id, @recurso_id, @form_aprov_id, @fuente_id, @proceso_id, @var_car_id); SELECT * FROM DATOS_VARIABLE WHERE (id = @@IDENTITY)";
			Update = "UPDATE DATOS_VARIABLE SET fecha = @fecha, responsable = @responsable, valor = @valor, criterio = @criterio, descripcion = @descripcion, fuente = @fuente, var_tecn_id = @var_tecn_id, recurso_id = @recurso_id, form_aprov_id = @form_aprov_id, fuente_id = @fuente_id, proceso_id = @proceso_id, var_car_id = @var_car_id ";
			Update +=" WHERE id = @id";
			string[] paramNameI = {"fecha", "responsable", "valor", "criterio", "descripcion", "fuente", "var_tecn_id", "recurso_id", "form_aprov_id", "fuente_id", "proceso_id", "var_car_id"};
			string []paramNameU = {"fecha", "responsable", "valor", "criterio", "descripcion", "fuente", "var_tecn_id", "recurso_id", "form_aprov_id", "fuente_id", "proceso_id", "var_car_id", "id"};
			SqlDbType[] paramTypeI = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int};
			SqlDbType[] paramTypeU = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int};
			int[] sizeI = {50, 50, 50, 100, 7000, 100, 4, 4, 4, 4, 4, 4};
			int[] sizeU = {50, 50, 50, 100, 7000, 100, 4, 4, 4, 4, 4, 4, 4};
			initializeInsertCommand(ref daDatVar, Insert, paramNameI, paramTypeI, sizeI);
			initializeUpdateCommand(ref daDatVar, Update, paramNameU, paramTypeU, sizeU);
		}

		private static void initializeDirectorio()
		{
			string Update;
			Update = "UPDATE DIRECTORIO SET ruta = @ruta";
			string []paramNameU = {"ruta"};
			SqlDbType[] paramTypeU = {SqlDbType.VarChar};
			int[] sizeU = {500};
			initializeUpdateCommand(ref daDir, Update, paramNameU, paramTypeU, sizeU);
		}

		private static void initializeArchivo()
		{
			string Insert, Update;
			Insert = "INSERT INTO ARCHIVO(fecha, autor, titulo, descripcion, ruta, var_tecn_id, recurso_id, form_aprov_id, fuente_id, proceso_id) VALUES";
			Insert += "(@fecha, @autor, @titulo, @descripcion, @ruta, @var_tecn_id, @recurso_id, @form_aprov_id, @fuente_id, @proceso_id); SELECT * FROM ARCHIVO WHERE (id = @@IDENTITY)";
			Update = "UPDATE ARCHIVO SET fecha = @fecha, autor = @autor, titulo = @titulo, descripcion = @descripcion, ruta = @ruta, var_tecn_id = @var_tecn_id, recurso_id = @recurso_id, form_aprov_id = @form_aprov_id, fuente_id = @fuente_id, proceso_id = @proceso_id";
			Update +=" WHERE id = @id";
			string[] paramNameI = {"fecha", "autor", "titulo", "descripcion", "ruta", "var_tecn_id", "recurso_id", "form_aprov_id", "fuente_id", "proceso_id"};
			string []paramNameU = {"fecha", "autor", "titulo", "descripcion", "ruta", "var_tecn_id", "recurso_id", "form_aprov_id", "fuente_id", "proceso_id", "id"};
			SqlDbType[] paramTypeI = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int};
			SqlDbType[] paramTypeU = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.Int};
			int[] sizeI = {50, 50, 100, 1000, 500, 4, 4, 4, 4, 4};
			int[] sizeU = {50, 50, 100, 1000, 500, 4, 4, 4, 4, 4, 4};
			initializeInsertCommand(ref daArchivo, Insert, paramNameI, paramTypeI, sizeI);
			initializeUpdateCommand(ref daArchivo, Update, paramNameU, paramTypeU, sizeU);

		}

		//para recursos
		private static void initializeRecurso()
		{
			string Insert, Update;
			Insert = "INSERT INTO RECURSO (nombre, descripcion) VALUES";
			Insert += "(@nombre, @descripcion); SELECT * FROM RECURSO WHERE (id = @@IDENTITY)";
			Update = "UPDATE RECURSO SET nombre = @nombre, descripcion = @descripcion";
			Update +=" WHERE id = @id";
			string[] paramNameI = {"nombre", "descripcion"};
			string []paramNameU = {"nombre", "descripcion", "id"};
			SqlDbType[] paramTypeI = {SqlDbType.VarChar, SqlDbType.VarChar};
			SqlDbType[] paramTypeU = {SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int};
			int[] sizeI = {100, 7000, 4};				
			int[] sizeU = {100, 7000, 4};	
			initializeInsertCommand(ref daRecurso, Insert, paramNameI, paramTypeI, sizeI);
			initializeUpdateCommand(ref daRecurso, Update, paramNameU, paramTypeU, sizeU);			
		}
		
	}
}
