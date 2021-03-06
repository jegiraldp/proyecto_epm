using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace EPM.formularios{
	using EPM.clases;
	public class frmNuevoGrupo : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.Button btnCrear;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button button1;
		private System.ComponentModel.Container components = null;
					
		public frmNuevoGrupo()
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

		#region C�digo generado por el Dise�ador de Windows Forms

		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmNuevoGrupo));
			this.lblNombre = new System.Windows.Forms.Label();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.btnCrear = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblNombre
			// 
			this.lblNombre.Location = new System.Drawing.Point(35, 8);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(48, 16);
			this.lblNombre.TabIndex = 0;
			this.lblNombre.Text = "Nombre";
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(35, 24);
			this.txtNombre.MaxLength = 100;
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(341, 20);
			this.txtNombre.TabIndex = 1;
			this.txtNombre.Text = "";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.Location = new System.Drawing.Point(35, 56);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(64, 16);
			this.lblDescripcion.TabIndex = 2;
			this.lblDescripcion.Text = "Descripci�n";
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(35, 72);
			this.txtDescripcion.MaxLength = 7000;
			this.txtDescripcion.Multiline = true;
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescripcion.Size = new System.Drawing.Size(341, 96);
			this.txtDescripcion.TabIndex = 3;
			this.txtDescripcion.Text = "";
			// 
			// btnCrear
			// 
			this.btnCrear.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
			this.btnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCrear.Location = new System.Drawing.Point(177, 192);
			this.btnCrear.Name = "btnCrear";
			this.btnCrear.Size = new System.Drawing.Size(80, 32);
			this.btnCrear.TabIndex = 4;
			this.btnCrear.Text = "&Agregar";
			this.btnCrear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(290, 192);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(80, 32);
			this.btnCancelar.TabIndex = 5;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(65, 192);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 6;
			this.button1.Text = "&Aceptar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmNuevoGrupo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(434, 239);
			this.Controls.Add(this.button1);
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
			this.Name = "frmNuevoGrupo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Nuevo Grupo";
			this.ResumeLayout(false);

		}
		#endregion
		//boton agregar
		private void btnCrear_Click(object sender, System.EventArgs e)
		{
			this.txtNombre.Text = this.txtNombre.Text.Trim();
			this.txtDescripcion.Text= this.txtDescripcion.Text.Trim();
			if (this.txtNombre.Text.Equals("")) 
			{
				MessageBox.Show("Debe ingresar un nombre para el Grupo.", "Atenci�n",
					             MessageBoxButtons.OK, MessageBoxIcon.Exclamation);			
			}
			else
			{
				if (this.txtDescripcion.Text.Equals("")) 
				{
					MessageBox.Show("Debe ingresar una Descripcion para el Grupo.", 
						"Atenci�n",	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					try
					{
						if (!(Util.buscar("GRUPO", "nombre", txtNombre.Text, "")))
						{
							string []colunmName = {"nombre", "descripcion"};
							Util.Insert(Util.getDAGrupo(), "Grupo", colunmName, txtNombre.Text,txtDescripcion.Text);
							MessageBox.Show("Se ha creado el grupo exitosamente.", "Grupo", 
										  	 MessageBoxButtons.OK, MessageBoxIcon.Information);
					
						}
						else
						{
							MessageBox.Show("El nombre del Grupo ya se encuentra registrado", "Grupo", 
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


		private void btnCancelar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		//boton aceptar
		private void button1_Click(object sender, System.EventArgs e)
		{
			this.txtNombre.Text = this.txtNombre.Text.Trim();
			this.txtDescripcion.Text= this.txtDescripcion.Text.Trim();
			if (this.txtNombre.Text.Equals("")) 
			{
				MessageBox.Show("Debe ingresar un nombre para el Grupo.", "Atenci�n",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);			
			}
			else
			{
				if (this.txtDescripcion.Text.Equals("")) 
				{
					MessageBox.Show("Debe ingresar una Descripcion para el Grupo.", 
						"Atenci�n",	MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					try
					{
						if (!(Util.buscar("GRUPO", "nombre", txtNombre.Text, "")))
						{
							string []colunmName = {"nombre", "descripcion"};
							Util.Insert(Util.getDAGrupo(), "Grupo", colunmName, txtNombre.Text,txtDescripcion.Text);
							MessageBox.Show("Se ha creado el grupo exitosamente.", "Grupo", 
								MessageBoxButtons.OK, MessageBoxIcon.Information);
					
						}
						else
						{
							MessageBox.Show("El nombre del Grupo ya se encuentra registrado", "Grupo", 
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
					this.Close();            
				}
			}
		}
    }
}
