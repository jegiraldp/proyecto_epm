using System;
using System.Drawing;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.rtf;

namespace EPM.formularios
{
	using EPM.clases;
	public class frmReportes : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblReporte;
		private System.Windows.Forms.CheckBox chkDes;
		private System.Windows.Forms.CheckBox chkVar;
		private System.Windows.Forms.CheckBox chkArc;
		private System.Windows.Forms.Button btnGenerar;
		private System.ComponentModel.Container components = null;
		

		private string[] header;
		private string[] nombre;
		private string des;
		private DataView dvDatos;
		private DataView dv2Datos;
		private DataView dv3Datos;
		private System.Windows.Forms.Button btnRTF;
		private DataView dvFiles;

		public frmReportes(string[] header, string[] nombre, string des, DataView dvDatos, DataView dvFiles)
		{
			InitializeComponent();
			
			this.header = header;
			this.nombre = nombre;
			this.des = des;
			this.dvDatos = dvDatos;
			this.dv2Datos = dv2Datos;
			this.dv3Datos = dv3Datos;
			this.dvFiles = dvFiles;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmReportes));
			this.lblReporte = new System.Windows.Forms.Label();
			this.chkDes = new System.Windows.Forms.CheckBox();
			this.chkVar = new System.Windows.Forms.CheckBox();
			this.chkArc = new System.Windows.Forms.CheckBox();
			this.btnGenerar = new System.Windows.Forms.Button();
			this.btnRTF = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblReporte
			// 
			this.lblReporte.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblReporte.Location = new System.Drawing.Point(35, 24);
			this.lblReporte.Name = "lblReporte";
			this.lblReporte.Size = new System.Drawing.Size(352, 24);
			this.lblReporte.TabIndex = 0;
			this.lblReporte.Text = "Seleccione los ítems que desea incluir en el reporte";
			// 
			// chkDes
			// 
			this.chkDes.Location = new System.Drawing.Point(80, 72);
			this.chkDes.Name = "chkDes";
			this.chkDes.Size = new System.Drawing.Size(88, 16);
			this.chkDes.TabIndex = 1;
			this.chkDes.Text = "Descripción";
			// 
			// chkVar
			// 
			this.chkVar.Location = new System.Drawing.Point(184, 72);
			this.chkVar.Name = "chkVar";
			this.chkVar.Size = new System.Drawing.Size(80, 16);
			this.chkVar.TabIndex = 2;
			this.chkVar.Text = "Variables";
			// 
			// chkArc
			// 
			this.chkArc.Location = new System.Drawing.Point(272, 72);
			this.chkArc.Name = "chkArc";
			this.chkArc.Size = new System.Drawing.Size(64, 16);
			this.chkArc.TabIndex = 3;
			this.chkArc.Text = "Archivos";
			// 
			// btnGenerar
			// 
			this.btnGenerar.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.btnGenerar.Location = new System.Drawing.Point(64, 128);
			this.btnGenerar.Name = "btnGenerar";
			this.btnGenerar.Size = new System.Drawing.Size(104, 32);
			this.btnGenerar.TabIndex = 4;
			this.btnGenerar.Text = "Reporte en PDF";
			this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
			// 
			// btnRTF
			// 
			this.btnRTF.BackColor = System.Drawing.SystemColors.ControlLight;
			this.btnRTF.Location = new System.Drawing.Point(232, 128);
			this.btnRTF.Name = "btnRTF";
			this.btnRTF.Size = new System.Drawing.Size(104, 32);
			this.btnRTF.TabIndex = 5;
			this.btnRTF.Text = "Reporte en RTF";
			this.btnRTF.Click += new System.EventHandler(this.btnRTF_Click);
			// 
			// frmReportes
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Info;
			this.ClientSize = new System.Drawing.Size(424, 183);
			this.Controls.Add(this.btnRTF);
			this.Controls.Add(this.btnGenerar);
			this.Controls.Add(this.chkArc);
			this.Controls.Add(this.chkVar);
			this.Controls.Add(this.chkDes);
			this.Controls.Add(this.lblReporte);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmReportes";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generar Reporte";
			this.Load += new System.EventHandler(this.frmReportes_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmReportes_Load(object sender, System.EventArgs e)
		{
			chkDes.Checked = true;			
			//Para las Variables Asociadas.
			if (dvDatos == null) chkVar.Enabled = false;
			else
			{
				if (dvDatos.Count > 0) chkVar.Checked = true;
				else chkVar.Enabled = false;			
			}
			//Para los Archivos Asociados.
			if (dvFiles == null) chkArc.Enabled = false;
			else
			{
				if (dvFiles.Count > 0) chkArc.Checked = true;
				else chkArc.Enabled = false;
			}
			this.btnGenerar.Select();	
		}

		private void btnGenerar_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			string name = getNombre();
			Document document = new Document(PageSize.LETTER.Rotate(), 50, 50, 80, 50);
			try 
			{
				PdfWriter.GetInstance(document, new FileStream(name, FileMode.Create));
				document.Open();
				encabezado(document);
				document.Close();
				Process.Start(name);
			}
			catch(DocumentException de) 
			{
				MessageBox.Show("Error en la generación del reporte: " + de.Message);
			}
			catch(IOException ioe) 
			{
				MessageBox.Show("Error en la generación del reporte: " + ioe.Message);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message,"EPM Alternativas",	MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
			
			MessageBox.Show("Se ha generado el reporte en formato PDF","BD EEPPM ALTERNATIVAS", MessageBoxButtons.OK, MessageBoxIcon.Information);
			this.Close();
		}
		#region Procedimientos que llevan a cabo la generación del PDF
		public void encabezado(Document document)
		{
			Table table = new Table(4);
			table.WidthPercentage = 100;
			table.Padding = 2;
			table.DefaultHorizontalAlignment = Element.ALIGN_JUSTIFIED;//.ALIGN_CENTER;
			
			//Logo
			iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("..\\Imagenes\\imgPresentacion.JPG");
			Cell cellImg  = new Cell();
			cellImg.Rowspan = 3;
			cellImg.Add(img);
			table.AddCell(cellImg);

			//Título
			BaseFont helvetica = BaseFont.CreateFont("Helvetica", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(helvetica, 10, iTextSharp.text.Font.BOLD);
			Cell cTitle = new Cell(new Chunk("\n"));
			cTitle.Colspan = 2;
			cTitle.Rowspan = 3;
			cTitle.Add(new Phrase("BASE DE DATOS\nEEPPM ALTERNATIVAS", fontTitle));
			table.AddCell(cTitle);
			
			//Fecha
			iTextSharp.text.Font font = new iTextSharp.text.Font(helvetica, 12, iTextSharp.text.Font.BOLD);
			Cell cFecha = new Cell(new Phrase("Fecha: ", font));
			cFecha.Add(new Phrase(DateTime.Today.ToShortDateString()));
			table.AddCell(cFecha);
			
			//Hora
			Cell cHora = new Cell(new Phrase("Hora: ", font));
			cHora.Add(new Phrase(DateTime.Now.ToShortTimeString()));
			table.AddCell(cHora);
			
			//Usuario
			Cell cUser = new Cell(new Phrase("Usuario: ",font));
			cUser.Add(new Phrase(User.getUser()));
			table.AddCell(cUser);
            
			document.Add(table);
			Phrase myPhrase = new Phrase("\n\n");
			document.Add(myPhrase);

			//Tipo de Informe.
			Table tableTitle = new Table(1);
			tableTitle.DefaultHorizontalAlignment = Element.ALIGN_JUSTIFIED;
			tableTitle.BorderWidth = 0.0f;
			tableTitle.DefaultCellBorder = 0;
			tableTitle.WidthPercentage = 100;
			int i = 0;
			while(i < 4)
			{
				if(header[i] != null)
				{
					Cell cellTitle = new Cell(new Phrase("- " + header[i] + ":", fontTitle));
					tableTitle.AddCell(cellTitle);
					Cell cellName = new Cell(new Phrase(nombre[i]));
					tableTitle.AddCell(cellName);
					i++;
				}else break;
			}
			document.Add(tableTitle);
			//Descripción
			if(chkDes.Checked) reportGenerator(document, fontTitle);

			//Variables Asociadas
			if(chkVar.Checked) addDatosVariable(document, fontTitle);

			//Archivos Asociados
			if(this.chkArc.Checked) addFiles(document,fontTitle);
		}
		
		public void reportGenerator(Document document, iTextSharp.text.Font fontTitle)
		{
			Phrase pDes;
			Table table = new Table(1);
			table.DefaultHorizontalAlignment = Element.ALIGN_JUSTIFIED;
			table.BorderWidth = 0.0f;
			table.DefaultCellBorder = 0;
			table.WidthPercentage = 100;

			if(header.Equals("Variable Característica")) pDes = new Phrase("- Unidad:", fontTitle);
			else pDes = new Phrase("- Descripción:", fontTitle);
			
			Cell cellDes = new Cell(pDes);
			table.AddCell(cellDes);
			Phrase myPhrase = new Phrase(des);
            Cell cell = new Cell(myPhrase);          		
			table.AddCell(cell);
			document.Add(table);			
		}

		public void addDatosVariable(Document document, iTextSharp.text.Font fontTitle)
		{
			document.Add(new Phrase("\n- Variables Asociadas:", fontTitle));
			PdfPTable dataTable = new PdfPTable(2);
			dataTable.DefaultCell.Padding = 2;
			float[] headerWidths = {15,70}; 
			dataTable.SetWidths(headerWidths);
			dataTable.WidthPercentage = 100;             
			dataTable.DefaultCell.BorderWidth = 1;
			dataTable.DefaultCell.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
			dataTable.DefaultCell.GrayFill = 0.7f;
			int j = 0; 
			float color = 0.0f;
			foreach (DataRowView dv in dvDatos)
			{
				if (j % 2 == 0) color = 0.9f;
				else color = 0.0f;
				dataTable.DefaultCell.GrayFill = 0.7f;dataTable.AddCell("Grupo");
				dataTable.DefaultCell.GrayFill = color;dataTable.AddCell(dv["nombreg"].ToString());
				
				dataTable.DefaultCell.GrayFill = 0.7f;dataTable.AddCell("Variable");
				dataTable.DefaultCell.GrayFill = color;dataTable.AddCell(dv["nombrev"].ToString());
				
				dataTable.DefaultCell.GrayFill = 0.7f;dataTable.AddCell("Unidad");
				dataTable.DefaultCell.GrayFill = color;dataTable.AddCell(dv["unidad"].ToString());
				
				dataTable.DefaultCell.GrayFill = 0.7f;dataTable.AddCell("Fecha");
				dataTable.DefaultCell.GrayFill = color;dataTable.AddCell(dv["fecha"].ToString());

				dataTable.DefaultCell.GrayFill = 0.7f;dataTable.AddCell("Responsable");
				dataTable.DefaultCell.GrayFill = color;dataTable.AddCell(dv["responsable"].ToString());

				dataTable.DefaultCell.GrayFill = 0.7f;dataTable.AddCell("Valor");
				dataTable.DefaultCell.GrayFill = color;dataTable.AddCell(dv["valor"].ToString());

				dataTable.DefaultCell.GrayFill = 0.7f;dataTable.AddCell("Criterio");
				dataTable.DefaultCell.GrayFill = color;dataTable.AddCell(dv["criterio"].ToString());

				dataTable.DefaultCell.GrayFill = 0.7f;dataTable.AddCell("Descripción");
				dataTable.DefaultCell.GrayFill = color;dataTable.AddCell(dv["descripcion"].ToString());

				dataTable.DefaultCell.GrayFill = 0.7f;dataTable.AddCell("Fuente");
				dataTable.DefaultCell.GrayFill = color;dataTable.AddCell(dv["fuente"].ToString());

				dataTable.DefaultCell.GrayFill = 1.0f;
				dataTable.AddCell("\n");
				dataTable.AddCell("\n");
				j++;
			}
			
			document.Add(dataTable);
		}


		public void addFiles(Document document, iTextSharp.text.Font fontTitle)
		{
			document.Add(new Phrase("\n- Archivos Asociados:", fontTitle));
			PdfPTable dataTable = new PdfPTable(5);            
			dataTable.DefaultCell.Padding = 3;
			float[] headerWidths = {9, 9, 9, 11, 11}; 
			dataTable.SetWidths(headerWidths);
			dataTable.WidthPercentage = 100;             
			dataTable.DefaultCell.BorderWidth = 2;
			dataTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
			dataTable.DefaultCell.GrayFill = 0.7f;
			dataTable.AddCell("Fecha");
			dataTable.AddCell("Autor");
			dataTable.AddCell("Título");
			dataTable.AddCell("Descripción");
			dataTable.AddCell("Ruta");
			dataTable.HeaderRows = 1;
			dataTable.DefaultCell.BorderWidth = 1;
			int j = 1;
			foreach (DataRowView dv in dvFiles)
			{
				if (j % 2 == 0) dataTable.DefaultCell.GrayFill = 0.9f;
				else dataTable.DefaultCell.GrayFill = 0.0f;
				dataTable.AddCell(dv["fecha"].ToString());
				dataTable.AddCell(dv["autor"].ToString());
				dataTable.AddCell(dv["titulo"].ToString());
				dataTable.AddCell(dv["descripcion"].ToString());
				dataTable.AddCell(dv["ruta"].ToString());
				j++;
			}
			document.Add(dataTable);
		}
#endregion


        #region Procedimientos que llevan a cabo la generación del RTF
		public void encabezadoRTF(Document document)
		{
			Table table = new Table(4);
			table.WidthPercentage = 100;
			table.Padding = 2;
			table.DefaultHorizontalAlignment = Element.ALIGN_CENTER;
		
			
			//Logo
			iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("..\\Imagenes\\imgPresentacion.JPG");
			Cell cellImg  = new Cell();
			cellImg.Rowspan = 3;
			cellImg.Add(img);
			table.AddCell(cellImg);

			//Título
			BaseFont helvetica = BaseFont.CreateFont("Helvetica", BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			iTextSharp.text.Font fontTitle = new iTextSharp.text.Font(helvetica, 10, iTextSharp.text.Font.BOLD);
			Cell cTitle = new Cell(new Chunk("\n"));
			cTitle.Colspan = 2;
			cTitle.Rowspan = 3;
			cTitle.Add(new Phrase("REPORTE\nBASE DE DATOS\nEEPPM ALTERNATIVAS", fontTitle));
			table.AddCell(cTitle);
			
			//Fecha
			iTextSharp.text.Font font = new iTextSharp.text.Font(helvetica, 12, iTextSharp.text.Font.BOLD);
			Cell cFecha = new Cell(new Phrase("Fecha: ", font));
			cFecha.Add(new Phrase(DateTime.Today.ToShortDateString()));
			table.AddCell(cFecha);
			
			//Hora
			Cell cHora = new Cell(new Phrase("Hora: ", font));
			cHora.Add(new Phrase(DateTime.Now.ToShortTimeString()));
			table.AddCell(cHora);
			
			//Usuario
			Cell cUser = new Cell(new Phrase("Usuario: ",font));
			cUser.Add(new Phrase(User.getUser()));
			table.AddCell(cUser);
            
			document.Add(table);
			Phrase myPhrase = new Phrase("\n\n");
			document.Add(myPhrase);

			//Tipo de Informe.
			Table tableTitle = new Table(1);
			tableTitle.DefaultHorizontalAlignment = Element.ALIGN_JUSTIFIED;
			tableTitle.BorderWidth = 0.0f;
			table.DefaultCellBorderWidth = 0;
			tableTitle.DefaultCellBorder = 0;
			tableTitle.WidthPercentage = 100;
			int i = 0;
			while(i < 4)
			{
				if(header[i] != null)
				{
					Cell cellTitle = new Cell(new Phrase("- " + header[i] + ":", fontTitle));
					tableTitle.AddCell(cellTitle);
					Cell cellName = new Cell(new Phrase(nombre[i]));
					tableTitle.AddCell(cellName);
					i++;
				}else break;
			}
			document.Add(tableTitle);

			//Descripción
			if(chkDes.Checked) reportGeneratorRTF(document, fontTitle);

			//Variables Asociadas
			if(chkVar.Checked) addDatosVariableRTF(document, fontTitle);

			//Archivos Asociados
			if(this.chkArc.Checked) addFilesRTF(document,fontTitle);
		}
		
		public void reportGeneratorRTF(Document document, iTextSharp.text.Font fontTitle)
		{
			Phrase pDes;
			Table table = new Table(1);
			table.DefaultHorizontalAlignment = Element.ALIGN_JUSTIFIED;
			table.BorderWidth = 0.0f;
			table.DefaultCellBorderWidth = 0;
			table.WidthPercentage = 100;

			if(header.Equals("Variable Característica")) pDes = new Phrase("- Unidad:", fontTitle);
			else pDes = new Phrase("- Descripción:", fontTitle);
			
			Cell cellDes = new Cell(pDes);
			table.AddCell(cellDes);
			Phrase myPhrase = new Phrase(des);
			Cell cell = new Cell(myPhrase);          		
			table.AddCell(cell);
			document.Add(table);			
		}

		public void addDatosVariableRTF(Document document, iTextSharp.text.Font fontTitle)
		{
			document.Add(new Phrase("\n- Variables Asociadas:", fontTitle));
			Table table = new Table(2);
			table.Cellpadding = 2;
			int[] headerWidths = {15,70}; 
			table.SetWidths(headerWidths);
			table.WidthPercentage = 100;             
			table.DefaultCellBorderWidth = 0;
			table.DefaultHorizontalAlignment = Element.ALIGN_JUSTIFIED;
			table.DefaultCellGrayFill = 0.7f;
			int j = 0; 
			float color = 0.0f;
			foreach (DataRowView dv in dvDatos)
			{
				if (j % 2 == 0) color = 0.9f;
				else color = 0.0f;
			
				table.DefaultCellGrayFill = 0.7f;table.AddCell("Grupo");
				table.DefaultCellGrayFill = color;table.AddCell(dv["nombreg"].ToString());
	
				table.DefaultCellGrayFill = 0.7f;table.AddCell("Variable");
				table.DefaultCellGrayFill = color;table.AddCell(dv["nombrev"].ToString());

				table.DefaultCellGrayFill = 0.7f;table.AddCell("Unidad");
				table.DefaultCellGrayFill = color;table.AddCell(dv["unidad"].ToString());

				table.DefaultCellGrayFill = 0.7f;table.AddCell("Fecha");
				table.DefaultCellGrayFill = color;table.AddCell(dv["fecha"].ToString());
				
				table.DefaultCellGrayFill = 0.7f;table.AddCell("Responsable");
				table.DefaultCellGrayFill = color;table.AddCell(dv["responsable"].ToString());

				table.DefaultCellGrayFill = 0.7f;table.AddCell("Valor");
				table.DefaultCellGrayFill = color;table.AddCell(dv["valor"].ToString());

				table.DefaultCellGrayFill = 0.7f;table.AddCell("Criterio");
				table.DefaultCellGrayFill = color;table.AddCell(dv["criterio"].ToString());

				table.DefaultCellGrayFill = 0.7f;table.AddCell("Descripción");
				table.DefaultCellGrayFill = color;table.AddCell(dv["descripcion"].ToString());

				table.DefaultCellGrayFill = 0.7f;table.AddCell("Fuente");
				table.DefaultCellGrayFill = color;table.AddCell(dv["fuente"].ToString());

				table.DefaultCellGrayFill = 1.0f;
				table.DefaultCellBorderWidth = 1;

				table.AddCell("\n");
				table.AddCell("\n");
				j++;

				table.EndHeaders();
			}
			
		
		document.Add(table);
		}


		public void addFilesRTF(Document document, iTextSharp.text.Font fontTitle)
		{
			document.Add(new Phrase("\n- Archivos Asociados:", fontTitle));
			Table table = new Table(5);
			table.Cellpadding = 3;
			int[] headerWidths = {9, 9, 9, 11, 11};
			table.SetWidths(headerWidths);
			table.WidthPercentage = 100;             
			table.DefaultCellBorderWidth = 1;
			table.DefaultHorizontalAlignment = Element.ALIGN_CENTER;
			table.DefaultCellGrayFill = 0.7f;
			table.AddCell("Fecha");
			table.AddCell("Autor");
			table.AddCell("Título");
			table.AddCell("Descripción");
			table.AddCell("Ruta");
			table.EndHeaders();
			//table.LastHeaderRow = 1;
			table.DefaultCellBorderWidth = 1; 
			int j = 1;
			foreach (DataRowView dv in dvFiles)
			{
				if (j % 2 == 0) table.DefaultCellGrayFill = 0.9f;
				else table.DefaultCellGrayFill = 0.0f;
				table.AddCell(dv["fecha"].ToString());
				table.AddCell(dv["autor"].ToString());
				table.AddCell(dv["titulo"].ToString());
				table.AddCell(dv["descripcion"].ToString());
				table.AddCell(dv["ruta"].ToString());
				j++;
			}
			document.Add(table);
		}

		#endregion


		private string getNombre()
		{
			int i;
			string name = "Reporte"; 
			string ext = ".pdf";
			string []pdfs = Directory.GetFiles(".", "*.pdf");
			foreach (string pdf in pdfs) 
			{
				try{ File.Delete(pdf);}
				catch{}
			}

			for(i = 1; ;i++)
			{
				if(!(File.Exists(name + i + ext))) break;
			}
			return (name + i + ext);
		}

		private void btnRTF_Click(object sender, System.EventArgs e)
		{
			Cursor.Current = Cursors.WaitCursor;
			string name = getNombreRTF();
			Document document = new Document(PageSize.LETTER.Rotate(), 50, 50, 80, 50);
			try 
			{
				RtfWriter.GetInstance(document, new FileStream(name, FileMode.Create));
				document.Open();
				encabezadoRTF(document);
				document.Close();
				Process.Start(name);
			}
			catch(DocumentException de) 
			{
				MessageBox.Show("Error en la generación del reporte: " + de.Message);
			}
			catch(IOException ioe) 
			{
				MessageBox.Show("Error en la generación del reporte: " + ioe.Message);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message,"EEPPM Alternativas",	MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				Cursor.Current = Cursors.Default;
			}
			
			
			this.Close();
		}

		private string getNombreRTF()
		{
			int i;
			string name = "Reporte"; 
			string ext = ".rtf";
			string []rtfs = Directory.GetFiles(".", "*.rtf");
			foreach (string rtf in rtfs) 
			{
				try{ File.Delete(rtf);}
				catch{}
			}

			for(i = 1; ;i++)
			{
				if(!(File.Exists(name + i + ext))) break;
			}
			return (name + i + ext);
		}

	}

}
