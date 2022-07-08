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
            this.label_Bailout1X = new System.Windows.Forms.Label();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.NativeInputRadioButton = new System.Windows.Forms.RadioButton();
            this.WinFormsInputRadioButton = new System.Windows.Forms.RadioButton();
            this.glControl = new OpenTK.WinForms.GLControl();
            this.button_Left = new System.Windows.Forms.Button();
            this.button_Right = new System.Windows.Forms.Button();
            this.label_OrbitTrap = new System.Windows.Forms.Label();
            this.label_Bailout2 = new System.Windows.Forms.Label();
            this.label_Formula = new System.Windows.Forms.Label();
            this.input_Bailout1Y = new System.Windows.Forms.TextBox();
            this.input_OrbitTrap = new System.Windows.Forms.ComboBox();
            this.input_Bailout2X = new System.Windows.Forms.TextBox();
            this.input_FractalFormula = new System.Windows.Forms.ComboBox();
            this.input_Bailout2Y = new System.Windows.Forms.TextBox();
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
            this.button5 = new System.Windows.Forms.Button();
            this.panel_FormulaMenu = new System.Windows.Forms.Panel();
            this.label_Bailout1 = new System.Windows.Forms.Label();
            this.input_Bailout1X = new System.Windows.Forms.TextBox();
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
            // button_Left
            // 
            this.button_Left.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Left.Location = new System.Drawing.Point(3, 313);
            this.button_Left.Name = "button_Left";
            this.button_Left.Size = new System.Drawing.Size(50, 25);
            this.button_Left.TabIndex = 33;
            this.button_Left.Text = "<<<";
            this.button_Left.UseVisualStyleBackColor = true;
            // 
            // button_Right
            // 
            this.button_Right.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Right.Location = new System.Drawing.Point(105, 313);
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
            this.label_OrbitTrap.Location = new System.Drawing.Point(3, 112);
            this.label_OrbitTrap.Name = "label_OrbitTrap";
            this.label_OrbitTrap.Size = new System.Drawing.Size(62, 15);
            this.label_OrbitTrap.TabIndex = 9;
            this.label_OrbitTrap.Text = "Orbit Trap:";
            this.label_OrbitTrap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Bailout2
            // 
            this.label_Bailout2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Bailout2.AutoSize = true;
            this.label_Bailout2.Location = new System.Drawing.Point(3, 199);
            this.label_Bailout2.Name = "label_Bailout2";
            this.label_Bailout2.Size = new System.Drawing.Size(59, 15);
            this.label_Bailout2.TabIndex = 14;
            this.label_Bailout2.Text = "Bailout 2: ";
            this.label_Bailout2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Formula
            // 
            this.label_Formula.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Formula.AutoSize = true;
            this.label_Formula.Location = new System.Drawing.Point(3, 51);
            this.label_Formula.Name = "label_Formula";
            this.label_Formula.Size = new System.Drawing.Size(54, 15);
            this.label_Formula.TabIndex = 20;
            this.label_Formula.Text = "Formula:";
            this.label_Formula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.input_OrbitTrap.Location = new System.Drawing.Point(68, 109);
            this.input_OrbitTrap.Name = "input_OrbitTrap";
            this.input_OrbitTrap.Size = new System.Drawing.Size(87, 23);
            this.input_OrbitTrap.TabIndex = 10;
            this.input_OrbitTrap.SelectionChangeCommitted += new System.EventHandler(this.input_OrbitTrap_SelectionChangeCommitted);
            // 
            // input_Bailout2X
            // 
            this.input_Bailout2X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Bailout2X.Location = new System.Drawing.Point(72, 196);
            this.input_Bailout2X.Name = "input_Bailout2X";
            this.input_Bailout2X.Size = new System.Drawing.Size(40, 23);
            this.input_Bailout2X.TabIndex = 22;
            this.input_Bailout2X.Text = "0";
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
            this.input_FractalFormula.Location = new System.Drawing.Point(68, 51);
            this.input_FractalFormula.Name = "input_FractalFormula";
            this.input_FractalFormula.Size = new System.Drawing.Size(87, 23);
            this.input_FractalFormula.TabIndex = 21;
            // 
            // input_Bailout2Y
            // 
            this.input_Bailout2Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Bailout2Y.Location = new System.Drawing.Point(115, 196);
            this.input_Bailout2Y.Name = "input_Bailout2Y";
            this.input_Bailout2Y.Size = new System.Drawing.Size(40, 23);
            this.input_Bailout2Y.TabIndex = 23;
            this.input_Bailout2Y.Text = "0";
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
            this.input_FractalType.Location = new System.Drawing.Point(68, 22);
            this.input_FractalType.Name = "input_FractalType";
            this.input_FractalType.Size = new System.Drawing.Size(87, 23);
            this.input_FractalType.TabIndex = 19;
            // 
            // input_Power
            // 
            this.input_Power.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Power.Location = new System.Drawing.Point(72, 225);
            this.input_Power.Name = "input_Power";
            this.input_Power.Size = new System.Drawing.Size(84, 23);
            this.input_Power.TabIndex = 28;
            this.input_Power.Text = "2";
            // 
            // label_FractalType
            // 
            this.label_FractalType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_FractalType.AutoSize = true;
            this.label_FractalType.Location = new System.Drawing.Point(3, 25);
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
            this.label_Power.Location = new System.Drawing.Point(3, 228);
            this.label_Power.Name = "label_Power";
            this.label_Power.Size = new System.Drawing.Size(46, 15);
            this.label_Power.TabIndex = 29;
            this.label_Power.Text = "Power: ";
            this.label_Power.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_CPower
            // 
            this.input_CPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_CPower.Location = new System.Drawing.Point(72, 254);
            this.input_CPower.Name = "input_CPower";
            this.input_CPower.Size = new System.Drawing.Size(84, 23);
            this.input_CPower.TabIndex = 30;
            this.input_CPower.Text = "1";
            // 
            // label_CPower
            // 
            this.label_CPower.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_CPower.AutoSize = true;
            this.label_CPower.Location = new System.Drawing.Point(3, 257);
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
            // button_Menu1
            // 
            this.button_Menu1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Menu1.Location = new System.Drawing.Point(3, 281);
            this.button_Menu1.Name = "button_Menu1";
            this.button_Menu1.Size = new System.Drawing.Size(35, 25);
            this.button_Menu1.TabIndex = 34;
            this.button_Menu1.Text = "1";
            this.button_Menu1.UseVisualStyleBackColor = true;
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
            this.button_Menu2.Location = new System.Drawing.Point(42, 281);
            this.button_Menu2.Name = "button_Menu2";
            this.button_Menu2.Size = new System.Drawing.Size(35, 25);
            this.button_Menu2.TabIndex = 35;
            this.button_Menu2.Text = "2";
            this.button_Menu2.UseVisualStyleBackColor = true;
            // 
            // label_Bailout
            // 
            this.label_Bailout.AutoSize = true;
            this.label_Bailout.Location = new System.Drawing.Point(3, 141);
            this.label_Bailout.Name = "label_Bailout";
            this.label_Bailout.Size = new System.Drawing.Size(100, 15);
            this.label_Bailout.TabIndex = 35;
            this.label_Bailout.Text = "Bailout (general): ";
            // 
            // button_Menu3
            // 
            this.button_Menu3.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Menu3.Location = new System.Drawing.Point(81, 281);
            this.button_Menu3.Name = "button_Menu3";
            this.button_Menu3.Size = new System.Drawing.Size(35, 25);
            this.button_Menu3.TabIndex = 36;
            this.button_Menu3.Text = "3";
            this.button_Menu3.UseVisualStyleBackColor = true;
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
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(121, 281);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 25);
            this.button5.TabIndex = 37;
            this.button5.Text = "4";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // panel_FormulaMenu
            // 
            this.panel_FormulaMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_FormulaMenu.CausesValidation = false;
            this.panel_FormulaMenu.Controls.Add(this.label_Bailout1);
            this.panel_FormulaMenu.Controls.Add(this.input_Bailout1X);
            this.panel_FormulaMenu.Controls.Add(this.button5);
            this.panel_FormulaMenu.Controls.Add(this.input_Bailout);
            this.panel_FormulaMenu.Controls.Add(this.button_Menu3);
            this.panel_FormulaMenu.Controls.Add(this.label_Bailout);
            this.panel_FormulaMenu.Controls.Add(this.button_Menu2);
            this.panel_FormulaMenu.Controls.Add(this.label_FormulaMenu);
            this.panel_FormulaMenu.Controls.Add(this.button_Menu1);
            this.panel_FormulaMenu.Controls.Add(this.input_MaxIterations);
            this.panel_FormulaMenu.Controls.Add(label_MaxIterations);
            this.panel_FormulaMenu.Controls.Add(this.label_CPower);
            this.panel_FormulaMenu.Controls.Add(this.input_CPower);
            this.panel_FormulaMenu.Controls.Add(this.label_Power);
            this.panel_FormulaMenu.Controls.Add(this.label_FractalType);
            this.panel_FormulaMenu.Controls.Add(this.input_Power);
            this.panel_FormulaMenu.Controls.Add(this.input_FractalType);
            this.panel_FormulaMenu.Controls.Add(this.input_Bailout2Y);
            this.panel_FormulaMenu.Controls.Add(this.input_FractalFormula);
            this.panel_FormulaMenu.Controls.Add(this.input_Bailout2X);
            this.panel_FormulaMenu.Controls.Add(this.input_OrbitTrap);
            this.panel_FormulaMenu.Controls.Add(this.input_Bailout1Y);
            this.panel_FormulaMenu.Controls.Add(this.label_Formula);
            this.panel_FormulaMenu.Controls.Add(this.label_Bailout2);
            this.panel_FormulaMenu.Controls.Add(this.label_OrbitTrap);
            this.panel_FormulaMenu.Controls.Add(this.button_Right);
            this.panel_FormulaMenu.Controls.Add(this.button_Left);
            this.panel_FormulaMenu.Location = new System.Drawing.Point(518, 24);
            this.panel_FormulaMenu.Name = "panel_FormulaMenu";
            this.panel_FormulaMenu.Size = new System.Drawing.Size(159, 345);
            this.panel_FormulaMenu.TabIndex = 32;
            // 
            // label_Bailout1
            // 
            this.label_Bailout1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Bailout1.AutoSize = true;
            this.label_Bailout1.Location = new System.Drawing.Point(3, 170);
            this.label_Bailout1.Name = "label_Bailout1";
            this.label_Bailout1.Size = new System.Drawing.Size(59, 15);
            this.label_Bailout1.TabIndex = 39;
            this.label_Bailout1.Text = "Bailout 1: ";
            this.label_Bailout1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_Bailout1X
            // 
            this.input_Bailout1X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.input_Bailout1X.Location = new System.Drawing.Point(72, 167);
            this.input_Bailout1X.Name = "input_Bailout1X";
            this.input_Bailout1X.Size = new System.Drawing.Size(40, 23);
            this.input_Bailout1X.TabIndex = 38;
            this.input_Bailout1X.Text = "0";
            this.input_Bailout1X.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_Bailout1X_KeyDown);
            this.input_Bailout1X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_Bailout1X_KeyPress);
            this.input_Bailout1X.Validating += new System.ComponentModel.CancelEventHandler(this.input_Bailout1X_Validating);
            this.input_Bailout1X.Validated += new System.EventHandler(this.input_Bailout1X_Validated);
            // 
            // MainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 374);
            this.Controls.Add(this.NativeInputRadioButton);
            this.Controls.Add(this.WinFormsInputRadioButton);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel_FormulaMenu);
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
        private System.Windows.Forms.Label label_Bailout1X;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.RadioButton NativeInputRadioButton;
        private System.Windows.Forms.RadioButton WinFormsInputRadioButton;
        private OpenTK.WinForms.GLControl glControl;
        private System.Windows.Forms.Button button_Left;
        private System.Windows.Forms.Button button_Right;
        private System.Windows.Forms.Label label_OrbitTrap;
        private System.Windows.Forms.Label label_Bailout2;
        private System.Windows.Forms.Label label_Formula;
        private System.Windows.Forms.TextBox input_Bailout1Y;
        private System.Windows.Forms.ComboBox input_OrbitTrap;
        private System.Windows.Forms.TextBox input_Bailout2X;
        private System.Windows.Forms.ComboBox input_FractalFormula;
        private System.Windows.Forms.TextBox input_Bailout2Y;
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
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel_FormulaMenu;
        private System.Windows.Forms.TextBox input_Bailout1X;
        private System.Windows.Forms.Label label_Bailout1;
    }
}

