using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace EPM.formularios
{
    using EPM.clases;
	public class frmDir : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblRepositorio;
		private System.Windows.Forms.TextBox txtDir;
		private System.Windows.Forms.Button btnGuardar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnRuta;
		//private string rt = "";
		//private System.Windows.Forms.OpenFileDialog capRuta;
		private System.Windows.Forms.FolderBrowserDialog folderBD;
		private System.ComponentModel.Container components = null;
		
		
		public frmDir()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDir));
			this.lblRepositorio = new System.Windows.Forms.Label();
			this.txtDir = new System.Windows.Forms.TextBox();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnRuta = new System.Windows.Forms.Button();
			this.folderBD = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// lblRepositorio
			// 
			this.lblRepositorio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRepositorio.Location = new System.Drawing.Point(16, 24);
			this.lblRepositorio.Name = "lblRepositorio";
			this.lblRepositorio.Size = new System.Drawing.Size(336, 16);
			this.lblRepositorio.TabIndex = 0;
			this.lblRepositorio.Text = "Escoja la ruta del directorio de Archivos";
			// 
			// txtDir
			// 
			this.txtDir.Location = new System.Drawing.Point(16, 56);
			this.txtDir.Name = "txtDir";
			this.txtDir.Size = new System.Drawing.Size(280, 20);
			this.txtDir.TabIndex = 1;
			this.txtDir.Text = "";
			// 
			// btnGuardar
			// 
			this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
			this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnGuardar.Location = new System.Drawing.Point(32, 96);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.TabIndex = 2;
			this.btnGuardar.Text = "&Guardar";
			this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(176, 96);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnRuta
			// 
			this.btnRuta.Location = new System.Drawing.Point(313, 56);
			this.btnRuta.Name = "btnRuta";
			this.btnRuta.Size = new System.Drawing.Size(24, 20);
			this.btnRuta.TabIndex = 4;
			this.btnRuta.Text = "...";
			this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
			// 
			// frmDir
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(346, 135);
			this.Controls.Add(this.btnRuta);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.txtDir);
			this.Controls.Add(this.lblRepositorio);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDir";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Configurar Ruta del Directorio";
			this.Load += new System.EventHandler(this.frmDir_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
					
		}

		private void btnGuardar_Click(object sender, System.EventArgs e)
		{
			txtDir.Text = txtDir.Text.Trim();
			string path = txtDir.Text;
			if(Directory.Exists(txtDir.Text))
			{
				if (!(path.Substring(path.Length - 1, 1).Equals("\\")))
					txtDir.Text += "\\";
				string []headers = new string[1];
				headers[0] = "ruta";
				Util.Update(Util.getDADirectorio(), "Directorio", 1, headers, txtDir.Text);
				MessageBox.Show("Se ha guardado la ruta del directorio exitosamente.", "Directorio Válido", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
			else
			{
				MessageBox.Show("La ruta del directorio no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void frmDir_Load(object sender, System.EventArgs e)
		{
			txtDir.Text = Util.getDirectorio();
		}

		private void btnRuta_Click(object sender, System.EventArgs e)
		{
			folderBD.RootFolder = Environment.SpecialFolder.MyComputer;		
			this.folderBD.Description= "Seleccionar directorio de archivos";
			folderBD.ShowNewFolderButton = true;
			this.folderBD.SelectedPath = this.txtDir.Text;
			if(this.folderBD.ShowDialog() == DialogResult.OK)
			{
			this.txtDir.Text = this.folderBD.SelectedPath;
			}
			
		}

		
	}
}
