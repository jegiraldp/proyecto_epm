using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace EPM.formularios
{
	public class frmConfig : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblServer;
		private System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Label lblBD;
		private System.Windows.Forms.TextBox txtBD;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.ComponentModel.Container components = null;

		public frmConfig()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmConfig));
			this.lblServer = new System.Windows.Forms.Label();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.lblBD = new System.Windows.Forms.Label();
			this.txtBD = new System.Windows.Forms.TextBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblServer
			// 
			this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblServer.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblServer.Location = new System.Drawing.Point(42, 14);
			this.lblServer.Name = "lblServer";
			this.lblServer.Size = new System.Drawing.Size(48, 16);
			this.lblServer.TabIndex = 0;
			this.lblServer.Text = "Server";
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(118, 11);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(112, 20);
			this.txtServer.TabIndex = 1;
			this.txtServer.Text = "";
			// 
			// lblBD
			// 
			this.lblBD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBD.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblBD.Location = new System.Drawing.Point(42, 40);
			this.lblBD.Name = "lblBD";
			this.lblBD.Size = new System.Drawing.Size(24, 16);
			this.lblBD.TabIndex = 4;
			this.lblBD.Text = "BD";
			// 
			// txtBD
			// 
			this.txtBD.Location = new System.Drawing.Point(118, 40);
			this.txtBD.Name = "txtBD";
			this.txtBD.Size = new System.Drawing.Size(112, 20);
			this.txtBD.TabIndex = 5;
			this.txtBD.Text = "";
			// 
			// btnAceptar
			// 
			this.btnAceptar.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnAceptar.Location = new System.Drawing.Point(48, 80);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(56, 24);
			this.btnAceptar.TabIndex = 10;
			this.btnAceptar.Text = "&Aceptar";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnCancelar.Location = new System.Drawing.Point(160, 80);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(64, 24);
			this.btnCancelar.TabIndex = 12;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// frmConfig
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(270, 115);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.txtBD);
			this.Controls.Add(this.lblBD);
			this.Controls.Add(this.txtServer);
			this.Controls.Add(this.lblServer);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmConfig";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configuración de Parámetros";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			if (this.txtServer.Text.Trim().Equals("") ||
				this.txtBD.Text.Trim().Equals("")     				
				)
			{
				MessageBox.Show("Debe ingresar todos los datos.","EPM Renovables",
					             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				//Se guarda los parámetros en el archivo bd.cfg
				string fileName = @"..\otros\bd.cfg";
				if (File.Exists(fileName))
				{
					File.Delete(fileName);					
				}
				StreamWriter wReader = File.CreateText(fileName);
				wReader.WriteLine(this.txtServer.Text);
				wReader.WriteLine(this.txtBD.Text);
				wReader.Close();

				ConexionDB cnn = new ConexionDB();
				try
				{
					cnn.initialize();
					cnn.openConnection();
					this.Hide();
					new frmWelcome().ShowDialog();
				}
				catch(SqlException sqlEx)
				{
					MessageBox.Show("Error: " + sqlEx.Message ,"EPM Renovables",
						            MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message, "EPM Renovables",
						             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
	}
}
