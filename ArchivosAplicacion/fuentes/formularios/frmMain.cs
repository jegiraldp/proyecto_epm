using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Security.Principal; //->Para Obtener el User;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using RKLib.ExportData; // -> para lo de excel

namespace EPM.formularios
{
	using EPM.clases;
	public class frmMain : System.Windows.Forms.Form
	{
		#region Objetos del Formulario frmMain
		private System.Windows.Forms.MainMenu mnuMenu;
		private System.Windows.Forms.ImageList imgList;
		private System.Windows.Forms.MenuItem mnuAyuda;
		private System.Windows.Forms.MenuItem mnuContenido;
		private System.Windows.Forms.MenuItem mnuAcercaDe;
		private System.Windows.Forms.StatusBar statusBarMain;
		private System.Windows.Forms.StatusBarPanel userPanel;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Panel leftPanel;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel rightPanel;
		private System.Windows.Forms.Panel topRightPanel;
		private System.Windows.Forms.ToolBar tlBarMain;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.Panel bottomRightPanel;
		private System.Windows.Forms.DataGrid dGridGrupo;
		private System.Windows.Forms.ToolBar tlbArchivo;
		private System.Windows.Forms.ToolBarButton tlbFisrt;
		private System.Windows.Forms.ToolBarButton tlbFileAttach;
		private System.Windows.Forms.Panel topBottobRightPanel;
		private System.Windows.Forms.ToolBar tlbVariable;
		private System.Windows.Forms.ToolBarButton tlbVarFirst;
		private System.Windows.Forms.ToolBarButton tlbVarNew;
		private System.Windows.Forms.DataGrid dGridVariables;
		private System.Windows.Forms.Splitter splitter4;		
		private System.Windows.Forms.DataGrid dGridFuente;		
		private System.Windows.Forms.DataGrid dGridArchivo;
		private System.Windows.Forms.ToolBarButton tblMainSave;
		private System.Windows.Forms.ToolBarButton tblMainPrint;
		private System.Windows.Forms.ToolBarButton tblFirst;
		private System.Windows.Forms.ToolBarButton tblSeparator;
		private System.Windows.Forms.ToolBarButton tblMainZoomIn;
		private System.Windows.Forms.ToolBarButton tblMainZoomOut;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.MenuItem mnuNuevo;
		private System.Windows.Forms.MenuItem mnuFuente;
		private System.Windows.Forms.MenuItem mnuProceso;
		private System.Windows.Forms.MenuItem mnuFA;
		private System.Windows.Forms.MenuItem mnuVT;
		private System.Windows.Forms.MenuItem mnuSeparator;
		private System.Windows.Forms.MenuItem mnuGrupo;
		private System.Windows.Forms.MenuItem mnuVC;
		private System.Windows.Forms.MenuItem mnuSeparator2;//Fila Actual de la Tabla Actual		
		#endregion
		//private static SqlDataAdapter daDatVar = null;//provisional******************************
		string[] jerarquiaTabla = new string[4];
		string[] jerarquiaValor = new string[4];
		private SqlConnection cnx;	
		public string titledel; //titulo del formulario eliminar
		public string table; //la tabla del formulario eliminar
		public string result; //para manejar la consulta de la fuente, en el caso de exportar excel
		public string foranea;//maneja la llave foranea en el hijo 
		public string hijo;//maneja nombre de la tabla hijo
        DataSet ds;
		DataSet ds2 = new DataSet();
		DataSet dsG; //data set para actualizar datagrid grupo
		DataSet dsRecurso = new DataSet();//DataSet para almacenar los recursos
		SqlDataAdapter da; //para recursos
		bool noComp = false;//para el caso visualizar
		DataView dv; //DataView para datos Variable
		DataView dvArchivo; //DataView para Archivo
		string currentTableF = "Fuente", currentTableG = "Grupo";
		string currentTableR = "Recurso";
		string currentTable = "";//Tabla Actual
		int currentRow, currentRowG, pk;
		private System.Windows.Forms.ToolBarButton tblVarEdit;
		private System.Windows.Forms.ToolBarButton tblFileEdit;
		private System.Windows.Forms.MenuItem mnuTool;
		private System.Windows.Forms.MenuItem mnuRepositorio;
		private System.Windows.Forms.ToolBarButton tlbFileOpen;
		private System.Windows.Forms.DataGrid dGridRecurso;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem mnuUsers;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.ToolTip TipGridVariables;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.ToolBarButton tblVarDel;
		private System.Windows.Forms.ToolBarButton tblFileDel;
		private System.Windows.Forms.ToolBarButton tblVisualizar;
		private System.Windows.Forms.ToolBarButton tblFileVisualizar;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Splitter splitter5;
		private System.Windows.Forms.ToolBarButton tblExcel;

		string[ , ] dic = {
							{"Fuente", "Fuente"}, 
							{"Procesos", "Proceso"},
							{"Formas de Aprovechamiento", "Forma Aprovech"},
							{"Variantes Tecnológicas", "Variante Tecn"}
						  };

		
		public frmMain( frmWelcome window)
		{
			InitializeComponent();
			EPM.clases.MdiParent.setFather(this);
			//Se oculta la ventana y la referencia se hace nula.
			window.Visible = false;
			window = null;
			cnx = ConexionDB.getConnection();
			ds = Util.getDataSet();
		}

		#region Código generado por el Diseñador de Windows Forms
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
			this.mnuMenu = new System.Windows.Forms.MainMenu();
			this.mnuNuevo = new System.Windows.Forms.MenuItem();
			this.mnuFuente = new System.Windows.Forms.MenuItem();
			this.mnuProceso = new System.Windows.Forms.MenuItem();
			this.mnuFA = new System.Windows.Forms.MenuItem();
			this.mnuVT = new System.Windows.Forms.MenuItem();
			this.mnuSeparator = new System.Windows.Forms.MenuItem();
			this.mnuGrupo = new System.Windows.Forms.MenuItem();
			this.mnuVC = new System.Windows.Forms.MenuItem();
			this.mnuSeparator2 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuTool = new System.Windows.Forms.MenuItem();
			this.mnuRepositorio = new System.Windows.Forms.MenuItem();
			this.mnuUsers = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.mnuAyuda = new System.Windows.Forms.MenuItem();
			this.mnuContenido = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.mnuAcercaDe = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.imgList = new System.Windows.Forms.ImageList(this.components);
			this.statusBarMain = new System.Windows.Forms.StatusBar();
			this.userPanel = new System.Windows.Forms.StatusBarPanel();
			this.leftPanel = new System.Windows.Forms.Panel();
			this.dGridRecurso = new System.Windows.Forms.DataGrid();
			this.splitter5 = new System.Windows.Forms.Splitter();
			this.dGridGrupo = new System.Windows.Forms.DataGrid();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.dGridFuente = new System.Windows.Forms.DataGrid();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.rightPanel = new System.Windows.Forms.Panel();
			this.bottomRightPanel = new System.Windows.Forms.Panel();
			this.dGridArchivo = new System.Windows.Forms.DataGrid();
			this.splitter4 = new System.Windows.Forms.Splitter();
			this.topBottobRightPanel = new System.Windows.Forms.Panel();
			this.dGridVariables = new System.Windows.Forms.DataGrid();
			this.tlbVariable = new System.Windows.Forms.ToolBar();
			this.tlbVarFirst = new System.Windows.Forms.ToolBarButton();
			this.tlbVarNew = new System.Windows.Forms.ToolBarButton();
			this.tblVarEdit = new System.Windows.Forms.ToolBarButton();
			this.tblVarDel = new System.Windows.Forms.ToolBarButton();
			this.tblVisualizar = new System.Windows.Forms.ToolBarButton();
			this.tblExcel = new System.Windows.Forms.ToolBarButton();
			this.tlbArchivo = new System.Windows.Forms.ToolBar();
			this.tlbFisrt = new System.Windows.Forms.ToolBarButton();
			this.tlbFileAttach = new System.Windows.Forms.ToolBarButton();
			this.tblFileEdit = new System.Windows.Forms.ToolBarButton();
			this.tlbFileOpen = new System.Windows.Forms.ToolBarButton();
			this.tblFileVisualizar = new System.Windows.Forms.ToolBarButton();
			this.tblFileDel = new System.Windows.Forms.ToolBarButton();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.topRightPanel = new System.Windows.Forms.Panel();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.tlBarMain = new System.Windows.Forms.ToolBar();
			this.tblFirst = new System.Windows.Forms.ToolBarButton();
			this.tblMainSave = new System.Windows.Forms.ToolBarButton();
			this.tblMainPrint = new System.Windows.Forms.ToolBarButton();
			this.tblSeparator = new System.Windows.Forms.ToolBarButton();
			this.tblMainZoomIn = new System.Windows.Forms.ToolBarButton();
			this.tblMainZoomOut = new System.Windows.Forms.ToolBarButton();
			this.TipGridVariables = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.userPanel)).BeginInit();
			this.leftPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridRecurso)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dGridGrupo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dGridFuente)).BeginInit();
			this.rightPanel.SuspendLayout();
			this.bottomRightPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridArchivo)).BeginInit();
			this.topBottobRightPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dGridVariables)).BeginInit();
			this.topRightPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMenu
			// 
			this.mnuMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuNuevo,
																					this.mnuTool,
																					this.mnuUsers,
																					this.menuItem6,
																					this.mnuAyuda,
																					this.menuItem2});
			// 
			// mnuNuevo
			// 
			this.mnuNuevo.Index = 0;
			this.mnuNuevo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuFuente,
																					 this.mnuProceso,
																					 this.mnuFA,
																					 this.mnuVT,
																					 this.mnuSeparator,
																					 this.mnuGrupo,
																					 this.mnuVC,
																					 this.mnuSeparator2,
																					 this.menuItem1});
			this.mnuNuevo.Text = "&Nuevo";
			// 
			// mnuFuente
			// 
			this.mnuFuente.Index = 0;
			this.mnuFuente.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.mnuFuente.Text = "&Fuente";
			this.mnuFuente.Click += new System.EventHandler(this.mnuFuente_Click);
			// 
			// mnuProceso
			// 
			this.mnuProceso.Index = 1;
			this.mnuProceso.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.mnuProceso.Text = "&Proceso";
			this.mnuProceso.Click += new System.EventHandler(this.mnuProceso_Click);
			// 
			// mnuFA
			// 
			this.mnuFA.Index = 2;
			this.mnuFA.Text = "&Forma Aprovechamiento";
			this.mnuFA.Click += new System.EventHandler(this.mnuFA_Click);
			// 
			// mnuVT
			// 
			this.mnuVT.Index = 3;
			this.mnuVT.Text = "&Variante Tecnológica";
			this.mnuVT.Click += new System.EventHandler(this.mnuVT_Click);
			// 
			// mnuSeparator
			// 
			this.mnuSeparator.Index = 4;
			this.mnuSeparator.Text = "-";
			// 
			// mnuGrupo
			// 
			this.mnuGrupo.Index = 5;
			this.mnuGrupo.Shortcut = System.Windows.Forms.Shortcut.CtrlG;
			this.mnuGrupo.Text = "&Grupo";
			this.mnuGrupo.Click += new System.EventHandler(this.mnuGrupo_Click);
			// 
			// mnuVC
			// 
			this.mnuVC.Index = 6;
			this.mnuVC.Text = "Variable &Característica";
			this.mnuVC.Click += new System.EventHandler(this.mnuVC_Click);
			// 
			// mnuSeparator2
			// 
			this.mnuSeparator2.Index = 7;
			this.mnuSeparator2.Text = "-";
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 8;
			this.menuItem1.Text = "&Recurso";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// mnuTool
			// 
			this.mnuTool.Index = 1;
			this.mnuTool.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuRepositorio});
			this.mnuTool.Text = "&Herramientas";
			// 
			// mnuRepositorio
			// 
			this.mnuRepositorio.Index = 0;
			this.mnuRepositorio.Text = "&Configuración Sistema";
			this.mnuRepositorio.Click += new System.EventHandler(this.mnuRepositorio_Click);
			// 
			// mnuUsers
			// 
			this.mnuUsers.Index = 2;
			this.mnuUsers.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem4,
																					 this.menuItem5,
																					 this.menuItem8});
			this.mnuUsers.Text = "&Usuarios";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Text = "Nuevo usuario";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 1;
			this.menuItem5.Text = "Editar usuarios";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 2;
			this.menuItem8.Text = "Eliminar usuario";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 3;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem7,
																					  this.menuItem9,
																					  this.menuItem10,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem13,
																					  this.menuItem14,
																					  this.menuItem15});
			this.menuItem6.Text = "&Eliminar";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 0;
			this.menuItem7.Text = "Fuente";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.Text = "Proceso";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 2;
			this.menuItem10.Text = "Forma de aprovechamiento";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 3;
			this.menuItem11.Text = "Variante Tecnológica";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 4;
			this.menuItem12.Text = "Grupo";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 5;
			this.menuItem13.Text = "Variable característica";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 6;
			this.menuItem14.Text = "Recurso";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 7;
			this.menuItem15.Text = "Usuario";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// mnuAyuda
			// 
			this.mnuAyuda.Index = 4;
			this.mnuAyuda.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuContenido,
																					 this.menuItem3,
																					 this.mnuAcercaDe});
			this.mnuAyuda.Text = "&Ayuda";
			// 
			// mnuContenido
			// 
			this.mnuContenido.Index = 0;
			this.mnuContenido.Text = "&Contenido";
			this.mnuContenido.Click += new System.EventHandler(this.mnuContenido_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "&Glosario";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// mnuAcercaDe
			// 
			this.mnuAcercaDe.Index = 2;
			this.mnuAcercaDe.Text = "A&cerca de...";
			this.mnuAcercaDe.Click += new System.EventHandler(this.mnuAcercaDe_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 5;
			this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F10;
			this.menuItem2.Text = "&Salir";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// imgList
			// 
			this.imgList.ImageSize = new System.Drawing.Size(16, 16);
			this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
			this.imgList.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// statusBarMain
			// 
			this.statusBarMain.Location = new System.Drawing.Point(0, 497);
			this.statusBarMain.Name = "statusBarMain";
			this.statusBarMain.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																							 this.userPanel});
			this.statusBarMain.ShowPanels = true;
			this.statusBarMain.Size = new System.Drawing.Size(794, 22);
			this.statusBarMain.TabIndex = 2;
			// 
			// userPanel
			// 
			this.userPanel.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None;
			this.userPanel.Text = "Usuario:  ";
			this.userPanel.Width = 300;
			// 
			// leftPanel
			// 
			this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.leftPanel.Controls.Add(this.dGridRecurso);
			this.leftPanel.Controls.Add(this.splitter5);
			this.leftPanel.Controls.Add(this.dGridGrupo);
			this.leftPanel.Controls.Add(this.splitter2);
			this.leftPanel.Controls.Add(this.dGridFuente);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.Size = new System.Drawing.Size(272, 497);
			this.leftPanel.TabIndex = 3;
			// 
			// dGridRecurso
			// 
			this.dGridRecurso.CaptionBackColor = System.Drawing.Color.CadetBlue;
			this.dGridRecurso.CaptionForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridRecurso.CaptionText = "Recursos";
			this.dGridRecurso.DataMember = "";
			this.dGridRecurso.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dGridRecurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dGridRecurso.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridRecurso.Location = new System.Drawing.Point(0, 485);
			this.dGridRecurso.Name = "dGridRecurso";
			this.dGridRecurso.ReadOnly = true;
			this.dGridRecurso.Size = new System.Drawing.Size(270, 10);
			this.dGridRecurso.TabIndex = 4;
			this.dGridRecurso.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dGridRecurso_MouseUp);
			this.dGridRecurso.CurrentCellChanged += new System.EventHandler(this.dGridRecurso_CurrentCellChanged);
			// 
			// splitter5
			// 
			this.splitter5.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.splitter5.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter5.Location = new System.Drawing.Point(0, 480);
			this.splitter5.Name = "splitter5";
			this.splitter5.Size = new System.Drawing.Size(270, 5);
			this.splitter5.TabIndex = 3;
			this.splitter5.TabStop = false;
			// 
			// dGridGrupo
			// 
			this.dGridGrupo.AllowSorting = false;
			this.dGridGrupo.CaptionBackColor = System.Drawing.Color.PaleTurquoise;
			this.dGridGrupo.CaptionFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dGridGrupo.CaptionForeColor = System.Drawing.SystemColors.Desktop;
			this.dGridGrupo.CaptionText = "Información Grupos y Variables";
			this.dGridGrupo.ColumnHeadersVisible = false;
			this.dGridGrupo.DataMember = "";
			this.dGridGrupo.Dock = System.Windows.Forms.DockStyle.Top;
			this.dGridGrupo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dGridGrupo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridGrupo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridGrupo.LinkColor = System.Drawing.SystemColors.ControlText;
			this.dGridGrupo.Location = new System.Drawing.Point(0, 245);
			this.dGridGrupo.Name = "dGridGrupo";
			this.dGridGrupo.ParentRowsBackColor = System.Drawing.SystemColors.Info;
			this.dGridGrupo.ParentRowsForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridGrupo.ReadOnly = true;
			this.dGridGrupo.SelectionBackColor = System.Drawing.SystemColors.ControlText;
			this.dGridGrupo.Size = new System.Drawing.Size(270, 235);
			this.dGridGrupo.TabIndex = 2;
			this.dGridGrupo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dGridGrupo_MouseUp);
			this.dGridGrupo.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dGridGrupo_Navigate);
			this.dGridGrupo.CurrentCellChanged += new System.EventHandler(this.dGridGrupo_CurrentCellChanged);
			// 
			// splitter2
			// 
			this.splitter2.BackColor = System.Drawing.SystemColors.Highlight;
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(0, 240);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(270, 5);
			this.splitter2.TabIndex = 1;
			this.splitter2.TabStop = false;
			// 
			// dGridFuente
			// 
			this.dGridFuente.AllowSorting = false;
			this.dGridFuente.CaptionBackColor = System.Drawing.Color.CadetBlue;
			this.dGridFuente.CaptionForeColor = System.Drawing.SystemColors.Desktop;
			this.dGridFuente.CaptionText = "Fuentes";
			this.dGridFuente.ColumnHeadersVisible = false;
			this.dGridFuente.DataMember = "";
			this.dGridFuente.Dock = System.Windows.Forms.DockStyle.Top;
			this.dGridFuente.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dGridFuente.ForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridFuente.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridFuente.LinkColor = System.Drawing.SystemColors.Desktop;
			this.dGridFuente.Location = new System.Drawing.Point(0, 0);
			this.dGridFuente.Name = "dGridFuente";
			this.dGridFuente.ParentRowsBackColor = System.Drawing.SystemColors.Info;
			this.dGridFuente.ParentRowsForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.dGridFuente.ReadOnly = true;
			this.dGridFuente.SelectionBackColor = System.Drawing.SystemColors.Info;
			this.dGridFuente.Size = new System.Drawing.Size(270, 240);
			this.dGridFuente.TabIndex = 0;
			this.dGridFuente.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dGridFuente_MouseUp);
			this.dGridFuente.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dGridFuente_Navigate);
			this.dGridFuente.CurrentCellChanged += new System.EventHandler(this.dGridFuente_CurrentCellChanged);
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.Control;
			this.splitter1.Location = new System.Drawing.Point(272, 0);
			this.splitter1.MinExtra = 300;
			this.splitter1.MinSize = 230;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 497);
			this.splitter1.TabIndex = 4;
			this.splitter1.TabStop = false;
			this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
			// 
			// rightPanel
			// 
			this.rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rightPanel.Controls.Add(this.bottomRightPanel);
			this.rightPanel.Controls.Add(this.splitter3);
			this.rightPanel.Controls.Add(this.topRightPanel);
			this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPanel.Location = new System.Drawing.Point(280, 0);
			this.rightPanel.Name = "rightPanel";
			this.rightPanel.Size = new System.Drawing.Size(514, 497);
			this.rightPanel.TabIndex = 5;
			// 
			// bottomRightPanel
			// 
			this.bottomRightPanel.Controls.Add(this.dGridArchivo);
			this.bottomRightPanel.Controls.Add(this.splitter4);
			this.bottomRightPanel.Controls.Add(this.topBottobRightPanel);
			this.bottomRightPanel.Controls.Add(this.tlbArchivo);
			this.bottomRightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.bottomRightPanel.Location = new System.Drawing.Point(0, 204);
			this.bottomRightPanel.Name = "bottomRightPanel";
			this.bottomRightPanel.Size = new System.Drawing.Size(512, 291);
			this.bottomRightPanel.TabIndex = 7;
			// 
			// dGridArchivo
			// 
			this.dGridArchivo.CaptionBackColor = System.Drawing.SystemColors.Info;
			this.dGridArchivo.CaptionFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
			this.dGridArchivo.CaptionForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridArchivo.CaptionText = "Archivos";
			this.dGridArchivo.DataMember = "";
			this.dGridArchivo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dGridArchivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dGridArchivo.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridArchivo.Location = new System.Drawing.Point(0, 164);
			this.dGridArchivo.Name = "dGridArchivo";
			this.dGridArchivo.ReadOnly = true;
			this.dGridArchivo.Size = new System.Drawing.Size(512, 99);
			this.dGridArchivo.TabIndex = 32;
			this.dGridArchivo.DoubleClick += new System.EventHandler(this.dGridArchivo_DoubleClick);
			// 
			// splitter4
			// 
			this.splitter4.BackColor = System.Drawing.SystemColors.Highlight;
			this.splitter4.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter4.Location = new System.Drawing.Point(0, 160);
			this.splitter4.MinExtra = 100;
			this.splitter4.MinSize = 100;
			this.splitter4.Name = "splitter4";
			this.splitter4.Size = new System.Drawing.Size(512, 4);
			this.splitter4.TabIndex = 31;
			this.splitter4.TabStop = false;
			// 
			// topBottobRightPanel
			// 
			this.topBottobRightPanel.Controls.Add(this.dGridVariables);
			this.topBottobRightPanel.Controls.Add(this.tlbVariable);
			this.topBottobRightPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.topBottobRightPanel.Location = new System.Drawing.Point(0, 0);
			this.topBottobRightPanel.Name = "topBottobRightPanel";
			this.topBottobRightPanel.Size = new System.Drawing.Size(512, 160);
			this.topBottobRightPanel.TabIndex = 30;
			// 
			// dGridVariables
			// 
			this.dGridVariables.AllowSorting = false;
			this.dGridVariables.CaptionBackColor = System.Drawing.SystemColors.Info;
			this.dGridVariables.CaptionFont = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
			this.dGridVariables.CaptionForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridVariables.CaptionText = "Datos Variables";
			this.dGridVariables.DataMember = "";
			this.dGridVariables.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dGridVariables.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.dGridVariables.GridLineColor = System.Drawing.SystemColors.HotTrack;
			this.dGridVariables.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dGridVariables.Location = new System.Drawing.Point(0, 0);
			this.dGridVariables.Name = "dGridVariables";
			this.dGridVariables.ReadOnly = true;
			this.dGridVariables.Size = new System.Drawing.Size(512, 132);
			this.dGridVariables.TabIndex = 30;
			this.TipGridVariables.SetToolTip(this.dGridVariables, "Para editar hacer doble click en la parte gris ubicada a la izquierda");
			this.dGridVariables.DoubleClick += new System.EventHandler(this.dGridVariables_DoubleClick);
			// 
			// tlbVariable
			// 
			this.tlbVariable.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tlbVariable.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						   this.tlbVarFirst,
																						   this.tlbVarNew,
																						   this.tblVarEdit,
																						   this.tblVarDel,
																						   this.tblVisualizar,
																						   this.tblExcel});
			this.tlbVariable.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tlbVariable.DropDownArrows = true;
			this.tlbVariable.ImageList = this.imgList;
			this.tlbVariable.Location = new System.Drawing.Point(0, 132);
			this.tlbVariable.Name = "tlbVariable";
			this.tlbVariable.ShowToolTips = true;
			this.tlbVariable.Size = new System.Drawing.Size(512, 28);
			this.tlbVariable.TabIndex = 29;
			this.tlbVariable.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tlbVariable_ButtonClick);
			// 
			// tlbVarFirst
			// 
			this.tlbVarFirst.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tlbVarNew
			// 
			this.tlbVarNew.ImageIndex = 0;
			this.tlbVarNew.ToolTipText = "Nueva Variable";
			// 
			// tblVarEdit
			// 
			this.tblVarEdit.ImageIndex = 11;
			this.tblVarEdit.ToolTipText = "Editar Dato Variable";
			// 
			// tblVarDel
			// 
			this.tblVarDel.ImageIndex = 6;
			this.tblVarDel.ToolTipText = "Borrar Dato Variable";
			// 
			// tblVisualizar
			// 
			this.tblVisualizar.ImageIndex = 2;
			this.tblVisualizar.ToolTipText = "Visualizar la información del dato variable";
			// 
			// tblExcel
			// 
			this.tblExcel.ImageIndex = 12;
			this.tblExcel.ToolTipText = "Exportar \"Valor\"  a Excel";
			// 
			// tlbArchivo
			// 
			this.tlbArchivo.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tlbArchivo.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						  this.tlbFisrt,
																						  this.tlbFileAttach,
																						  this.tblFileEdit,
																						  this.tlbFileOpen,
																						  this.tblFileVisualizar,
																						  this.tblFileDel});
			this.tlbArchivo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tlbArchivo.DropDownArrows = true;
			this.tlbArchivo.ImageList = this.imgList;
			this.tlbArchivo.Location = new System.Drawing.Point(0, 263);
			this.tlbArchivo.Name = "tlbArchivo";
			this.tlbArchivo.ShowToolTips = true;
			this.tlbArchivo.Size = new System.Drawing.Size(512, 28);
			this.tlbArchivo.TabIndex = 23;
			this.tlbArchivo.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tlbArchivo_ButtonClick);
			// 
			// tlbFisrt
			// 
			this.tlbFisrt.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			this.tlbFisrt.ToolTipText = "Visualizar datos sobre el archivo adjunto.";
			// 
			// tlbFileAttach
			// 
			this.tlbFileAttach.ImageIndex = 7;
			this.tlbFileAttach.ToolTipText = "Adicionar Archivo";
			// 
			// tblFileEdit
			// 
			this.tblFileEdit.ImageIndex = 11;
			this.tblFileEdit.ToolTipText = "Editar Archivo";
			// 
			// tlbFileOpen
			// 
			this.tlbFileOpen.ImageIndex = 1;
			this.tlbFileOpen.ToolTipText = "Abrir el archivo adjunto.";
			// 
			// tblFileVisualizar
			// 
			this.tblFileVisualizar.ImageIndex = 2;
			this.tblFileVisualizar.ToolTipText = "Visualizar la  información del archivo.";
			// 
			// tblFileDel
			// 
			this.tblFileDel.ImageIndex = 6;
			this.tblFileDel.ToolTipText = "Borrar el archivo adjunto.";
			// 
			// splitter3
			// 
			this.splitter3.BackColor = System.Drawing.SystemColors.Highlight;
			this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter3.Location = new System.Drawing.Point(0, 200);
			this.splitter3.MinExtra = 250;
			this.splitter3.MinSize = 200;
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(512, 4);
			this.splitter3.TabIndex = 1;
			this.splitter3.TabStop = false;
			// 
			// topRightPanel
			// 
			this.topRightPanel.Controls.Add(this.txtDescripcion);
			this.topRightPanel.Controls.Add(this.lblDescripcion);
			this.topRightPanel.Controls.Add(this.txtName);
			this.topRightPanel.Controls.Add(this.lblName);
			this.topRightPanel.Controls.Add(this.tlBarMain);
			this.topRightPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.topRightPanel.Location = new System.Drawing.Point(0, 0);
			this.topRightPanel.Name = "topRightPanel";
			this.topRightPanel.Size = new System.Drawing.Size(512, 200);
			this.topRightPanel.TabIndex = 0;
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtDescripcion.Enabled = false;
			this.txtDescripcion.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtDescripcion.Location = new System.Drawing.Point(0, 80);
			this.txtDescripcion.Multiline = true;
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescripcion.Size = new System.Drawing.Size(512, 92);
			this.txtDescripcion.TabIndex = 16;
			this.txtDescripcion.Text = "";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.BackColor = System.Drawing.SystemColors.Info;
			this.lblDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblDescripcion.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblDescripcion.Location = new System.Drawing.Point(0, 56);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(512, 24);
			this.lblDescripcion.TabIndex = 14;
			this.lblDescripcion.Text = "Descripción";
			// 
			// txtName
			// 
			this.txtName.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtName.Enabled = false;
			this.txtName.Font = new System.Drawing.Font("Tahoma", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtName.Location = new System.Drawing.Point(0, 24);
			this.txtName.Multiline = true;
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(512, 32);
			this.txtName.TabIndex = 13;
			this.txtName.Text = "";
			// 
			// lblName
			// 
			this.lblName.BackColor = System.Drawing.SystemColors.Info;
			this.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblName.Location = new System.Drawing.Point(0, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(512, 24);
			this.lblName.TabIndex = 12;
			this.lblName.Text = "Nombre";
			// 
			// tlBarMain
			// 
			this.tlBarMain.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tlBarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						 this.tblFirst,
																						 this.tblMainSave,
																						 this.tblMainPrint,
																						 this.tblSeparator,
																						 this.tblMainZoomIn,
																						 this.tblMainZoomOut});
			this.tlBarMain.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tlBarMain.DropDownArrows = true;
			this.tlBarMain.ImageList = this.imgList;
			this.tlBarMain.Location = new System.Drawing.Point(0, 172);
			this.tlBarMain.Name = "tlBarMain";
			this.tlBarMain.ShowToolTips = true;
			this.tlBarMain.Size = new System.Drawing.Size(512, 28);
			this.tlBarMain.TabIndex = 0;
			this.tlBarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tlBarMain_ButtonClick);
			// 
			// tblFirst
			// 
			this.tblFirst.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tblMainSave
			// 
			this.tblMainSave.ImageIndex = 8;
			this.tblMainSave.ToolTipText = "Guardar Cambios Realizados";
			// 
			// tblMainPrint
			// 
			this.tblMainPrint.ImageIndex = 3;
			this.tblMainPrint.ToolTipText = "Generar Reporte ";
			// 
			// tblSeparator
			// 
			this.tblSeparator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tblMainZoomIn
			// 
			this.tblMainZoomIn.ImageIndex = 9;
			// 
			// tblMainZoomOut
			// 
			this.tblMainZoomOut.ImageIndex = 10;
			// 
			// TipGridVariables
			// 
			this.TipGridVariables.ShowAlways = true;
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(794, 519);
			this.Controls.Add(this.rightPanel);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.leftPanel);
			this.Controls.Add(this.statusBarMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mnuMenu;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "EEPPM ALTERNATIVAS";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.userPanel)).EndInit();
			this.leftPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridRecurso)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dGridGrupo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dGridFuente)).EndInit();
			this.rightPanel.ResumeLayout(false);
			this.bottomRightPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridArchivo)).EndInit();
			this.topBottobRightPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dGridVariables)).EndInit();
			this.topRightPanel.ResumeLayout(false);
			this.ResumeLayout(false);

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
		#endregion

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			
			userPanel.Text += clases.User.getUser();
			splitter4.SplitPosition = 230;		
			try 
			{
				initializeGridFuente();	
				initializeGridGrupo();	
				initializeGridVariables();
				initializeGridArchivo();
			}
			catch{}

			if (!(getPerfil().Equals("a")))
			{
				this.mnuNuevo.Visible = false;
				this.mnuNuevo.Enabled = false;
				this.mnuTool.Visible = false;
				this.mnuTool.Enabled = false;
				this.mnuUsers.Visible = false;
				this.mnuUsers.Enabled = false;
				this.menuItem6.Visible = false;
				this.menuItem6.Enabled = false;

				//Boton guardar
				this.tblMainSave.Enabled = false;
				this.tblMainSave.Visible = false;

				//Toolbar Variable
				this.tlbVariable.Enabled = false;
				this.tlbVariable.Visible = false;
				
				//Toolbar Archivo
				this.tlbFileAttach.Enabled = false;
				this.tlbFileAttach.Visible = false;

				this.tblFileEdit.Enabled = false;
				this.tblFileEdit.Visible = false;

				this.tblFileDel.Enabled = false;
				this.tblFileDel.Visible = false;

			}

		}	

		private void initializeGridRecurso()
		{

			//Definición de los  TablesStyles para recurso.
			dGridRecurso.TableStyles.Clear();
			addTableStyle(dGridRecurso, "Recurso");
			
			DataViewManager DataSetView = dsRecurso.DefaultViewManager;
			dGridRecurso.DataSource = DataSetView;
			dGridRecurso.DataMember = "Recurso";
			dGridRecurso.Update();
		}



		private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DialogResult result;
			result = MessageBox.Show ("Realmente desea salir de la aplicación?", "Confirmar salida", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
			
			if(result == DialogResult.Yes)
			{
				if (cnx != null)
				{
					cnx.Close();
				}
				Application.Exit();
			}
			e.Cancel = (result != DialogResult.Yes);
		}

		//Muestra el formulario nueva fuente.				
		private void mnuFuente_Click(object sender, System.EventArgs e)
		{
			frmNuevaFuente newFuente = new frmNuevaFuente();
			newFuente.ShowDialog(this); 
		}
		
		#region Código Comentado del Toolbar 
		//		private void toolBarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		//		{
		//			switch (toolBarMain.Buttons.IndexOf(e.Button))
		//			{
		//				case 0: //Nueva Fuente
		//					mostrarNuevaFuente();
		//			    break;
		//				
		//				case 1: //Abrir Fuente
		//					mostrarAbrirFuente();
		//				break;
		//
		//				case 3: //Previsualizar
		//				break;
		//				
		//				case 4: //Imprimir
		//					if (this.ActiveMdiChild== null) 
		//					   MessageBox.Show("No hay ni chimba");
		//					else
		//					  MessageBox.Show(this.ActiveMdiChild.GetType().Name);
		//				break;
		//
		//				case 6: //Ayuda
		//				break;
		//
		//				case 7: //Salir
		//					this.Close();
		//				break;
		//
		//			}
		//		}
		#endregion

		#region Cargar Fuentes, Procesos, Formas de Aprovechamiento y Variantes.
		public void initializeGridFuente()
		{
			//Definición de los  TablesStyles.
			addTableStyle(dGridFuente, "Fuente");
			addTableStyle(dGridFuente, "Proceso");
			addTableStyle(dGridFuente, "Forma Aprovech");
			addTableStyle(dGridFuente, "Variante Tecn");			
			
			DataViewManager DataSetView = ds.DefaultViewManager;
			dGridFuente.DataSource = DataSetView;
			dGridFuente.DataMember = "Fuente";			
		}
		#endregion

		#region Cargar Grupos y Variables Características
		private void initializeGridGrupo()
		{
			//Definición de los  TablesStyles.
			addTableStyle(dGridGrupo, "Grupo");
			addTableStyle(dGridGrupo, "Variables");

			//Asignación del DataSet (ds) al grid -> dGridFuente.			
			DataViewManager DataSetView = ds.DefaultViewManager;
			dGridGrupo.DataSource = DataSetView;
			dGridGrupo.DataMember = "Grupo";
		}

		#endregion

		#region Método que agrega TablesStyle a un Grid Específico.
		private void  addTableStyle(DataGrid dg, string table)
		{
			DataGridTableStyle ts;
			ts = new DataGridTableStyle(); 
			ts.MappingName = table;
			ts.PreferredColumnWidth = dg.Width - 40;
			ts.PreferredRowHeight = 22;
			DataGridTextBoxColumn name = new DataGridTextBoxColumn();
			name.MappingName = "nombre";
			ts.GridColumnStyles.Add(name);
			DataGridTextBoxColumn id = new DataGridTextBoxColumn();
			id.MappingName = "id";
			id.Width = 0;
			ts.GridColumnStyles.Add(id);
			dg.TableStyles.Add(ts);
		}
		#endregion

		#region Método que inicializa los tables styles del grid de datos variables.
		private void initializeGridVariables()
		{
			DataGridTableStyle ts;
			ts = new DataGridTableStyle();
			ts.MappingName = "Datos";
			ts.PreferredColumnWidth = 100;
			ts.PreferredRowHeight = 22;
			
			//Grupo
			DataGridTextBoxColumn name = new DataGridTextBoxColumn();
			name.MappingName = "nombreg";
			name.HeaderText = "Grupo";
			ts.GridColumnStyles.Add(name);

			//Variable
			DataGridTextBoxColumn var = new DataGridTextBoxColumn();
			var.MappingName = "nombrev";
			var.HeaderText = "Variable";
			ts.GridColumnStyles.Add(var);
			
			//Fecha
			DataGridTextBoxColumn fecha = new DataGridTextBoxColumn();
			fecha.MappingName = "fecha";
			fecha.HeaderText = "Fecha";
			ts.GridColumnStyles.Add(fecha);
			
			//Valor
			DataGridTextBoxColumn val = new DataGridTextBoxColumn();
			val.MappingName = "valor";
			val.HeaderText = "Valor";
			ts.GridColumnStyles.Add(val);
			
			//Unidad
			DataGridTextBoxColumn unidad = new DataGridTextBoxColumn();
			unidad.MappingName = "unidad";
			unidad.HeaderText = "Unidad";
			ts.GridColumnStyles.Add(unidad);

			//Descripción
			DataGridTextBoxColumn des = new DataGridTextBoxColumn();
			des.MappingName = "descripcion";
			des.HeaderText = "Descripción";
			des.Width = 200;
			ts.GridColumnStyles.Add(des);

			//Criterio
			DataGridTextBoxColumn crit = new DataGridTextBoxColumn();
			crit.MappingName = "criterio";
			crit.HeaderText = "Criterio";
			crit.Width = 150;
			ts.GridColumnStyles.Add(crit);

			
			//Fuente
			DataGridTextBoxColumn fuente = new DataGridTextBoxColumn();
			fuente.MappingName = "fuente";
			fuente.HeaderText = "Fuente";
			fuente.Width = 150;
			ts.GridColumnStyles.Add(fuente);

			//Responsable
			DataGridTextBoxColumn resp = new DataGridTextBoxColumn();
			resp.MappingName = "responsable";
			resp.HeaderText = "Responsable";
			resp.Width = 150;
			ts.GridColumnStyles.Add(resp);

			//Id del Dato Variable
			DataGridTextBoxColumn datVar = new DataGridTextBoxColumn();
			datVar.MappingName = "id";
			datVar.Width = 0;
			ts.GridColumnStyles.Add(datVar);
			dGridVariables.TableStyles.Add(ts);			
		}
		#endregion

		#region Método que inicializa los tables styles del grid de Archivo.
		private void initializeGridArchivo()
		{
			DataGridTableStyle ts;
			ts = new DataGridTableStyle();
			ts.MappingName = "Archivo";
			ts.PreferredColumnWidth = 100;
			ts.PreferredRowHeight = 22;
			
			//Fecha
			DataGridTextBoxColumn fecha = new DataGridTextBoxColumn();
			fecha.MappingName = "fecha";
			fecha.HeaderText = "Fecha";
			ts.GridColumnStyles.Add(fecha);

			//Autor
			DataGridTextBoxColumn autor = new DataGridTextBoxColumn();
			autor.MappingName = "autor";
			autor.HeaderText = "Autor";
			autor.Width = 150;
			ts.GridColumnStyles.Add(autor);

			//Título
			DataGridTextBoxColumn titulo = new DataGridTextBoxColumn();
			titulo.MappingName = "titulo";
			titulo.HeaderText = "Título";
			ts.GridColumnStyles.Add(titulo);

			//Descripción
			DataGridTextBoxColumn des = new DataGridTextBoxColumn();
			des.MappingName = "descripcion";
			des.HeaderText = "Descripción";
			des.Width = 200;
			ts.GridColumnStyles.Add(des);

			//Ruta
			DataGridTextBoxColumn ruta = new DataGridTextBoxColumn();
			ruta.MappingName = "ruta";
			ruta.HeaderText = "Ruta";
			ruta.Width = 150;
			ts.GridColumnStyles.Add(ruta);

			//Id del Archivo
			DataGridTextBoxColumn id= new DataGridTextBoxColumn();
			id.MappingName = "id";
			id.Width = 0;
			ts.GridColumnStyles.Add(id);
			dGridArchivo.TableStyles.Add(ts);			
		}
		#endregion

		private string dsTable(string str)
		{
			for (int i=0; i<dic.Length/2 ; i++)
			{
				if(str.Equals(dic[i,0])) return(dic[i,1]);
			}
			return ("");
		}

		private void mostrarDatos(string table, int row)
		{
			try
			{	
				textBoxesState(true);
				DataRow dr = ds.Tables[table].Rows[row];
				txtName.Text = dr["nombre"].ToString();
				if(table.Equals("Variables"))
				{
					lblDescripcion.Text= "Unidad";
					txtDescripcion.Text = dr["unidad"].ToString();
				}
				else 
				{	
					lblDescripcion.Text= "Descripción";
					txtDescripcion.Text = dr["descripcion"].ToString();
				}
			}
			catch{}
		}

		private void splitter1_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
		{
			int i;
			for(i = 0; i<dGridFuente.TableStyles.Count; i++)
				dGridFuente.TableStyles[i].GridColumnStyles["nombre"].Width = dGridFuente.Width - 40;
			for(i = 0; i<dGridGrupo.TableStyles.Count; i++)
				dGridGrupo.TableStyles[i].GridColumnStyles["nombre"].Width = dGridGrupo.Width - 40;
			for(i = 0; i<dGridRecurso.TableStyles.Count; i++)
				dGridRecurso.TableStyles[i].GridColumnStyles["nombre"].Width = dGridGrupo.Width - 40;

		}
		
		
		//Actualiza el Datagrid de recursos para forma aprovechamiento		
		private void actualizarDGridRecursos(int id_FormAproc)
		{
			try
			{
				dsRecurso.Clear();
				string selectCommand = "SELECT R.* " +
					"FROM RECURSO R, Forma_Aprovechamiento F,  Inter_FA_R I "+
					"WHERE F.id = I.id_fa and R.id = I.id_recurso and F.id = " + id_FormAproc +
					" ORDER BY R.nombre";
				da = new SqlDataAdapter(selectCommand, ConexionDB.getConnection());
				da.TableMappings.Add("Table", "Recurso");
				da.Fill(dsRecurso);
				initializeGridRecurso();
			}
			catch{}
		}

		//Actualiza el Datagrid de recursos para variante tecnologica		
		private void actualizarDGridRecursosVT(int id_VarTecno)
		{
			try
			{
				dsRecurso.Clear();
				string selectCommand = "SELECT R.* " +
					"FROM RECURSO R, VARIANTE_TECNOLOGICA VT,  Inter_VT_R II "+
					"WHERE VT.id = II.id_vt and R.id = II.id_recurso and VT.id = " + id_VarTecno +
					" ORDER BY R.nombre";
				da = new SqlDataAdapter(selectCommand, ConexionDB.getConnection());
				da.TableMappings.Add("Table", "Recurso");
				da.Fill(dsRecurso);
				initializeGridRecurso();
			}
			catch{}
		}
		
		
		private int buscarPk(string currentTable, int pk)
		{
			int pos = 0;
			DataTable dt = ds.Tables[currentTable];
			foreach (DataRow dr in dt.Rows)
			{
				if (int.Parse(dr["id"].ToString())== pk) return(pos);
				pos++;			
			}
			return(-1);
		}

		private void dGridFuente_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
			
			string []relation = dGridFuente.DataMember.Split(new char[] {'.'});
			string currentRelation = relation[relation.Length - 1];
			currentTableF = dsTable(currentRelation);
			currentTable = currentTableF;
			txtName.Text = "";
			txtDescripcion.Text="";
			//Para poder controlar la jerarquía en el reporte
			int count = relation.Length-1;
			if(count >= 0)
			{
				try
				{
					jerarquiaTabla[count] = currentTable;
					jerarquiaValor[count] = dGridFuente[dGridFuente.CurrentCell.RowNumber, 0].ToString();
				}
				catch{}
			}
			textBoxesState(false);

			//modificación al método para las FA
			if(currentTable.Equals("Forma Aprovech"))
			{
				try
				{
					pk = int.Parse(dGridFuente[dGridFuente.CurrentCell.RowNumber,1].ToString());
					actualizarDGridRecursos (pk);
				}
				catch{}
			}
			else 
			{
				
				//evalua si la tabla actual es variante_tecnológica
				if(currentTable.Equals("Variante Tecn"))
				{
					try
					{
						pk = int.Parse(dGridFuente[dGridFuente.CurrentCell.RowNumber,1].ToString());
						actualizarDGridRecursosVT(pk);
					}
					catch{}
				}

					//No carga datos
				else dGridRecurso.DataSource = null;
			}
		}

		private void dGridFuente_CurrentCellChanged(object sender, System.EventArgs e)
		{
			pk = int.Parse(dGridFuente[dGridFuente.CurrentCell.RowNumber,1].ToString());
			currentRow = buscarPk(currentTableF, pk);
			mostrarDatos(currentTableF, currentRow);
			currentTable = currentTableF;
			mostrarDatosVariables();
			mostrarArchivos();
			//modificación al método para aceptar recursos en forma de aprovechamiento
			if(currentTable.Equals("Forma Aprovech"))
			{
				actualizarDGridRecursos(pk);
			}
			else 
			{
				//modificación al método para aceptar recursos en variante tecn
				if(currentTable.Equals("Variante Tecn"))
				{
					actualizarDGridRecursosVT(pk);
				}
				else
				{
					dGridRecurso.DataSource = null;
				}
			}
			string []relation = dGridFuente.DataMember.Split(new char[] {'.'});
			int count = relation.Length-1;
			if(count >= 0)
			{
				try
				{
					jerarquiaTabla[count] = currentTable;
					jerarquiaValor[count] = dGridFuente[dGridFuente.CurrentCell.RowNumber, 0].ToString();
				}
				catch{}
			}
		}

		private void dGridFuente_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			DataGrid.HitTestInfo hitInfo = dGridFuente.HitTest(e.X, e.Y);
			switch(hitInfo.Type)
			{
				case DataGrid.HitTestType.Cell:
					
				case DataGrid.HitTestType.RowHeader:
					pk = int.Parse(dGridFuente[hitInfo.Row, 1].ToString());					 
					currentRow = buscarPk(currentTableF, pk);
					mostrarDatos(currentTableF, currentRow);	
					currentTable = currentTableF;
					enableControls(true);
					mostrarDatosVariables();
					mostrarArchivos();
					if(currentTable.Equals("Forma Aprovech"))
					{
						actualizarDGridRecursos(pk);
					}
					else 
					{
						//modificación al método para aceptar recursos en variante tecn
						if(currentTable.Equals("Variante Tecn"))
						{
							actualizarDGridRecursosVT(pk);
						}
						else
						{
							dGridRecurso.DataSource = null;
						}
					}
					string []relation = dGridFuente.DataMember.Split(new char[] {'.'});
					int count = relation.Length-1;
					if(count >= 0)
					{
						try
						{
							jerarquiaTabla[count] = currentTable;
							jerarquiaValor[count] = dGridFuente[dGridFuente.CurrentCell.RowNumber, 0].ToString();
						}
						catch{}
					}
					break;					
			}		
		}

		private void dGridGrupo_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
			string []relation = dGridGrupo.DataMember.Split(new char[] {'.'});
			currentTableG = relation[relation.Length - 1];			
			if(currentTableG.Equals("Variables")) lblDescripcion.Text= "Unidad";
			else lblDescripcion.Text= "Descripción";
			txtName.Text = "";
			txtDescripcion.Text="";
			textBoxesState(false);
			currentTable = currentTableG;
			
		}

		private void dGridGrupo_CurrentCellChanged(object sender, System.EventArgs e)
		{
			pk = int.Parse(dGridGrupo[dGridGrupo.CurrentCell.RowNumber, 1].ToString());
			currentRowG = buscarPk(currentTableG, pk);
			currentTable = currentTableG;
			mostrarDatos(currentTableG, currentRowG);
			this.dGridRecurso.DataSource = null;
			
			this.tlbVariable.Visible = false;
			this.tlbFileAttach.Visible = false;
			this.tblFileEdit.Visible = false;
			this.tblFileDel.Visible = false;
			this.tlbFileOpen.Visible = false;
			this.tblFileVisualizar.Visible = false;
			this.tblMainPrint.Visible = false;
						
		}

		private void dGridGrupo_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			DataGrid.HitTestInfo hitInfo = dGridGrupo.HitTest(e.X, e.Y);
			switch(hitInfo.Type)
			{
				case DataGrid.HitTestType.Cell:
					
				case DataGrid.HitTestType.RowHeader:
					pk = int.Parse(dGridGrupo[hitInfo.Row, 1].ToString());
					currentRowG = buscarPk(currentTableG, pk);					
					currentTable = currentTableG;
					mostrarDatos(currentTableG, currentRowG);	
					enableControls(false);
					dGridArchivo.DataSource = null;
					dGridVariables.DataSource = null;
					break;					
			}
		}

		private void textBoxesState(bool state)
		{
			txtName.Text = txtDescripcion.Text = "";
			txtName.Enabled = state;
			txtDescripcion.Enabled = state;
			dGridArchivo.DataSource = null; 
			dGridVariables.DataSource = null; 
		}
		private void newFuenteSize(float size)
		{
			Font f;
			f = new Font(new FontFamily("Tahoma") , size);
			txtName.Font = f;			
			txtDescripcion.Font = f;
		}		

		private void tlBarMain_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			float size;
			string []headers = {"nombre", "descripcion"};
			txtName.Text = txtName.Text.Trim();
			txtDescripcion.Text = txtDescripcion.Text.Trim();
			if (txtName.Enabled)
			{
				switch (tlBarMain.Buttons.IndexOf(e.Button))
				{
					case 0:
						break;
			
					case 1:
						try
						{
							if (!((txtName.Text.Equals("")) || (txtDescripcion.Text.Equals(""))))
							{
								switch (currentTable)
								{
									case "Fuente":									
										Util.Update(Util.getDAFuente(), "Fuente", pk, headers, txtName.Text, txtDescripcion.Text);
										MessageBox.Show("Se han guardado los cambios realizados.", "Fuente", MessageBoxButtons.OK, MessageBoxIcon.Information);
										textBoxesState(false);
										initCurrentTables();
										break;
						
									case "Proceso":
										Util.Update(Util.getDAProceso(), "Proceso", pk, headers, txtName.Text, txtDescripcion.Text);
										MessageBox.Show("Se han guardado los cambios realizados.", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
										textBoxesState(false);
										initCurrentTables();
										break;

									case "Forma Aprovech":
										Util.Update(Util.getDAFA(), "Forma Aprovech", pk, headers, txtName.Text, txtDescripcion.Text);
										MessageBox.Show("Se han guardado los cambios realizados.", "Formas de Aprovechamiento", MessageBoxButtons.OK, MessageBoxIcon.Information);
										textBoxesState(false);
										initCurrentTables();
										break;

									case "Variante Tecn":
										Util.Update(Util.getDAVT(), "Variante Tecn", pk, headers, txtName.Text, txtDescripcion.Text);
										MessageBox.Show("Se han guardado los cambios realizados.", "Variante Tecnológica", MessageBoxButtons.OK, MessageBoxIcon.Information);
										textBoxesState(false);
										initCurrentTables();
										break;

									case "Grupo":
										Util.Update(Util.getDAGrupo(), "Grupo", pk, headers, txtName.Text, txtDescripcion.Text);
										Util.updateGrupoVariablesEnDV();
										MessageBox.Show("Se han guardado los cambios realizados.", "Grupo", MessageBoxButtons.OK, MessageBoxIcon.Information);
										textBoxesState(false);
										initCurrentTables();
										break;

									case "Variables":
										headers[1] = "unidad";
										Util.Update(Util.getDAVar(), "Variables", pk, headers, txtName.Text, txtDescripcion.Text);
										Util.updateGrupoVariablesEnDV();
										MessageBox.Show("Se han guardado los cambios realizados.", "Variable Característica", MessageBoxButtons.OK, MessageBoxIcon.Information);
										textBoxesState(false);
										initCurrentTables();
										break;

									case "Recurso":
										
										Util.Update(Util.getDARec(), "Recurso", pk, headers, txtName.Text, txtDescripcion.Text);
										Util.updateGrupoVariablesEnDV();
										MessageBox.Show("Se han guardado los cambios realizados.", "Variable Característica", MessageBoxButtons.OK, MessageBoxIcon.Information);
										textBoxesState(false);
										initCurrentTables();
										dGridRecurso.DataSource = null;
										break;
								
								
								}
							}
							else MessageBox.Show("El nombre y/o la descripción son campos obligatorios", "EPM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);							
					
						}
						catch(Exception ex){MessageBox.Show("Error: " + ex.Message + ".","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);}					
						break;
					
						//caso para generar reporte
					case 2:
						string header;
					switch (currentTable)
					{
						case "Fuente":
							header = "Fuente";
							jerarquia();
							break;
							
						case "Proceso":
							header = "Fuente";
							jerarquia();
							break;

						case "Forma Aprovech":
							header = "Forma de Aprovechamiento";
							jerarquia();
							break;

						case "Variante Tecn":
							header = "Variante Tecnológica";
							jerarquia();
							break;

						case "Recurso":
							header = "Recurso";
							jerarquia();
							break;

						case "Grupo":
							header = "Grupo";
							jerarquia();
							break;
							
						default:
							header = currentTable;
							jerarquia();
								
							break;
					}
					
						break;
					case 3:
						break;

					case 4: // controla aumento de tamaño de la letra
						size = txtName.Font.Size;
						if (size < 15) newFuenteSize(size += 1.0F);
						break;
			
					case 5: // controla disminuir tamaño de la letra
						size = txtName.Font.Size;
						if (size > 8) newFuenteSize(size -= 1.0F);
						break;
				}
			}
		}


		public void jerarquia() // controla la jerarquia que será impresa en el reporte
		{
			string []relation = dGridFuente.DataMember.Split(new char[] {'.'});
			for(int i = 0; i < relation.Length; i++)
			{
				jerarquiaTabla[i] = relation[i];
			}
			for(int i = relation.Length; i < 4; i++)
			{
				jerarquiaTabla[i] = null;
				jerarquiaValor[i] = null;
			}
			frmReportes newReport = new frmReportes(jerarquiaTabla, jerarquiaValor, txtDescripcion.Text, dv, dvArchivo);
			newReport.ShowDialog(this);
		
		}

		
		public void mostrarDatosVariables()
		{
			this.tblMainPrint.Visible = true;
			this.tlbVariable.Visible = true;
			dv = null;
			dv = new DataView();
			dv.Table = ds.Tables["Datos"];
			this.dGridVariables.DataSource = dv;
			switch(currentTable)
			{
				case "Fuente":
					dv.RowFilter = "fuente_id = " + pk;
					break;

				case "Proceso":
					dv.RowFilter = "proceso_id = " + pk;
					break;

				case "Forma Aprovech":
					dv.RowFilter = "form_aprov_id = " + pk;
					break;

				case "Variante Tecn":	
					dv.RowFilter = "var_tecn_id = " + pk;
					break;

				case "Recurso":
					dv.RowFilter = "recurso_id = " + pk;
					break;
			}			
		}

		public void mostrarArchivos()
		{
			this.tlbFileAttach.Visible = true;
			this.tblFileEdit.Visible = true;
			this.tblFileDel.Visible = true;
			this.tlbFileOpen.Visible = true;
			this.tblFileVisualizar.Visible = true;

			dvArchivo = null;
			dvArchivo = new DataView();
			dvArchivo.Table = ds.Tables["Archivo"];
			this.dGridArchivo.DataSource = dvArchivo;
			switch(currentTable)
			{
				case "Fuente":
					dvArchivo.RowFilter = "fuente_id = " + pk;
					break;

				case "Proceso":
					dvArchivo.RowFilter = "proceso_id = " + pk;
					break;

				case "Forma Aprovech":
					dvArchivo.RowFilter = "form_aprov_id = " + pk;
					break;

				case "Variante Tecn":	
					dvArchivo.RowFilter = "var_tecn_id = " + pk;
					break;

				case "Recurso":
					dvArchivo.RowFilter = "recurso_id = " + pk;
					break;
			}			
		}

		private void initCurrentTables()
		{
			currentTableF = dataGridCurrentTable(this.dGridFuente);
			currentTableG = dataGridCurrentTable(this.dGridGrupo);
			if (currentTableF.Equals(""))  currentTableF = "Fuente";
			if (currentTableG.Equals(""))  currentTableG = "Grupo";
						
		}

		private string dataGridCurrentTable(DataGrid dg)
		{
			string []relation = dg.DataMember.Split(new char[] {'.'});
			string currentRelation = relation[relation.Length - 1];
			return(dsTable(currentRelation));			
		}

		private void enableControls(bool bol)
		{
			this.dGridVariables.Enabled = bol;
			this.tlbVariable.Enabled = bol;
			this.dGridArchivo.Enabled = bol;
			this.tlbArchivo.Enabled = bol;
		}

		private void mnuProceso_Click(object sender, System.EventArgs e)
		{
			frmNuevoProceso newProceso = new frmNuevoProceso();
			newProceso.ShowDialog(this); 		
		}

		private void mnuFA_Click(object sender, System.EventArgs e)
		{
			frmNuevaFA newFA = new frmNuevaFA();
			newFA.ShowDialog(this); 
		}

		private void mnuVT_Click(object sender, System.EventArgs e)
		{
			frmNuevaVT newVT = new frmNuevaVT();
			newVT.ShowDialog(this); 		
		}

		private void mnuGrupo_Click(object sender, System.EventArgs e)
		{
			frmNuevoGrupo newGroup = new frmNuevoGrupo();
			newGroup.ShowDialog(this); 
			actualizarR();
		}

		private void mnuVC_Click(object sender, System.EventArgs e)
		{
			frmNuevaVariable newVar = new frmNuevaVariable();
			newVar.ShowDialog(this); 
		}
		#region Opciones para el manejo de variables.
		private void tlbVariable_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			 
			frmDatosVariable newDV = null;
			if (txtName.Enabled)
			{
				switch (tlbVariable.Buttons.IndexOf(e.Button))
				{
					case 0:
						break;

						//ingresar nueva variable
					case 1:
					switch (currentTable)
					{
						case "Fuente":	
							newDV = new frmDatosVariable(pk, "fuente_id");
							newDV.ShowDialog(this);
							textBoxesState(false);
							initCurrentTables();
							actualizar();
							break;

						case "Proceso":
							newDV = new frmDatosVariable(pk, "proceso_id");
							newDV.ShowDialog(this); 
							textBoxesState(false);
							initCurrentTables();
							break;

						case "Forma Aprovech":
							newDV = new frmDatosVariable(pk,"form_aprov_id");
							newDV.ShowDialog(this); 
							textBoxesState(false);
							initCurrentTables();
							break;

						case "Variante Tecn":
							newDV = new frmDatosVariable(pk, "var_tecn_id");
							newDV.ShowDialog(this); 
							textBoxesState(false);
							initCurrentTables();
							break;
							
						case "Recurso":
							newDV = new frmDatosVariable(pk, "recurso_id");
							newDV.ShowDialog(this); 
							textBoxesState(false);
							initCurrentTables();	
							break;
					}
						
						break;

						//editar
					case 2:
						if (this.dGridVariables.CurrentRowIndex > -1)
						{
							int pos = int.Parse(dGridVariables[dGridVariables.CurrentCell.RowNumber,9].ToString());
							newDV = new frmDatosVariable(buscarPk("Datos",  pos));
							newDV.ShowDialog(this);
						}						
						break;

						//caso eliminar datos variable
					case 3:
						try
						{
							DialogResult resultado = new DialogResult();
							resultado = MessageBox.Show ("Realmente desea Eliminar el dato del sistema?", "Confirmar Eliminar", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
							if (resultado == DialogResult.Yes)
							{							
								if (this.dGridVariables.CurrentRowIndex > -1)
								{
									int pos = int.Parse(dGridVariables[dGridVariables.CurrentCell.RowNumber,9].ToString());
									SqlConnection conn = ConexionDB.getConnection();
									SqlCommand sqlcmddelvar = conn.CreateCommand();
									string sqldel = "DELETE DATOS_VARIABLE WHERE id = " + pos ;  
									sqlcmddelvar.CommandText = sqldel;
									sqlcmddelvar.ExecuteNonQuery();	
									MessageBox.Show("Se ha eliminado el dato  del sistema ", "Usuarios", 
										MessageBoxButtons.OK, MessageBoxIcon.Information);	
							
									
									Util.initializeDataset();
									actualizar();
								}
							}
							else return;
						}
						catch{}
						break;

						//visualizar
					case 4:
						if (this.dGridVariables.CurrentRowIndex > -1)
						{
							int pos = int.Parse(dGridVariables[dGridVariables.CurrentCell.RowNumber,9].ToString());
							newDV = new frmDatosVariable(buscarPk("Datos",  pos), noComp);
							newDV.ShowDialog(this);
						}						
						break;
					
						//caso  exportar a excel
					case 5:
						if (this.dGridVariables.CurrentRowIndex > -1)
						{
						
							switch (currentTable)
							{
								case "Fuente":	
									nivel(pk, "fuente");
									export(pk, "fuente_id");   
									break;

								case "Proceso":
									nivel(pk, "proceso");
									export(pk, "proceso_id");
									break;

								case "Forma Aprovech":
									nivel(pk, "forma_aprovechamiento");
									export(pk, "form_aprov_id");
									break;

								case "Variante Tecn":
									nivel(pk, "variante_tecnologica");
									export(pk, "var_tecn_id");
									break;
							
								case "Recurso":
									nivel(pk, "recurso");	
									export(pk, "recurso_id");
									break;
							}
						}
						break;
		
				}
			}
		
			this.dGridRecurso.DataSource = null;
					
		}
		#endregion

		
		//método que exporta a XLS
		public void export (int key, string foreing)
		{
				
			try
			{
				string nombre = this.getNombre();
				string sqlexport = "SELECT * FROM datos_variable where " + foreing +" = "+ key;
				da = new SqlDataAdapter(); 
				da.SelectCommand = new SqlCommand(sqlexport,cnx); 
				da.Fill(ds2, "datos_variable");
				int[] col = {3}; //se definen las columnas a exportar
				MessageBox.Show ("Se han exportado los datos acerca de "+ result +" a Excel\nPresione 'Aceptar' para visualizar Excel", "Exportar datos", MessageBoxButtons.OK,MessageBoxIcon.Information);
				DataTable tablaEX = ds2.Tables["datos_variable"].Copy();
				RKLib.ExportData.Export uno = new RKLib.ExportData.Export("Win");
				uno.ExportDetails (tablaEX,col,Export.ExportFormat.Excel,nombre);
				ds2.Tables["datos_variable"].Clear();
				Process.Start(nombre);	
			}
			catch (Exception){};
		}

		//metodo para obtener nombre de el XLS
		private string getNombre()
		{
			int i;
			string name = "Excel"; 
			string ext = ".xls";
			string []xlss = Directory.GetFiles(".","*.xls");
			foreach (string xls in xlss) 
			{
				try{ File.Delete(xls);}
				catch{}
			}

			for(i = 1; ;i++)
			{
				if(!(File.Exists(name + i + ext))) break;
			}
			return (name + i + ext);
		}
		//metodo para obtener el nivel
		public string nivel (int nivel,string tblactual)
		{
			try
			{
				SqlConnection conn = ConexionDB.getConnection();
				SqlCommand sqlcmdin = conn.CreateCommand();
				string sqlin = "SELECT nombre FROM " +tblactual + " where id =" + nivel;  
				sqlcmdin.CommandText = sqlin;
				SqlDataReader rdrnivel = sqlcmdin.ExecuteReader();
				while (rdrnivel.Read())
				{
					result = rdrnivel.GetString(0);
				}
				rdrnivel.Close();
			}
			catch{};
			return result;
			
		}
		

		private void mnuRepositorio_Click(object sender, System.EventArgs e)
		{
			frmDir newDir = new  frmDir();
			newDir.ShowDialog(this); 	
		}
		#region Opciones para el manejo de los archivos
		private void tlbArchivo_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			frmArchivo newArchivo = null;            
			if (txtName.Enabled)
			{
				switch (tlbArchivo.Buttons.IndexOf(e.Button))
				{
					case 0:
						break;

					case 1:
					switch (currentTable)
					{
						case "Fuente":	
							newArchivo = new frmArchivo(pk, "fuente_id");
							newArchivo.ShowDialog(this);
							textBoxesState(false);
							initCurrentTables();
							break;

						case "Proceso":
							newArchivo = new frmArchivo(pk, "proceso_id");
							newArchivo.ShowDialog(this);
							textBoxesState(false);
							initCurrentTables();							
							break;

						case "Forma Aprovech":
							newArchivo = new frmArchivo(pk, "form_aprov_id");
							newArchivo.ShowDialog(this);
							textBoxesState(false);
							initCurrentTables();	
							break;

						case "Variante Tecn":
							newArchivo = new frmArchivo(pk, "var_tecn_id");
							newArchivo.ShowDialog(this);
							textBoxesState(false);
							initCurrentTables();		
							break;
							
						case "Recurso":
							newArchivo = new frmArchivo(pk, "recurso_id");
							newArchivo.ShowDialog(this);
							textBoxesState(false);
							initCurrentTables();		
							break;
					}
						break;
						//editar
					case 2:
						if (this.dGridArchivo.CurrentRowIndex > -1)
						{
							
							string dir = Util.getDirectorio();
							string fileName = dGridArchivo[dGridArchivo.CurrentCell.RowNumber,4].ToString();
							int pos = int.Parse(dGridArchivo[dGridArchivo.CurrentCell.RowNumber,5].ToString());
							newArchivo = new frmArchivo(buscarPk("Archivo",  pos), dir, fileName);
							newArchivo.ShowDialog(this);	
							
						}						
						break;
					
						//abrir archivo adjunto
					case 3:
						if (this.dGridArchivo.CurrentRowIndex > -1)
						{
							try
							{
								string dir = Util.getDirectorio();
								string fileName = dGridArchivo[dGridArchivo.CurrentCell.RowNumber,4].ToString();
								Process.Start(dir + fileName);
							}
							catch
							{
								MessageBox.Show("Error: No se encuentra el archivo en la ruta especificada  " + Util.getDirectorio() + 
									"\nPara configurar esta opción dirijase a Herramientas-Configuación de Sistema.","EPM Alternativas",
									MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
						break;
						// visualizar archivos adjuntos
					case 4:
						
						if (this.dGridArchivo.CurrentRowIndex > -1)
						{
							
							string dir = Util.getDirectorio();
							string fileName = dGridArchivo[dGridArchivo.CurrentCell.RowNumber,4].ToString();
							int pos = int.Parse(dGridArchivo[dGridArchivo.CurrentCell.RowNumber,5].ToString());
							newArchivo = new frmArchivo(buscarPk("Archivo",  pos), noComp, dir, fileName);
							newArchivo.ShowDialog(this);	
							
						}						
						break;

						// eliminar archivos adjuntos
					case 5:
						
						try
						{
							DialogResult resultado = new DialogResult();
							resultado = MessageBox.Show ("Realmente desea Eliminar el archivo del sistema?", "Confirmar Eliminar", MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
							if (resultado == DialogResult.Yes)
							{
								int pos = int.Parse(this.dGridArchivo[dGridArchivo.CurrentCell.RowNumber,5].ToString());
								SqlConnection conn = ConexionDB.getConnection();
								SqlCommand sqlcmddelfile = conn.CreateCommand();
								string sqldel = "DELETE ARCHIVO WHERE id = " + pos ;  
								sqlcmddelfile.CommandText = sqldel;
								sqlcmddelfile.ExecuteNonQuery();	
								MessageBox.Show("Se ha eliminado el archivo adjunto  del sistema ", "Usuarios", 
									MessageBoxButtons.OK, MessageBoxIcon.Information);	
								Util.initializeDataset();
							}
							else return;
						}
						catch{}
						break;
				}
				actualizar();
				this.dGridRecurso.DataSource = null;
			}
			
		
		}
		#endregion

		private void dGridRecurso_CurrentCellChanged(object sender, System.EventArgs e)
		{
			try
			{
				pk = int.Parse(dGridRecurso[dGridRecurso.CurrentCell.RowNumber,1].ToString());
				currentRow = buscarPk("Recurso", pk);
				currentTable = currentTableR;
				mostrarDatos("Recurso", currentRow);
				mostrarDatosVariables();
				mostrarArchivos();
			}
			catch(Exception){}
		}

		private void dGridRecurso_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			dGridRecurso_CurrentCellChanged(null, null);
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			frmNuevoRecurso nvr = new frmNuevoRecurso();
			nvr.ShowDialog(this);
			actualizarR();
		}

		private void mnuContenido_Click(object sender, System.EventArgs e)
		{
			//Ejecuta la ayuda del sistema. Se ubica en la misma carpeta del ejecutable del sistema
			string path = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
			Process.Start("IExplore.exe" , path + "\\ayuda\\Index.htm");
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void mnuAcercaDe_Click(object sender, System.EventArgs e)
		{
			frmAbout que = new frmAbout();
			que.ShowDialog(this);
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			//Ejecuta el glosario. Se ubica en la misma carpeta del ejecutable del sistema
			string path = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
			Process.Start("IExplore.exe" , path + "\\ayuda\\Pagina_glos2.htm");
		}

		

		private string getPerfil()
		{
			string result = "";
			SqlConnection conn = ConexionDB.getConnection();
			SqlCommand sql = conn.CreateCommand();
			string sqlSelect = "SELECT perfil FROM usuario WHERE LOWER(login) = '" + User.getUser().ToLower() + "'";
			sql.CommandText = sqlSelect;
			SqlDataReader rdr = sql.ExecuteReader();
			while (rdr.Read())
			{
				result = rdr.GetString(0);
			}
			rdr.Close();
			return(result.ToLower());
			
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			frmUser user = new frmUser();
			user.ShowDialog(this);
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			frmUsuarioEdit edt = new frmUsuarioEdit();
			edt.ShowDialog();
		}

		//actualiza el datagrid fuente..
		private void actualizar()
		{
			try
			{
				this.txtName.DataBindings.Clear();
				this.txtDescripcion.DataBindings.Clear();

				Util.initializeDataset();
				ds = Util.getDataSet();
				mostrarDatosVariables();
				mostrarArchivos();
				//Datagrid fuente			
				DataViewManager DataSetView = ds.DefaultViewManager;
				dGridFuente.DataSource = DataSetView;
				dGridFuente.DataMember = "Fuente";	
				//Datagrid grupo
				dsG = Util.getDataSet();
				this.dGridGrupo.DataSource = DataSetView;
				this.dGridGrupo.DataMember = "Grupo";
			}
			catch {};
		}

		private void actualizarR()
		{
			this.dGridRecurso.DataSource = null;
		}


		
		private void dGridVariables_DoubleClick(object sender, System.EventArgs e)
		{
			
			frmDatosVariable newDV;
			
			if (this.dGridVariables.CurrentRowIndex > -1)
			{
				int pos = int.Parse(dGridVariables[dGridVariables.CurrentCell.RowNumber,9].ToString());
				newDV = new frmDatosVariable(buscarPk("Datos",  pos));
				newDV.ShowDialog(this);
			}	
		}

		private void dGridArchivo_DoubleClick(object sender, System.EventArgs e)
		{
			frmArchivo newArchivo;
			
			if (this.dGridArchivo.CurrentRowIndex > -1)
			{
							
				int pos = int.Parse(dGridArchivo[dGridArchivo.CurrentCell.RowNumber,5].ToString());
				string dir = Util.getDirectorio();
				string fileName = dGridArchivo[dGridArchivo.CurrentCell.RowNumber,4].ToString();
				newArchivo = new frmArchivo(buscarPk("Archivo",  pos), dir, fileName);
				newArchivo.ShowDialog(this);	
							
			}		
		}
		#region Opciones en el menú de eliminar
		
		//opcion menu borrar usuario
		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			frmDelUser bye = new frmDelUser();
			bye.ShowDialog();
		}
		//opcion menu borrar fuente
		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			pk = int.Parse(dGridFuente[dGridFuente.CurrentCell.RowNumber,1].ToString());
			currentRow = buscarPk(currentTableF, pk);
			eliminar("Fuente", "Fuente", "fuente_id", "Proceso", currentRow, "Proceso");
		}
		//opcion menu borrar proceso
		public void menuItem9_Click(object sender, System.EventArgs e)
		{
			pk = int.Parse(dGridFuente[dGridFuente.CurrentCell.RowNumber,1].ToString());
			currentRow = buscarPk(currentTableF, pk);
			eliminar("Proceso", "Proceso", "proceso_id", "forma_aprovechamiento",currentRow, "Forma Aprovech");
		}
		//opcion menu Forma aprovechamiento
		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			eliminar("Forma Aprovech", "Forma de Aprovechamiento", null, null,0, "Variante Tecn");
		}
		//opcion menu Variante Tecnológica
		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			eliminar("Variante Tecn", "Variante Tecnológica", null, null,0, "Grupo");
		}
		//opcion menu Variante grupo
		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			eliminar("Grupo", "Grupo", null, null,0, "Variables");
			actualizarR();
		}
		//opcion menu Variable Característica
		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			eliminar("Variables", "Variable Característica", null, null,0, null);
		}
		//opcion menu recurso
		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			eliminar("Recurso", "Recurso", null, null,0, null);
			actualizarR();
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			frmDelUser bye = new frmDelUser();
			bye.ShowDialog();
		}

		
		//metodo para eliminar
		public void eliminar(string table, string titledel, string foranea, string hijo, int row, string hijods)
		{
			
			/*
			DataRow dr = ds.Tables[table].Rows[row];
			string nombreF = dr["nombre"].ToString();
			object resultID = 0;
			string elid = "select id from " + table + " where nombre = '" + nombreF + "'";
			SqlCommand sqllook2 = cnx.CreateCommand();
			sqllook2.CommandText = elid;
			sqllook2.ExecuteNonQuery();
			SqlDataReader rdid = sqllook2.ExecuteReader();
			while (rdid.Read())
			{
				resultID = rdid.GetValue(0);

			}

			rdid.Close();
			string ides = Convert.ToString(resultID);
			string sihay = "Select " + foranea + " from " + hijo + " where " + foranea + " = " + ides;
			object resultadoForey = 0;
			SqlCommand sqllook = cnx.CreateCommand();
			sqllook.CommandText = sihay;
			sqllook.ExecuteNonQuery();
			SqlDataReader rdr = sqllook.ExecuteReader();
	
			while (rdr.Read())
			{
				resultadoForey = rdr.GetValue(0);

			}
			rdr.Close();
			int hola = Convert.ToInt32(resultadoForey);

			if (hola > 0)
			{
			
				DialogResult resultado = new DialogResult();
				resultado = MessageBox.Show ("Existe un " + hijo + " que depende de " + nombreF + "\nDesea eliminarlo","ATENCIÓN",
					MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2);
				if (resultado == DialogResult.Yes)
				{
					
					switch (hijo)
					{
						case "Proceso":	
							frmEliminar bye = new frmEliminar (hijo, hijods);
							bye.ShowDialog(this);
							//menuItem9_Click(null,null);
							break;

						case "Forma Aprovech":
							
							break;
					}
					
					
				}
			

			}
			
			else
			{
			
				MessageBox.Show("NO existe un " + hijo + " que depende de " + nombreF);

			}

			*/					
			

			frmEliminar bye = new frmEliminar (titledel, table);
			bye.ShowDialog(this);
			actualizar();
		}

		

		
					

	}
	#endregion		 

}