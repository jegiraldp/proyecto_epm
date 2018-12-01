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
	public class frmNuevaVT : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmbFuente;
		private System.Windows.Forms.Label lblFuente;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnCrear;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblProceso;
		private System.Windows.Forms.ComboBox cmbProceso;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ComboBox cmbFA;
		private System.Windows.Forms.Label lblFA;
		private System.Windows.Forms.Button button1;
		private DataSet ds = null;
		
		public frmNuevaVT()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNuevaVT));
			this.cmbFuente = new System.Windows.Forms.ComboBox();
			this.lblFuente = new System.Windows.Forms.Label();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnCrear = new System.Windows.Forms.Button();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.lblNombre = new System.Windows.Forms.Label();
			this.cmbProceso = new System.Windows.Forms.ComboBox();
			this.lblProceso = new System.Windows.Forms.Label();
			this.cmbFA = new System.Windows.Forms.ComboBox();
			this.lblFA = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmbFuente
			// 
			this.cmbFuente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFuente.Location = new System.Drawing.Point(18, 40);
			this.cmbFuente.Name = "cmbFuente";
			this.cmbFuente.Size = new System.Drawing.Size(152, 21);
			this.cmbFuente.TabIndex = 1;
			// 
			// lblFuente
			// 
			this.lblFuente.Location = new System.Drawing.Point(18, 24);
			this.lblFuente.Name = "lblFuente";
			this.lblFuente.Size = new System.Drawing.Size(48, 16);
			this.lblFuente.TabIndex = 0;
			this.lblFuente.Text = "Fuente";
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(274, 312);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(79, 32);
			this.btnCancelar.TabIndex = 9;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnCrear
			// 
			this.btnCrear.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
			this.btnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCrear.Location = new System.Drawing.Point(162, 312);
			this.btnCrear.Name = "btnCrear";
			this.btnCrear.Size = new System.Drawing.Size(79, 32);
			this.btnCrear.TabIndex = 8;
			this.btnCrear.Text = "&Agregar";
			this.btnCrear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(16, 184);
			this.txtDescripcion.MaxLength = 7000;
			this.txtDescripcion.Multiline = true;
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescripcion.Size = new System.Drawing.Size(365, 104);
			this.txtDescripcion.TabIndex = 7;
			this.txtDescripcion.Text = "";
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(16, 133);
			this.txtNombre.MaxLength = 100;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(360, 20);
			this.txtNombre.TabIndex = 5;
			this.txtNombre.Text = "";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.Location = new System.Drawing.Point(16, 168);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(64, 16);
			this.lblDescripcion.TabIndex = 6;
			this.lblDescripcion.Text = "Descripción";
			// 
			// lblNombre
			// 
			this.lblNombre.Location = new System.Drawing.Point(16, 117);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(216, 16);
			this.lblNombre.TabIndex = 4;
			this.lblNombre.Text = "Nombre de la Variante Tecnológica";
			// 
			// cmbProceso
			// 
			this.cmbProceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProceso.Location = new System.Drawing.Point(200, 40);
			this.cmbProceso.Name = "cmbProceso";
			this.cmbProceso.Size = new System.Drawing.Size(152, 21);
			this.cmbProceso.TabIndex = 3;
			// 
			// lblProceso
			// 
			this.lblProceso.Location = new System.Drawing.Point(200, 24);
			this.lblProceso.Name = "lblProceso";
			this.lblProceso.Size = new System.Drawing.Size(48, 16);
			this.lblProceso.TabIndex = 2;
			this.lblProceso.Text = "Proceso";
			// 
			// cmbFA
			// 
			this.cmbFA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFA.Location = new System.Drawing.Point(16, 88);
			this.cmbFA.Name = "cmbFA";
			this.cmbFA.Size = new System.Drawing.Size(152, 21);
			this.cmbFA.TabIndex = 11;
			// 
			// lblFA
			// 
			this.lblFA.Location = new System.Drawing.Point(16, 72);
			this.lblFA.Name = "lblFA";
			this.lblFA.Size = new System.Drawing.Size(144, 16);
			this.lblFA.TabIndex = 10;
			this.lblFA.Text = "Forma de Aprovechamiento";
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(50, 312);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(79, 32);
			this.button1.TabIndex = 12;
			this.button1.Text = "&Aceptar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmNuevaVT
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(402, 359);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.cmbFA);
			this.Controls.Add(this.lblFA);
			this.Controls.Add(this.cmbProceso);
			this.Controls.Add(this.lblProceso);
			this.Controls.Add(this.cmbFuente);
			this.Controls.Add(this.lblFuente);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnCrear);
			this.Controls.Add(this.txtDescripcion);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.lblDescripcion);
			this.Controls.Add(this.lblNombre);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNuevaVT";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nueva Variante Tecnológica";
			this.Load += new System.EventHandler(this.frmNuevaFA_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmNuevaFA_Load(object sender, System.EventArgs e)
		{
			this.cmbFuente.DisplayMember = "Fuente.nombre";
			this.cmbFuente.ValueMember = "Fuente.id";
			this.cmbFuente.DataSource = ds;

			this.cmbProceso.DisplayMember = "Fuente.Procesos.nombre";
			this.cmbProceso.ValueMember = "Fuente.Procesos.id";
			this.cmbProceso.DataSource = ds;

			this.cmbFA.DisplayMember = "Fuente.Procesos.Formas de Aprovechamiento.nombre";
			this.cmbFA.ValueMember = "Fuente.Procesos.Formas de Aprovechamiento.id";
			this.cmbFA.DataSource = ds;

		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//boton agregar
		private void btnCrear_Click(object sender, System.EventArgs e)
		{
			txtNombre.Text = txtNombre.Text.Trim();
			txtDescripcion.Text = txtDescripcion.Text.Trim();
			if(cmbFA.Items.Count == 0)
			{
				MessageBox.Show("Debe seleccionar una Forma de Aprovechamiento para crear la \nVariante Tecnológica.", "Atención",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (txtNombre.Text.Equals("")) 
				{
					MessageBox.Show("Debe ingresar un nombre para la Forma de Aprovechamiento.", "Atención",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);			
				}
				else
				{
					if (txtDescripcion.Text.Equals("")) 
					{
						MessageBox.Show("Debe ingresar una descripcion para la Forma de Aprovechamiento.", 
							"Atención",	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						try
						{		
							if (!(Util.buscar("VARIANTE_TECNOLOGICA", "nombre", txtNombre.Text, "")))
							{
								string []colunmName = {"nombre", "descripcion", "form_aprov_id"};
								Util.Insert(Util.getDAVT(), "Variante Tecn", colunmName, txtNombre.Text,txtDescripcion.Text, cmbFA.SelectedValue.ToString());
								MessageBox.Show("Se ha creado la Variante Tecnológica exitosamente.", "Variante Tecnológica", 
									MessageBoxButtons.OK, MessageBoxIcon.Information);
															}
							else
							{
								MessageBox.Show("El nombre de la Variante Tecnológica ya se encuentra registrado", "Variante Tecnológica", 
									MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						catch(Exception ex)
						{
							MessageBox.Show("Error: " + ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
				        
						this.txtNombre.Clear();
						this.txtDescripcion.Clear();
						this.txtNombre.Select();      
					}
				}
			}
		}

		//boton aceptar
		private void button1_Click(object sender, System.EventArgs e)
		{
			txtNombre.Text = txtNombre.Text.Trim();
			txtDescripcion.Text = txtDescripcion.Text.Trim();
			if(cmbFA.Items.Count == 0)
			{
				MessageBox.Show("Debe seleccionar una Forma de Aprovechamiento para crear la \nVariante Tecnológica.", "Atención",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (txtNombre.Text.Equals("")) 
				{
					MessageBox.Show("Debe ingresar un nombre para la Variante Tecnológica.", "Atención",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);			
				}
				else
				{
					if (txtDescripcion.Text.Equals("")) 
					{
						MessageBox.Show("Debe ingresar una descripcion para la Variante Tecnológica.", 
							"Atención",	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						try
						{		
							if (!(Util.buscar("VARIANTE_TECNOLOGICA", "nombre", txtNombre.Text, "")))
							{
								string []colunmName = {"nombre", "descripcion", "form_aprov_id"};
								Util.Insert(Util.getDAVT(), "Variante Tecn", colunmName, txtNombre.Text,txtDescripcion.Text, cmbFA.SelectedValue.ToString());
								MessageBox.Show("Se ha creado la Variante Tecnológica exitosamente.", "Variante Tecnológica", 
									MessageBoxButtons.OK, MessageBoxIcon.Information);
								
							}
							else
							{
								MessageBox.Show("El nombre de la Variante Tecnológica ya se encuentra registrado", "Variante Tecnológica", 
									MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						catch(Exception ex)
						{
							MessageBox.Show("Error: " + ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
				        
					this.Close();     
					}
				}
			}
		
		}

		
	}
}
