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
	public class frmUsuarioEdit : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmbUsuario;
		private System.Windows.Forms.Label lblUsuario;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblLogin;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox txtLogin;
		private System.Windows.Forms.ComboBox cmbPerfil;

		
	
		string perfil;
		private System.Windows.Forms.TextBox txtidU;
		private DataSet ds = null;

		public frmUsuarioEdit()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmUsuarioEdit));
			this.cmbUsuario = new System.Windows.Forms.ComboBox();
			this.lblUsuario = new System.Windows.Forms.Label();
			this.lblLogin = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.cmbPerfil = new System.Windows.Forms.ComboBox();
			this.txtidU = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cmbUsuario
			// 
			this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbUsuario.Location = new System.Drawing.Point(40, 42);
			this.cmbUsuario.Name = "cmbUsuario";
			this.cmbUsuario.Size = new System.Drawing.Size(256, 21);
			this.cmbUsuario.TabIndex = 0;
			this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);
			// 
			// lblUsuario
			// 
			this.lblUsuario.Location = new System.Drawing.Point(40, 18);
			this.lblUsuario.Name = "lblUsuario";
			this.lblUsuario.Size = new System.Drawing.Size(208, 24);
			this.lblUsuario.TabIndex = 1;
			this.lblUsuario.Text = "Elegir usuario a editar";
			// 
			// lblLogin
			// 
			this.lblLogin.Location = new System.Drawing.Point(40, 77);
			this.lblLogin.Name = "lblLogin";
			this.lblLogin.Size = new System.Drawing.Size(96, 16);
			this.lblLogin.TabIndex = 2;
			this.lblLogin.Text = "Login";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(40, 128);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(152, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Elegir nuevo perfil de usuario";
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(64, 202);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 24);
			this.button1.TabIndex = 7;
			this.button1.Text = "&Agregar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(184, 202);
			this.button2.Name = "button2";
			this.button2.TabIndex = 8;
			this.button2.Text = "&Cancelar";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtLogin
			// 
			this.txtLogin.Location = new System.Drawing.Point(40, 96);
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(256, 20);
			this.txtLogin.TabIndex = 9;
			this.txtLogin.Text = "";
			// 
			// cmbPerfil
			// 
			this.cmbPerfil.Items.AddRange(new object[] {
														   "Administrador",
														   "Consulta"});
			this.cmbPerfil.Location = new System.Drawing.Point(40, 152);
			this.cmbPerfil.Name = "cmbPerfil";
			this.cmbPerfil.Size = new System.Drawing.Size(256, 21);
			this.cmbPerfil.TabIndex = 10;
			// 
			// txtidU
			// 
			this.txtidU.Location = new System.Drawing.Point(600, 184);
			this.txtidU.Name = "txtidU";
			this.txtidU.Size = new System.Drawing.Size(48, 20);
			this.txtidU.TabIndex = 11;
			this.txtidU.Text = "";
			// 
			// frmUsuarioEdit
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 237);
			this.Controls.Add(this.txtidU);
			this.Controls.Add(this.cmbPerfil);
			this.Controls.Add(this.txtLogin);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.lblUsuario);
			this.Controls.Add(this.cmbUsuario);
			this.Controls.Add(this.lblLogin);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmUsuarioEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Editar Usuario";
			this.Load += new System.EventHandler(this.frmUsuarioEdit_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmUsuarioEdit_Load(object sender, System.EventArgs e)
		{
			
			listU();
			cmbPerfil.SelectedIndex =0;
			
		}

		

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void cmbUsuario_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			txtLogin.Text = "";
			txtLogin.DataBindings.Clear();
			if(cmbUsuario.SelectedIndex < 0)return;
			try
			{
				DataView dv = (DataView)this.cmbUsuario.DataSource;
				dv.RowFilter = "id = " + this.cmbUsuario.ValueMember;
				txtLogin.Text = this.cmbUsuario.Text;
				DataView dv2 = (DataView)this.cmbUsuario.DataSource;
				dv.RowFilter = "id = " + this.cmbUsuario.ValueMember;
				txtidU.DataBindings.Add("Text", dv2, "id");	
			}
			catch{}
			
		}

		//listar usuarios en comobo usuarios..cmbUsuario
		public void listU()
		{
			try
			{
				ds = Util.getDataSet();
				DataView dv = ds.Tables["Usuario"].DefaultView;
				this.cmbUsuario.DisplayMember = "login";
				this.cmbUsuario.ValueMember = "id";
				this.cmbUsuario.DataSource = dv;
							
			}
			catch
			{
				this.cmbUsuario.DataSource = null;
				this.cmbUsuario.Items.Clear();
			}
		
		}

		// boton editar -- guardar
		private void button1_Click(object sender, System.EventArgs e)
		{
			
			string usuario = txtLogin.Text.ToLower();
						
			if (this.cmbPerfil.SelectedIndex == 0)
			{
				this.cmbPerfil.ValueMember = "a";
				this.perfil = "a"; 
			}
			else
			{ 
				this.cmbPerfil.ValueMember = "c";
				this.perfil = "c"; 
			}
			
			try
			{
					SqlConnection conn = ConexionDB.getConnection();
					SqlCommand sqlcmd = conn.CreateCommand();
					string sqlActualizar = "UPDATE usuario SET login = '"+ usuario +"', perfil = '"+ perfil +"' where id = " + this.txtidU.Text + "";  
					sqlcmd.CommandText = sqlActualizar;
					sqlcmd.ExecuteNonQuery();	
					Util.initializeDataset();
					MessageBox.Show("Se ha actualizado el usuario en el sistema ", "Usuarios", 
					MessageBoxButtons.OK, MessageBoxIcon.Information);	
					this.Close();
			}
			catch(Exception ex)
			{
				MessageBox.Show("El usuario ya se encuentra registrado\nComuniquese con el administrador del sistema"+ex.ToString(),"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
				
			}		
			
		
		}



	

		
		
		
	}
}
