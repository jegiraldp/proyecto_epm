using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace EPM.formularios{
	using EPM.clases;
	public class frmNuevoProceso : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.Button btnCrear;
		private System.Windows.Forms.Button btnCancelar;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblFuente;
		private System.Windows.Forms.ComboBox cmbFuente;
		private System.Windows.Forms.Button button1;
		private DataSet ds = null;
		
			
		public frmNuevoProceso()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNuevoProceso));
			this.lblNombre = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.btnCrear = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblFuente = new System.Windows.Forms.Label();
			this.cmbFuente = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblNombre
			// 
			this.lblNombre.Location = new System.Drawing.Point(40, 62);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(111, 16);
			this.lblNombre.TabIndex = 2;
			this.lblNombre.Text = "Nombre del  Proceso";
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(40, 78);
			this.txtNombre.MaxLength = 100;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(368, 20);
			this.txtNombre.TabIndex = 3;
			this.txtNombre.Text = "";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.Location = new System.Drawing.Point(40, 102);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(64, 16);
			this.lblDescripcion.TabIndex = 4;
			this.lblDescripcion.Text = "Descripción";
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(40, 126);
			this.txtDescripcion.MaxLength = 7000;
			this.txtDescripcion.Multiline = true;
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescripcion.Size = new System.Drawing.Size(365, 104);
			this.txtDescripcion.TabIndex = 5;
			this.txtDescripcion.Text = "";
			// 
			// btnCrear
			// 
			this.btnCrear.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
			this.btnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCrear.Location = new System.Drawing.Point(181, 244);
			this.btnCrear.Name = "btnCrear";
			this.btnCrear.Size = new System.Drawing.Size(80, 32);
			this.btnCrear.TabIndex = 6;
			this.btnCrear.Text = "&Agregar";
			this.btnCrear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(293, 244);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(80, 32);
			this.btnCancelar.TabIndex = 7;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// lblFuente
			// 
			this.lblFuente.Location = new System.Drawing.Point(40, 14);
			this.lblFuente.Name = "lblFuente";
			this.lblFuente.Size = new System.Drawing.Size(48, 16);
			this.lblFuente.TabIndex = 0;
			this.lblFuente.Text = "Fuente";
			// 
			// cmbFuente
			// 
			this.cmbFuente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFuente.Location = new System.Drawing.Point(40, 30);
			this.cmbFuente.Name = "cmbFuente";
			this.cmbFuente.Size = new System.Drawing.Size(152, 21);
			this.cmbFuente.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(69, 244);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 8;
			this.button1.Text = "&Aceptar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmNuevoProceso
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(442, 295);
			this.Controls.Add(this.button1);
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
			this.Name = "frmNuevoProceso";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nuevo Proceso";
			this.Load += new System.EventHandler(this.frmNuevoProceso_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCrear_Click(object sender, System.EventArgs e)
		{
			txtNombre.Text = txtNombre.Text.Trim();
			txtDescripcion.Text = txtDescripcion.Text.Trim();
			if(this.cmbFuente.Items.Count == 0)
			{
				MessageBox.Show("Debe seleccionar un proceso para crear la \nForma de Aprovechamiento.", "Atención",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (txtNombre.Text.Equals("")) 
				{
					MessageBox.Show("Debe ingresar un nombre para el proceso.", "Atención",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);			
				}
				else
				{
					if (txtDescripcion.Text.Equals("")) 
					{
						MessageBox.Show("Debe ingresar una descripcion para el proceso.", 
							"Atención",	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						try
						{		
							if (!(Util.buscar("PROCESO", "nombre", txtNombre.Text, "")))
							{
								string []colunmName = {"nombre", "descripcion", "fuente_id"};
								Util.Insert(Util.getDAProceso(), "Proceso", colunmName, txtNombre.Text,txtDescripcion.Text, cmbFuente.SelectedValue.ToString());
								MessageBox.Show("Se ha creado el proceso exitosamente.", "Proceso", 
									MessageBoxButtons.OK, MessageBoxIcon.Information);
								
							}
							else
							{
								MessageBox.Show("El nombre del Proceso ya se encuentra registrado", "Proceso", 
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

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
		  this.Close();
		}

		private void frmNuevoProceso_Load(object sender, System.EventArgs e)
		{
			ds = Util.getDataSet();
			
			this.cmbFuente.DisplayMember = "Fuente.nombre";
			this.cmbFuente.ValueMember = "Fuente.id";
			this.cmbFuente.DataSource = ds.DefaultViewManager;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			txtNombre.Text = txtNombre.Text.Trim();
			txtDescripcion.Text = txtDescripcion.Text.Trim();
			if(this.cmbFuente.Items.Count == 0)
			{
				MessageBox.Show("Debe seleccionar un proceso para crear la \nForma de Aprovechamiento.", "Atención",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (txtNombre.Text.Equals("")) 
				{
					MessageBox.Show("Debe ingresar un nombre para el proceso.", "Atención",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);			
				}
				else
				{
					if (txtDescripcion.Text.Equals("")) 
					{
						MessageBox.Show("Debe ingresar una descripcion para el proceso.", 
							"Atención",	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						try
						{		
							if (!(Util.buscar("PROCESO", "nombre", txtNombre.Text, "")))
							{
								string []colunmName = {"nombre", "descripcion", "fuente_id"};
								Util.Insert(Util.getDAProceso(), "Proceso", colunmName, txtNombre.Text,txtDescripcion.Text, cmbFuente.SelectedValue.ToString());
								MessageBox.Show("Se ha creado el proceso exitosamente.", "Proceso", 
									MessageBoxButtons.OK, MessageBoxIcon.Information);
								
							}
							else
							{
								MessageBox.Show("El nombre del Proceso ya se encuentra registrado", "Proceso", 
									MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								return;
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
