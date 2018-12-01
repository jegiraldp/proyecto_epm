using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace EPM
{
	public class frmWelcome : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Label lblWelcome;
		private System.Windows.Forms.PictureBox picPresent;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblquees;
		private System.ComponentModel.Container components = null;
		
		public frmWelcome()
		{
			InitializeComponent();
			
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmWelcome));
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblWelcome = new System.Windows.Forms.Label();
			this.picPresent = new System.Windows.Forms.PictureBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblquees = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTitle.ForeColor = System.Drawing.Color.Black;
			this.lblTitle.Location = new System.Drawing.Point(168, 20);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(176, 24);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "BASE DE DATOS ";
			// 
			// lblWelcome
			// 
			this.lblWelcome.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblWelcome.Location = new System.Drawing.Point(184, 113);
			this.lblWelcome.Name = "lblWelcome";
			this.lblWelcome.Size = new System.Drawing.Size(184, 16);
			this.lblWelcome.TabIndex = 1;
			this.lblWelcome.Text = "BIENVENIDO AL SISTEMA";
			// 
			// picPresent
			// 
			this.picPresent.Image = ((System.Drawing.Image)(resources.GetObject("picPresent.Image")));
			this.picPresent.Location = new System.Drawing.Point(408, 200);
			this.picPresent.Name = "picPresent";
			this.picPresent.Size = new System.Drawing.Size(120, 48);
			this.picPresent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPresent.TabIndex = 3;
			this.picPresent.TabStop = false;
			// 
			// btnStart
			// 
			this.btnStart.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnStart.Location = new System.Drawing.Point(232, 224);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(80, 24);
			this.btnStart.TabIndex = 4;
			this.btnStart.Text = "&Entrar";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(138, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(236, 24);
			this.label1.TabIndex = 5;
			this.label1.Text = "EEPPM ALTERNATIVAS";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblTitle);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(512, 80);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// lblquees
			// 
			this.lblquees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblquees.ForeColor = System.Drawing.SystemColors.Info;
			this.lblquees.Location = new System.Drawing.Point(168, 152);
			this.lblquees.Name = "lblquees";
			this.lblquees.Size = new System.Drawing.Size(216, 16);
			this.lblquees.TabIndex = 8;
			this.lblquees.Text = "22";
			this.lblquees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmWelcome
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.CadetBlue;
			this.ClientSize = new System.Drawing.Size(544, 256);
			this.Controls.Add(this.lblquees);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.picPresent);
			this.Controls.Add(this.lblWelcome);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmWelcome";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "EPM RENOVABLES";
			this.Load += new System.EventHandler(this.frmWelcome_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		private void btnStart_Click(object sender, System.EventArgs e)
		{
			Form f = new formularios.frmMain(this);
			f.ShowDialog();
		}

		private void frmWelcome_Load(object sender, System.EventArgs e)
		{
            
			getPerfilW();
			if (!(getPerfilW().Equals("a")))
			{
				lblquees.Text = "Su perfil es de : Consulta";
			}

			else 
			{
			this.lblquees.Text = " Su perfil es de : Administración";
			}
					
		}

		private string getPerfilW()
		{
			string result = "";
			SqlConnection connn = ConexionDB.getConnection();
			SqlCommand sqlW = connn.CreateCommand();
			string sqlSelectW = "SELECT perfil FROM usuario WHERE LOWER(login) = '" + clases.User.getUser().ToLower() + "'";
			sqlW.CommandText = sqlSelectW;
			SqlDataReader rdrperfil = sqlW.ExecuteReader();
			while (rdrperfil.Read())
			{
				result = rdrperfil.GetString(0);
				
			}
			rdrperfil.Close();
			return(result.ToLower());
		}
	
	
	}
}
