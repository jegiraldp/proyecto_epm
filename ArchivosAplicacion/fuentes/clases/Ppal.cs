using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace EPM.clases
{
	public class Ppal
	{
		[STAThreadAttribute]
		public static void Main(string []args)
		{		
			ConexionDB cnn = new ConexionDB();
			try
			{
				cnn.initialize();
				cnn.openConnection();
				Util.initializeDataset();
				if (Util.buscar("USUARIO","login", User.getUser(),"" ))
					new frmWelcome().ShowDialog();
				else
					MessageBox.Show("Usted no es un usuario autorizado para el sistema.\nComuniquese con el administrador " ,"EPM Alternativas",
									MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Application.Exit();
			}
			catch(SqlException sqlEx)
			{
				MessageBox.Show("Error: " + sqlEx.Message,"EPM Alternativas",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				new formularios.frmConfig().ShowDialog();
			}
			catch(FileNotFoundException ex)
			{
				if (MessageBox.Show("Error: " + ex.Message + ".\nDesea configurar este archivo? ","EPM Alternativas",
					MessageBoxButtons.YesNo , MessageBoxIcon.Exclamation)==DialogResult.Yes)
				{
					new formularios.frmConfig().ShowDialog();					
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message,"EPM Alternativas",	MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
