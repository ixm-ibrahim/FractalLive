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
            this.glControl = new OpenTK.WinForms.GLControl();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.WinFormsInputRadioButton = new System.Windows.Forms.RadioButton();
            this.NativeInputRadioButton = new System.Windows.Forms.RadioButton();
            this.input_MaxIterations = new System.Windows.Forms.NumericUpDown();
            this.label_OrbitTrap = new System.Windows.Forms.Label();
            this.input_OrbitTrap = new System.Windows.Forms.ComboBox();
            this.input_Bailout1X = new System.Windows.Forms.TextBox();
            this.label_Bailout1X = new System.Windows.Forms.Label();
            this.label_BailoutY = new System.Windows.Forms.Label();
            this.input_Bailout1Y = new System.Windows.Forms.TextBox();
            this.input_FractalType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.input_FractalFormula = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.panel_FormulaMenu = new System.Windows.Forms.Panel();
            this.input_Bailout = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Right = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            label_MaxIterations = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_MaxIterations)).BeginInit();
            this.panel_FormulaMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_MaxIterations
            // 
            label_MaxIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label_MaxIterations.AutoSize = true;
            label_MaxIterations.Location = new System.Drawing.Point(3, 82);
            label_MaxIterations.Name = "label_MaxIterations";
            label_MaxIterations.Size = new System.Drawing.Size(88, 15);
            label_MaxIterations.TabIndex = 6;
            label_MaxIterations.Text = "Max Iterations: ";
            label_MaxIterations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.menuStrip1.Size = new System.Drawing.Size(689, 24);
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
            // glControl
            // 
            this.glControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.LogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogTextBox.Location = new System.Drawing.Point(353, 339);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.Size = new System.Drawing.Size(159, 39);
            this.LogTextBox.TabIndex = 3;
            // 
            // WinFormsInputRadioButton
            // 
            this.WinFormsInputRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WinFormsInputRadioButton.AutoSize = true;
            this.WinFormsInputRadioButton.Location = new System.Drawing.Point(12, 343);
            this.WinFormsInputRadioButton.Name = "WinFormsInputRadioButton";
            this.WinFormsInputRadioButton.Size = new System.Drawing.Size(110, 19);
            this.WinFormsInputRadioButton.TabIndex = 4;
            this.WinFormsInputRadioButton.TabStop = true;
            this.WinFormsInputRadioButton.Text = "WinForms Input";
            this.WinFormsInputRadioButton.UseVisualStyleBackColor = true;
            this.WinFormsInputRadioButton.CheckedChanged += new System.EventHandler(this.WinFormsInputRadioButton_CheckedChanged);
            // 
            // NativeInputRadioButton
            // 
            this.NativeInputRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NativeInputRadioButton.AutoSize = true;
            this.NativeInputRadioButton.Location = new System.Drawing.Point(128, 343);
            this.NativeInputRadioButton.Name = "NativeInputRadioButton";
            this.NativeInputRadioButton.Size = new System.Drawing.Size(90, 19);
            this.NativeInputRadioButton.TabIndex = 5;
            this.NativeInputRadioButton.TabStop = true;
            this.NativeInputRadioButton.Text = "Native Input";
            this.NativeInputRadioButton.UseVisualStyleBackColor = true;
            this.NativeInputRadioButton.CheckedChanged += new System.EventHandler(this.NativeInputRadioButton_CheckedChanged);
            // 
            // input_MaxIterations
            // 
            this.input_MaxIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_MaxIterations.CausesValidation = false;
            this.input_MaxIterations.Location = new System.Drawing.Point(90, 80);
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
            // label_OrbitTrap
            // 
            this.label_OrbitTrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_OrbitTrap.AutoSize = true;
            this.label_OrbitTrap.Location = new System.Drawing.Point(3, 112);
            this.label_OrbitTrap.Name = "label_OrbitTrap";
            this.label_OrbitTrap.Size = new System.Drawing.Size(62, 15);
            this.label_OrbitTrap.TabIndex = 9;
            this.label_OrbitTrap.Text = "Orbit Trap:";
            this.label_OrbitTrap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            "Point",
            "Line",
            "Cross/2 Lines"});
            this.input_OrbitTrap.Location = new System.Drawing.Point(71, 109);
            this.input_OrbitTrap.Name = "input_OrbitTrap";
            this.input_OrbitTrap.Size = new System.Drawing.Size(84, 23);
            this.input_OrbitTrap.TabIndex = 10;
            this.input_OrbitTrap.SelectionChangeCommitted += new System.EventHandler(this.input_OrbitTrap_SelectionChangeCommitted);
            // 
            // input_Bailout1X
            // 
            this.input_Bailout1X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Bailout1X.Location = new System.Drawing.Point(72, 167);
            this.input_Bailout1X.Name = "input_Bailout1X";
            this.input_Bailout1X.Size = new System.Drawing.Size(40, 23);
            this.input_Bailout1X.TabIndex = 12;
            this.input_Bailout1X.Text = "2";
            this.input_Bailout1X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_Bailout1X_KeyDown);
            this.input_Bailout1X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_Bailout1X_KeyPress);
            this.input_Bailout1X.Validating += new System.ComponentModel.CancelEventHandler(this.input_Bailout1X_Validating);
            this.input_Bailout1X.Validated += new System.EventHandler(this.input_Bailout1X_Validated);
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
            // label_BailoutY
            // 
            this.label_BailoutY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_BailoutY.AutoSize = true;
            this.label_BailoutY.Location = new System.Drawing.Point(3, 199);
            this.label_BailoutY.Name = "label_BailoutY";
            this.label_BailoutY.Size = new System.Drawing.Size(59, 15);
            this.label_BailoutY.TabIndex = 14;
            this.label_BailoutY.Text = "Bailout 2: ";
            this.label_BailoutY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_Bailout1Y
            // 
            this.input_Bailout1Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Bailout1Y.Location = new System.Drawing.Point(116, 167);
            this.input_Bailout1Y.Name = "input_Bailout1Y";
            this.input_Bailout1Y.Size = new System.Drawing.Size(40, 23);
            this.input_Bailout1Y.TabIndex = 17;
            this.input_Bailout1Y.Text = "0";
            this.input_Bailout1Y.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_Bailout1Y_KeyDown);
            this.input_Bailout1Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_Bailout1Y_KeyPress);
            this.input_Bailout1Y.Validating += new System.ComponentModel.CancelEventHandler(this.input_Bailout1Y_Validating);
            this.input_Bailout1Y.Validated += new System.EventHandler(this.input_Bailout1Y_Validated);
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
            this.input_FractalType.Location = new System.Drawing.Point(72, 22);
            this.input_FractalType.Name = "input_FractalType";
            this.input_FractalType.Size = new System.Drawing.Size(84, 23);
            this.input_FractalType.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Fractal:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.input_FractalFormula.Location = new System.Drawing.Point(72, 51);
            this.input_FractalFormula.Name = "input_FractalFormula";
            this.input_FractalFormula.Size = new System.Drawing.Size(84, 23);
            this.input_FractalFormula.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Formula:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(115, 196);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 23);
            this.textBox1.TabIndex = 23;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(72, 196);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 23);
            this.textBox2.TabIndex = 22;
            this.textBox2.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "Power: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(72, 225);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(84, 23);
            this.textBox7.TabIndex = 28;
            this.textBox7.Text = "2";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 31;
            this.label4.Text = "C Power: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Location = new System.Drawing.Point(72, 254);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(84, 23);
            this.textBox8.TabIndex = 30;
            this.textBox8.Text = "1";
            // 
            // panel_FormulaMenu
            // 
            this.panel_FormulaMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_FormulaMenu.CausesValidation = false;
            this.panel_FormulaMenu.Controls.Add(this.input_Bailout);
            this.panel_FormulaMenu.Controls.Add(this.label6);
            this.panel_FormulaMenu.Controls.Add(this.label5);
            this.panel_FormulaMenu.Controls.Add(this.input_MaxIterations);
            this.panel_FormulaMenu.Controls.Add(label_MaxIterations);
            this.panel_FormulaMenu.Controls.Add(this.label4);
            this.panel_FormulaMenu.Controls.Add(this.button_Right);
            this.panel_FormulaMenu.Controls.Add(this.textBox8);
            this.panel_FormulaMenu.Controls.Add(this.button1);
            this.panel_FormulaMenu.Controls.Add(this.label3);
            this.panel_FormulaMenu.Controls.Add(this.label1);
            this.panel_FormulaMenu.Controls.Add(this.textBox7);
            this.panel_FormulaMenu.Controls.Add(this.input_FractalType);
            this.panel_FormulaMenu.Controls.Add(this.textBox1);
            this.panel_FormulaMenu.Controls.Add(this.input_FractalFormula);
            this.panel_FormulaMenu.Controls.Add(this.textBox2);
            this.panel_FormulaMenu.Controls.Add(this.input_OrbitTrap);
            this.panel_FormulaMenu.Controls.Add(this.input_Bailout1Y);
            this.panel_FormulaMenu.Controls.Add(this.label2);
            this.panel_FormulaMenu.Controls.Add(this.label_BailoutY);
            this.panel_FormulaMenu.Controls.Add(this.label_OrbitTrap);
            this.panel_FormulaMenu.Controls.Add(this.label_Bailout1X);
            this.panel_FormulaMenu.Controls.Add(this.input_Bailout1X);
            this.panel_FormulaMenu.Location = new System.Drawing.Point(518, 24);
            this.panel_FormulaMenu.Name = "panel_FormulaMenu";
            this.panel_FormulaMenu.Size = new System.Drawing.Size(159, 309);
            this.panel_FormulaMenu.TabIndex = 32;
            // 
            // input_Bailout
            // 
            this.input_Bailout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Bailout.Location = new System.Drawing.Point(116, 138);
            this.input_Bailout.Name = "input_Bailout";
            this.input_Bailout.Size = new System.Drawing.Size(40, 23);
            this.input_Bailout.TabIndex = 36;
            this.input_Bailout.Text = "0";
            this.input_Bailout.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_Bailout_KeyDown);
            this.input_Bailout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_Bailout_KeyPress);
            this.input_Bailout.Validating += new System.ComponentModel.CancelEventHandler(this.input_Bailout_Validating);
            this.input_Bailout.Validated += new System.EventHandler(this.input_Bailout_Validated);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 15);
            this.label6.TabIndex = 35;
            this.label6.Text = "Bailout (general): ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(29, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 19);
            this.label5.TabIndex = 34;
            this.label5.Text = "Formula Menu";
            // 
            // button_Right
            // 
            this.button_Right.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Right.Location = new System.Drawing.Point(106, 281);
            this.button_Right.Name = "button_Right";
            this.button_Right.Size = new System.Drawing.Size(50, 25);
            this.button_Right.TabIndex = 22;
            this.button_Right.Text = ">>>";
            this.button_Right.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(3, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 25);
            this.button1.TabIndex = 33;
            this.button1.Text = "<<<";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 374);
            this.Controls.Add(this.panel_FormulaMenu);
            this.Controls.Add(this.NativeInputRadioButton);
            this.Controls.Add(this.WinFormsInputRadioButton);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.menuStrip1);
            this.MinimumSize = new System.Drawing.Size(705, 413);
            this.Name = "MainDlg";
            this.Text = "GLControl Input Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDlg_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_MaxIterations)).EndInit();
            this.panel_FormulaMenu.ResumeLayout(false);
            this.panel_FormulaMenu.PerformLayout();
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
		private OpenTK.WinForms.GLControl glControl;
		private System.Windows.Forms.TextBox LogTextBox;
		private System.Windows.Forms.RadioButton WinFormsInputRadioButton;
		private System.Windows.Forms.RadioButton NativeInputRadioButton;
        private System.Windows.Forms.NumericUpDown input_MaxIterations;
        private System.Windows.Forms.Label label_OrbitTrap;
        private System.Windows.Forms.ComboBox input_OrbitTrap;
        private System.Windows.Forms.TextBox input_Bailout1X;
        private System.Windows.Forms.Label label_Bailout1X;
        private System.Windows.Forms.Label label_BailoutY;
        private System.Windows.Forms.TextBox input_Bailout1Y;
        private System.Windows.Forms.ComboBox input_FractalType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox input_FractalFormula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Panel panel_FormulaMenu;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Right;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox input_Bailout;
        private System.Windows.Forms.Label label6;
    }
}

