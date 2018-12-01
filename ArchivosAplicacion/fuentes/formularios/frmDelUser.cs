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

	public class frmDelUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cmbUsuario;
		private DataSet ds = null;
		private System.Windows.Forms.Button DelButton;
		private System.Windows.Forms.TextBox txtIDUsuario;
		private System.Windows.Forms.Button ButCancel;
		private System.ComponentModel.Container components = null;

		public frmDelUser()
		{
			
			InitializeComponent();
			this.listU();
			
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

		//lista los usuarios de la base de datos
		public void listU()
		{
			try
			{
				ds = Util.getDataSet();
				DataView dv = ds.Tables["Usuario"].DefaultView;
				this.cmbUsuario.DisplayMember = "login";
				this.cmbUsuario.ValueMember = "id";
				this.cmbUsuario.DataSource = dv;
							
			}
			catch
			{
				this.cmbUsuario.DataSource = null;
				this.cmbUsuario.Items.Clear();
			}
		
		}





		#region Código generado por el Diseñador de Windows Forms
		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDelUser));
			this.cmbUsuario = new System.Windows.Forms.ComboBox();
			this.DelButton = new System.Windows.Forms.Button();
			this.txtIDUsuario = new System.Windows.Forms.TextBox();
			this.ButCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cmbUsuario
			// 
			this.cmbUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbUsuario.Location = new System.Drawing.Point(29, 32);
			this.cmbUsuario.Name = "cmbUsuario";
			this.cmbUsuario.Size = new System.Drawing.Size(192, 21);
			this.cmbUsuario.TabIndex = 0;
			this.cmbUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbUsuario_SelectedIndexChanged);
			// 
			// DelButton
			// 
			this.DelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.DelButton.Image = ((System.Drawing.Image)(resources.GetObject("DelButton.Image")));
			this.DelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.DelButton.Location = new System.Drawing.Point(40, 76);
			this.DelButton.Name = "DelButton";
			this.DelButton.Size = new System.Drawing.Size(64, 23);
			this.DelButton.TabIndex = 1;
			this.DelButton.Text = "&Eliminar";
			this.DelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
			// 
			// txtIDUsuario
			// 
			this.txtIDUsuario.Location = new System.Drawing.Point(300, 64);
			this.txtIDUsuario.Name = "txtIDUsuario";
			this.txtIDUsuario.Size = new System.Drawing.Size(32, 20);
			this.txtIDUsuario.TabIndex = 3;
			this.txtIDUsuario.Text = "";
			// 
			// ButCancel
			// 
			this.ButCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.ButCancel.Image = ((System.Drawing.Image)(resources.GetObject("ButCancel.Image")));
			this.ButCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.ButCancel.Location = new System.Drawing.Point(144, 76);
			this.ButCancel.Name = "ButCancel";
			this.ButCancel.Size = new System.Drawing.Size(64, 23);
			this.ButCancel.TabIndex = 4;
			this.ButCancel.Text = "&Cancelar";
			this.ButCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.ButCancel.Click += new System.EventHandler(this.ButCancel_Click);
			// 
			// frmDelUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(250, 111);
			this.Controls.Add(this.ButCancel);
			this.Controls.Add(this.txtIDUsuario);
			this.Controls.Add(this.DelButton);
			this.Controls.Add(this.cmbUsuario);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmDelUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Eliminar Usuario";
			this.ResumeLayout(false);

		}
		#endregion

		private void CancelButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void DelButton_Click(object sender, System.EventArgs e)
		{
			DialogResult resultado = new DialogResult();
			resultado = MessageBox.Show ("Realmente desea Eliminar el usuario " +this.cmbUsuario.Text+ " del sistema?", "Confirmar Eliminar", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
			if (resultado == DialogResult.Yes)
			{
				SqlConnection conn = ConexionDB.getConnection();
				SqlCommand sqlcmddel = conn.CreateCommand();
				string sqlDel = "DELETE usuario WHERE id ="+ this.txtIDUsuario.Text;  
				sqlcmddel.CommandText = sqlDel;
				sqlcmddel.ExecuteNonQuery();	
				Util.initializeDataset();
				MessageBox.Show("Se ha eliminado el usuario  " +this.cmbUsuario.Text+ "  del sistema ", "Usuarios", 
					MessageBoxButtons.OK, MessageBoxIcon.Information);	
				this.Close();
			}
			else return;
			
		}

		private void cmbUsuario_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.txtIDUsuario.Text = this.cmbUsuario.SelectedValue.ToString();
		}

		private void ButCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		
	}
}
