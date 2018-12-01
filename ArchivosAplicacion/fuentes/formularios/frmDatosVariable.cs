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
	public class frmDatosVariable : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmbVar;
		private System.Windows.Forms.Label lblVariableCarac;
		private System.Windows.Forms.ComboBox cmbGrupo;
		private System.Windows.Forms.Label lblGrupo;
		private System.Windows.Forms.DateTimePicker dtFecha;
		private System.Windows.Forms.Label lblFecha;
		private System.Windows.Forms.TextBox txtResponsable;
		private System.Windows.Forms.Label lblResponsable;
		private System.Windows.Forms.Label lblValor;
		private System.Windows.Forms.TextBox txtValor;
		private System.Windows.Forms.Label lblCriterio;
		private System.Windows.Forms.TextBox txtCriterio;
		private System.Windows.Forms.Label lblFuente;
		private System.Windows.Forms.TextBox txtFuente;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnCrear;
		private System.Windows.Forms.TextBox txtDescripcion;

		private DataSet ds = null;
		private System.Windows.Forms.TextBox txtUnidad;
		private bool ok = false;
		private string strHeader;
		private bool insert;
		private int pk, fk ;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lblUnidad;

		private System.ComponentModel.Container components = null;

		public frmDatosVariable(int fk , string h)
		{
			InitializeComponent();
			ds = Util.getDataSet();
			grupoVariableCarac();
			this.fk = fk;
			this.strHeader = h;
			insert = true;
		}
		//editar
		public frmDatosVariable(int pos)
		{
			InitializeComponent();
			ds = Util.getDataSet();
			grupoVariableCarac();
			DataRow dr = ds.Tables["Datos"].Rows[pos];
			cmbGrupo.Text = dr[0].ToString();
			cmbVar.Text = dr[1].ToString();
			txtUnidad.Text = dr[2].ToString();
			pk = int.Parse(dr[3].ToString());
			dtFecha.Value = DateTime.Parse(dr[4].ToString());
			txtResponsable.Text = dr[5].ToString();
			txtValor.Text = dr[6].ToString();
			txtCriterio.Text = dr[7].ToString();
			txtDescripcion.Text = dr[8].ToString();
			txtFuente.Text = dr[9].ToString();		
			insert = false;
			this.btnCrear.Enabled = false;
            this.btnCrear.Visible = false;			
			this.dtFecha.Enabled = false;
			this.button1.Location = new Point (264, 493);
			this.btnCancelar.Location = new Point (424, 493);
			this.cmbVar.Enabled = false;
			this.cmbGrupo.Enabled = false;
		}

		//para el caso de visualizar
		public frmDatosVariable(int pos, bool txt)
		{
			txt = true;
			InitializeComponent();
			ds = Util.getDataSet();
			grupoVariableCarac();
			DataRow dr = ds.Tables["Datos"].Rows[pos];
			cmbGrupo.Text = dr[0].ToString();
			cmbVar.Text = dr[1].ToString();
			txtUnidad.Text = dr[2].ToString();
			pk = int.Parse(dr[3].ToString());
			dtFecha.Value = DateTime.Parse(dr[4].ToString());
			txtResponsable.Text = dr[5].ToString();
			txtValor.Text = dr[6].ToString();
			txtCriterio.Text = dr[7].ToString();
			txtDescripcion.Text = dr[8].ToString();
			txtFuente.Text = dr[9].ToString();		
			this.btnCrear.Enabled = false;
			this.dtFecha.Enabled = false;
			this.button1.Enabled = false;
			this.button1.Visible = false;
			this.txtCriterio.ReadOnly = txt;
			this.txtDescripcion.ReadOnly = txt;
			this.txtFuente.ReadOnly = txt;
			this.txtResponsable.ReadOnly = txt;
			this.txtUnidad.ReadOnly = txt;
			this.txtValor.ReadOnly = txt;
			this.cmbVar.Enabled = false;
			this.cmbGrupo.Enabled = false;
			this.btnCrear.Enabled = false;
			this.btnCrear.Visible = false;			
			this.dtFecha.Enabled = false;
			this.btnCancelar.Location = new Point (345, 493);
			
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDatosVariable));
			this.cmbVar = new System.Windows.Forms.ComboBox();
			this.lblVariableCarac = new System.Windows.Forms.Label();
			this.cmbGrupo = new System.Windows.Forms.ComboBox();
			this.lblGrupo = new System.Windows.Forms.Label();
			this.dtFecha = new System.Windows.Forms.DateTimePicker();
			this.lblFecha = new System.Windows.Forms.Label();
			this.txtResponsable = new System.Windows.Forms.TextBox();
			this.lblResponsable = new System.Windows.Forms.Label();
			this.lblValor = new System.Windows.Forms.Label();
			this.txtValor = new System.Windows.Forms.TextBox();
			this.lblCriterio = new System.Windows.Forms.Label();
			this.txtCriterio = new System.Windows.Forms.TextBox();
			this.lblFuente = new System.Windows.Forms.Label();
			this.txtFuente = new System.Windows.Forms.TextBox();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnCrear = new System.Windows.Forms.Button();
			this.txtUnidad = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.lblUnidad = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cmbVar
			// 
			this.cmbVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVar.Location = new System.Drawing.Point(223, 32);
			this.cmbVar.Name = "cmbVar";
			this.cmbVar.Size = new System.Drawing.Size(152, 21);
			this.cmbVar.TabIndex = 7;
			// 
			// lblVariableCarac
			// 
			this.lblVariableCarac.Location = new System.Drawing.Point(223, 16);
			this.lblVariableCarac.Name = "lblVariableCarac";
			this.lblVariableCarac.Size = new System.Drawing.Size(120, 16);
			this.lblVariableCarac.TabIndex = 6;
			this.lblVariableCarac.Text = "Variable Característica";
			// 
			// cmbGrupo
			// 
			this.cmbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGrupo.Location = new System.Drawing.Point(28, 32);
			this.cmbGrupo.Name = "cmbGrupo";
			this.cmbGrupo.Size = new System.Drawing.Size(152, 21);
			this.cmbGrupo.TabIndex = 5;
			// 
			// lblGrupo
			// 
			this.lblGrupo.Location = new System.Drawing.Point(28, 16);
			this.lblGrupo.Name = "lblGrupo";
			this.lblGrupo.Size = new System.Drawing.Size(48, 16);
			this.lblGrupo.TabIndex = 4;
			this.lblGrupo.Text = "Grupo";
			// 
			// dtFecha
			// 
			this.dtFecha.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtFecha.Cursor = System.Windows.Forms.Cursors.SizeNS;
			this.dtFecha.CustomFormat = "yyyy/MM/dd";
			this.dtFecha.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
			this.dtFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtFecha.Location = new System.Drawing.Point(576, 32);
			this.dtFecha.Name = "dtFecha";
			this.dtFecha.Size = new System.Drawing.Size(136, 21);
			this.dtFecha.TabIndex = 8;
			this.dtFecha.Value = new System.DateTime(2006, 1, 26, 0, 0, 0, 0);
			// 
			// lblFecha
			// 
			this.lblFecha.Location = new System.Drawing.Point(576, 16);
			this.lblFecha.Name = "lblFecha";
			this.lblFecha.Size = new System.Drawing.Size(120, 16);
			this.lblFecha.TabIndex = 9;
			this.lblFecha.Text = "Fecha";
			// 
			// txtResponsable
			// 
			this.txtResponsable.Location = new System.Drawing.Point(136, 96);
			this.txtResponsable.Multiline = true;
			this.txtResponsable.Name = "txtResponsable";
			this.txtResponsable.Size = new System.Drawing.Size(512, 49);
			this.txtResponsable.TabIndex = 10;
			this.txtResponsable.Text = "";
			// 
			// lblResponsable
			// 
			this.lblResponsable.Location = new System.Drawing.Point(64, 112);
			this.lblResponsable.Name = "lblResponsable";
			this.lblResponsable.Size = new System.Drawing.Size(72, 16);
			this.lblResponsable.TabIndex = 11;
			this.lblResponsable.Text = "Responsable";
			// 
			// lblValor
			// 
			this.lblValor.Location = new System.Drawing.Point(80, 176);
			this.lblValor.Name = "lblValor";
			this.lblValor.Size = new System.Drawing.Size(32, 16);
			this.lblValor.TabIndex = 13;
			this.lblValor.Text = "Valor";
			// 
			// txtValor
			// 
			this.txtValor.Location = new System.Drawing.Point(136, 160);
			this.txtValor.Multiline = true;
			this.txtValor.Name = "txtValor";
			this.txtValor.Size = new System.Drawing.Size(512, 49);
			this.txtValor.TabIndex = 12;
			this.txtValor.Text = "";
			// 
			// lblCriterio
			// 
			this.lblCriterio.Location = new System.Drawing.Point(72, 240);
			this.lblCriterio.Name = "lblCriterio";
			this.lblCriterio.Size = new System.Drawing.Size(48, 16);
			this.lblCriterio.TabIndex = 15;
			this.lblCriterio.Text = "Criterio";
			// 
			// txtCriterio
			// 
			this.txtCriterio.Location = new System.Drawing.Point(136, 216);
			this.txtCriterio.Multiline = true;
			this.txtCriterio.Name = "txtCriterio";
			this.txtCriterio.Size = new System.Drawing.Size(512, 49);
			this.txtCriterio.TabIndex = 14;
			this.txtCriterio.Text = "";
			// 
			// lblFuente
			// 
			this.lblFuente.Location = new System.Drawing.Point(72, 280);
			this.lblFuente.Name = "lblFuente";
			this.lblFuente.Size = new System.Drawing.Size(48, 16);
			this.lblFuente.TabIndex = 17;
			this.lblFuente.Text = "Fuente";
			// 
			// txtFuente
			// 
			this.txtFuente.Location = new System.Drawing.Point(136, 272);
			this.txtFuente.Multiline = true;
			this.txtFuente.Name = "txtFuente";
			this.txtFuente.Size = new System.Drawing.Size(512, 49);
			this.txtFuente.TabIndex = 16;
			this.txtFuente.Text = "";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.Location = new System.Drawing.Point(56, 376);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(64, 16);
			this.lblDescripcion.TabIndex = 18;
			this.lblDescripcion.Text = "Descripción";
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(136, 336);
			this.txtDescripcion.Multiline = true;
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtDescripcion.Size = new System.Drawing.Size(512, 120);
			this.txtDescripcion.TabIndex = 19;
			this.txtDescripcion.Text = "";
			// 
			// btnCancelar
			// 
			this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
			this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnCancelar.Location = new System.Drawing.Point(488, 493);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(72, 32);
			this.btnCancelar.TabIndex = 21;
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
			this.btnCrear.Location = new System.Drawing.Point(346, 493);
			this.btnCrear.Name = "btnCrear";
			this.btnCrear.Size = new System.Drawing.Size(72, 32);
			this.btnCrear.TabIndex = 20;
			this.btnCrear.Text = "&Agregar";
			this.btnCrear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
			// 
			// txtUnidad
			// 
			this.txtUnidad.Location = new System.Drawing.Point(400, 32);
			this.txtUnidad.Name = "txtUnidad";
			this.txtUnidad.ReadOnly = true;
			this.txtUnidad.Size = new System.Drawing.Size(144, 20);
			this.txtUnidad.TabIndex = 22;
			this.txtUnidad.Text = "";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.button1.Location = new System.Drawing.Point(200, 493);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 32);
			this.button1.TabIndex = 23;
			this.button1.Text = "&Aceptar";
			this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// lblUnidad
			// 
			this.lblUnidad.Location = new System.Drawing.Point(400, 16);
			this.lblUnidad.Name = "lblUnidad";
			this.lblUnidad.Size = new System.Drawing.Size(120, 16);
			this.lblUnidad.TabIndex = 25;
			this.lblUnidad.Text = "Unidad - Variable";
			// 
			// frmDatosVariable
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.ClientSize = new System.Drawing.Size(762, 551);
			this.Controls.Add(this.lblUnidad);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtUnidad);
			this.Controls.Add(this.txtDescripcion);
			this.Controls.Add(this.txtFuente);
			this.Controls.Add(this.txtCriterio);
			this.Controls.Add(this.txtValor);
			this.Controls.Add(this.txtResponsable);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnCrear);
			this.Controls.Add(this.lblDescripcion);
			this.Controls.Add(this.lblFuente);
			this.Controls.Add(this.lblCriterio);
			this.Controls.Add(this.lblValor);
			this.Controls.Add(this.lblResponsable);
			this.Controls.Add(this.lblFecha);
			this.Controls.Add(this.dtFecha);
			this.Controls.Add(this.cmbVar);
			this.Controls.Add(this.lblVariableCarac);
			this.Controls.Add(this.cmbGrupo);
			this.Controls.Add(this.lblGrupo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmDatosVariable";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Datos Variable";
			this.Load += new System.EventHandler(this.frmDatosVariable_Load);
			this.ResumeLayout(false);

		}
		#endregion

		
		
		private void grupoVariableCarac()
		{
			this.dtFecha.Format = DateTimePickerFormat.Custom;
			this.dtFecha.CustomFormat = "yyyy'/'MM'/'dd";
			this.cmbGrupo.DisplayMember = "Grupo.nombre";
			this.cmbGrupo.ValueMember = "Grupo.id";
			this.cmbGrupo.DataSource = ds;
			this.cmbVar.DisplayMember = "Grupo.Variables.nombre";
			this.cmbVar.ValueMember = "Grupo.Variables.id";
			this.cmbVar.DataSource = ds;
			this.txtUnidad.DataBindings.Add("Text",ds, "Grupo.Variables.unidad"); //Para la Unidad
		}
		// boton agregar 
		private void btnCrear_Click(object sender, System.EventArgs e)
		{
			ok = false;
			this.txtResponsable.Text = this.txtResponsable.Text.Trim();
			this.txtValor.Text = this.txtValor.Text.Trim();
			this.txtCriterio.Text = this.txtCriterio.Text.Trim();
			this.txtFuente.Text = this.txtFuente.Text.Trim();
			this.txtDescripcion.Text = this.txtDescripcion.Text.Trim();
			if(cmbVar.Items.Count == 0)
			{
				MessageBox.Show("Debe seleccionar una Variable Característica para crear el \nDato Variable.", "Atención",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				ok = false;
			}
			else
			{
				if ((this.txtResponsable.Text.Equals("")) ||
					(this.txtValor.Text.Equals(""))       ||
					(this.txtCriterio.Text.Equals(""))	  ||
					(this.txtFuente.Text.Equals(""))	  ||
					(this.txtDescripcion.Text.Equals("")))
				{
					MessageBox.Show("Los Campos: Responsable, Valor, Criterio, Fuente y Descripción son Obligatorios.", "Atención",
						MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					ok = false;
				}
				else
				{
					SqlCommand sql = ConexionDB.getConnection().CreateCommand();
					if (this.insert)
					{
						string sqlInsert = "INSERT INTO Datos_Variable(fecha, responsable, valor, criterio, descripcion, fuente, var_car_id, " + strHeader + ") VALUES('";
						sqlInsert += dtFecha.Value.ToShortDateString() + "','" + txtResponsable.Text +"','" + txtValor.Text + "','" + txtCriterio.Text + "','" + txtDescripcion.Text + "','" + txtFuente.Text + "'," + cmbVar.SelectedValue.ToString() + "," + fk.ToString() + ")";
						sql.CommandText = sqlInsert;
						sql.ExecuteNonQuery();
						MessageBox.Show("Se ha insertado los datos con éxito.", "Datos Variable", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);	
						ok = true;

					}				
					else //Edición
					{
						string []colunmName = {"fecha", "responsable", "valor", "criterio", "descripcion", "fuente", "var_car_id"};
						Util.Update( Util.getDADatVar(), "Datos", pk, colunmName, dtFecha.Value.ToShortDateString(), txtResponsable.Text, txtValor.Text, txtCriterio.Text, txtDescripcion.Text, txtFuente.Text, cmbVar.SelectedValue.ToString());
						MessageBox.Show("Se han guardado los cambios realizados en el Dato Variable exitosamente.", "Dato Variable", 
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						ok = true;
					}					
					this.txtResponsable.Clear();
					this.txtValor.Clear();
					this.txtCriterio.Clear();
					this.txtFuente.Clear();
					this.txtDescripcion.Clear();
					this.txtResponsable.Select();
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
			btnCrear_Click(null,null);
			if(ok)
			{
				this.Close();
			}
		}

		private void frmDatosVariable_Load(object sender, System.EventArgs e)
		{
			this.dtFecha.Format = DateTimePickerFormat.Custom;
			this.dtFecha.CustomFormat = "yyyy'/'MM'/'dd";
		}


	}
}

