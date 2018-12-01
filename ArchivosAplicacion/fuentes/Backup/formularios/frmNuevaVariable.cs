using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace EPM.formularios{
	using EPM.clases;
	public class frmNuevaVariable : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.Button btnCrear;
		private System.Windows.Forms.Button btnCancelar;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblGrupo;
		private System.Windows.Forms.ComboBox cmbGrupo;
		private System.Windows.Forms.TextBox txtUnidad;
		private System.Windows.Forms.Button button1;
		private DataSet ds = null;
		
			
		public frmNuevaVariable()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNuevaVariable));
			this.lblNombre = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.txtUnidad = new System.Windows.Forms.TextBox();
			this.btnCrear = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblGrupo = new System.Windows.Forms.Label();
			this.cmbGrupo = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblNombre
			// 
			this.lblNombre.Location = new System.Drawing.Point(24, 64);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(199, 16);
			this.lblNombre.TabIndex = 2;
			this.lblNombre.Text = "Nombre de la Variable Característica";
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(24, 80);
			this.txtNombre.MaxLength = 100;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(360, 20);
			this.txtNombre.TabIndex = 3;
			this.txtNombre.Text = "";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.Location = new System.Drawing.Point(24, 112);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(64, 27);
			this.lblDescripcion.TabIndex = 4;
			this.lblDescripcion.Text = "Unidad";
			// 
			// txtUnidad
			// 
			this.txtUnidad.Location = new System.Drawing.Point(24, 128);
			this.txtUnidad.MaxLength = 7000;
			this.txtUnidad.Name = "txtUnidad";
			this.txtUnidad.Size = new System.Drawing.Size(152, 20);
			this.txtUnidad.TabIndex = 5;
			this.txtUnidad.Text = "";
			// 
			// btnCrear
			// 
			this.btnCrear.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
			this.btnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCrear.Location = new System.Drawing.Point(169, 168);
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
			this.btnCancelar.Location = new System.Drawing.Point(281, 168);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(80, 32);
			this.btnCancelar.TabIndex = 7;
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// lblGrupo
			// 
			this.lblGrupo.Location = new System.Drawing.Point(24, 14);
			this.lblGrupo.Name = "lblGrupo";
			this.lblGrupo.Size = new System.Drawing.Size(48, 16);
			this.lblGrupo.TabIndex = 0;
			this.lblGrupo.Text = "Grupo";
			// 
			// cmbGrupo
			// 
			this.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGrupo.Location = new System.Drawing.Point(24, 30);
			this.cmbGrupo.Name = "cmbGrupo";
			this.cmbGrupo.Size = new System.Drawing.Size(152, 21);
			this.cmbGrupo.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(57, 168);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 8;
			this.button1.Text = "&Aceptar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmNuevaVariable
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(418, 207);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.cmbGrupo);
			this.Controls.Add(this.lblGrupo);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnCrear);
			this.Controls.Add(this.txtUnidad);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.lblDescripcion);
			this.Controls.Add(this.lblNombre);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmNuevaVariable";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nueva Variable";
			this.Load += new System.EventHandler(this.frmNuevaVariable_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCrear_Click(object sender, System.EventArgs e)
		{
			txtNombre.Text = txtNombre.Text.Trim();
			txtUnidad.Text = txtUnidad.Text.Trim();
			if(this.cmbGrupo.Items.Count == 0)
			{
				MessageBox.Show("Debe seleccionar un Grupo para crear la \nVariable Característica.", "Atención",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (txtNombre.Text.Equals("")) 
				{
					MessageBox.Show("Debe ingresar un nombre para la Variable Característica.", "Atención",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);			
				}
				else
				{
					if (txtUnidad.Text.Equals("")) 
					{
						MessageBox.Show("Debe ingresar una Unidad para la Variable Característica.", 
							"Atención",	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						try
						{		
							if (!(Util.buscar("VARIABLE_CARACTERISTICA", "nombre", txtNombre.Text, "")))
							{
								string []colunmName = {"nombre", "unidad", "grupo_id"};
								Util.Insert(Util.getDAVar(), "Variables", colunmName, txtNombre.Text, txtUnidad.Text, cmbGrupo.SelectedValue.ToString());
								MessageBox.Show("Se ha creado la Variable Característica exitosamente.", "Variable Característica", 
								MessageBoxButtons.OK, MessageBoxIcon.Information);
								
							}
							else
							{
								MessageBox.Show("El nombre de la Variable Característica ya se encuentra registrado", "Variable Característica", 
									MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						catch(Exception ex)
						{
							MessageBox.Show("Error: " + ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
				        
						this.txtNombre.Clear();
						this.txtUnidad.Clear();
						this.txtNombre.Select();      
					}
				}
			}
		}

		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
		  this.Close();
		}

		private void frmNuevaVariable_Load(object sender, System.EventArgs e)
		{
			ds = Util.getDataSet();
			this.cmbGrupo.DisplayMember = "Grupo.nombre";
			this.cmbGrupo.ValueMember = "Grupo.id";
			this.cmbGrupo.DataSource = ds.DefaultViewManager;
		}

		//boton aceptar
		private void button1_Click(object sender, System.EventArgs e)
		{
			txtNombre.Text = txtNombre.Text.Trim();
			txtUnidad.Text = txtUnidad.Text.Trim();
			if(this.cmbGrupo.Items.Count == 0)
			{
				MessageBox.Show("Debe seleccionar un Grupo para crear la \nVariable Característica.", "Atención",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				if (txtNombre.Text.Equals("")) 
				{
					MessageBox.Show("Debe ingresar un nombre para la Variable Característica.", "Atención",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);			
				}
				else
				{
					if (txtUnidad.Text.Equals("")) 
					{
						MessageBox.Show("Debe ingresar una Unidad para la Variable Característica.", 
							"Atención",	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					else
					{
						try
						{		
							if (!(Util.buscar("VARIABLE_CARACTERISTICA", "nombre", txtNombre.Text, "")))
							{
								string []colunmName = {"nombre", "unidad", "grupo_id"};
								Util.Insert(Util.getDAVar(), "Variables", colunmName, txtNombre.Text, txtUnidad.Text, cmbGrupo.SelectedValue.ToString());
								MessageBox.Show("Se ha creado la Variable Característica exitosamente.", "Variable Característica", 
									MessageBoxButtons.OK, MessageBoxIcon.Information);
								
							}
							else
							{
								MessageBox.Show("El nombre de la Variable Característica ya se encuentra registrado", "Variable Característica", 
									MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							}
						}
						catch(Exception ex)
						{
							MessageBox.Show("Error: " + ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
				        
						this.txtNombre.Clear();
						this.txtUnidad.Clear();
						this.txtNombre.Select();  
						this.Close();
					}
				}
			}
		}

    }
}
