using System;
using System.Drawing;
using System.Collections;
using System.Diagnostics;	
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace EPM.formularios
{   
	using EPM.clases;
	using EPM.formularios;
	public class frmArchivo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnCrear;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.TextBox txtUnidad;
		private System.Windows.Forms.Label lblFecha;
		private System.Windows.Forms.DateTimePicker dtFecha;
		private System.Windows.Forms.TextBox txtAutor;
		private System.Windows.Forms.Label lblAutor;
		private System.Windows.Forms.Label lblTitulo;
		private System.Windows.Forms.TextBox txtTitulo;
		private System.Windows.Forms.Label lblRuta;
		private System.Windows.Forms.TextBox txtRuta;
		private System.Windows.Forms.Button btnRuta;
		private System.Windows.Forms.OpenFileDialog ofdArchivo;
		private bool insert;
		private int pk, fk;
		private string strHeader;
		private string directorio,file;
		private string dir = "";
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnOpenFile; //Directorio de Documentos;
		private System.ComponentModel.Container components = null;

		//cuando va a ingresar nuevo archivo
		public frmArchivo(int fk, string h)
		{
			InitializeComponent();
           	this.fk = fk;
			this.strHeader = h;
			insert = true;
		}
		
		//cuando va a editar
		public frmArchivo(int pos, string directorio, string file)
		{
			DataSet ds = null;
			InitializeComponent();
			ds = Util.getDataSet();
			DataRow dr = ds.Tables["Archivo"].Rows[pos];
			pk = int.Parse(dr[0].ToString());
			dtFecha.Value = DateTime.Parse(dr[1].ToString());
			txtAutor.Text = dr[2].ToString();
			txtTitulo.Text = dr[3].ToString();
			txtDescripcion.Text = dr[4].ToString();
			txtRuta.Text = dr[5].ToString();		
			insert = false;
			this.dtFecha.Enabled= false;
			this.btnOpenFile.Visible = true;
			this.directorio = directorio;
			this.file = file;
			
			
			
		}

		//cuando va a visualizar
		public frmArchivo(int pos, bool txt, string directorio, string file)
		{
			txt = true;
			DataSet ds = null;
			InitializeComponent();
			ds = Util.getDataSet();
			DataRow dr = ds.Tables["Archivo"].Rows[pos];
			pk = int.Parse(dr[0].ToString());
			dtFecha.Value = DateTime.Parse(dr[1].ToString());
			txtAutor.Text = dr[2].ToString();
			txtTitulo.Text = dr[3].ToString();
			txtDescripcion.Text = dr[4].ToString();
			txtRuta.Text = dr[5].ToString();		
			this.dtFecha.Enabled= txt;
			this.txtTitulo.ReadOnly = txt;
			this.txtAutor.ReadOnly = txt;
			this.txtDescripcion.ReadOnly = txt;
			this.txtRuta.ReadOnly = txt;
			this.btnRuta.Enabled = false;
			this.btnCrear.Enabled = false;
			this.button1.Enabled = false;
			this.dtFecha.Enabled = false;
			this.btnOpenFile.Visible = true;
			this.directorio = directorio;
			this.file = file;
		}


		public frmArchivo()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmArchivo));
			this.txtAutor = new System.Windows.Forms.TextBox();
			this.lblAutor = new System.Windows.Forms.Label();
			this.lblTitulo = new System.Windows.Forms.Label();
			this.txtTitulo = new System.Windows.Forms.TextBox();
			this.lblRuta = new System.Windows.Forms.Label();
			this.txtRuta = new System.Windows.Forms.TextBox();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnCrear = new System.Windows.Forms.Button();
			this.txtUnidad = new System.Windows.Forms.TextBox();
			this.lblFecha = new System.Windows.Forms.Label();
			this.dtFecha = new System.Windows.Forms.DateTimePicker();
			this.btnRuta = new System.Windows.Forms.Button();
			this.ofdArchivo = new System.Windows.Forms.OpenFileDialog();
			this.button1 = new System.Windows.Forms.Button();
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtAutor
			// 
			this.txtAutor.Location = new System.Drawing.Point(96, 64);
			this.txtAutor.Multiline = true;
			this.txtAutor.Name = "txtAutor";
			this.txtAutor.Size = new System.Drawing.Size(400, 48);
			this.txtAutor.TabIndex = 3;
			this.txtAutor.Text = "";
			// 
			// lblAutor
			// 
			this.lblAutor.Location = new System.Drawing.Point(24, 80);
			this.lblAutor.Name = "lblAutor";
			this.lblAutor.Size = new System.Drawing.Size(40, 16);
			this.lblAutor.TabIndex = 2;
			this.lblAutor.Text = "Autor";
			this.lblAutor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblTitulo
			// 
			this.lblTitulo.Location = new System.Drawing.Point(24, 144);
			this.lblTitulo.Name = "lblTitulo";
			this.lblTitulo.Size = new System.Drawing.Size(32, 16);
			this.lblTitulo.TabIndex = 4;
			this.lblTitulo.Text = "Título";
			// 
			// txtTitulo
			// 
			this.txtTitulo.Location = new System.Drawing.Point(96, 128);
			this.txtTitulo.Multiline = true;
			this.txtTitulo.Name = "txtTitulo";
			this.txtTitulo.Size = new System.Drawing.Size(400, 48);
			this.txtTitulo.TabIndex = 5;
			this.txtTitulo.Text = "";
			// 
			// lblRuta
			// 
			this.lblRuta.Location = new System.Drawing.Point(16, 304);
			this.lblRuta.Name = "lblRuta";
			this.lblRuta.Size = new System.Drawing.Size(72, 16);
			this.lblRuta.TabIndex = 8;
			this.lblRuta.Text = "Ruta Archivo";
			// 
			// txtRuta
			// 
			this.txtRuta.Location = new System.Drawing.Point(96, 304);
			this.txtRuta.Name = "txtRuta";
			this.txtRuta.Size = new System.Drawing.Size(400, 20);
			this.txtRuta.TabIndex = 9;
			this.txtRuta.Text = "";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.Location = new System.Drawing.Point(16, 240);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(64, 16);
			this.lblDescripcion.TabIndex = 6;
			this.lblDescripcion.Text = "Descripción";
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(96, 208);
			this.txtDescripcion.Multiline = true;
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescripcion.Size = new System.Drawing.Size(400, 72);
			this.txtDescripcion.TabIndex = 7;
			this.txtDescripcion.Text = "";
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(368, 376);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(76, 32);
			this.btnCancelar.TabIndex = 12;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnCrear
			// 
			this.btnCrear.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
			this.btnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCrear.Location = new System.Drawing.Point(248, 376);
			this.btnCrear.Name = "btnCrear";
			this.btnCrear.Size = new System.Drawing.Size(76, 32);
			this.btnCrear.TabIndex = 11;
			this.btnCrear.Text = "&Guardar";
			this.btnCrear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
			// 
			// txtUnidad
			// 
			this.txtUnidad.Location = new System.Drawing.Point(88, 500);
			this.txtUnidad.Name = "txtUnidad";
			this.txtUnidad.Size = new System.Drawing.Size(120, 20);
			this.txtUnidad.TabIndex = 22;
			this.txtUnidad.Text = "";
			// 
			// lblFecha
			// 
			this.lblFecha.Location = new System.Drawing.Point(24, 32);
			this.lblFecha.Name = "lblFecha";
			this.lblFecha.Size = new System.Drawing.Size(40, 16);
			this.lblFecha.TabIndex = 0;
			this.lblFecha.Text = "Fecha";
			// 
			// dtFecha
			// 
			this.dtFecha.Cursor = System.Windows.Forms.Cursors.Hand;
			this.dtFecha.CustomFormat = "yyyy/MM/dd";
			this.dtFecha.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFecha.Location = new System.Drawing.Point(96, 32);
			this.dtFecha.Name = "dtFecha";
			this.dtFecha.Size = new System.Drawing.Size(152, 20);
			this.dtFecha.TabIndex = 1;
			this.dtFecha.Value = new System.DateTime(2006, 1, 26, 0, 0, 0, 0);
			// 
			// btnRuta
			// 
			this.btnRuta.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnRuta.Location = new System.Drawing.Point(512, 304);
			this.btnRuta.Name = "btnRuta";
			this.btnRuta.Size = new System.Drawing.Size(25, 20);
			this.btnRuta.TabIndex = 10;
			this.btnRuta.Text = "...";
			this.btnRuta.Click += new System.EventHandler(this.btnRuta_Click);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(128, 376);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(76, 32);
			this.button1.TabIndex = 23;
			this.button1.Text = "&Aceptar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.Location = new System.Drawing.Point(240, 336);
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.Size = new System.Drawing.Size(88, 24);
			this.btnOpenFile.TabIndex = 24;
			this.btnOpenFile.Text = "Abrir Archivo";
			this.btnOpenFile.Visible = false;
			this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
			// 
			// frmArchivo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(554, 431);
			this.Controls.Add(this.btnOpenFile);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btnRuta);
			this.Controls.Add(this.txtUnidad);
			this.Controls.Add(this.txtDescripcion);
			this.Controls.Add(this.txtRuta);
			this.Controls.Add(this.txtTitulo);
			this.Controls.Add(this.txtAutor);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnCrear);
			this.Controls.Add(this.lblDescripcion);
			this.Controls.Add(this.lblRuta);
			this.Controls.Add(this.lblTitulo);
			this.Controls.Add(this.lblAutor);
			this.Controls.Add(this.lblFecha);
			this.Controls.Add(this.dtFecha);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmArchivo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Archivo";
			this.Load += new System.EventHandler(this.frmArchivo_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCrear_Click(object sender, System.EventArgs e)
		{
			this.txtAutor.Text = this.txtAutor.Text.Trim();
			this.txtTitulo.Text = this.txtTitulo.Text.Trim();
			this.txtDescripcion.Text = this.txtDescripcion.Text.Trim();
			this.txtRuta.Text = this.txtRuta.Text.Trim();
			if ((this.txtAutor.Text.Equals(""))  ||
				(this.txtTitulo.Text.Equals("")) ||
				(this.txtRuta.Text.Equals(""))   ||
				(this.txtDescripcion.Text.Equals("")))
			{
				MessageBox.Show("Los Campos: Autor, Título, Criterio, Ruta y Descripción son Obligatorios.", "Atención",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (!(File.Exists(dir + this.txtRuta.Text)))
				{
					MessageBox.Show("No existe el archivo: " + txtRuta.Text +"\nEn la ruta del directorio configurada. \n" + dir +"\nVerifique dicha ruta en: Herramientas -> Configuración del Sistema"  , "Atención",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					if (this.insert)
					{
						string []colunmName = {"fecha", "autor", "titulo", "descripcion", "ruta", strHeader};
						Util.Insert(Util.getDAArchivo(),"Archivo", colunmName, dtFecha.Value.ToShortDateString(), txtAutor.Text, txtTitulo.Text, txtDescripcion.Text, txtRuta.Text, fk.ToString());
						MessageBox.Show("Se ha anexado el archivo exitosamente.", "Archivo", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else //Edición
					{
						
						string []colunmName = {"fecha", "autor", "titulo", "descripcion", "ruta"};
						Util.Update(Util.getDAArchivo(), "Archivo", pk, colunmName, dtFecha.Value.ToShortDateString(), txtAutor.Text, txtTitulo.Text, txtDescripcion.Text, txtRuta.Text);
						MessageBox.Show("Se han guardado los cambios realizados en el Archivo exitosamente.", "Archivo", 
						MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
						
					}					
					this.txtAutor.Clear();
					this.txtDescripcion.Clear();
					this.txtRuta.Clear();
					this.txtTitulo.Clear();
					this.txtUnidad.Clear();
					this.txtAutor.Select();
					}	
			}

			
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void frmArchivo_Load(object sender, System.EventArgs e)
		{
			
			this.dtFecha.Format = DateTimePickerFormat.Custom;
			this.dtFecha.CustomFormat = "yyyy'/'MM'/'dd";
			dir = Util.getDirectorio();
		}

		
		
		
		private void btnRuta_Click(object sender, System.EventArgs e)
		{
			string fileName="";
			ofdArchivo.InitialDirectory = Util.getDirectorio();
			ofdArchivo.Filter = "Todos los archivos (*.*)|*.*";
			if(ofdArchivo.ShowDialog() == DialogResult.OK)
			{
				if((fileName = ofdArchivo.FileName)!= null)
				{
					fileName = fileName.Substring(dir.Length);
					this.txtRuta.Text= fileName;
				}
			}

		}

		// boton aceptar
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.txtAutor.Text = this.txtAutor.Text.Trim();
			this.txtTitulo.Text = this.txtTitulo.Text.Trim();
			this.txtDescripcion.Text = this.txtDescripcion.Text.Trim();
			this.txtRuta.Text = this.txtRuta.Text.Trim();
			if ((this.txtAutor.Text.Equals(""))  ||
				(this.txtTitulo.Text.Equals("")) ||
				(this.txtRuta.Text.Equals(""))   ||
				(this.txtDescripcion.Text.Equals("")))
			{
				MessageBox.Show("Los Campos: Autor, Título, Criterio, Ruta y Descripción son Obligatorios.", "Atención",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (!(File.Exists(dir + this.txtRuta.Text)))
				{
					MessageBox.Show("No existe el archivo: " + txtRuta.Text +"\nEn la ruta del directorio configurada. \n" + dir +"\nVerifique dicha ruta en: Herramientas -> Configuración del Sistema"  , "Atención",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					if (this.insert)
					{
						string []colunmName = { "fecha", "autor", "titulo", "descripcion", "ruta", strHeader};
						Util.Insert(Util.getDAArchivo(),"Archivo", colunmName, dtFecha.Value.ToShortDateString(), txtAutor.Text, txtTitulo.Text, txtDescripcion.Text, txtRuta.Text, fk.ToString());
						MessageBox.Show("Se ha anexado el archivo exitosamente.", "Archivo", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else //Edición
					{
						string []colunmName = {"fecha", "autor", "titulo", "descripcion", "ruta"};
						Util.Update(Util.getDAArchivo(), "Archivo", pk, colunmName, dtFecha.Value.ToShortDateString(), txtAutor.Text, txtTitulo.Text, txtDescripcion.Text, txtRuta.Text);
						MessageBox.Show("Se han guardado los cambios realizados en el Archivo exitosamente.", "Archivo", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.Close();
						
					}					
					this.Close();
				}	
			}
		}

		private void btnOpenFile_Click(object sender, System.EventArgs e)
		{
			try
			{
				Process.Start(directorio + file);
			}
			catch
			{
				MessageBox.Show("Error: No se encuentra el archivo en la ruta especificada  " + Util.getDirectorio() + 
					"\nPara configurar esta opción dirijase a Herramientas-Configuación de Sistema.","EPM Alternativas",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			
		}

		
	}
}
