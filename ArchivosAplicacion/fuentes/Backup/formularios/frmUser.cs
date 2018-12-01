using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace EPM.formularios
{
	using EPM.clases;

	public class frmUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.Label lblLogin;
		private System.Windows.Forms.GroupBox groupPerfil;
		private System.Windows.Forms.RadioButton rButCon;
		private System.Windows.Forms.RadioButton rButAdm;
		private System.Windows.Forms.Button btnGuardar;

		private System.ComponentModel.Container components = null;

		public frmUser()
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
		
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUser));
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.lblLogin = new System.Windows.Forms.Label();
			this.groupPerfil = new System.Windows.Forms.GroupBox();
			this.rButAdm = new System.Windows.Forms.RadioButton();
			this.rButCon = new System.Windows.Forms.RadioButton();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.groupPerfil.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtLogin
			// 
			this.txtLogin.Location = new System.Drawing.Point(26, 44);
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(224, 20);
			this.txtLogin.TabIndex = 0;
			this.txtLogin.Text = "";
			// 
			// lblLogin
			// 
			this.lblLogin.Location = new System.Drawing.Point(26, 25);
			this.lblLogin.Name = "lblLogin";
			this.lblLogin.Size = new System.Drawing.Size(96, 16);
			this.lblLogin.TabIndex = 1;
			this.lblLogin.Text = "Usuario Windows";
			// 
			// groupPerfil
			// 
			this.groupPerfil.Controls.Add(this.rButAdm);
			this.groupPerfil.Controls.Add(this.rButCon);
			this.groupPerfil.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupPerfil.Location = new System.Drawing.Point(26, 94);
			this.groupPerfil.Name = "groupPerfil";
			this.groupPerfil.Size = new System.Drawing.Size(224, 56);
			this.groupPerfil.TabIndex = 5;
			this.groupPerfil.TabStop = false;
			this.groupPerfil.Text = "Perfil";
			// 
			// rButAdm
			// 
			this.rButAdm.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rButAdm.Location = new System.Drawing.Point(16, 24);
			this.rButAdm.Name = "rButAdm";
			this.rButAdm.Size = new System.Drawing.Size(112, 16);
			this.rButAdm.TabIndex = 5;
			this.rButAdm.Text = "Administrador";
			// 
			// rButCon
			// 
			this.rButCon.Checked = true;
			this.rButCon.ForeColor = System.Drawing.SystemColors.ControlText;
			this.rButCon.Location = new System.Drawing.Point(144, 24);
			this.rButCon.Name = "rButCon";
			this.rButCon.Size = new System.Drawing.Size(72, 16);
			this.rButCon.TabIndex = 6;
			this.rButCon.TabStop = true;
			this.rButCon.Text = "Consulta";
			// 
			// btnGuardar
			// 
			this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
			this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGuardar.Location = new System.Drawing.Point(100, 160);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(72, 32);
			this.btnGuardar.TabIndex = 6;
			this.btnGuardar.Text = "&Guardar";
			this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// frmUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(272, 205);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.groupPerfil);
			this.Controls.Add(this.lblLogin);
			this.Controls.Add(this.txtLogin);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Usuarios del Sistema";
			this.groupPerfil.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnGuardar_Click(object sender, System.EventArgs e)
		{
			string usuario = "";
			string perfil = "";
			txtLogin.Text = txtLogin.Text.Trim();
			if (txtLogin.Text.Equals("")) 
			{
				MessageBox.Show("Debe ingresar un login de usuario.", "Atención",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);			
			}
			else
			{
				usuario = txtLogin.Text.ToLower().ToString();
				perfil = "";
				if(this.rButAdm.Checked) 
					perfil = "a";
				else
					perfil = "c";
				
				
				try
				{
					SqlConnection conn = ConexionDB.getConnection();
					SqlCommand sql = conn.CreateCommand();
					string sqlInsert = "INSERT INTO USUARIO VALUES('" + usuario + "', '" + perfil + "')";
					sql.CommandText = sqlInsert;
					sql.ExecuteNonQuery();	
					MessageBox.Show("Se ha ingresado el usuario al sistema ", "Usuarios", 
									 MessageBoxButtons.OK, MessageBoxIcon.Information);	
					Util.initializeDataset(); //actualiza dataset
					this.Close();

				}
				catch(Exception)
				{
					MessageBox.Show("El usuario ya se encuentra registrado\nComuniquese con el administrador del sistema","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
				}		
			}
		}
	}
}
