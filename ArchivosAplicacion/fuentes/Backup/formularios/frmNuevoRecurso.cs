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


	public class frmNuevoRecurso : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button button2;
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.ComboBox cmbRecurso;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbTablaPadre;
		private System.Windows.Forms.ComboBox cmb;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioNo;
		private System.Windows.Forms.RadioButton radioSi;
		private System.Windows.Forms.Label lblRecurso;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.Label lbl;
		private System.Windows.Forms.TextBox txtIDcmb;
		private System.Windows.Forms.TextBox txtIDcmbRecurso;
		private System.Windows.Forms.Button button3;
		private DataSet ds = null;
			
		public frmNuevoRecurso()
		{
			InitializeComponent();
			ds = Util.getDataSet();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNuevoRecurso));
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioNo = new System.Windows.Forms.RadioButton();
			this.radioSi = new System.Windows.Forms.RadioButton();
			this.cmbRecurso = new System.Windows.Forms.ComboBox();
			this.lblRecurso = new System.Windows.Forms.Label();
			this.cmbTablaPadre = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmb = new System.Windows.Forms.ComboBox();
			this.lbl = new System.Windows.Forms.Label();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.lblNombre = new System.Windows.Forms.Label();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.txtIDcmbRecurso = new System.Windows.Forms.TextBox();
			this.txtIDcmb = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(221, 296);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(79, 32);
			this.button1.TabIndex = 13;
			this.button1.Text = "&Agregar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.groupBox1);
			this.groupBox3.Controls.Add(this.cmbRecurso);
			this.groupBox3.Controls.Add(this.lblRecurso);
			this.groupBox3.Controls.Add(this.cmbTablaPadre);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.cmb);
			this.groupBox3.Controls.Add(this.lbl);
			this.groupBox3.Controls.Add(this.txtDescripcion);
			this.groupBox3.Controls.Add(this.txtNombre);
			this.groupBox3.Controls.Add(this.lblNombre);
			this.groupBox3.Controls.Add(this.lblDescripcion);
			this.groupBox3.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox3.Location = new System.Drawing.Point(8, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(512, 280);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioNo);
			this.groupBox1.Controls.Add(this.radioSi);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox1.Location = new System.Drawing.Point(24, 72);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(224, 40);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Agregar e&xistente:";
			// 
			// radioNo
			// 
			this.radioNo.Checked = true;
			this.radioNo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.radioNo.Location = new System.Drawing.Point(143, 16);
			this.radioNo.Name = "radioNo";
			this.radioNo.Size = new System.Drawing.Size(42, 16);
			this.radioNo.TabIndex = 6;
			this.radioNo.TabStop = true;
			this.radioNo.Text = "No";
			this.radioNo.CheckedChanged += new System.EventHandler(this.radioNo_CheckedChanged);
			// 
			// radioSi
			// 
			this.radioSi.ForeColor = System.Drawing.SystemColors.ControlText;
			this.radioSi.Location = new System.Drawing.Point(40, 16);
			this.radioSi.Name = "radioSi";
			this.radioSi.Size = new System.Drawing.Size(42, 16);
			this.radioSi.TabIndex = 5;
			this.radioSi.Text = "Si";
			this.radioSi.CheckedChanged += new System.EventHandler(this.radioSi_CheckedChanged);
			// 
			// cmbRecurso
			// 
			this.cmbRecurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbRecurso.Enabled = false;
			this.cmbRecurso.Location = new System.Drawing.Point(264, 85);
			this.cmbRecurso.Name = "cmbRecurso";
			this.cmbRecurso.Size = new System.Drawing.Size(224, 21);
			this.cmbRecurso.TabIndex = 8;
			this.cmbRecurso.SelectedIndexChanged += new System.EventHandler(this.cmbRecurso_SelectedIndexChanged);
			// 
			// lblRecurso
			// 
			this.lblRecurso.Enabled = false;
			this.lblRecurso.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblRecurso.Location = new System.Drawing.Point(264, 70);
			this.lblRecurso.Name = "lblRecurso";
			this.lblRecurso.Size = new System.Drawing.Size(152, 16);
			this.lblRecurso.TabIndex = 7;
			this.lblRecurso.Text = "Seleccione el &Recurso:";
			// 
			// cmbTablaPadre
			// 
			this.cmbTablaPadre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTablaPadre.Items.AddRange(new object[] {
															   "Formas de Aprovechamiento",
															   "Variantes Tecnológicas"});
			this.cmbTablaPadre.Location = new System.Drawing.Point(24, 40);
			this.cmbTablaPadre.Name = "cmbTablaPadre";
			this.cmbTablaPadre.Size = new System.Drawing.Size(224, 21);
			this.cmbTablaPadre.TabIndex = 1;
			this.cmbTablaPadre.SelectedIndexChanged += new System.EventHandler(this.cmbTablaPadre_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(24, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Nuevo recurso para:";
			// 
			// cmb
			// 
			this.cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb.ItemHeight = 13;
			this.cmb.Location = new System.Drawing.Point(264, 40);
			this.cmb.Name = "cmb";
			this.cmb.Size = new System.Drawing.Size(224, 21);
			this.cmb.TabIndex = 3;
			this.cmb.SelectedIndexChanged += new System.EventHandler(this.cmb_SelectedIndexChanged);
			// 
			// lbl
			// 
			this.lbl.AutoSize = true;
			this.lbl.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.lbl.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lbl.Location = new System.Drawing.Point(264, 24);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(217, 16);
			this.lbl.TabIndex = 2;
			this.lbl.Text = "&Seleccione la Forma de Aprovechamiento:";
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(24, 180);
			this.txtDescripcion.Multiline = true;
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(464, 80);
			this.txtDescripcion.TabIndex = 12;
			this.txtDescripcion.Text = "";
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(24, 137);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(464, 20);
			this.txtNombre.TabIndex = 10;
			this.txtNombre.Text = "";
			// 
			// lblNombre
			// 
			this.lblNombre.ForeColor = System.Drawing.SystemColors.MenuText;
			this.lblNombre.Location = new System.Drawing.Point(24, 121);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(56, 16);
			this.lblNombre.TabIndex = 9;
			this.lblNombre.Text = "N&ombre";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.ForeColor = System.Drawing.SystemColors.MenuText;
			this.lblDescripcion.Location = new System.Drawing.Point(24, 164);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(64, 16);
			this.lblDescripcion.TabIndex = 11;
			this.lblDescripcion.Text = "&Descripción";
			// 
			// txtIDcmbRecurso
			// 
			this.txtIDcmbRecurso.Location = new System.Drawing.Point(600, 304);
			this.txtIDcmbRecurso.Name = "txtIDcmbRecurso";
			this.txtIDcmbRecurso.Size = new System.Drawing.Size(30, 20);
			this.txtIDcmbRecurso.TabIndex = 14;
			this.txtIDcmbRecurso.Text = "";
			// 
			// txtIDcmb
			// 
			this.txtIDcmb.Location = new System.Drawing.Point(600, 304);
			this.txtIDcmb.Name = "txtIDcmb";
			this.txtIDcmb.Size = new System.Drawing.Size(32, 20);
			this.txtIDcmb.TabIndex = 13;
			this.txtIDcmb.Text = "";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button2.Location = new System.Drawing.Point(341, 296);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(79, 32);
			this.button2.TabIndex = 14;
			this.button2.Text = "&Cancelar";
			this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
			this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button3.Location = new System.Drawing.Point(102, 296);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(79, 32);
			this.button3.TabIndex = 15;
			this.button3.Text = "&Aceptar";
			this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// frmNuevoRecurso
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(530, 335);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.txtIDcmbRecurso);
			this.Controls.Add(this.txtIDcmb);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNuevoRecurso";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nuevo Recurso";
			this.Load += new System.EventHandler(this.frmNuevoRecurso_Load);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		//Boton agregar recurso
		private void button1_Click(object sender, System.EventArgs e)
		{
			if (this.cmb.Items.Count==0 || this.cmbTablaPadre.Items.Count==0) 
			{
				MessageBox.Show("El recurso debe ser asociado a un Item", "Atención", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string nombre = txtNombre.Text.Trim();
			string descripcion = txtDescripcion.Text.Trim();
			string idTablaPadre = this.cmb.ValueMember;
			
			//validar nombre y descripcion
			if(nombre.Equals("") || descripcion.Equals(""))
			{
				MessageBox.Show("Los campos 'Nombre' y 'Descripción' son obligatorios para ingresar un nuevo recurso", 
					"Atención",	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				if(nombre.Equals("")) txtNombre.Focus();
				else txtDescripcion.Focus();
				return;
			}
			SqlConnection conn = ConexionDB.getConnection();
			SqlCommand sql = conn.CreateCommand();
			txtIDcmb.DataBindings.Clear();
			txtIDcmbRecurso.DataBindings.Clear();
			//insertar un recurso existente  //no inserta el recurso, se inserta en inter_fa_r
			if(this.radioSi.Checked)
			{
					if(this.cmbTablaPadre.SelectedIndex == 0) //seleccionado Formas de Aprovechamiento
					{
						try
						{
							DataView dv = (DataView)this.cmb.DataSource;
							DataView dv2 = (DataView)this.cmbRecurso.DataSource;
							dv.RowFilter = "id = " + this.cmb.ValueMember;
							dv2.RowFilter = "id = " + this.cmbRecurso.ValueMember;
							txtIDcmb.DataBindings.Add("Text", dv, "id");
							txtIDcmbRecurso.DataBindings.Add("Text", dv2, "id");
							string sqlSelect = "SELECT * FROM Inter_fa_r WHERE id_fa = "+txtIDcmb.Text + " AND id_recurso = " + txtIDcmbRecurso.Text;
							sql.CommandText = sqlSelect;
							SqlDataReader dr = sql.ExecuteReader();
							bool hayDatos = dr.Read();
							dr.Close();
							if(hayDatos)
								{
									MessageBox.Show("El recurso ya se encuentra asociado a esta Forma de Aprovechamiento.", "Recursos", 
										MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
									return;
								}
							string sqlInsert = "INSERT INTO Inter_fa_r VALUES("+txtIDcmb.Text + ", "+txtIDcmbRecurso.Text +")";
							sql.CommandText = sqlInsert;
							sql.ExecuteNonQuery();						
							MessageBox.Show("Se ha asociado el recurso con esta Forma de Aprovechamiento.", "Recursos", 
								MessageBoxButtons.OK, MessageBoxIcon.Information);	
							actualizar();
						
							this.txtNombre.Clear();
							this.txtDescripcion.Clear();
							this.txtIDcmb.Clear();
							this.txtIDcmbRecurso.Clear();
							this.radioNo.Checked = true; 
							this.txtNombre.Select();					
						
							return;
						}
						catch(Exception ex)
						{
							MessageBox.Show ("Error: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
					else //Seleccionado Variantes Tecnológicas
					{
						try
						{
							DataView dv = (DataView)this.cmb.DataSource;
							DataView dv2 = (DataView)this.cmbRecurso.DataSource;
							dv.RowFilter = "id = " + this.cmb.ValueMember;
							dv2.RowFilter = "id = " + this.cmbRecurso.ValueMember;
							txtIDcmb.DataBindings.Add("Text", dv, "id");
							txtIDcmbRecurso.DataBindings.Add("Text", dv2, "id");
							string sqlSelect = "SELECT * FROM Inter_vt_r WHERE id_vt = "+txtIDcmb.Text + " AND id_recurso = " + txtIDcmbRecurso.Text;
							sql.CommandText = sqlSelect;
							SqlDataReader dr = sql.ExecuteReader();
							bool hayDatos = dr.Read();
							dr.Close();
							if(hayDatos)
								{
									MessageBox.Show("El recurso ya se encuentra asociado a esta Variante Tecnológica.", "Recursos", 
										MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
									return;
								}
							
							string sqlInsert = "INSERT INTO Inter_vt_r VALUES("+txtIDcmb.Text + ", "+txtIDcmbRecurso.Text +")";
							sql.CommandText = sqlInsert;
							sql.ExecuteNonQuery();						
							MessageBox.Show("Se ha asociado el recurso con esta Variante Tecnológica.", "Recursos", 
								MessageBoxButtons.OK, MessageBoxIcon.Information);	
							actualizar();
							this.txtNombre.Clear();
							this.txtDescripcion.Clear();
							this.txtIDcmb.Clear();
							this.txtIDcmbRecurso.Clear();
							this.radioNo.Checked = true;
							this.txtNombre.Select();	
							return;
						}
						catch(Exception ex)
						{
							MessageBox.Show ("Error: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}	
					}
				}
								
			
			else //insertar en recurso e insertar en intercepciones
			{
				//insertar un recurso nuevo
				
				try
				{	
					if (!(Util.buscar("RECURSO", "nombre", nombre, "")))
					{
						string []columnName = {"nombre", "descripcion"};
						Util.Insert(Util.getDARec(), "Recurso", columnName, nombre, descripcion);
						try
						{
							DataView dv = (DataView)this.cmb.DataSource;
							dv.RowFilter = "id = " + this.cmb.ValueMember;
							txtIDcmb.DataBindings.Add("Text", dv, "id");
							string sqlSelect = "SELECT id FROM recurso WHERE id = @@IDENTITY";
							sql.CommandText = sqlSelect;
							SqlDataReader dr = sql.ExecuteReader();
							if(dr.Read())
							{
								string sqlInsert;
								if(cmbTablaPadre.SelectedIndex == 0)
									sqlInsert = "INSERT INTO Inter_fa_r VALUES("+txtIDcmb.Text + ", "+dr.GetValue(0) +")";
								
								else
								
									sqlInsert = "INSERT INTO Inter_vt_r VALUES("+txtIDcmb.Text + ", "+dr.GetValue(0) +")";
								
								dr.Close();
								sql.CommandText = sqlInsert;
								sql.ExecuteNonQuery();						
								MessageBox.Show("Se ha agregado el recurso y asociado con esta "+(cmbTablaPadre.SelectedIndex == 0 ? "Forma de Aprovechamiento.":"Variante Tecnológica."), "Recursos", 
									MessageBoxButtons.OK, MessageBoxIcon.Information);	
								actualizar();
								this.txtNombre.Clear();
								this.txtDescripcion.Clear();
								this.txtIDcmb.Clear();
								this.txtIDcmbRecurso.Clear();
								this.txtNombre.Select();
							}
							else dr.Close();
							return;
						}
						catch(Exception ex)
						{
							MessageBox.Show ("Error: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}	
					}
					else
					{
						MessageBox.Show("El nombre del Recurso ya se encuentra registrado.", "Recursos", 
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			}
		
				
						
		

		//cerrar formulario
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close (); 
		}

		private void frmNuevoRecurso_Load(object sender, System.EventArgs e)
		{
			
			cmbTablaPadre.SelectedIndex = 0;
		}
		
		private void actualizar()
		{
			if(radioSi.Checked)listR();
		}

		
		//Listar Recursos
		private void listR()
		{
			
				this.cmbRecurso.DataSource = null;
				this.cmbRecurso.Items.Clear();
				try
				{
					DataView dv = ds.Tables["Recurso"].DefaultView;
					this.cmbRecurso.DisplayMember = "nombre";
					this.cmbRecurso.ValueMember = "id";
					this.cmbRecurso.DataSource = dv;
					cmbRecurso.SelectedIndex = 0;
				}
				catch
				{
					this.cmbRecurso.DataSource = null;
					this.cmbRecurso.Items.Clear();
				}
			
		}
		
		
		//Lista formas de aprovechamiento
		private void listFA()
		{
			try
			{
				DataView dv = ds.Tables["Forma Aprovech"].DefaultView;
				this.cmb.DisplayMember = "nombre";
				this.cmb.ValueMember = "id";
				this.cmb.DataSource = dv;
			}
			catch
			{
				this.cmb.DataSource = null;
				this.cmb.Items.Clear();
			}
		}

		//Lista variantes tecnológicas
		private void listVT()
		{
			try
			{
				DataView dv = ds.Tables["Variante Tecn"].DefaultView;
				this.cmb.DisplayMember = "nombre";
				this.cmb.ValueMember = "id";
				this.cmb.DataSource = dv;
				
			}
			catch
			{
				this.cmb.DataSource = null;
				this.cmb.Items.Clear();
			}
		}

		private void cmbTablaPadre_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cmbTablaPadre.SelectedIndex == 0)
			{
				this.txtIDcmb.DataBindings.Clear();
				lbl.Text = "&Seleccione la Forma de Aprovechamiento:";
				listFA();
				DataView dv = (DataView)this.cmb.DataSource;
				dv.RowFilter = "id = " + this.cmb.ValueMember;
				txtIDcmb.DataBindings.Add("Text", dv, "id");
				
			}
			else
			{
				this.txtIDcmb.DataBindings.Clear();
				lbl.Text = "&Seleccione la Variante Tecnológica:";
				listVT();
				DataView dv = (DataView)this.cmb.DataSource;
				dv.RowFilter = "id = " + this.cmb.ValueMember;
				txtIDcmb.DataBindings.Add("Text", dv, "id");
			}
		}

		private void radioNo_CheckedChanged(object sender, System.EventArgs e)
		{
			cmbRecurso.SelectedIndex = -1;
			lblRecurso.Enabled = false;
			cmbRecurso.Enabled = false;
			txtNombre.ReadOnly  = false;
			txtDescripcion.ReadOnly = false;
			txtNombre.DataBindings.Clear();
			txtDescripcion.DataBindings.Clear();
			txtNombre.Text = "";
			txtDescripcion.Text = "";
		}

		private void radioSi_CheckedChanged(object sender, System.EventArgs e)
		{
			try
			{
				lblRecurso.Enabled = true;
				cmbRecurso.Enabled = true;
				txtNombre.ReadOnly  = true;
				txtDescripcion.ReadOnly = true;
				listR();
				cmbRecurso.SelectedIndex = 0;
			}
			catch{}
			
		}

		private void cmbRecurso_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtNombre.DataBindings.Clear();
			txtDescripcion.DataBindings.Clear();
			if(cmbRecurso.SelectedIndex < 0)return;
			try
			{
				DataView dv = (DataView)this.cmbRecurso.DataSource;
				dv.RowFilter = "id = " + this.cmbRecurso.ValueMember;
				txtNombre.DataBindings.Add("Text", dv, "nombre");
				txtDescripcion.DataBindings.Add("Text", dv, "descripcion");
			}
			catch{}
		}

		private void cmb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtNombre.DataBindings.Clear();
			txtDescripcion.DataBindings.Clear();
			if(cmbRecurso.SelectedIndex < 0)return;
			try
			{
				DataView dv = (DataView)this.cmbRecurso.DataSource;
				dv.RowFilter = "id = " + this.cmbRecurso.ValueMember;
				txtNombre.DataBindings.Add("Text", dv, "nombre");
				txtDescripcion.DataBindings.Add("Text", dv, "descripcion");
			}
			catch{}
		}

		//boton aceptar
		private void button3_Click(object sender, System.EventArgs e)
		{
			if (this.cmb.Items.Count==0 || this.cmbTablaPadre.Items.Count==0) 
			{
				MessageBox.Show("El recurso debe ser asociado a un Item", "Atención", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string nombre = txtNombre.Text.Trim();
			string descripcion = txtDescripcion.Text.Trim();
			string idTablaPadre = this.cmb.ValueMember;
			
			//validar nombre y descripcion
			if(nombre.Equals("") || descripcion.Equals(""))
			{
				MessageBox.Show("Los campos 'Nombre' y 'Descripción' son obligatorios para ingresar un nuevo recurso", 
					"Atención",	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				if(nombre.Equals("")) txtNombre.Focus();
				else txtDescripcion.Focus();
				return;
			}
			SqlConnection conn = ConexionDB.getConnection();
			SqlCommand sql = conn.CreateCommand();
			txtIDcmb.DataBindings.Clear();
			txtIDcmbRecurso.DataBindings.Clear();
			//insertar un recurso existente  //no inserta el recurso, se inserta en inter_fa_r
			if(this.radioSi.Checked)
			{
				if(this.cmbTablaPadre.SelectedIndex == 0) //seleccionado Formas de Aprovechamiento
				{
					try
					{
						DataView dv = (DataView)this.cmb.DataSource;
						DataView dv2 = (DataView)this.cmbRecurso.DataSource;
						dv.RowFilter = "id = " + this.cmb.ValueMember;
						dv2.RowFilter = "id = " + this.cmbRecurso.ValueMember;
						txtIDcmb.DataBindings.Add("Text", dv, "id");
						txtIDcmbRecurso.DataBindings.Add("Text", dv2, "id");
						string sqlSelect = "SELECT * FROM Inter_fa_r WHERE id_fa = "+txtIDcmb.Text + " AND id_recurso = " + txtIDcmbRecurso.Text;
						sql.CommandText = sqlSelect;
						SqlDataReader dr = sql.ExecuteReader();
						bool hayDatos = dr.Read();
						dr.Close();
						if(hayDatos)
						{
							MessageBox.Show("El recurso ya se encuentra asociado a esta Forma de Aprovechamiento.", "Recursos", 
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						string sqlInsert = "INSERT INTO Inter_fa_r VALUES("+txtIDcmb.Text + ", "+txtIDcmbRecurso.Text +")";
						sql.CommandText = sqlInsert;
						sql.ExecuteNonQuery();						
						MessageBox.Show("Se ha asociado el recurso con esta Forma de Aprovechamiento.", "Recursos", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);	
						actualizar();
						
						this.Close();				
						
						return;
					}
					catch(Exception ex)
					{
						MessageBox.Show ("Error: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else //Seleccionado Variantes Tecnológicas se inserta en Inter_vt_r
				{
					try
					{
						DataView dv = (DataView)this.cmb.DataSource;
						DataView dv2 = (DataView)this.cmbRecurso.DataSource;
						dv.RowFilter = "id = " + this.cmb.ValueMember;
						dv2.RowFilter = "id = " + this.cmbRecurso.ValueMember;
						txtIDcmb.DataBindings.Add("Text", dv, "id");
						txtIDcmbRecurso.DataBindings.Add("Text", dv2, "id");
						string sqlSelect = "SELECT * FROM Inter_vt_r WHERE id_vt = "+txtIDcmb.Text + " AND id_recurso = " + txtIDcmbRecurso.Text;
						sql.CommandText = sqlSelect;
						SqlDataReader dr = sql.ExecuteReader();
						bool hayDatos = dr.Read();
						dr.Close();
						if(hayDatos)
						{
							MessageBox.Show("El recurso ya se encuentra asociado a esta Variante Tecnológica.", "Recursos", 
								MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						string sqlInsert = "INSERT INTO Inter_vt_r VALUES("+txtIDcmb.Text + ", "+txtIDcmbRecurso.Text +")";
						sql.CommandText = sqlInsert;
						sql.ExecuteNonQuery();						
						MessageBox.Show("Se ha asociado el recurso con esta Variante Tecnológica.", "Recursos", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);	
						actualizar();
						
						this.Close();
					}
					catch(Exception ex)
					{
						MessageBox.Show ("Error: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}	
				}
			}		
			else //insertar en recurso y insertar en intercepciones
			{
				//insertar un recurso nuevo
				try
				{	
					if (!(Util.buscar("RECURSO", "nombre", nombre, "")))
					{
						string []columnName = {"nombre", "descripcion"};
						Util.Insert(Util.getDARec(), "Recurso", columnName, nombre, descripcion);
						try
						{
							DataView dv = (DataView)this.cmb.DataSource;
							dv.RowFilter = "id = " + this.cmb.ValueMember;
							txtIDcmb.DataBindings.Add("Text", dv, "id");
							string sqlSelect = "SELECT id FROM Recurso WHERE id = @@IDENTITY";
							sql.CommandText = sqlSelect;
							SqlDataReader dr = sql.ExecuteReader();
							if(dr.Read())
							{
								string sqlInsert;
								if(cmbTablaPadre.SelectedIndex == 0)
									sqlInsert = "INSERT INTO Inter_fa_r VALUES("+txtIDcmb.Text + ", "+dr.GetValue(0) +")";
								else
									sqlInsert = "INSERT INTO Inter_vt_r VALUES("+txtIDcmb.Text + ", "+dr.GetValue(0) +")";
								dr.Close();
								sql.CommandText = sqlInsert;
								sql.ExecuteNonQuery();						
								MessageBox.Show("Se ha agregado el recurso y asociado con esta "+(cmbTablaPadre.SelectedIndex == 0 ? "Forma de Aprovechamiento.":"Variante Tecnológica."), "Recursos", 
									MessageBoxButtons.OK, MessageBoxIcon.Information);	
								actualizar();
								this.Close();

							}
							else dr.Close();
							return;
						}
						catch(Exception ex)
						{
							MessageBox.Show ("Error: "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}	
					}
					else
					{
						MessageBox.Show("El nombre del Recurso ya se encuentra registrado.", "Recursos", 
							MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}
				catch(Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				
			
			}
			
		}

		
	}
}
