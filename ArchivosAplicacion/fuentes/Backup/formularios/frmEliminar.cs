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
	public class frmEliminar : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblEliminar;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.ComboBox cmbDel;
		private DataSet ds = null;
		private int hola;
		private SqlConnection cnx;
		public string deltbl;
		public string table;
		public string forey;
		private System.Windows.Forms.TextBox txtGetID; 
	
		private System.ComponentModel.Container components = null;

		
		//sobrecarga para la generaación de ventana dinámica
		public frmEliminar(string title, string tbl)
		{
			cnx = ConexionDB.getConnection();
			this.table = tbl;
			InitializeComponent();
			this.Text = "Eliminar " + title;
			lblEliminar.Text = "Elegir " + title + " a eliminar"; 
			list(tbl);									
		}


		//para filtrar y elegir los hijos asociados

		public frmEliminar(string title, string tbl, string foraneadel, int hi)
		{
			
			cnx = ConexionDB.getConnection();
			this.table = tbl;
			this.forey = foraneadel;
			this.hola = hi;
			InitializeComponent();
			this.Text = "Eliminar " + title;
			lblEliminar.Text = "Elegir " + title + " a eliminar"; 
			list2(tbl, foraneadel, hi);									
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEliminar));
			this.cmbDel = new System.Windows.Forms.ComboBox();
			this.lblEliminar = new System.Windows.Forms.Label();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.txtGetID = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// cmbDel
			// 
			this.cmbDel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDel.Items.AddRange(new object[] {
														""});
			this.cmbDel.Location = new System.Drawing.Point(21, 56);
			this.cmbDel.Name = "cmbDel";
			this.cmbDel.Size = new System.Drawing.Size(264, 21);
			this.cmbDel.TabIndex = 0;
			this.cmbDel.SelectedIndexChanged += new System.EventHandler(this.cmbDel_SelectedIndexChanged);
			// 
			// lblEliminar
			// 
			this.lblEliminar.Location = new System.Drawing.Point(33, 24);
			this.lblEliminar.Name = "lblEliminar";
			this.lblEliminar.Size = new System.Drawing.Size(264, 16);
			this.lblEliminar.TabIndex = 1;
			this.lblEliminar.Text = "Elegir";
			// 
			// btnAceptar
			// 
			this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(60, 104);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(72, 24);
			this.btnAceptar.TabIndex = 2;
			this.btnAceptar.Text = "&Eliminar";
			this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(172, 104);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.TabIndex = 3;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// txtGetID
			// 
			this.txtGetID.Location = new System.Drawing.Point(600, 96);
			this.txtGetID.Name = "txtGetID";
			this.txtGetID.Size = new System.Drawing.Size(40, 20);
			this.txtGetID.TabIndex = 4;
			this.txtGetID.Text = "";
			// 
			// frmEliminar
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(306, 135);
			this.Controls.Add(this.txtGetID);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.lblEliminar);
			this.Controls.Add(this.cmbDel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmEliminar";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Eliminar";
			this.ResumeLayout(false);

		}
		#endregion

	
		//método para listar los items
		public void list(string tbl)
		{
			try
			{
				ds = Util.getDataSet();
				DataView dv = ds.Tables[tbl].DefaultView;
				this.cmbDel.DisplayMember = "nombre";
				this.cmbDel.ValueMember = "id";
				this.cmbDel.DataSource = dv;
							
			}
			catch
			{
				this.cmbDel.DataSource = null;
				this.cmbDel.Items.Clear();
			}
		
		}


		
		//método para listar los segun filtro
		public void list2(string tbl, string foraneano, int del)
		{
			try
			{
				ds = Util.getDataSet();
				DataView dv = ds.Tables[tbl].DefaultView;
				dv.RowFilter = foraneano + " = " + del; 
				this.cmbDel.DisplayMember = "nombre";
				this.cmbDel.ValueMember = "id";
				this.cmbDel.DataSource = dv;
				  
							
			}
			catch
			{
				this.cmbDel.DataSource = null;
				this.cmbDel.Items.Clear();
			}
		
		}




		private void actualizar()
		{
			Util.initializeDataset();
			ds = Util.getDataSet();
			ds.AcceptChanges();
			
		}


		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//BOTON ELIMINAR.
		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			
			
			if(this.cmbDel.Items.Count==0)return;
			
			DialogResult resultado = new DialogResult();
			resultado = MessageBox.Show ("Realmente desea Eliminar " +this.cmbDel.Text+ " del sistema?", "Confirmar Eliminar", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
			if (resultado == DialogResult.Yes)
			{
				if (this.Text=="Eliminar Fuente")
				{
					deltbl = "FUENTE";
					sihayhijo("fuente_id", "proceso", deltbl);
				}
				
				if (this.Text=="Eliminar Proceso")
				{
					
					deltbl = "PROCESO";
					sihayhijo("proceso_id", "forma_aprovechamiento", deltbl);
				}
				
				if (this.Text== "Eliminar Forma de Aprovechamiento")
				{
					deltbl = "FORMA_APROVECHAMIENTO";
					sihayhijo("form_aprov_id", "variante_tecnologica", deltbl);
				}
				
				if (this.Text== "Eliminar Variante Tecnológica")
				{
					deltbl = "VARIANTE_TECNOLOGICA";
					eliminar(deltbl);
				}
				
				if (this.Text== "Eliminar Recurso")
				{
					deltbl = "RECURSO";
					eliminar(deltbl);
				}
				
				if (this.Text== "Eliminar Grupo")
				{
					deltbl = "GRUPO";
					sihayhijo("grupo_id", "variable_caracteristica", deltbl);
				}
				
				if (this.Text== "Eliminar Variable Característica")
				{
					deltbl = "VARIABLE_CARACTERISTICA";
					eliminar(deltbl);
				}

				this.Close();
				
			}
			else return;
			
		}

		
		//eliminar la tabla seleccionada
		public void eliminar (string tblborrar)
		{
			SqlConnection conn = ConexionDB.getConnection();
			SqlCommand sqlcmddel = conn.CreateCommand();
			string sqlDel = "DELETE " +tblborrar +" WHERE id ="+ this.txtGetID.Text;  
			sqlcmddel.CommandText = sqlDel;
			sqlcmddel.ExecuteNonQuery();	
			MessageBox.Show("Se ha eliminado " +this.cmbDel.Text+ "  del sistema ", "Usuarios", 
			MessageBoxButtons.OK, MessageBoxIcon.Information);	
			Util.initializeDataset();
			
		}
		
				
		private void cmbDel_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			txtGetID.Text = this.cmbDel.SelectedValue.ToString();
				
		}

		public void sihayhijo(string foranea, string hijo, string tbl)
		{
		
			string nombreF = "";
			nombreF = this.cmbDel.Text;
			string sihay = "Select " + foranea + " from " + hijo + " where " + foranea + " = " + this.txtGetID.Text;
			object resultadoForey = 0;
			SqlCommand sqllookH = cnx.CreateCommand();
			sqllookH.CommandText = sihay;
			sqllookH.ExecuteNonQuery();
			SqlDataReader rdr = sqllookH.ExecuteReader();
	
			while (rdr.Read())
			{
				resultadoForey = rdr.GetValue(0);

			}
			rdr.Close();
			hola = Convert.ToInt32(resultadoForey);

			if (hola > 0)
			{
			
				DialogResult resultado = new DialogResult();
				resultado = MessageBox.Show ("Existe un " + hijo + " que depende de " + nombreF + "\nDesea eliminarlo","ATENCIÓN",
					MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
				if (resultado == DialogResult.Yes)
				{
					
					switch (hijo)
					{
						case "proceso":
							
							frmEliminar bye = new frmEliminar("Proceso", "Proceso", foranea, hola);
							bye.ShowDialog();
							break;
					
						case "forma_aprovechamiento":
							frmEliminar bye2 = new frmEliminar("Forma de Aprovechamiento", "Forma Aprovech",foranea, hola);
							bye2.ShowDialog();
							break;			
		
						case "variante_tecnologica":
							frmEliminar bye3 = new frmEliminar("Variante Tecnológica", "Variante Tecn",foranea, hola);
							bye3.ShowDialog();
							break;		
					}
				
				}

				else
				{
					MessageBox.Show("Se ha cancelado el proceso de eliminación", "EEPPM Alternativas",MessageBoxButtons.OK, MessageBoxIcon.Information);
				}

			}

			else 
			{
				switch (tbl)
				{
					case "FUENTE":
						eliminar(deltbl);
						break;

					case "PROCESO":
						eliminar(deltbl);
						break;
						
					case "FORMA_APROVECHAMIENTO":
						eliminar(deltbl);
						break;
				}
			
			}
		}


	}
}
