namespace FractalLive
{
	partial class MainDlg
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.Label label_MaxIterations;
            System.Windows.Forms.Label label_StartOrbit;
            System.Windows.Forms.Label label_OrbitRange;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainDlg));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_Bailout1X = new System.Windows.Forms.Label();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.glControl = new OpenTK.WinForms.GLControl();
            this.button_Left = new System.Windows.Forms.Button();
            this.button_Right = new System.Windows.Forms.Button();
            this.label_OrbitTrap = new System.Windows.Forms.Label();
            this.label_Formula = new System.Windows.Forms.Label();
            this.input_BailoutY = new System.Windows.Forms.TextBox();
            this.input_OrbitTrap = new System.Windows.Forms.ComboBox();
            this.input_FractalFormula = new System.Windows.Forms.ComboBox();
            this.input_FractalType = new System.Windows.Forms.ComboBox();
            this.input_Power = new System.Windows.Forms.TextBox();
            this.label_FractalType = new System.Windows.Forms.Label();
            this.label_Power = new System.Windows.Forms.Label();
            this.input_CPower = new System.Windows.Forms.TextBox();
            this.label_CPower = new System.Windows.Forms.Label();
            this.input_MaxIterations = new System.Windows.Forms.NumericUpDown();
            this.button_Menu1 = new System.Windows.Forms.Button();
            this.label_FormulaMenu = new System.Windows.Forms.Label();
            this.button_Menu2 = new System.Windows.Forms.Button();
            this.label_Bailout = new System.Windows.Forms.Label();
            this.button_Menu3 = new System.Windows.Forms.Button();
            this.input_Bailout = new System.Windows.Forms.TextBox();
            this.button_Menu4 = new System.Windows.Forms.Button();
            this.panel_FormulaMenu = new System.Windows.Forms.Panel();
            this.label_BailoutTrap = new System.Windows.Forms.Label();
            this.input_BailoutX = new System.Windows.Forms.TextBox();
            this.panel_OrbitTrapMenu = new System.Windows.Forms.Panel();
            this.label_OrbitTrapFactors = new System.Windows.Forms.Label();
            this.label_EditingOrbitBailout = new System.Windows.Forms.Label();
            this.input_StartOrbit = new System.Windows.Forms.NumericUpDown();
            this.input_OrbitTrapFactor1 = new System.Windows.Forms.TextBox();
            this.input_EditingBailoutTrap = new System.Windows.Forms.NumericUpDown();
            this.input_OrbitTrapFactor2 = new System.Windows.Forms.TextBox();
            this.input_OrbitRange = new System.Windows.Forms.NumericUpDown();
            this.button_RemoveBailoutTrap = new System.Windows.Forms.Button();
            this.button_AddBailoutTrap = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Texture = new System.Windows.Forms.Label();
            this.input_Texture = new System.Windows.Forms.TextBox();
            this.checkBox_LockZoomFactor = new System.Windows.Forms.CheckBox();
            this.input_ColorCycles = new System.Windows.Forms.TextBox();
            this.label_ColorCycles = new System.Windows.Forms.Label();
            this.input_ColorFactor = new System.Windows.Forms.TextBox();
            this.label_ColorFactor = new System.Windows.Forms.Label();
            this.input_Center = new System.Windows.Forms.TextBox();
            this.label_Center = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.input_Zoom = new System.Windows.Forms.TextBox();
            label_MaxIterations = new System.Windows.Forms.Label();
            label_StartOrbit = new System.Windows.Forms.Label();
            label_OrbitRange = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_MaxIterations)).BeginInit();
            this.panel_FormulaMenu.SuspendLayout();
            this.panel_OrbitTrapMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_StartOrbit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_EditingBailoutTrap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_OrbitRange)).BeginInit();
            this.SuspendLayout();
            // 
            // label_MaxIterations
            // 
            label_MaxIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label_MaxIterations.AutoSize = true;
            label_MaxIterations.Location = new System.Drawing.Point(3, 79);
            label_MaxIterations.Name = "label_MaxIterations";
            label_MaxIterations.Size = new System.Drawing.Size(88, 15);
            label_MaxIterations.TabIndex = 6;
            label_MaxIterations.Text = "Max Iterations: ";
            label_MaxIterations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_StartOrbit
            // 
            label_StartOrbit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label_StartOrbit.AutoSize = true;
            label_StartOrbit.Location = new System.Drawing.Point(3, 155);
            label_StartOrbit.Name = "label_StartOrbit";
            label_StartOrbit.Size = new System.Drawing.Size(67, 15);
            label_StartOrbit.TabIndex = 47;
            label_StartOrbit.Text = "Start Orbit: ";
            label_StartOrbit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_OrbitRange
            // 
            label_OrbitRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label_OrbitRange.AutoSize = true;
            label_OrbitRange.Location = new System.Drawing.Point(3, 181);
            label_OrbitRange.Name = "label_OrbitRange";
            label_OrbitRange.Size = new System.Drawing.Size(76, 15);
            label_OrbitRange.TabIndex = 49;
            label_OrbitRange.Text = "Orbit Range: ";
            label_OrbitRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1078, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator4,
            this.selectAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(119, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label_Bailout1X
            // 
            this.label_Bailout1X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Bailout1X.AutoSize = true;
            this.label_Bailout1X.Location = new System.Drawing.Point(3, 170);
            this.label_Bailout1X.Name = "label_Bailout1X";
            this.label_Bailout1X.Size = new System.Drawing.Size(59, 15);
            this.label_Bailout1X.TabIndex = 13;
            this.label_Bailout1X.Text = "Bailout 1: ";
            this.label_Bailout1X.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LogTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogTextBox.Location = new System.Drawing.Point(877, 290);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.Size = new System.Drawing.Size(159, 71);
            this.LogTextBox.TabIndex = 3;
            // 
            // glControl
            // 
            this.glControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.glControl.API = OpenTK.Windowing.Common.ContextAPI.OpenGL;
            this.glControl.APIVersion = new System.Version(3, 3, 0, 0);
            this.glControl.Flags = OpenTK.Windowing.Common.ContextFlags.Default;
            this.glControl.IsEventDriven = true;
            this.glControl.Location = new System.Drawing.Point(12, 24);
            this.glControl.Name = "glControl";
            this.glControl.Profile = OpenTK.Windowing.Common.ContextProfile.Compatability;
            this.glControl.Size = new System.Drawing.Size(500, 309);
            this.glControl.TabIndex = 2;
            this.glControl.Text = "glControl1";
            // 
            // button_Left
            // 
            this.button_Left.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Left.Location = new System.Drawing.Point(521, 340);
            this.button_Left.Name = "button_Left";
            this.button_Left.Size = new System.Drawing.Size(50, 25);
            this.button_Left.TabIndex = 33;
            this.button_Left.Text = "<<<";
            this.button_Left.UseVisualStyleBackColor = true;
            // 
            // button_Right
            // 
            this.button_Right.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Right.Location = new System.Drawing.Point(623, 340);
            this.button_Right.Name = "button_Right";
            this.button_Right.Size = new System.Drawing.Size(50, 25);
            this.button_Right.TabIndex = 22;
            this.button_Right.Text = ">>>";
            this.button_Right.UseVisualStyleBackColor = true;
            // 
            // label_OrbitTrap
            // 
            this.label_OrbitTrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_OrbitTrap.AutoSize = true;
            this.label_OrbitTrap.Location = new System.Drawing.Point(4, 25);
            this.label_OrbitTrap.Name = "label_OrbitTrap";
            this.label_OrbitTrap.Size = new System.Drawing.Size(62, 15);
            this.label_OrbitTrap.TabIndex = 9;
            this.label_OrbitTrap.Text = "Orbit Trap:";
            this.label_OrbitTrap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Formula
            // 
            this.label_Formula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Formula.AutoSize = true;
            this.label_Formula.Location = new System.Drawing.Point(4, 48);
            this.label_Formula.Name = "label_Formula";
            this.label_Formula.Size = new System.Drawing.Size(54, 15);
            this.label_Formula.TabIndex = 20;
            this.label_Formula.Text = "Formula:";
            this.label_Formula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_BailoutY
            // 
            this.input_BailoutY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_BailoutY.Location = new System.Drawing.Point(115, 126);
            this.input_BailoutY.Name = "input_BailoutY";
            this.input_BailoutY.Size = new System.Drawing.Size(40, 23);
            this.input_BailoutY.TabIndex = 17;
            this.input_BailoutY.Text = "0";
            this.input_BailoutY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_BailoutY_KeyDown);
            this.input_BailoutY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_BailoutY_KeyPress);
            this.input_BailoutY.Validating += new System.ComponentModel.CancelEventHandler(this.input_BailoutY_Validating);
            this.input_BailoutY.Validated += new System.EventHandler(this.input_BailoutY_Validated);
            // 
            // input_OrbitTrap
            // 
            this.input_OrbitTrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_OrbitTrap.CausesValidation = false;
            this.input_OrbitTrap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_OrbitTrap.FormattingEnabled = true;
            this.input_OrbitTrap.Items.AddRange(new object[] {
            "Circle",
            "Square",
            "Real",
            "Imaginary",
            "Rectangle",
            "Points",
            "Lines"});
            this.input_OrbitTrap.Location = new System.Drawing.Point(69, 22);
            this.input_OrbitTrap.Name = "input_OrbitTrap";
            this.input_OrbitTrap.Size = new System.Drawing.Size(87, 23);
            this.input_OrbitTrap.TabIndex = 10;
            this.input_OrbitTrap.SelectionChangeCommitted += new System.EventHandler(this.input_OrbitTrap_SelectionChangeCommitted);
            // 
            // input_FractalFormula
            // 
            this.input_FractalFormula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_FractalFormula.CausesValidation = false;
            this.input_FractalFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_FractalFormula.FormattingEnabled = true;
            this.input_FractalFormula.Items.AddRange(new object[] {
            "Classic",
            "Lambda"});
            this.input_FractalFormula.Location = new System.Drawing.Point(69, 48);
            this.input_FractalFormula.Name = "input_FractalFormula";
            this.input_FractalFormula.Size = new System.Drawing.Size(87, 23);
            this.input_FractalFormula.TabIndex = 21;
            // 
            // input_FractalType
            // 
            this.input_FractalType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_FractalType.CausesValidation = false;
            this.input_FractalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_FractalType.FormattingEnabled = true;
            this.input_FractalType.Items.AddRange(new object[] {
            "Mandelbrot",
            "Julia",
            "Julia Mating"});
            this.input_FractalType.Location = new System.Drawing.Point(69, 22);
            this.input_FractalType.Name = "input_FractalType";
            this.input_FractalType.Size = new System.Drawing.Size(87, 23);
            this.input_FractalType.TabIndex = 19;
            // 
            // input_Power
            // 
            this.input_Power.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Power.Location = new System.Drawing.Point(71, 103);
            this.input_Power.Name = "input_Power";
            this.input_Power.Size = new System.Drawing.Size(84, 23);
            this.input_Power.TabIndex = 28;
            this.input_Power.Text = "2";
            // 
            // label_FractalType
            // 
            this.label_FractalType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FractalType.AutoSize = true;
            this.label_FractalType.Location = new System.Drawing.Point(4, 25);
            this.label_FractalType.Name = "label_FractalType";
            this.label_FractalType.Size = new System.Drawing.Size(45, 15);
            this.label_FractalType.TabIndex = 18;
            this.label_FractalType.Text = "Fractal:";
            this.label_FractalType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Power
            // 
            this.label_Power.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Power.AutoSize = true;
            this.label_Power.Location = new System.Drawing.Point(2, 106);
            this.label_Power.Name = "label_Power";
            this.label_Power.Size = new System.Drawing.Size(46, 15);
            this.label_Power.TabIndex = 29;
            this.label_Power.Text = "Power: ";
            this.label_Power.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_CPower
            // 
            this.input_CPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_CPower.Location = new System.Drawing.Point(71, 129);
            this.input_CPower.Name = "input_CPower";
            this.input_CPower.Size = new System.Drawing.Size(84, 23);
            this.input_CPower.TabIndex = 30;
            this.input_CPower.Text = "1";
            // 
            // label_CPower
            // 
            this.label_CPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CPower.AutoSize = true;
            this.label_CPower.Location = new System.Drawing.Point(3, 132);
            this.label_CPower.Name = "label_CPower";
            this.label_CPower.Size = new System.Drawing.Size(57, 15);
            this.label_CPower.TabIndex = 31;
            this.label_CPower.Text = "C Power: ";
            this.label_CPower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_MaxIterations
            // 
            this.input_MaxIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_MaxIterations.CausesValidation = false;
            this.input_MaxIterations.Location = new System.Drawing.Point(90, 77);
            this.input_MaxIterations.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.input_MaxIterations.Name = "input_MaxIterations";
            this.input_MaxIterations.Size = new System.Drawing.Size(65, 23);
            this.input_MaxIterations.TabIndex = 8;
            this.input_MaxIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.input_MaxIterations.ValueChanged += new System.EventHandler(this.input_MaxIterations_ValueChanged);
            // 
            // button_Menu1
            // 
            this.button_Menu1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Menu1.Location = new System.Drawing.Point(521, 308);
            this.button_Menu1.Name = "button_Menu1";
            this.button_Menu1.Size = new System.Drawing.Size(35, 25);
            this.button_Menu1.TabIndex = 34;
            this.button_Menu1.Text = "1";
            this.button_Menu1.UseVisualStyleBackColor = true;
            this.button_Menu1.Click += new System.EventHandler(this.button_Menu1_Click);
            // 
            // label_FormulaMenu
            // 
            this.label_FormulaMenu.AutoSize = true;
            this.label_FormulaMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_FormulaMenu.Location = new System.Drawing.Point(29, 0);
            this.label_FormulaMenu.Name = "label_FormulaMenu";
            this.label_FormulaMenu.Size = new System.Drawing.Size(100, 19);
            this.label_FormulaMenu.TabIndex = 34;
            this.label_FormulaMenu.Text = "Formula Menu";
            // 
            // button_Menu2
            // 
            this.button_Menu2.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Menu2.Location = new System.Drawing.Point(560, 308);
            this.button_Menu2.Name = "button_Menu2";
            this.button_Menu2.Size = new System.Drawing.Size(35, 25);
            this.button_Menu2.TabIndex = 35;
            this.button_Menu2.Text = "2";
            this.button_Menu2.UseVisualStyleBackColor = true;
            this.button_Menu2.Click += new System.EventHandler(this.button_Menu2_Click);
            // 
            // label_Bailout
            // 
            this.label_Bailout.AutoSize = true;
            this.label_Bailout.Location = new System.Drawing.Point(3, 51);
            this.label_Bailout.Name = "label_Bailout";
            this.label_Bailout.Size = new System.Drawing.Size(100, 15);
            this.label_Bailout.TabIndex = 35;
            this.label_Bailout.Text = "Bailout (general): ";
            // 
            // button_Menu3
            // 
            this.button_Menu3.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Menu3.Location = new System.Drawing.Point(599, 308);
            this.button_Menu3.Name = "button_Menu3";
            this.button_Menu3.Size = new System.Drawing.Size(35, 25);
            this.button_Menu3.TabIndex = 36;
            this.button_Menu3.Text = "3";
            this.button_Menu3.UseVisualStyleBackColor = true;
            this.button_Menu3.Click += new System.EventHandler(this.button_Menu3_Click);
            // 
            // input_Bailout
            // 
            this.input_Bailout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Bailout.Location = new System.Drawing.Point(116, 48);
            this.input_Bailout.Name = "input_Bailout";
            this.input_Bailout.Size = new System.Drawing.Size(40, 23);
            this.input_Bailout.TabIndex = 36;
            this.input_Bailout.Text = "0";
            this.input_Bailout.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_Bailout_KeyDown);
            this.input_Bailout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_Bailout_KeyPress);
            this.input_Bailout.Validating += new System.ComponentModel.CancelEventHandler(this.input_Bailout_Validating);
            this.input_Bailout.Validated += new System.EventHandler(this.input_Bailout_Validated);
            // 
            // button_Menu4
            // 
            this.button_Menu4.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Menu4.Location = new System.Drawing.Point(639, 308);
            this.button_Menu4.Name = "button_Menu4";
            this.button_Menu4.Size = new System.Drawing.Size(35, 25);
            this.button_Menu4.TabIndex = 37;
            this.button_Menu4.Text = "4";
            this.button_Menu4.UseVisualStyleBackColor = true;
            this.button_Menu4.Click += new System.EventHandler(this.button_Menu4_Click);
            // 
            // panel_FormulaMenu
            // 
            this.panel_FormulaMenu.AutoScroll = true;
            this.panel_FormulaMenu.CausesValidation = false;
            this.panel_FormulaMenu.Controls.Add(this.label_FormulaMenu);
            this.panel_FormulaMenu.Controls.Add(this.label_Formula);
            this.panel_FormulaMenu.Controls.Add(this.input_FractalFormula);
            this.panel_FormulaMenu.Controls.Add(this.input_FractalType);
            this.panel_FormulaMenu.Controls.Add(this.input_Power);
            this.panel_FormulaMenu.Controls.Add(this.input_MaxIterations);
            this.panel_FormulaMenu.Controls.Add(this.label_FractalType);
            this.panel_FormulaMenu.Controls.Add(label_MaxIterations);
            this.panel_FormulaMenu.Controls.Add(this.input_CPower);
            this.panel_FormulaMenu.Controls.Add(this.label_Power);
            this.panel_FormulaMenu.Controls.Add(this.label_CPower);
            this.panel_FormulaMenu.Location = new System.Drawing.Point(518, 24);
            this.panel_FormulaMenu.Name = "panel_FormulaMenu";
            this.panel_FormulaMenu.Size = new System.Drawing.Size(159, 276);
            this.panel_FormulaMenu.TabIndex = 32;
            // 
            // label_BailoutTrap
            // 
            this.label_BailoutTrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_BailoutTrap.AutoSize = true;
            this.label_BailoutTrap.Location = new System.Drawing.Point(3, 129);
            this.label_BailoutTrap.Name = "label_BailoutTrap";
            this.label_BailoutTrap.Size = new System.Drawing.Size(50, 15);
            this.label_BailoutTrap.TabIndex = 39;
            this.label_BailoutTrap.Text = "Bailout: ";
            this.label_BailoutTrap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_BailoutX
            // 
            this.input_BailoutX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_BailoutX.Location = new System.Drawing.Point(72, 126);
            this.input_BailoutX.Name = "input_BailoutX";
            this.input_BailoutX.Size = new System.Drawing.Size(40, 23);
            this.input_BailoutX.TabIndex = 38;
            this.input_BailoutX.Text = "0";
            this.input_BailoutX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_BailoutX_KeyDown);
            this.input_BailoutX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_BailoutX_KeyPress);
            this.input_BailoutX.Validating += new System.ComponentModel.CancelEventHandler(this.input_BailoutX_Validating);
            this.input_BailoutX.Validated += new System.EventHandler(this.input_BailoutX_Validated);
            // 
            // panel_OrbitTrapMenu
            // 
            this.panel_OrbitTrapMenu.AutoScroll = true;
            this.panel_OrbitTrapMenu.Controls.Add(this.label_OrbitTrapFactors);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_EditingOrbitBailout);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_StartOrbit);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_OrbitTrapFactor1);
            this.panel_OrbitTrapMenu.Controls.Add(label_StartOrbit);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_EditingBailoutTrap);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_OrbitTrapFactor2);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_OrbitRange);
            this.panel_OrbitTrapMenu.Controls.Add(label_OrbitRange);
            this.panel_OrbitTrapMenu.Controls.Add(this.button_RemoveBailoutTrap);
            this.panel_OrbitTrapMenu.Controls.Add(this.button_AddBailoutTrap);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_BailoutTrap);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_BailoutX);
            this.panel_OrbitTrapMenu.Controls.Add(this.label1);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_OrbitTrap);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_Bailout);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_BailoutY);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_Bailout);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_OrbitTrap);
            this.panel_OrbitTrapMenu.Location = new System.Drawing.Point(518, 24);
            this.panel_OrbitTrapMenu.Name = "panel_OrbitTrapMenu";
            this.panel_OrbitTrapMenu.Size = new System.Drawing.Size(159, 276);
            this.panel_OrbitTrapMenu.TabIndex = 33;
            // 
            // label_OrbitTrapFactors
            // 
            this.label_OrbitTrapFactors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_OrbitTrapFactors.AutoSize = true;
            this.label_OrbitTrapFactors.Location = new System.Drawing.Point(3, 206);
            this.label_OrbitTrapFactors.Name = "label_OrbitTrapFactors";
            this.label_OrbitTrapFactors.Size = new System.Drawing.Size(51, 15);
            this.label_OrbitTrapFactors.TabIndex = 54;
            this.label_OrbitTrapFactors.Text = "Factors: ";
            this.label_OrbitTrapFactors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_EditingOrbitBailout
            // 
            this.label_EditingOrbitBailout.AutoSize = true;
            this.label_EditingOrbitBailout.Location = new System.Drawing.Point(4, 104);
            this.label_EditingOrbitBailout.Name = "label_EditingOrbitBailout";
            this.label_EditingOrbitBailout.Size = new System.Drawing.Size(78, 15);
            this.label_EditingOrbitBailout.TabIndex = 51;
            this.label_EditingOrbitBailout.Text = "Editing Point:";
            // 
            // input_StartOrbit
            // 
            this.input_StartOrbit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_StartOrbit.CausesValidation = false;
            this.input_StartOrbit.Location = new System.Drawing.Point(90, 152);
            this.input_StartOrbit.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.input_StartOrbit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_StartOrbit.Name = "input_StartOrbit";
            this.input_StartOrbit.Size = new System.Drawing.Size(65, 23);
            this.input_StartOrbit.TabIndex = 48;
            this.input_StartOrbit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_StartOrbit.ValueChanged += new System.EventHandler(this.input_StartOrbit_ValueChanged);
            // 
            // input_OrbitTrapFactor1
            // 
            this.input_OrbitTrapFactor1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_OrbitTrapFactor1.Location = new System.Drawing.Point(72, 203);
            this.input_OrbitTrapFactor1.Name = "input_OrbitTrapFactor1";
            this.input_OrbitTrapFactor1.Size = new System.Drawing.Size(40, 23);
            this.input_OrbitTrapFactor1.TabIndex = 53;
            this.input_OrbitTrapFactor1.Text = "0.25";
            this.input_OrbitTrapFactor1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_OrbitTrapFactor1_KeyDown);
            this.input_OrbitTrapFactor1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_OrbitTrapFactor1_KeyPress);
            this.input_OrbitTrapFactor1.Validating += new System.ComponentModel.CancelEventHandler(this.input_OrbitTrapFactor1_Validating);
            this.input_OrbitTrapFactor1.Validated += new System.EventHandler(this.input_OrbitTrapFactor1_Validated);
            // 
            // input_EditingBailoutTrap
            // 
            this.input_EditingBailoutTrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_EditingBailoutTrap.CausesValidation = false;
            this.input_EditingBailoutTrap.Location = new System.Drawing.Point(91, 100);
            this.input_EditingBailoutTrap.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_EditingBailoutTrap.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_EditingBailoutTrap.Name = "input_EditingBailoutTrap";
            this.input_EditingBailoutTrap.Size = new System.Drawing.Size(65, 23);
            this.input_EditingBailoutTrap.TabIndex = 50;
            this.input_EditingBailoutTrap.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_EditingBailoutTrap.ValueChanged += new System.EventHandler(this.input_EditingBailoutTrap_ValueChanged);
            // 
            // input_OrbitTrapFactor2
            // 
            this.input_OrbitTrapFactor2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_OrbitTrapFactor2.Location = new System.Drawing.Point(116, 203);
            this.input_OrbitTrapFactor2.Name = "input_OrbitTrapFactor2";
            this.input_OrbitTrapFactor2.Size = new System.Drawing.Size(40, 23);
            this.input_OrbitTrapFactor2.TabIndex = 52;
            this.input_OrbitTrapFactor2.Text = "7";
            this.input_OrbitTrapFactor2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_OrbitTrapFactor2_KeyDown);
            this.input_OrbitTrapFactor2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_OrbitTrapFactor2_KeyPress);
            this.input_OrbitTrapFactor2.Validating += new System.ComponentModel.CancelEventHandler(this.input_OrbitTrapFactor2_Validating);
            this.input_OrbitTrapFactor2.Validated += new System.EventHandler(this.input_OrbitTrapFactor2_Validated);
            // 
            // input_OrbitRange
            // 
            this.input_OrbitRange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_OrbitRange.CausesValidation = false;
            this.input_OrbitRange.Location = new System.Drawing.Point(90, 178);
            this.input_OrbitRange.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.input_OrbitRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_OrbitRange.Name = "input_OrbitRange";
            this.input_OrbitRange.Size = new System.Drawing.Size(65, 23);
            this.input_OrbitRange.TabIndex = 50;
            this.input_OrbitRange.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_OrbitRange.ValueChanged += new System.EventHandler(this.input_OrbitRange_ValueChanged);
            // 
            // button_RemoveBailoutTrap
            // 
            this.button_RemoveBailoutTrap.Location = new System.Drawing.Point(81, 74);
            this.button_RemoveBailoutTrap.Name = "button_RemoveBailoutTrap";
            this.button_RemoveBailoutTrap.Size = new System.Drawing.Size(74, 23);
            this.button_RemoveBailoutTrap.TabIndex = 43;
            this.button_RemoveBailoutTrap.Text = "Remove";
            this.button_RemoveBailoutTrap.UseVisualStyleBackColor = true;
            this.button_RemoveBailoutTrap.Click += new System.EventHandler(this.button_RemoveBailoutTrap_Click);
            // 
            // button_AddBailoutTrap
            // 
            this.button_AddBailoutTrap.Location = new System.Drawing.Point(3, 74);
            this.button_AddBailoutTrap.Name = "button_AddBailoutTrap";
            this.button_AddBailoutTrap.Size = new System.Drawing.Size(74, 23);
            this.button_AddBailoutTrap.TabIndex = 42;
            this.button_AddBailoutTrap.Text = "Add";
            this.button_AddBailoutTrap.UseVisualStyleBackColor = true;
            this.button_AddBailoutTrap.Click += new System.EventHandler(this.button_AddBailoutTrap_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 19);
            this.label1.TabIndex = 35;
            this.label1.Text = "Orbit Trap Menu";
            // 
            // label_Texture
            // 
            this.label_Texture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Texture.AutoSize = true;
            this.label_Texture.Location = new System.Drawing.Point(878, 44);
            this.label_Texture.Name = "label_Texture";
            this.label_Texture.Size = new System.Drawing.Size(48, 15);
            this.label_Texture.TabIndex = 40;
            this.label_Texture.Text = "Texture:";
            this.label_Texture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_Texture
            // 
            this.input_Texture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Texture.Location = new System.Drawing.Point(932, 41);
            this.input_Texture.Name = "input_Texture";
            this.input_Texture.Size = new System.Drawing.Size(98, 23);
            this.input_Texture.TabIndex = 41;
            // 
            // checkBox_LockZoomFactor
            // 
            this.checkBox_LockZoomFactor.AutoSize = true;
            this.checkBox_LockZoomFactor.Location = new System.Drawing.Point(307, 344);
            this.checkBox_LockZoomFactor.Name = "checkBox_LockZoomFactor";
            this.checkBox_LockZoomFactor.Size = new System.Drawing.Size(122, 19);
            this.checkBox_LockZoomFactor.TabIndex = 38;
            this.checkBox_LockZoomFactor.Text = "Lock Zoom Factor";
            this.checkBox_LockZoomFactor.UseVisualStyleBackColor = true;
            this.checkBox_LockZoomFactor.CheckedChanged += new System.EventHandler(this.checkBox_LockZoomFactor_CheckedChanged);
            // 
            // input_ColorCycles
            // 
            this.input_ColorCycles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_ColorCycles.Location = new System.Drawing.Point(990, 128);
            this.input_ColorCycles.Name = "input_ColorCycles";
            this.input_ColorCycles.Size = new System.Drawing.Size(40, 23);
            this.input_ColorCycles.TabIndex = 43;
            this.input_ColorCycles.Text = "0";
            // 
            // label_ColorCycles
            // 
            this.label_ColorCycles.AutoSize = true;
            this.label_ColorCycles.Location = new System.Drawing.Point(877, 130);
            this.label_ColorCycles.Name = "label_ColorCycles";
            this.label_ColorCycles.Size = new System.Drawing.Size(76, 15);
            this.label_ColorCycles.TabIndex = 42;
            this.label_ColorCycles.Text = "Color Cycles:";
            // 
            // input_ColorFactor
            // 
            this.input_ColorFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_ColorFactor.Location = new System.Drawing.Point(990, 159);
            this.input_ColorFactor.Name = "input_ColorFactor";
            this.input_ColorFactor.Size = new System.Drawing.Size(40, 23);
            this.input_ColorFactor.TabIndex = 45;
            this.input_ColorFactor.Text = "0";
            // 
            // label_ColorFactor
            // 
            this.label_ColorFactor.AutoSize = true;
            this.label_ColorFactor.Location = new System.Drawing.Point(877, 162);
            this.label_ColorFactor.Name = "label_ColorFactor";
            this.label_ColorFactor.Size = new System.Drawing.Size(78, 15);
            this.label_ColorFactor.TabIndex = 44;
            this.label_ColorFactor.Text = "Color Factor: ";
            // 
            // input_Center
            // 
            this.input_Center.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Center.Location = new System.Drawing.Point(57, 342);
            this.input_Center.Name = "input_Center";
            this.input_Center.Size = new System.Drawing.Size(141, 23);
            this.input_Center.TabIndex = 55;
            this.input_Center.Text = "0, 0";
            this.input_Center.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_Center_KeyDown);
            this.input_Center.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_Center_KeyPress);
            this.input_Center.Validating += new System.ComponentModel.CancelEventHandler(this.input_Center_Validating);
            this.input_Center.Validated += new System.EventHandler(this.input_Center_Validated);
            // 
            // label_Center
            // 
            this.label_Center.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Center.AutoSize = true;
            this.label_Center.Location = new System.Drawing.Point(12, 346);
            this.label_Center.Name = "label_Center";
            this.label_Center.Size = new System.Drawing.Size(45, 15);
            this.label_Center.TabIndex = 56;
            this.label_Center.Text = "Center:";
            this.label_Center.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 58;
            this.label2.Text = "Zoom: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_Zoom
            // 
            this.input_Zoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Zoom.Location = new System.Drawing.Point(249, 342);
            this.input_Zoom.Name = "input_Zoom";
            this.input_Zoom.Size = new System.Drawing.Size(52, 23);
            this.input_Zoom.TabIndex = 57;
            this.input_Zoom.Text = "0";
            this.input_Zoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_Zoom_KeyDown);
            this.input_Zoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_Zoom_KeyPress);
            this.input_Zoom.Validating += new System.ComponentModel.CancelEventHandler(this.input_Zoom_Validating);
            this.input_Zoom.Validated += new System.EventHandler(this.input_Zoom_Validated);
            // 
            // MainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 374);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.input_Zoom);
            this.Controls.Add(this.label_Center);
            this.Controls.Add(this.input_Center);
            this.Controls.Add(this.label_Texture);
            this.Controls.Add(this.input_ColorFactor);
            this.Controls.Add(this.label_ColorFactor);
            this.Controls.Add(this.input_ColorCycles);
            this.Controls.Add(this.checkBox_LockZoomFactor);
            this.Controls.Add(this.input_Texture);
            this.Controls.Add(this.label_ColorCycles);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.button_Menu1);
            this.Controls.Add(this.button_Menu2);
            this.Controls.Add(this.button_Menu3);
            this.Controls.Add(this.button_Menu4);
            this.Controls.Add(this.button_Left);
            this.Controls.Add(this.button_Right);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel_FormulaMenu);
            this.Controls.Add(this.panel_OrbitTrapMenu);
            this.MinimumSize = new System.Drawing.Size(705, 413);
            this.Name = "MainDlg";
            this.Text = "GLControl Input Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDlg_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_MaxIterations)).EndInit();
            this.panel_FormulaMenu.ResumeLayout(false);
            this.panel_FormulaMenu.PerformLayout();
            this.panel_OrbitTrapMenu.ResumeLayout(false);
            this.panel_OrbitTrapMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_StartOrbit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_EditingBailoutTrap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_OrbitRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label_Bailout1X;
        private System.Windows.Forms.TextBox LogTextBox;
        private OpenTK.WinForms.GLControl glControl;
        private System.Windows.Forms.Button button_Left;
        private System.Windows.Forms.Button button_Right;
        private System.Windows.Forms.Label label_OrbitTrap;
        private System.Windows.Forms.Label label_Formula;
        private System.Windows.Forms.TextBox input_BailoutY;
        private System.Windows.Forms.ComboBox input_OrbitTrap;
        private System.Windows.Forms.ComboBox input_FractalFormula;
        private System.Windows.Forms.ComboBox input_FractalType;
        private System.Windows.Forms.TextBox input_Power;
        private System.Windows.Forms.Label label_FractalType;
        private System.Windows.Forms.Label label_Power;
        private System.Windows.Forms.TextBox input_CPower;
        private System.Windows.Forms.Label label_CPower;
        private System.Windows.Forms.NumericUpDown input_MaxIterations;
        private System.Windows.Forms.Button button_Menu1;
        private System.Windows.Forms.Label label_FormulaMenu;
        private System.Windows.Forms.Button button_Menu2;
        private System.Windows.Forms.Label label_Bailout;
        private System.Windows.Forms.Button button_Menu3;
        private System.Windows.Forms.TextBox input_Bailout;
        private System.Windows.Forms.Button button_Menu4;
        private System.Windows.Forms.Panel panel_FormulaMenu;
        private System.Windows.Forms.TextBox input_BailoutX;
        private System.Windows.Forms.Label label_BailoutTrap;
        private System.Windows.Forms.Panel panel_OrbitTrapMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Texture;
        private System.Windows.Forms.TextBox input_Texture;
        private System.Windows.Forms.CheckBox checkBox_LockZoomFactor;
        private System.Windows.Forms.Button button_RemoveBailoutTrap;
        private System.Windows.Forms.Button button_AddBailoutTrap;
        private System.Windows.Forms.TextBox input_ColorCycles;
        private System.Windows.Forms.Label label_ColorCycles;
        private System.Windows.Forms.TextBox input_ColorFactor;
        private System.Windows.Forms.Label label_ColorFactor;
        private System.Windows.Forms.NumericUpDown input_StartOrbit;
        private System.Windows.Forms.NumericUpDown input_EditingBailoutTrap;
        private System.Windows.Forms.NumericUpDown input_OrbitRange;
        private System.Windows.Forms.Label label_EditingOrbitBailout;
        private System.Windows.Forms.Label label_OrbitTrapFactors;
        private System.Windows.Forms.TextBox input_OrbitTrapFactor1;
        private System.Windows.Forms.TextBox input_OrbitTrapFactor2;
        private System.Windows.Forms.TextBox input_Center;
        private System.Windows.Forms.Label label_Center;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox input_Zoom;
    }
}

