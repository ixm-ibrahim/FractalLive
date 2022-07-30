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
            System.Windows.Forms.Label label_TextureBlend;
            System.Windows.Forms.Label label_StartDistance;
            System.Windows.Forms.Label label_MinIterations;
            System.Windows.Forms.Label label_FoldCount;
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
            this.label_CurrentMatingStep = new System.Windows.Forms.Label();
            this.label_MatingSteps = new System.Windows.Forms.Label();
            this.input_CurrentMatingStep = new System.Windows.Forms.NumericUpDown();
            this.input_MatingSteps = new System.Windows.Forms.TextBox();
            this.input_StartPositionY = new System.Windows.Forms.TextBox();
            this.input_StartPositionX = new System.Windows.Forms.TextBox();
            this.label_StartPosition = new System.Windows.Forms.Label();
            this.label_JuliaPosition = new System.Windows.Forms.Label();
            this.input_JuliaX = new System.Windows.Forms.TextBox();
            this.input_JuliaY = new System.Windows.Forms.TextBox();
            this.input_MinIterations = new System.Windows.Forms.NumericUpDown();
            this.checkBox_UseConjugate = new System.Windows.Forms.CheckBox();
            this.input_FoldCount = new System.Windows.Forms.TextBox();
            this.input_FoldOffsetY = new System.Windows.Forms.TextBox();
            this.label_FoldOffset = new System.Windows.Forms.Label();
            this.input_FoldOffsetX = new System.Windows.Forms.TextBox();
            this.input_FoldAngle = new System.Windows.Forms.TextBox();
            this.label_FoldAngle = new System.Windows.Forms.Label();
            this.checkBox_UseBuddhabrot = new System.Windows.Forms.CheckBox();
            this.label_BuddhabrotType = new System.Windows.Forms.Label();
            this.input_BuddhabrotType = new System.Windows.Forms.ComboBox();
            this.label_OrbitTrapPosition = new System.Windows.Forms.Label();
            this.input_BailoutX = new System.Windows.Forms.TextBox();
            this.panel_OrbitTrapMenu = new System.Windows.Forms.Panel();
            this.label_OrbitTrapMenu = new System.Windows.Forms.Label();
            this.label_EditingOrbitBailout = new System.Windows.Forms.Label();
            this.input_EditingBailoutTrap = new System.Windows.Forms.NumericUpDown();
            this.button_AddBailoutTrap = new System.Windows.Forms.Button();
            this.button_RemoveBailoutTrap = new System.Windows.Forms.Button();
            this.input_StartDistance = new System.Windows.Forms.TextBox();
            this.label_OrbitTrapCalculation = new System.Windows.Forms.Label();
            this.input_OrbitTrapCalculation = new System.Windows.Forms.ComboBox();
            this.input_StartOrbit = new System.Windows.Forms.NumericUpDown();
            this.input_OrbitRange = new System.Windows.Forms.NumericUpDown();
            this.label_OrbitTrapFactors = new System.Windows.Forms.Label();
            this.input_OrbitTrapBlendingFactor = new System.Windows.Forms.TextBox();
            this.input_OrbitTrapThicknessFactor = new System.Windows.Forms.TextBox();
            this.checkBox_UseSecondValue = new System.Windows.Forms.CheckBox();
            this.label_SecondValueFactors = new System.Windows.Forms.Label();
            this.input_SecondValueFactor1 = new System.Windows.Forms.TextBox();
            this.input_SecondValueFactor2 = new System.Windows.Forms.TextBox();
            this.label_Texture = new System.Windows.Forms.Label();
            this.input_Texture = new System.Windows.Forms.TextBox();
            this.checkBox_LockZoomFactor = new System.Windows.Forms.CheckBox();
            this.input_ColorCycles = new System.Windows.Forms.TextBox();
            this.label_ColorFactors = new System.Windows.Forms.Label();
            this.input_ColorFactor = new System.Windows.Forms.TextBox();
            this.input_Center = new System.Windows.Forms.TextBox();
            this.label_FractalCenter = new System.Windows.Forms.Label();
            this.label_FractalZoom = new System.Windows.Forms.Label();
            this.input_Zoom = new System.Windows.Forms.TextBox();
            this.panel_ColorMenu = new System.Windows.Forms.Panel();
            this.label_ColorMenu = new System.Windows.Forms.Label();
            this.label_EditingColor = new System.Windows.Forms.Label();
            this.input_EditingColor = new System.Windows.Forms.ComboBox();
            this.label_Coloring = new System.Windows.Forms.Label();
            this.input_Coloring = new System.Windows.Forms.ComboBox();
            this.checkBox_UseCustomPalette = new System.Windows.Forms.CheckBox();
            this.button_Color1 = new System.Windows.Forms.Button();
            this.button_Color2 = new System.Windows.Forms.Button();
            this.button_Color3 = new System.Windows.Forms.Button();
            this.button_Color4 = new System.Windows.Forms.Button();
            this.button_Color5 = new System.Windows.Forms.Button();
            this.button_Color6 = new System.Windows.Forms.Button();
            this.label_OrbitTrapFactor = new System.Windows.Forms.Label();
            this.input_OrbitTrapFactor = new System.Windows.Forms.TextBox();
            this.label_StripeDensity = new System.Windows.Forms.Label();
            this.input_StripeDensity = new System.Windows.Forms.TextBox();
            this.checkBox_MatchOrbitTrap = new System.Windows.Forms.CheckBox();
            this.label_DomainCalculation = new System.Windows.Forms.Label();
            this.input_DomainCalculation = new System.Windows.Forms.ComboBox();
            this.checkBox_UseDomainIteration = new System.Windows.Forms.CheckBox();
            this.checkBox_UseSecondDomainValue = new System.Windows.Forms.CheckBox();
            this.label_SecondDomainValueFactors = new System.Windows.Forms.Label();
            this.input_SecondDomainValueFactor1 = new System.Windows.Forms.TextBox();
            this.input_SecondDomainValueFactor2 = new System.Windows.Forms.TextBox();
            this.checkBox_UseDistanceEstimation = new System.Windows.Forms.CheckBox();
            this.label_DistanceEstimationMax = new System.Windows.Forms.Label();
            this.input_MaxDistanceEstimation = new System.Windows.Forms.TextBox();
            this.label_DistanceEstimationFactors = new System.Windows.Forms.Label();
            this.input_DistanceEstimationFactor1 = new System.Windows.Forms.TextBox();
            this.input_DistanceEstimationFactor2 = new System.Windows.Forms.TextBox();
            this.checkBox_UseNormals = new System.Windows.Forms.CheckBox();
            this.button_ClearTexture = new System.Windows.Forms.Button();
            this.input_TextureBlend = new System.Windows.Forms.NumericUpDown();
            this.input_TextureDistortionFactor = new System.Windows.Forms.TextBox();
            this.label_TextureScale = new System.Windows.Forms.Label();
            this.input_TextureScaleX = new System.Windows.Forms.TextBox();
            this.input_TextureScaleY = new System.Windows.Forms.TextBox();
            this.checkBox_UsePolarTextureCoordinates = new System.Windows.Forms.CheckBox();
            this.checkBox_UseDistortedTexture = new System.Windows.Forms.CheckBox();
            this.label_TextureDistortionFactor = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.input_LockedZoom = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label_CameraOrientation = new System.Windows.Forms.Label();
            this.input_RiemannAngles = new System.Windows.Forms.TextBox();
            this.label_RiemannAngles = new System.Windows.Forms.Label();
            this.input_CameraAngles = new System.Windows.Forms.TextBox();
            this.input_CameraPosition = new System.Windows.Forms.TextBox();
            this.input_CameraRoll = new System.Windows.Forms.TextBox();
            this.panel_GeneralMenu = new System.Windows.Forms.Panel();
            this.panel_MenuSelect = new System.Windows.Forms.Panel();
            label_MaxIterations = new System.Windows.Forms.Label();
            label_StartOrbit = new System.Windows.Forms.Label();
            label_OrbitRange = new System.Windows.Forms.Label();
            label_TextureBlend = new System.Windows.Forms.Label();
            label_StartDistance = new System.Windows.Forms.Label();
            label_MinIterations = new System.Windows.Forms.Label();
            label_FoldCount = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_MaxIterations)).BeginInit();
            this.panel_FormulaMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_CurrentMatingStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_MinIterations)).BeginInit();
            this.panel_OrbitTrapMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_EditingBailoutTrap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_StartOrbit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_OrbitRange)).BeginInit();
            this.panel_ColorMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_TextureBlend)).BeginInit();
            this.panel_GeneralMenu.SuspendLayout();
            this.panel_MenuSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_MaxIterations
            // 
            label_MaxIterations.AutoSize = true;
            label_MaxIterations.Location = new System.Drawing.Point(3, 165);
            label_MaxIterations.Name = "label_MaxIterations";
            label_MaxIterations.Size = new System.Drawing.Size(85, 15);
            label_MaxIterations.TabIndex = 6;
            label_MaxIterations.Text = "Max Iterations:";
            label_MaxIterations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_StartOrbit
            // 
            label_StartOrbit.AutoSize = true;
            label_StartOrbit.Location = new System.Drawing.Point(3, 221);
            label_StartOrbit.Name = "label_StartOrbit";
            label_StartOrbit.Size = new System.Drawing.Size(67, 15);
            label_StartOrbit.TabIndex = 47;
            label_StartOrbit.Text = "Start Orbit: ";
            label_StartOrbit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_OrbitRange
            // 
            label_OrbitRange.AutoSize = true;
            label_OrbitRange.Location = new System.Drawing.Point(3, 247);
            label_OrbitRange.Name = "label_OrbitRange";
            label_OrbitRange.Size = new System.Drawing.Size(76, 15);
            label_OrbitRange.TabIndex = 49;
            label_OrbitRange.Text = "Orbit Range: ";
            label_OrbitRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_TextureBlend
            // 
            label_TextureBlend.AutoSize = true;
            label_TextureBlend.Location = new System.Drawing.Point(3, 479);
            label_TextureBlend.Name = "label_TextureBlend";
            label_TextureBlend.Size = new System.Drawing.Size(86, 15);
            label_TextureBlend.TabIndex = 70;
            label_TextureBlend.Text = "Texture Blend:*";
            label_TextureBlend.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_StartDistance
            // 
            label_StartDistance.AutoSize = true;
            label_StartDistance.Location = new System.Drawing.Point(3, 169);
            label_StartDistance.Name = "label_StartDistance";
            label_StartDistance.Size = new System.Drawing.Size(87, 15);
            label_StartDistance.TabIndex = 57;
            label_StartDistance.Text = "Start Distance:*";
            label_StartDistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_MinIterations
            // 
            label_MinIterations.AutoSize = true;
            label_MinIterations.Location = new System.Drawing.Point(3, 191);
            label_MinIterations.Name = "label_MinIterations";
            label_MinIterations.Size = new System.Drawing.Size(83, 15);
            label_MinIterations.TabIndex = 85;
            label_MinIterations.Text = "Min Iterations:";
            label_MinIterations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_FoldCount
            // 
            label_FoldCount.AutoSize = true;
            label_FoldCount.Location = new System.Drawing.Point(3, 317);
            label_FoldCount.Name = "label_FoldCount";
            label_FoldCount.Size = new System.Drawing.Size(74, 15);
            label_FoldCount.TabIndex = 88;
            label_FoldCount.Text = "Fold Count:*";
            label_FoldCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
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
            this.LogTextBox.Location = new System.Drawing.Point(8, 308);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.Size = new System.Drawing.Size(156, 71);
            this.LogTextBox.TabIndex = 3;
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
            this.glControl.MinimumSize = new System.Drawing.Size(500, 309);
            this.glControl.Name = "glControl";
            this.glControl.Profile = OpenTK.Windowing.Common.ContextProfile.Compatability;
            this.glControl.Size = new System.Drawing.Size(500, 316);
            this.glControl.TabIndex = 2;
            this.glControl.Text = "glControl1";
            // 
            // button_Left
            // 
            this.button_Left.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Left.Location = new System.Drawing.Point(3, 36);
            this.button_Left.Name = "button_Left";
            this.button_Left.Size = new System.Drawing.Size(50, 25);
            this.button_Left.TabIndex = 33;
            this.button_Left.Text = "<<<";
            this.button_Left.UseVisualStyleBackColor = true;
            // 
            // button_Right
            // 
            this.button_Right.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Right.Location = new System.Drawing.Point(107, 36);
            this.button_Right.Name = "button_Right";
            this.button_Right.Size = new System.Drawing.Size(50, 25);
            this.button_Right.TabIndex = 22;
            this.button_Right.Text = ">>>";
            this.button_Right.UseVisualStyleBackColor = true;
            // 
            // label_OrbitTrap
            // 
            this.label_OrbitTrap.AutoSize = true;
            this.label_OrbitTrap.Location = new System.Drawing.Point(3, 30);
            this.label_OrbitTrap.Name = "label_OrbitTrap";
            this.label_OrbitTrap.Size = new System.Drawing.Size(62, 15);
            this.label_OrbitTrap.TabIndex = 9;
            this.label_OrbitTrap.Text = "Orbit Trap:";
            this.label_OrbitTrap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Formula
            // 
            this.label_Formula.AutoSize = true;
            this.label_Formula.Location = new System.Drawing.Point(3, 56);
            this.label_Formula.Name = "label_Formula";
            this.label_Formula.Size = new System.Drawing.Size(54, 15);
            this.label_Formula.TabIndex = 20;
            this.label_Formula.Text = "Formula:";
            this.label_Formula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_BailoutY
            // 
            this.input_BailoutY.Location = new System.Drawing.Point(116, 137);
            this.input_BailoutY.Name = "input_BailoutY";
            this.input_BailoutY.Size = new System.Drawing.Size(40, 23);
            this.input_BailoutY.TabIndex = 17;
            this.input_BailoutY.Text = "0";
            this.input_BailoutY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_BailoutY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_BailoutY_KeyPress);
            this.input_BailoutY.Validating += new System.ComponentModel.CancelEventHandler(this.input_BailoutY_Validating);
            this.input_BailoutY.Validated += new System.EventHandler(this.input_BailoutY_Validated);
            // 
            // input_OrbitTrap
            // 
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
            "Lines",
            "Custom"});
            this.input_OrbitTrap.Location = new System.Drawing.Point(69, 27);
            this.input_OrbitTrap.Name = "input_OrbitTrap";
            this.input_OrbitTrap.Size = new System.Drawing.Size(87, 23);
            this.input_OrbitTrap.TabIndex = 10;
            this.input_OrbitTrap.SelectionChangeCommitted += new System.EventHandler(this.input_OrbitTrap_SelectionChangeCommitted);
            // 
            // input_FractalFormula
            // 
            this.input_FractalFormula.CausesValidation = false;
            this.input_FractalFormula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_FractalFormula.FormattingEnabled = true;
            this.input_FractalFormula.Items.AddRange(new object[] {
            "Classic",
            "Lambda",
            "Custom"});
            this.input_FractalFormula.Location = new System.Drawing.Point(68, 53);
            this.input_FractalFormula.Name = "input_FractalFormula";
            this.input_FractalFormula.Size = new System.Drawing.Size(87, 23);
            this.input_FractalFormula.TabIndex = 21;
            this.input_FractalFormula.SelectionChangeCommitted += new System.EventHandler(this.input_FractalFormula_SelectionChangeCommitted);
            // 
            // input_FractalType
            // 
            this.input_FractalType.CausesValidation = false;
            this.input_FractalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_FractalType.FormattingEnabled = true;
            this.input_FractalType.Items.AddRange(new object[] {
            "Mandelbrot",
            "Julia",
            "Julia Mating"});
            this.input_FractalType.Location = new System.Drawing.Point(68, 27);
            this.input_FractalType.Name = "input_FractalType";
            this.input_FractalType.Size = new System.Drawing.Size(87, 23);
            this.input_FractalType.TabIndex = 19;
            this.input_FractalType.SelectionChangeCommitted += new System.EventHandler(this.input_FractalType_SelectionChangeCommitted);
            // 
            // input_Power
            // 
            this.input_Power.Location = new System.Drawing.Point(76, 261);
            this.input_Power.Name = "input_Power";
            this.input_Power.Size = new System.Drawing.Size(79, 23);
            this.input_Power.TabIndex = 28;
            this.input_Power.Text = "2,  0";
            this.input_Power.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_Power.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateMultipleDecimalChar);
            this.input_Power.Validating += new System.ComponentModel.CancelEventHandler(this.input_Power_Validating);
            this.input_Power.Validated += new System.EventHandler(this.input_Power_Validated);
            // 
            // label_FractalType
            // 
            this.label_FractalType.AutoSize = true;
            this.label_FractalType.Location = new System.Drawing.Point(3, 30);
            this.label_FractalType.Name = "label_FractalType";
            this.label_FractalType.Size = new System.Drawing.Size(45, 15);
            this.label_FractalType.TabIndex = 18;
            this.label_FractalType.Text = "Fractal:";
            this.label_FractalType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Power
            // 
            this.label_Power.AutoSize = true;
            this.label_Power.Location = new System.Drawing.Point(3, 264);
            this.label_Power.Name = "label_Power";
            this.label_Power.Size = new System.Drawing.Size(48, 15);
            this.label_Power.TabIndex = 29;
            this.label_Power.Text = "Power:*";
            this.label_Power.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_CPower
            // 
            this.input_CPower.Location = new System.Drawing.Point(76, 287);
            this.input_CPower.Name = "input_CPower";
            this.input_CPower.Size = new System.Drawing.Size(79, 23);
            this.input_CPower.TabIndex = 30;
            this.input_CPower.Text = "1, 0";
            this.input_CPower.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_CPower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateMultipleDecimalChar);
            this.input_CPower.Validating += new System.ComponentModel.CancelEventHandler(this.input_CPower_Validating);
            this.input_CPower.Validated += new System.EventHandler(this.input_CPower_Validated);
            // 
            // label_CPower
            // 
            this.label_CPower.AutoSize = true;
            this.label_CPower.Location = new System.Drawing.Point(3, 290);
            this.label_CPower.Name = "label_CPower";
            this.label_CPower.Size = new System.Drawing.Size(59, 15);
            this.label_CPower.TabIndex = 31;
            this.label_CPower.Text = "C Power:*";
            this.label_CPower.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_MaxIterations
            // 
            this.input_MaxIterations.CausesValidation = false;
            this.input_MaxIterations.Location = new System.Drawing.Point(100, 162);
            this.input_MaxIterations.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.input_MaxIterations.Name = "input_MaxIterations";
            this.input_MaxIterations.Size = new System.Drawing.Size(55, 23);
            this.input_MaxIterations.TabIndex = 8;
            this.input_MaxIterations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.input_MaxIterations.ValueChanged += new System.EventHandler(this.input_MaxIterations_ValueChanged);
            this.input_MaxIterations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            // 
            // button_Menu1
            // 
            this.button_Menu1.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Menu1.Location = new System.Drawing.Point(4, 5);
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
            this.button_Menu2.Location = new System.Drawing.Point(42, 5);
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
            this.label_Bailout.Location = new System.Drawing.Point(3, 56);
            this.label_Bailout.Name = "label_Bailout";
            this.label_Bailout.Size = new System.Drawing.Size(102, 15);
            this.label_Bailout.TabIndex = 35;
            this.label_Bailout.Text = "Bailout (general):*";
            // 
            // button_Menu3
            // 
            this.button_Menu3.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Menu3.Location = new System.Drawing.Point(81, 5);
            this.button_Menu3.Name = "button_Menu3";
            this.button_Menu3.Size = new System.Drawing.Size(35, 25);
            this.button_Menu3.TabIndex = 36;
            this.button_Menu3.Text = "3";
            this.button_Menu3.UseVisualStyleBackColor = true;
            this.button_Menu3.Click += new System.EventHandler(this.button_Menu3_Click);
            // 
            // input_Bailout
            // 
            this.input_Bailout.Location = new System.Drawing.Point(116, 53);
            this.input_Bailout.Name = "input_Bailout";
            this.input_Bailout.Size = new System.Drawing.Size(40, 23);
            this.input_Bailout.TabIndex = 36;
            this.input_Bailout.Text = "2";
            this.input_Bailout.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_Bailout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_Bailout.Validating += new System.ComponentModel.CancelEventHandler(this.input_Bailout_Validating);
            this.input_Bailout.Validated += new System.EventHandler(this.input_Bailout_Validated);
            // 
            // button_Menu4
            // 
            this.button_Menu4.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Menu4.Location = new System.Drawing.Point(122, 5);
            this.button_Menu4.Name = "button_Menu4";
            this.button_Menu4.Size = new System.Drawing.Size(35, 25);
            this.button_Menu4.TabIndex = 37;
            this.button_Menu4.Text = "4";
            this.button_Menu4.UseVisualStyleBackColor = true;
            this.button_Menu4.Click += new System.EventHandler(this.button_Menu4_Click);
            // 
            // panel_FormulaMenu
            // 
            this.panel_FormulaMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_FormulaMenu.AutoScroll = true;
            this.panel_FormulaMenu.CausesValidation = false;
            this.panel_FormulaMenu.Controls.Add(this.label_FormulaMenu);
            this.panel_FormulaMenu.Controls.Add(this.label_FractalType);
            this.panel_FormulaMenu.Controls.Add(this.input_FractalType);
            this.panel_FormulaMenu.Controls.Add(this.label_Formula);
            this.panel_FormulaMenu.Controls.Add(this.input_FractalFormula);
            this.panel_FormulaMenu.Controls.Add(this.label_JuliaPosition);
            this.panel_FormulaMenu.Controls.Add(this.input_JuliaX);
            this.panel_FormulaMenu.Controls.Add(this.input_JuliaY);
            this.panel_FormulaMenu.Controls.Add(this.label_MatingSteps);
            this.panel_FormulaMenu.Controls.Add(this.input_MatingSteps);
            this.panel_FormulaMenu.Controls.Add(this.label_CurrentMatingStep);
            this.panel_FormulaMenu.Controls.Add(this.input_CurrentMatingStep);
            this.panel_FormulaMenu.Controls.Add(label_MaxIterations);
            this.panel_FormulaMenu.Controls.Add(this.input_MaxIterations);
            this.panel_FormulaMenu.Controls.Add(label_MinIterations);
            this.panel_FormulaMenu.Controls.Add(this.input_MinIterations);
            this.panel_FormulaMenu.Controls.Add(this.checkBox_UseConjugate);
            this.panel_FormulaMenu.Controls.Add(this.label_StartPosition);
            this.panel_FormulaMenu.Controls.Add(this.input_StartPositionX);
            this.panel_FormulaMenu.Controls.Add(this.input_StartPositionY);
            this.panel_FormulaMenu.Controls.Add(this.label_Power);
            this.panel_FormulaMenu.Controls.Add(this.input_Power);
            this.panel_FormulaMenu.Controls.Add(this.label_CPower);
            this.panel_FormulaMenu.Controls.Add(this.input_CPower);
            this.panel_FormulaMenu.Controls.Add(this.input_FoldCount);
            this.panel_FormulaMenu.Controls.Add(this.input_FoldOffsetY);
            this.panel_FormulaMenu.Controls.Add(this.label_FoldOffset);
            this.panel_FormulaMenu.Controls.Add(this.input_FoldOffsetX);
            this.panel_FormulaMenu.Controls.Add(this.input_FoldAngle);
            this.panel_FormulaMenu.Controls.Add(this.label_FoldAngle);
            this.panel_FormulaMenu.Controls.Add(label_FoldCount);
            this.panel_FormulaMenu.Controls.Add(this.checkBox_UseBuddhabrot);
            this.panel_FormulaMenu.Controls.Add(this.label_BuddhabrotType);
            this.panel_FormulaMenu.Controls.Add(this.input_BuddhabrotType);
            this.panel_FormulaMenu.Location = new System.Drawing.Point(517, 24);
            this.panel_FormulaMenu.MinimumSize = new System.Drawing.Size(178, 276);
            this.panel_FormulaMenu.Name = "panel_FormulaMenu";
            this.panel_FormulaMenu.Size = new System.Drawing.Size(178, 316);
            this.panel_FormulaMenu.TabIndex = 32;
            // 
            // label_CurrentMatingStep
            // 
            this.label_CurrentMatingStep.AutoSize = true;
            this.label_CurrentMatingStep.Location = new System.Drawing.Point(3, 135);
            this.label_CurrentMatingStep.Name = "label_CurrentMatingStep";
            this.label_CurrentMatingStep.Size = new System.Drawing.Size(81, 15);
            this.label_CurrentMatingStep.TabIndex = 110;
            this.label_CurrentMatingStep.Text = "Current Step:*";
            this.label_CurrentMatingStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_MatingSteps
            // 
            this.label_MatingSteps.AutoSize = true;
            this.label_MatingSteps.Location = new System.Drawing.Point(3, 109);
            this.label_MatingSteps.Name = "label_MatingSteps";
            this.label_MatingSteps.Size = new System.Drawing.Size(79, 15);
            this.label_MatingSteps.TabIndex = 109;
            this.label_MatingSteps.Text = "Mating Steps:";
            this.label_MatingSteps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_CurrentMatingStep
            // 
            this.input_CurrentMatingStep.CausesValidation = false;
            this.input_CurrentMatingStep.Location = new System.Drawing.Point(99, 133);
            this.input_CurrentMatingStep.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.input_CurrentMatingStep.Name = "input_CurrentMatingStep";
            this.input_CurrentMatingStep.Size = new System.Drawing.Size(55, 23);
            this.input_CurrentMatingStep.TabIndex = 108;
            this.input_CurrentMatingStep.ValueChanged += new System.EventHandler(this.input_CurrentMatingStep_ValueChanged);
            this.input_CurrentMatingStep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            // 
            // input_MatingSteps
            // 
            this.input_MatingSteps.Location = new System.Drawing.Point(99, 106);
            this.input_MatingSteps.Name = "input_MatingSteps";
            this.input_MatingSteps.Size = new System.Drawing.Size(56, 23);
            this.input_MatingSteps.TabIndex = 107;
            this.input_MatingSteps.Text = "25, 16";
            this.input_MatingSteps.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_MatingSteps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateMultipleUintChar);
            this.input_MatingSteps.Validating += new System.ComponentModel.CancelEventHandler(this.input_MatingSteps_Validating);
            this.input_MatingSteps.Validated += new System.EventHandler(this.input_MatingSteps_Validated);
            // 
            // input_StartPositionY
            // 
            this.input_StartPositionY.Location = new System.Drawing.Point(117, 235);
            this.input_StartPositionY.Name = "input_StartPositionY";
            this.input_StartPositionY.Size = new System.Drawing.Size(38, 23);
            this.input_StartPositionY.TabIndex = 103;
            this.input_StartPositionY.Text = "0";
            this.input_StartPositionY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_StartPositionY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_StartPositionY.Validating += new System.ComponentModel.CancelEventHandler(this.input_StartPositionY_Validating);
            this.input_StartPositionY.Validated += new System.EventHandler(this.input_StartPositionY_Validated);
            // 
            // input_StartPositionX
            // 
            this.input_StartPositionX.Location = new System.Drawing.Point(76, 235);
            this.input_StartPositionX.Name = "input_StartPositionX";
            this.input_StartPositionX.Size = new System.Drawing.Size(38, 23);
            this.input_StartPositionX.TabIndex = 102;
            this.input_StartPositionX.Text = "0";
            this.input_StartPositionX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_StartPositionX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_StartPositionX.Validating += new System.ComponentModel.CancelEventHandler(this.input_StartPositionX_Validating);
            this.input_StartPositionX.Validated += new System.EventHandler(this.input_StartPositionX_Validated);
            // 
            // label_StartPosition
            // 
            this.label_StartPosition.AutoSize = true;
            this.label_StartPosition.Location = new System.Drawing.Point(3, 238);
            this.label_StartPosition.Name = "label_StartPosition";
            this.label_StartPosition.Size = new System.Drawing.Size(47, 15);
            this.label_StartPosition.TabIndex = 101;
            this.label_StartPosition.Text = "Start at:";
            this.label_StartPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_JuliaPosition
            // 
            this.label_JuliaPosition.AutoSize = true;
            this.label_JuliaPosition.Location = new System.Drawing.Point(3, 83);
            this.label_JuliaPosition.Name = "label_JuliaPosition";
            this.label_JuliaPosition.Size = new System.Drawing.Size(38, 15);
            this.label_JuliaPosition.TabIndex = 98;
            this.label_JuliaPosition.Text = "Julia:*";
            this.label_JuliaPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_JuliaX
            // 
            this.input_JuliaX.Location = new System.Drawing.Point(68, 80);
            this.input_JuliaX.Name = "input_JuliaX";
            this.input_JuliaX.Size = new System.Drawing.Size(42, 23);
            this.input_JuliaX.TabIndex = 97;
            this.input_JuliaX.Text = "0";
            this.input_JuliaX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_JuliaX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_JuliaX_KeyPress);
            this.input_JuliaX.Validating += new System.ComponentModel.CancelEventHandler(this.input_JuliaX_Validating);
            this.input_JuliaX.Validated += new System.EventHandler(this.input_JuliaX_Validated);
            // 
            // input_JuliaY
            // 
            this.input_JuliaY.Location = new System.Drawing.Point(113, 80);
            this.input_JuliaY.Name = "input_JuliaY";
            this.input_JuliaY.Size = new System.Drawing.Size(42, 23);
            this.input_JuliaY.TabIndex = 96;
            this.input_JuliaY.Text = "0";
            this.input_JuliaY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_JuliaY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_JuliaY_KeyPress);
            this.input_JuliaY.Validating += new System.ComponentModel.CancelEventHandler(this.input_JuliaY_Validating);
            this.input_JuliaY.Validated += new System.EventHandler(this.input_JuliaY_Validated);
            // 
            // input_MinIterations
            // 
            this.input_MinIterations.CausesValidation = false;
            this.input_MinIterations.Location = new System.Drawing.Point(100, 189);
            this.input_MinIterations.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.input_MinIterations.Name = "input_MinIterations";
            this.input_MinIterations.Size = new System.Drawing.Size(55, 23);
            this.input_MinIterations.TabIndex = 86;
            this.input_MinIterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_MinIterations.ValueChanged += new System.EventHandler(this.input_MinIterations_ValueChanged);
            this.input_MinIterations.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            // 
            // checkBox_UseConjugate
            // 
            this.checkBox_UseConjugate.AutoSize = true;
            this.checkBox_UseConjugate.Location = new System.Drawing.Point(8, 214);
            this.checkBox_UseConjugate.Name = "checkBox_UseConjugate";
            this.checkBox_UseConjugate.Size = new System.Drawing.Size(103, 19);
            this.checkBox_UseConjugate.TabIndex = 87;
            this.checkBox_UseConjugate.Text = "Use Conjugate";
            this.checkBox_UseConjugate.UseVisualStyleBackColor = true;
            this.checkBox_UseConjugate.CheckedChanged += new System.EventHandler(this.checkBox_UseConjugate_CheckedChanged);
            // 
            // input_FoldCount
            // 
            this.input_FoldCount.Location = new System.Drawing.Point(99, 314);
            this.input_FoldCount.Name = "input_FoldCount";
            this.input_FoldCount.Size = new System.Drawing.Size(56, 23);
            this.input_FoldCount.TabIndex = 95;
            this.input_FoldCount.Text = "0";
            this.input_FoldCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_FoldCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_FoldCount.Validating += new System.ComponentModel.CancelEventHandler(this.input_FoldCount_Validating);
            this.input_FoldCount.Validated += new System.EventHandler(this.input_FoldCount_Validated);
            // 
            // input_FoldOffsetY
            // 
            this.input_FoldOffsetY.Location = new System.Drawing.Point(117, 368);
            this.input_FoldOffsetY.Name = "input_FoldOffsetY";
            this.input_FoldOffsetY.Size = new System.Drawing.Size(38, 23);
            this.input_FoldOffsetY.TabIndex = 93;
            this.input_FoldOffsetY.Text = "0";
            this.input_FoldOffsetY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_FoldOffsetY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_FoldOffsetY.Validating += new System.ComponentModel.CancelEventHandler(this.input_FoldOffsetY_Validating);
            this.input_FoldOffsetY.Validated += new System.EventHandler(this.input_FoldOffsetY_Validated);
            // 
            // label_FoldOffset
            // 
            this.label_FoldOffset.AutoSize = true;
            this.label_FoldOffset.Location = new System.Drawing.Point(3, 371);
            this.label_FoldOffset.Name = "label_FoldOffset";
            this.label_FoldOffset.Size = new System.Drawing.Size(73, 15);
            this.label_FoldOffset.TabIndex = 94;
            this.label_FoldOffset.Text = "Fold Offset:*";
            this.label_FoldOffset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_FoldOffsetX
            // 
            this.input_FoldOffsetX.Location = new System.Drawing.Point(76, 368);
            this.input_FoldOffsetX.Name = "input_FoldOffsetX";
            this.input_FoldOffsetX.Size = new System.Drawing.Size(38, 23);
            this.input_FoldOffsetX.TabIndex = 92;
            this.input_FoldOffsetX.Text = "0";
            this.input_FoldOffsetX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_FoldOffsetX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_FoldOffsetX.Validating += new System.ComponentModel.CancelEventHandler(this.input_FoldOffsetX_Validating);
            this.input_FoldOffsetX.Validated += new System.EventHandler(this.input_FoldOffsetX_Validated);
            // 
            // input_FoldAngle
            // 
            this.input_FoldAngle.Location = new System.Drawing.Point(99, 341);
            this.input_FoldAngle.Name = "input_FoldAngle";
            this.input_FoldAngle.Size = new System.Drawing.Size(56, 23);
            this.input_FoldAngle.TabIndex = 90;
            this.input_FoldAngle.Text = "0";
            this.input_FoldAngle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_FoldAngle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_FoldAngle.Validating += new System.ComponentModel.CancelEventHandler(this.input_FoldAngle_Validating);
            this.input_FoldAngle.Validated += new System.EventHandler(this.input_FoldAngle_Validated);
            // 
            // label_FoldAngle
            // 
            this.label_FoldAngle.AutoSize = true;
            this.label_FoldAngle.Location = new System.Drawing.Point(3, 344);
            this.label_FoldAngle.Name = "label_FoldAngle";
            this.label_FoldAngle.Size = new System.Drawing.Size(72, 15);
            this.label_FoldAngle.TabIndex = 91;
            this.label_FoldAngle.Text = "Fold Angle:*";
            this.label_FoldAngle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox_UseBuddhabrot
            // 
            this.checkBox_UseBuddhabrot.AutoSize = true;
            this.checkBox_UseBuddhabrot.Location = new System.Drawing.Point(8, 398);
            this.checkBox_UseBuddhabrot.Name = "checkBox_UseBuddhabrot";
            this.checkBox_UseBuddhabrot.Size = new System.Drawing.Size(111, 19);
            this.checkBox_UseBuddhabrot.TabIndex = 65;
            this.checkBox_UseBuddhabrot.Text = "Use Buddhabrot";
            this.checkBox_UseBuddhabrot.UseVisualStyleBackColor = true;
            // 
            // label_BuddhabrotType
            // 
            this.label_BuddhabrotType.AutoSize = true;
            this.label_BuddhabrotType.Location = new System.Drawing.Point(3, 420);
            this.label_BuddhabrotType.Name = "label_BuddhabrotType";
            this.label_BuddhabrotType.Size = new System.Drawing.Size(34, 15);
            this.label_BuddhabrotType.TabIndex = 83;
            this.label_BuddhabrotType.Text = "Type:";
            this.label_BuddhabrotType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_BuddhabrotType
            // 
            this.input_BuddhabrotType.CausesValidation = false;
            this.input_BuddhabrotType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_BuddhabrotType.FormattingEnabled = true;
            this.input_BuddhabrotType.Items.AddRange(new object[] {
            "Normal",
            "Inverse",
            "Nebulabrot"});
            this.input_BuddhabrotType.Location = new System.Drawing.Point(69, 417);
            this.input_BuddhabrotType.Name = "input_BuddhabrotType";
            this.input_BuddhabrotType.Size = new System.Drawing.Size(86, 23);
            this.input_BuddhabrotType.TabIndex = 84;
            // 
            // label_OrbitTrapPosition
            // 
            this.label_OrbitTrapPosition.AutoSize = true;
            this.label_OrbitTrapPosition.Location = new System.Drawing.Point(3, 140);
            this.label_OrbitTrapPosition.Name = "label_OrbitTrapPosition";
            this.label_OrbitTrapPosition.Size = new System.Drawing.Size(58, 15);
            this.label_OrbitTrapPosition.TabIndex = 39;
            this.label_OrbitTrapPosition.Text = "Position:*";
            this.label_OrbitTrapPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_BailoutX
            // 
            this.input_BailoutX.Location = new System.Drawing.Point(72, 137);
            this.input_BailoutX.Name = "input_BailoutX";
            this.input_BailoutX.Size = new System.Drawing.Size(40, 23);
            this.input_BailoutX.TabIndex = 38;
            this.input_BailoutX.Text = "0";
            this.input_BailoutX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_BailoutX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.input_BailoutX_KeyPress);
            this.input_BailoutX.Validating += new System.ComponentModel.CancelEventHandler(this.input_BailoutX_Validating);
            this.input_BailoutX.Validated += new System.EventHandler(this.input_BailoutX_Validated);
            // 
            // panel_OrbitTrapMenu
            // 
            this.panel_OrbitTrapMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_OrbitTrapMenu.AutoScroll = true;
            this.panel_OrbitTrapMenu.Controls.Add(this.label_OrbitTrapMenu);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_EditingOrbitBailout);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_EditingBailoutTrap);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_Bailout);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_OrbitTrap);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_OrbitTrap);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_Bailout);
            this.panel_OrbitTrapMenu.Controls.Add(this.LogTextBox);
            this.panel_OrbitTrapMenu.Controls.Add(this.button_AddBailoutTrap);
            this.panel_OrbitTrapMenu.Controls.Add(this.button_RemoveBailoutTrap);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_OrbitTrapPosition);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_BailoutX);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_BailoutY);
            this.panel_OrbitTrapMenu.Controls.Add(label_StartDistance);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_StartDistance);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_OrbitTrapCalculation);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_OrbitTrapCalculation);
            this.panel_OrbitTrapMenu.Controls.Add(label_StartOrbit);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_StartOrbit);
            this.panel_OrbitTrapMenu.Controls.Add(label_OrbitRange);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_OrbitRange);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_OrbitTrapFactors);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_OrbitTrapBlendingFactor);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_OrbitTrapThicknessFactor);
            this.panel_OrbitTrapMenu.Controls.Add(this.checkBox_UseSecondValue);
            this.panel_OrbitTrapMenu.Controls.Add(this.label_SecondValueFactors);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_SecondValueFactor1);
            this.panel_OrbitTrapMenu.Controls.Add(this.input_SecondValueFactor2);
            this.panel_OrbitTrapMenu.Location = new System.Drawing.Point(517, 24);
            this.panel_OrbitTrapMenu.MinimumSize = new System.Drawing.Size(178, 276);
            this.panel_OrbitTrapMenu.Name = "panel_OrbitTrapMenu";
            this.panel_OrbitTrapMenu.Size = new System.Drawing.Size(178, 316);
            this.panel_OrbitTrapMenu.TabIndex = 33;
            // 
            // label_OrbitTrapMenu
            // 
            this.label_OrbitTrapMenu.AutoSize = true;
            this.label_OrbitTrapMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_OrbitTrapMenu.Location = new System.Drawing.Point(22, 0);
            this.label_OrbitTrapMenu.Name = "label_OrbitTrapMenu";
            this.label_OrbitTrapMenu.Size = new System.Drawing.Size(113, 19);
            this.label_OrbitTrapMenu.TabIndex = 35;
            this.label_OrbitTrapMenu.Text = "Orbit Trap Menu";
            // 
            // label_EditingOrbitBailout
            // 
            this.label_EditingOrbitBailout.AutoSize = true;
            this.label_EditingOrbitBailout.Location = new System.Drawing.Point(3, 116);
            this.label_EditingOrbitBailout.Name = "label_EditingOrbitBailout";
            this.label_EditingOrbitBailout.Size = new System.Drawing.Size(78, 15);
            this.label_EditingOrbitBailout.TabIndex = 51;
            this.label_EditingOrbitBailout.Text = "Editing Point:";
            // 
            // input_EditingBailoutTrap
            // 
            this.input_EditingBailoutTrap.CausesValidation = false;
            this.input_EditingBailoutTrap.Location = new System.Drawing.Point(91, 111);
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
            this.input_EditingBailoutTrap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            // 
            // button_AddBailoutTrap
            // 
            this.button_AddBailoutTrap.Location = new System.Drawing.Point(3, 85);
            this.button_AddBailoutTrap.Name = "button_AddBailoutTrap";
            this.button_AddBailoutTrap.Size = new System.Drawing.Size(74, 23);
            this.button_AddBailoutTrap.TabIndex = 42;
            this.button_AddBailoutTrap.Text = "Add";
            this.button_AddBailoutTrap.UseVisualStyleBackColor = true;
            this.button_AddBailoutTrap.Click += new System.EventHandler(this.button_AddBailoutTrap_Click);
            // 
            // button_RemoveBailoutTrap
            // 
            this.button_RemoveBailoutTrap.Location = new System.Drawing.Point(81, 85);
            this.button_RemoveBailoutTrap.Name = "button_RemoveBailoutTrap";
            this.button_RemoveBailoutTrap.Size = new System.Drawing.Size(74, 23);
            this.button_RemoveBailoutTrap.TabIndex = 43;
            this.button_RemoveBailoutTrap.Text = "Remove";
            this.button_RemoveBailoutTrap.UseVisualStyleBackColor = true;
            this.button_RemoveBailoutTrap.Click += new System.EventHandler(this.button_RemoveBailoutTrap_Click);
            // 
            // input_StartDistance
            // 
            this.input_StartDistance.Location = new System.Drawing.Point(92, 166);
            this.input_StartDistance.Name = "input_StartDistance";
            this.input_StartDistance.Size = new System.Drawing.Size(64, 23);
            this.input_StartDistance.TabIndex = 58;
            this.input_StartDistance.Text = "2";
            this.input_StartDistance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_StartDistance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_StartDistance.Validating += new System.ComponentModel.CancelEventHandler(this.input_StartDistance_Validating);
            this.input_StartDistance.Validated += new System.EventHandler(this.input_StartDistance_Validated);
            // 
            // label_OrbitTrapCalculation
            // 
            this.label_OrbitTrapCalculation.AutoSize = true;
            this.label_OrbitTrapCalculation.Location = new System.Drawing.Point(3, 195);
            this.label_OrbitTrapCalculation.Name = "label_OrbitTrapCalculation";
            this.label_OrbitTrapCalculation.Size = new System.Drawing.Size(70, 15);
            this.label_OrbitTrapCalculation.TabIndex = 55;
            this.label_OrbitTrapCalculation.Text = "Calculation:";
            this.label_OrbitTrapCalculation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_OrbitTrapCalculation
            // 
            this.input_OrbitTrapCalculation.CausesValidation = false;
            this.input_OrbitTrapCalculation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_OrbitTrapCalculation.FormattingEnabled = true;
            this.input_OrbitTrapCalculation.Items.AddRange(new object[] {
            "Minimum",
            "Maximum",
            "Average",
            "First",
            "Last"});
            this.input_OrbitTrapCalculation.Location = new System.Drawing.Point(81, 192);
            this.input_OrbitTrapCalculation.Name = "input_OrbitTrapCalculation";
            this.input_OrbitTrapCalculation.Size = new System.Drawing.Size(74, 23);
            this.input_OrbitTrapCalculation.TabIndex = 56;
            this.input_OrbitTrapCalculation.SelectionChangeCommitted += new System.EventHandler(this.input_OrbitTrapCalculation_SelectionChangeCommitted);
            // 
            // input_StartOrbit
            // 
            this.input_StartOrbit.CausesValidation = false;
            this.input_StartOrbit.Location = new System.Drawing.Point(91, 219);
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
            this.input_StartOrbit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            // 
            // input_OrbitRange
            // 
            this.input_OrbitRange.CausesValidation = false;
            this.input_OrbitRange.Location = new System.Drawing.Point(91, 245);
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
            this.input_OrbitRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            // 
            // label_OrbitTrapFactors
            // 
            this.label_OrbitTrapFactors.AutoSize = true;
            this.label_OrbitTrapFactors.Location = new System.Drawing.Point(3, 274);
            this.label_OrbitTrapFactors.Name = "label_OrbitTrapFactors";
            this.label_OrbitTrapFactors.Size = new System.Drawing.Size(53, 15);
            this.label_OrbitTrapFactors.TabIndex = 54;
            this.label_OrbitTrapFactors.Text = "Factors:*";
            this.label_OrbitTrapFactors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_OrbitTrapBlendingFactor
            // 
            this.input_OrbitTrapBlendingFactor.Location = new System.Drawing.Point(72, 271);
            this.input_OrbitTrapBlendingFactor.Name = "input_OrbitTrapBlendingFactor";
            this.input_OrbitTrapBlendingFactor.Size = new System.Drawing.Size(40, 23);
            this.input_OrbitTrapBlendingFactor.TabIndex = 53;
            this.input_OrbitTrapBlendingFactor.Text = "0.25";
            this.input_OrbitTrapBlendingFactor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_OrbitTrapBlendingFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_OrbitTrapBlendingFactor.Validating += new System.ComponentModel.CancelEventHandler(this.input_OrbitTrapFactor1_Validating);
            this.input_OrbitTrapBlendingFactor.Validated += new System.EventHandler(this.input_OrbitTrapFactor1_Validated);
            // 
            // input_OrbitTrapThicknessFactor
            // 
            this.input_OrbitTrapThicknessFactor.Location = new System.Drawing.Point(116, 271);
            this.input_OrbitTrapThicknessFactor.Name = "input_OrbitTrapThicknessFactor";
            this.input_OrbitTrapThicknessFactor.Size = new System.Drawing.Size(40, 23);
            this.input_OrbitTrapThicknessFactor.TabIndex = 52;
            this.input_OrbitTrapThicknessFactor.Text = "7";
            this.input_OrbitTrapThicknessFactor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_OrbitTrapThicknessFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_OrbitTrapThicknessFactor.Validating += new System.ComponentModel.CancelEventHandler(this.input_OrbitTrapFactor2_Validating);
            this.input_OrbitTrapThicknessFactor.Validated += new System.EventHandler(this.input_OrbitTrapFactor2_Validated);
            // 
            // checkBox_UseSecondValue
            // 
            this.checkBox_UseSecondValue.AutoSize = true;
            this.checkBox_UseSecondValue.Location = new System.Drawing.Point(8, 298);
            this.checkBox_UseSecondValue.Name = "checkBox_UseSecondValue";
            this.checkBox_UseSecondValue.Size = new System.Drawing.Size(118, 19);
            this.checkBox_UseSecondValue.TabIndex = 84;
            this.checkBox_UseSecondValue.Text = "Use Second Value";
            this.checkBox_UseSecondValue.UseVisualStyleBackColor = true;
            this.checkBox_UseSecondValue.CheckedChanged += new System.EventHandler(this.checkBox_UseSecondValue_CheckedChanged);
            // 
            // label_SecondValueFactors
            // 
            this.label_SecondValueFactors.AutoSize = true;
            this.label_SecondValueFactors.Location = new System.Drawing.Point(3, 320);
            this.label_SecondValueFactors.Name = "label_SecondValueFactors";
            this.label_SecondValueFactors.Size = new System.Drawing.Size(53, 15);
            this.label_SecondValueFactors.TabIndex = 86;
            this.label_SecondValueFactors.Text = "Factors:*";
            this.label_SecondValueFactors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_SecondValueFactor1
            // 
            this.input_SecondValueFactor1.Location = new System.Drawing.Point(72, 317);
            this.input_SecondValueFactor1.Name = "input_SecondValueFactor1";
            this.input_SecondValueFactor1.Size = new System.Drawing.Size(40, 23);
            this.input_SecondValueFactor1.TabIndex = 85;
            this.input_SecondValueFactor1.Text = "4";
            this.input_SecondValueFactor1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_SecondValueFactor1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_SecondValueFactor1.Validating += new System.ComponentModel.CancelEventHandler(this.input_SecondValueFactor1_Validating);
            this.input_SecondValueFactor1.Validated += new System.EventHandler(this.input_SecondValueFactor1_Validated);
            // 
            // input_SecondValueFactor2
            // 
            this.input_SecondValueFactor2.Location = new System.Drawing.Point(116, 317);
            this.input_SecondValueFactor2.Name = "input_SecondValueFactor2";
            this.input_SecondValueFactor2.Size = new System.Drawing.Size(40, 23);
            this.input_SecondValueFactor2.TabIndex = 87;
            this.input_SecondValueFactor2.Text = "20";
            this.input_SecondValueFactor2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_SecondValueFactor2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_SecondValueFactor2.Validating += new System.ComponentModel.CancelEventHandler(this.input_SecondValueFactor2_Validating);
            this.input_SecondValueFactor2.Validated += new System.EventHandler(this.input_SecondValueFactor2_Validated);
            // 
            // label_Texture
            // 
            this.label_Texture.AutoSize = true;
            this.label_Texture.Location = new System.Drawing.Point(3, 454);
            this.label_Texture.Name = "label_Texture";
            this.label_Texture.Size = new System.Drawing.Size(48, 15);
            this.label_Texture.TabIndex = 40;
            this.label_Texture.Text = "Texture:";
            this.label_Texture.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_Texture
            // 
            this.input_Texture.Location = new System.Drawing.Point(57, 451);
            this.input_Texture.Name = "input_Texture";
            this.input_Texture.Size = new System.Drawing.Size(98, 23);
            this.input_Texture.TabIndex = 41;
            this.input_Texture.Click += new System.EventHandler(this.input_Texture_Click);
            this.input_Texture.TextChanged += new System.EventHandler(this.input_Texture_TextChanged);
            this.input_Texture.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            // 
            // checkBox_LockZoomFactor
            // 
            this.checkBox_LockZoomFactor.AutoSize = true;
            this.checkBox_LockZoomFactor.Location = new System.Drawing.Point(343, 7);
            this.checkBox_LockZoomFactor.Name = "checkBox_LockZoomFactor";
            this.checkBox_LockZoomFactor.Size = new System.Drawing.Size(122, 19);
            this.checkBox_LockZoomFactor.TabIndex = 38;
            this.checkBox_LockZoomFactor.Text = "Lock Zoom Factor";
            this.checkBox_LockZoomFactor.UseVisualStyleBackColor = true;
            this.checkBox_LockZoomFactor.CheckedChanged += new System.EventHandler(this.checkBox_LockZoomFactor_CheckedChanged);
            // 
            // input_ColorCycles
            // 
            this.input_ColorCycles.Location = new System.Drawing.Point(68, 132);
            this.input_ColorCycles.Name = "input_ColorCycles";
            this.input_ColorCycles.Size = new System.Drawing.Size(40, 23);
            this.input_ColorCycles.TabIndex = 43;
            this.input_ColorCycles.Text = "1";
            this.input_ColorCycles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_ColorCycles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_ColorCycles.Validating += new System.ComponentModel.CancelEventHandler(this.input_ColorCycles_Validating);
            this.input_ColorCycles.Validated += new System.EventHandler(this.input_ColorCycles_Validated);
            // 
            // label_ColorFactors
            // 
            this.label_ColorFactors.AutoSize = true;
            this.label_ColorFactors.Location = new System.Drawing.Point(2, 135);
            this.label_ColorFactors.Name = "label_ColorFactors";
            this.label_ColorFactors.Size = new System.Drawing.Size(53, 15);
            this.label_ColorFactors.TabIndex = 42;
            this.label_ColorFactors.Text = "Factors:*";
            // 
            // input_ColorFactor
            // 
            this.input_ColorFactor.Location = new System.Drawing.Point(115, 132);
            this.input_ColorFactor.Name = "input_ColorFactor";
            this.input_ColorFactor.Size = new System.Drawing.Size(40, 23);
            this.input_ColorFactor.TabIndex = 45;
            this.input_ColorFactor.Text = "6";
            this.input_ColorFactor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_ColorFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_ColorFactor.Validating += new System.ComponentModel.CancelEventHandler(this.input_ColorFactor_Validating);
            this.input_ColorFactor.Validated += new System.EventHandler(this.input_ColorFactor_Validated);
            // 
            // input_Center
            // 
            this.input_Center.Location = new System.Drawing.Point(49, 5);
            this.input_Center.Name = "input_Center";
            this.input_Center.Size = new System.Drawing.Size(145, 23);
            this.input_Center.TabIndex = 55;
            this.input_Center.Text = "0, 0";
            this.input_Center.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_Center.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateMultipleDecimalChar);
            this.input_Center.Validating += new System.ComponentModel.CancelEventHandler(this.input_Center_Validating);
            this.input_Center.Validated += new System.EventHandler(this.input_Center_Validated);
            // 
            // label_FractalCenter
            // 
            this.label_FractalCenter.AutoSize = true;
            this.label_FractalCenter.Location = new System.Drawing.Point(3, 8);
            this.label_FractalCenter.Name = "label_FractalCenter";
            this.label_FractalCenter.Size = new System.Drawing.Size(45, 15);
            this.label_FractalCenter.TabIndex = 56;
            this.label_FractalCenter.Text = "Center:";
            this.label_FractalCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_FractalZoom
            // 
            this.label_FractalZoom.AutoSize = true;
            this.label_FractalZoom.Location = new System.Drawing.Point(198, 10);
            this.label_FractalZoom.Name = "label_FractalZoom";
            this.label_FractalZoom.Size = new System.Drawing.Size(45, 15);
            this.label_FractalZoom.TabIndex = 58;
            this.label_FractalZoom.Text = "Zoom: ";
            this.label_FractalZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_Zoom
            // 
            this.input_Zoom.Location = new System.Drawing.Point(240, 5);
            this.input_Zoom.Name = "input_Zoom";
            this.input_Zoom.Size = new System.Drawing.Size(45, 23);
            this.input_Zoom.TabIndex = 57;
            this.input_Zoom.Text = "0";
            this.input_Zoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_Zoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_Zoom.Validating += new System.ComponentModel.CancelEventHandler(this.input_Zoom_Validating);
            this.input_Zoom.Validated += new System.EventHandler(this.input_Zoom_Validated);
            // 
            // panel_ColorMenu
            // 
            this.panel_ColorMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_ColorMenu.AutoScroll = true;
            this.panel_ColorMenu.Controls.Add(this.label_ColorMenu);
            this.panel_ColorMenu.Controls.Add(this.label_EditingColor);
            this.panel_ColorMenu.Controls.Add(this.input_EditingColor);
            this.panel_ColorMenu.Controls.Add(this.label_Coloring);
            this.panel_ColorMenu.Controls.Add(this.input_Coloring);
            this.panel_ColorMenu.Controls.Add(this.checkBox_UseCustomPalette);
            this.panel_ColorMenu.Controls.Add(this.button_Color1);
            this.panel_ColorMenu.Controls.Add(this.button_Color2);
            this.panel_ColorMenu.Controls.Add(this.button_Color3);
            this.panel_ColorMenu.Controls.Add(this.button_Color4);
            this.panel_ColorMenu.Controls.Add(this.button_Color5);
            this.panel_ColorMenu.Controls.Add(this.button_Color6);
            this.panel_ColorMenu.Controls.Add(this.label_ColorFactors);
            this.panel_ColorMenu.Controls.Add(this.input_ColorCycles);
            this.panel_ColorMenu.Controls.Add(this.input_ColorFactor);
            this.panel_ColorMenu.Controls.Add(this.label_OrbitTrapFactor);
            this.panel_ColorMenu.Controls.Add(this.input_OrbitTrapFactor);
            this.panel_ColorMenu.Controls.Add(this.label_StripeDensity);
            this.panel_ColorMenu.Controls.Add(this.input_StripeDensity);
            this.panel_ColorMenu.Controls.Add(this.checkBox_MatchOrbitTrap);
            this.panel_ColorMenu.Controls.Add(this.label_DomainCalculation);
            this.panel_ColorMenu.Controls.Add(this.input_DomainCalculation);
            this.panel_ColorMenu.Controls.Add(this.checkBox_UseDomainIteration);
            this.panel_ColorMenu.Controls.Add(this.checkBox_UseSecondDomainValue);
            this.panel_ColorMenu.Controls.Add(this.label_SecondDomainValueFactors);
            this.panel_ColorMenu.Controls.Add(this.input_SecondDomainValueFactor1);
            this.panel_ColorMenu.Controls.Add(this.input_SecondDomainValueFactor2);
            this.panel_ColorMenu.Controls.Add(this.checkBox_UseDistanceEstimation);
            this.panel_ColorMenu.Controls.Add(this.label_DistanceEstimationMax);
            this.panel_ColorMenu.Controls.Add(this.input_MaxDistanceEstimation);
            this.panel_ColorMenu.Controls.Add(this.label_DistanceEstimationFactors);
            this.panel_ColorMenu.Controls.Add(this.input_DistanceEstimationFactor1);
            this.panel_ColorMenu.Controls.Add(this.input_DistanceEstimationFactor2);
            this.panel_ColorMenu.Controls.Add(this.checkBox_UseNormals);
            this.panel_ColorMenu.Controls.Add(this.button_ClearTexture);
            this.panel_ColorMenu.Controls.Add(this.label_Texture);
            this.panel_ColorMenu.Controls.Add(this.input_Texture);
            this.panel_ColorMenu.Controls.Add(label_TextureBlend);
            this.panel_ColorMenu.Controls.Add(this.input_TextureBlend);
            this.panel_ColorMenu.Controls.Add(this.input_TextureDistortionFactor);
            this.panel_ColorMenu.Controls.Add(this.label_TextureScale);
            this.panel_ColorMenu.Controls.Add(this.input_TextureScaleX);
            this.panel_ColorMenu.Controls.Add(this.input_TextureScaleY);
            this.panel_ColorMenu.Controls.Add(this.checkBox_UsePolarTextureCoordinates);
            this.panel_ColorMenu.Controls.Add(this.checkBox_UseDistortedTexture);
            this.panel_ColorMenu.Controls.Add(this.label_TextureDistortionFactor);
            this.panel_ColorMenu.Location = new System.Drawing.Point(517, 24);
            this.panel_ColorMenu.MinimumSize = new System.Drawing.Size(178, 276);
            this.panel_ColorMenu.Name = "panel_ColorMenu";
            this.panel_ColorMenu.Size = new System.Drawing.Size(178, 316);
            this.panel_ColorMenu.TabIndex = 59;
            // 
            // label_ColorMenu
            // 
            this.label_ColorMenu.AutoSize = true;
            this.label_ColorMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label_ColorMenu.Location = new System.Drawing.Point(30, 0);
            this.label_ColorMenu.Name = "label_ColorMenu";
            this.label_ColorMenu.Size = new System.Drawing.Size(83, 19);
            this.label_ColorMenu.TabIndex = 60;
            this.label_ColorMenu.Text = "Color Menu";
            // 
            // label_EditingColor
            // 
            this.label_EditingColor.AutoSize = true;
            this.label_EditingColor.Location = new System.Drawing.Point(3, 30);
            this.label_EditingColor.Name = "label_EditingColor";
            this.label_EditingColor.Size = new System.Drawing.Size(47, 15);
            this.label_EditingColor.TabIndex = 60;
            this.label_EditingColor.Text = "Editing:";
            this.label_EditingColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_EditingColor
            // 
            this.input_EditingColor.CausesValidation = false;
            this.input_EditingColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_EditingColor.FormattingEnabled = true;
            this.input_EditingColor.Items.AddRange(new object[] {
            "Both",
            "Interior",
            "Exterior"});
            this.input_EditingColor.Location = new System.Drawing.Point(68, 27);
            this.input_EditingColor.Name = "input_EditingColor";
            this.input_EditingColor.Size = new System.Drawing.Size(87, 23);
            this.input_EditingColor.TabIndex = 61;
            this.input_EditingColor.SelectionChangeCommitted += new System.EventHandler(this.input_EditingColor_SelectionChangeCommitted);
            // 
            // label_Coloring
            // 
            this.label_Coloring.AutoSize = true;
            this.label_Coloring.Location = new System.Drawing.Point(3, 56);
            this.label_Coloring.Name = "label_Coloring";
            this.label_Coloring.Size = new System.Drawing.Size(56, 15);
            this.label_Coloring.TabIndex = 62;
            this.label_Coloring.Text = "Coloring:";
            this.label_Coloring.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_Coloring
            // 
            this.input_Coloring.CausesValidation = false;
            this.input_Coloring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_Coloring.FormattingEnabled = true;
            this.input_Coloring.Items.AddRange(new object[] {
            "Black",
            "White",
            "Interation",
            "Smooth",
            "Stripes 1",
            "Stripes 2",
            "Domain 1",
            "Domain 2",
            "Domain 3",
            "Domain 4",
            "Domain 5",
            "Domain 6",
            "Domain 7",
            "Custom"});
            this.input_Coloring.Location = new System.Drawing.Point(68, 53);
            this.input_Coloring.Name = "input_Coloring";
            this.input_Coloring.Size = new System.Drawing.Size(87, 23);
            this.input_Coloring.TabIndex = 63;
            this.input_Coloring.SelectionChangeCommitted += new System.EventHandler(this.input_Coloring_SelectionChangeCommitted);
            // 
            // checkBox_UseCustomPalette
            // 
            this.checkBox_UseCustomPalette.AutoSize = true;
            this.checkBox_UseCustomPalette.Location = new System.Drawing.Point(9, 82);
            this.checkBox_UseCustomPalette.Name = "checkBox_UseCustomPalette";
            this.checkBox_UseCustomPalette.Size = new System.Drawing.Size(129, 19);
            this.checkBox_UseCustomPalette.TabIndex = 75;
            this.checkBox_UseCustomPalette.Text = "Use Custom Palette";
            this.checkBox_UseCustomPalette.UseVisualStyleBackColor = true;
            this.checkBox_UseCustomPalette.CheckedChanged += new System.EventHandler(this.checkBox_UseCustomPalette_CheckedChanged);
            // 
            // button_Color1
            // 
            this.button_Color1.BackColor = System.Drawing.Color.Red;
            this.button_Color1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Color1.Location = new System.Drawing.Point(3, 101);
            this.button_Color1.Name = "button_Color1";
            this.button_Color1.Size = new System.Drawing.Size(25, 25);
            this.button_Color1.TabIndex = 60;
            this.button_Color1.Text = "+";
            this.button_Color1.UseVisualStyleBackColor = false;
            this.button_Color1.Click += new System.EventHandler(this.button_Color1_Click);
            // 
            // button_Color2
            // 
            this.button_Color2.BackColor = System.Drawing.Color.Orange;
            this.button_Color2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Color2.Location = new System.Drawing.Point(28, 101);
            this.button_Color2.Name = "button_Color2";
            this.button_Color2.Size = new System.Drawing.Size(25, 25);
            this.button_Color2.TabIndex = 76;
            this.button_Color2.Text = "+";
            this.button_Color2.UseVisualStyleBackColor = false;
            this.button_Color2.Click += new System.EventHandler(this.button_Color2_Click);
            // 
            // button_Color3
            // 
            this.button_Color3.BackColor = System.Drawing.Color.Yellow;
            this.button_Color3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Color3.Location = new System.Drawing.Point(53, 101);
            this.button_Color3.Name = "button_Color3";
            this.button_Color3.Size = new System.Drawing.Size(25, 25);
            this.button_Color3.TabIndex = 77;
            this.button_Color3.Text = "+";
            this.button_Color3.UseVisualStyleBackColor = false;
            this.button_Color3.Click += new System.EventHandler(this.button_Color3_Click);
            // 
            // button_Color4
            // 
            this.button_Color4.BackColor = System.Drawing.Color.Green;
            this.button_Color4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Color4.Location = new System.Drawing.Point(79, 101);
            this.button_Color4.Name = "button_Color4";
            this.button_Color4.Size = new System.Drawing.Size(25, 25);
            this.button_Color4.TabIndex = 78;
            this.button_Color4.Text = "+";
            this.button_Color4.UseVisualStyleBackColor = false;
            this.button_Color4.Click += new System.EventHandler(this.button_Color4_Click);
            // 
            // button_Color5
            // 
            this.button_Color5.BackColor = System.Drawing.Color.Blue;
            this.button_Color5.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Color5.Location = new System.Drawing.Point(104, 101);
            this.button_Color5.Name = "button_Color5";
            this.button_Color5.Size = new System.Drawing.Size(25, 25);
            this.button_Color5.TabIndex = 79;
            this.button_Color5.Text = "+";
            this.button_Color5.UseVisualStyleBackColor = false;
            this.button_Color5.Click += new System.EventHandler(this.button_Color5_Click);
            // 
            // button_Color6
            // 
            this.button_Color6.BackColor = System.Drawing.Color.Purple;
            this.button_Color6.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Color6.Location = new System.Drawing.Point(129, 101);
            this.button_Color6.Name = "button_Color6";
            this.button_Color6.Size = new System.Drawing.Size(25, 25);
            this.button_Color6.TabIndex = 80;
            this.button_Color6.Text = "+";
            this.button_Color6.UseVisualStyleBackColor = false;
            this.button_Color6.Click += new System.EventHandler(this.button_Color6_Click);
            // 
            // label_OrbitTrapFactor
            // 
            this.label_OrbitTrapFactor.AutoSize = true;
            this.label_OrbitTrapFactor.Location = new System.Drawing.Point(2, 161);
            this.label_OrbitTrapFactor.Name = "label_OrbitTrapFactor";
            this.label_OrbitTrapFactor.Size = new System.Drawing.Size(103, 15);
            this.label_OrbitTrapFactor.TabIndex = 72;
            this.label_OrbitTrapFactor.Text = "Orbit Trap Factor:*";
            // 
            // input_OrbitTrapFactor
            // 
            this.input_OrbitTrapFactor.Location = new System.Drawing.Point(115, 158);
            this.input_OrbitTrapFactor.Name = "input_OrbitTrapFactor";
            this.input_OrbitTrapFactor.Size = new System.Drawing.Size(40, 23);
            this.input_OrbitTrapFactor.TabIndex = 74;
            this.input_OrbitTrapFactor.Text = "10";
            this.input_OrbitTrapFactor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_OrbitTrapFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_OrbitTrapFactor.Validating += new System.ComponentModel.CancelEventHandler(this.input_OrbitTrapFactor_Validating);
            this.input_OrbitTrapFactor.Validated += new System.EventHandler(this.input_OrbitTrapFactor_Validated);
            // 
            // label_StripeDensity
            // 
            this.label_StripeDensity.AutoSize = true;
            this.label_StripeDensity.Location = new System.Drawing.Point(2, 187);
            this.label_StripeDensity.Name = "label_StripeDensity";
            this.label_StripeDensity.Size = new System.Drawing.Size(87, 15);
            this.label_StripeDensity.TabIndex = 94;
            this.label_StripeDensity.Text = "Stripe Density:*";
            // 
            // input_StripeDensity
            // 
            this.input_StripeDensity.Location = new System.Drawing.Point(115, 184);
            this.input_StripeDensity.Name = "input_StripeDensity";
            this.input_StripeDensity.Size = new System.Drawing.Size(40, 23);
            this.input_StripeDensity.TabIndex = 95;
            this.input_StripeDensity.Text = "5";
            this.input_StripeDensity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_StripeDensity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_StripeDensity.Validating += new System.ComponentModel.CancelEventHandler(this.input_StripeDensity_Validating);
            this.input_StripeDensity.Validated += new System.EventHandler(this.input_StripeDensity_Validated);
            // 
            // checkBox_MatchOrbitTrap
            // 
            this.checkBox_MatchOrbitTrap.AutoSize = true;
            this.checkBox_MatchOrbitTrap.Location = new System.Drawing.Point(8, 215);
            this.checkBox_MatchOrbitTrap.Name = "checkBox_MatchOrbitTrap";
            this.checkBox_MatchOrbitTrap.Size = new System.Drawing.Size(115, 19);
            this.checkBox_MatchOrbitTrap.TabIndex = 85;
            this.checkBox_MatchOrbitTrap.Text = "Match Orbit Trap";
            this.checkBox_MatchOrbitTrap.UseVisualStyleBackColor = true;
            this.checkBox_MatchOrbitTrap.CheckedChanged += new System.EventHandler(this.checkBox_MatchOrbitTrap_CheckedChanged);
            // 
            // label_DomainCalculation
            // 
            this.label_DomainCalculation.AutoSize = true;
            this.label_DomainCalculation.Location = new System.Drawing.Point(3, 238);
            this.label_DomainCalculation.Name = "label_DomainCalculation";
            this.label_DomainCalculation.Size = new System.Drawing.Size(82, 15);
            this.label_DomainCalculation.TabIndex = 81;
            this.label_DomainCalculation.Text = "Domain Orbit:";
            this.label_DomainCalculation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_DomainCalculation
            // 
            this.input_DomainCalculation.CausesValidation = false;
            this.input_DomainCalculation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.input_DomainCalculation.FormattingEnabled = true;
            this.input_DomainCalculation.Items.AddRange(new object[] {
            "Minimum",
            "Maximum",
            "Average",
            "First",
            "Last"});
            this.input_DomainCalculation.Location = new System.Drawing.Point(88, 235);
            this.input_DomainCalculation.Name = "input_DomainCalculation";
            this.input_DomainCalculation.Size = new System.Drawing.Size(67, 23);
            this.input_DomainCalculation.TabIndex = 82;
            this.input_DomainCalculation.SelectionChangeCommitted += new System.EventHandler(this.input_DomainCalculation_SelectionChangeCommitted);
            // 
            // checkBox_UseDomainIteration
            // 
            this.checkBox_UseDomainIteration.AutoSize = true;
            this.checkBox_UseDomainIteration.Location = new System.Drawing.Point(8, 261);
            this.checkBox_UseDomainIteration.Name = "checkBox_UseDomainIteration";
            this.checkBox_UseDomainIteration.Size = new System.Drawing.Size(137, 19);
            this.checkBox_UseDomainIteration.TabIndex = 83;
            this.checkBox_UseDomainIteration.Text = "Use Domain Iteration";
            this.checkBox_UseDomainIteration.UseVisualStyleBackColor = true;
            this.checkBox_UseDomainIteration.CheckedChanged += new System.EventHandler(this.checkBox_UseDomainIteration_CheckedChanged);
            // 
            // checkBox_UseSecondDomainValue
            // 
            this.checkBox_UseSecondDomainValue.AutoSize = true;
            this.checkBox_UseSecondDomainValue.Location = new System.Drawing.Point(8, 281);
            this.checkBox_UseSecondDomainValue.Name = "checkBox_UseSecondDomainValue";
            this.checkBox_UseSecondDomainValue.Size = new System.Drawing.Size(118, 19);
            this.checkBox_UseSecondDomainValue.TabIndex = 84;
            this.checkBox_UseSecondDomainValue.Text = "Use Second Value";
            this.checkBox_UseSecondDomainValue.UseVisualStyleBackColor = true;
            this.checkBox_UseSecondDomainValue.CheckedChanged += new System.EventHandler(this.checkBox_UseSecondDomainValue_CheckedChanged);
            // 
            // label_SecondDomainValueFactors
            // 
            this.label_SecondDomainValueFactors.AutoSize = true;
            this.label_SecondDomainValueFactors.Location = new System.Drawing.Point(3, 303);
            this.label_SecondDomainValueFactors.Name = "label_SecondDomainValueFactors";
            this.label_SecondDomainValueFactors.Size = new System.Drawing.Size(53, 15);
            this.label_SecondDomainValueFactors.TabIndex = 89;
            this.label_SecondDomainValueFactors.Text = "Factors:*";
            this.label_SecondDomainValueFactors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_SecondDomainValueFactor1
            // 
            this.input_SecondDomainValueFactor1.Location = new System.Drawing.Point(68, 300);
            this.input_SecondDomainValueFactor1.Name = "input_SecondDomainValueFactor1";
            this.input_SecondDomainValueFactor1.Size = new System.Drawing.Size(40, 23);
            this.input_SecondDomainValueFactor1.TabIndex = 88;
            this.input_SecondDomainValueFactor1.Text = "10";
            this.input_SecondDomainValueFactor1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_SecondDomainValueFactor1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_SecondDomainValueFactor1.Validating += new System.ComponentModel.CancelEventHandler(this.input_SecondDomainValueFactor1_Validating);
            this.input_SecondDomainValueFactor1.Validated += new System.EventHandler(this.input_SecondDomainValueFactor1_Validated);
            // 
            // input_SecondDomainValueFactor2
            // 
            this.input_SecondDomainValueFactor2.Location = new System.Drawing.Point(115, 300);
            this.input_SecondDomainValueFactor2.Name = "input_SecondDomainValueFactor2";
            this.input_SecondDomainValueFactor2.Size = new System.Drawing.Size(40, 23);
            this.input_SecondDomainValueFactor2.TabIndex = 90;
            this.input_SecondDomainValueFactor2.Text = "7";
            this.input_SecondDomainValueFactor2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_SecondDomainValueFactor2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_SecondDomainValueFactor2.Validating += new System.ComponentModel.CancelEventHandler(this.input_SecondDomainValueFactor2_Validating);
            this.input_SecondDomainValueFactor2.Validated += new System.EventHandler(this.input_SecondDomainValueFactor2_Validated);
            // 
            // checkBox_UseDistanceEstimation
            // 
            this.checkBox_UseDistanceEstimation.AutoSize = true;
            this.checkBox_UseDistanceEstimation.Location = new System.Drawing.Point(9, 327);
            this.checkBox_UseDistanceEstimation.Name = "checkBox_UseDistanceEstimation";
            this.checkBox_UseDistanceEstimation.Size = new System.Drawing.Size(152, 19);
            this.checkBox_UseDistanceEstimation.TabIndex = 64;
            this.checkBox_UseDistanceEstimation.Text = "Use Distance Estimation";
            this.checkBox_UseDistanceEstimation.UseVisualStyleBackColor = true;
            this.checkBox_UseDistanceEstimation.CheckedChanged += new System.EventHandler(this.checkBox_UseDistanceEstimation_CheckedChanged);
            // 
            // label_DistanceEstimationMax
            // 
            this.label_DistanceEstimationMax.AutoSize = true;
            this.label_DistanceEstimationMax.Location = new System.Drawing.Point(3, 349);
            this.label_DistanceEstimationMax.Name = "label_DistanceEstimationMax";
            this.label_DistanceEstimationMax.Size = new System.Drawing.Size(86, 15);
            this.label_DistanceEstimationMax.TabIndex = 66;
            this.label_DistanceEstimationMax.Text = "Max Distance:*";
            this.label_DistanceEstimationMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_MaxDistanceEstimation
            // 
            this.input_MaxDistanceEstimation.Location = new System.Drawing.Point(115, 346);
            this.input_MaxDistanceEstimation.Name = "input_MaxDistanceEstimation";
            this.input_MaxDistanceEstimation.Size = new System.Drawing.Size(40, 23);
            this.input_MaxDistanceEstimation.TabIndex = 65;
            this.input_MaxDistanceEstimation.Text = "100";
            this.input_MaxDistanceEstimation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_MaxDistanceEstimation.Validating += new System.ComponentModel.CancelEventHandler(this.input_MaxDistanceEstimation_Validating);
            this.input_MaxDistanceEstimation.Validated += new System.EventHandler(this.input_MaxDistanceEstimation_Validated);
            // 
            // label_DistanceEstimationFactors
            // 
            this.label_DistanceEstimationFactors.AutoSize = true;
            this.label_DistanceEstimationFactors.Location = new System.Drawing.Point(3, 376);
            this.label_DistanceEstimationFactors.Name = "label_DistanceEstimationFactors";
            this.label_DistanceEstimationFactors.Size = new System.Drawing.Size(53, 15);
            this.label_DistanceEstimationFactors.TabIndex = 68;
            this.label_DistanceEstimationFactors.Text = "Factors:*";
            this.label_DistanceEstimationFactors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_DistanceEstimationFactor1
            // 
            this.input_DistanceEstimationFactor1.Location = new System.Drawing.Point(68, 373);
            this.input_DistanceEstimationFactor1.Name = "input_DistanceEstimationFactor1";
            this.input_DistanceEstimationFactor1.Size = new System.Drawing.Size(40, 23);
            this.input_DistanceEstimationFactor1.TabIndex = 67;
            this.input_DistanceEstimationFactor1.Text = "10";
            this.input_DistanceEstimationFactor1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_DistanceEstimationFactor1.Validating += new System.ComponentModel.CancelEventHandler(this.input_DistanceEstimationFactor1_Validating);
            this.input_DistanceEstimationFactor1.Validated += new System.EventHandler(this.input_DistanceEstimationFactor1_Validated);
            // 
            // input_DistanceEstimationFactor2
            // 
            this.input_DistanceEstimationFactor2.Location = new System.Drawing.Point(115, 373);
            this.input_DistanceEstimationFactor2.Name = "input_DistanceEstimationFactor2";
            this.input_DistanceEstimationFactor2.Size = new System.Drawing.Size(40, 23);
            this.input_DistanceEstimationFactor2.TabIndex = 103;
            this.input_DistanceEstimationFactor2.Text = "6";
            this.input_DistanceEstimationFactor2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_DistanceEstimationFactor2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_DistanceEstimationFactor2.Validating += new System.ComponentModel.CancelEventHandler(this.input_DistanceEstimationFactor2_Validating);
            this.input_DistanceEstimationFactor2.Validated += new System.EventHandler(this.input_DistanceEstimationFactor2_Validated);
            // 
            // checkBox_UseNormals
            // 
            this.checkBox_UseNormals.AutoSize = true;
            this.checkBox_UseNormals.Location = new System.Drawing.Point(8, 398);
            this.checkBox_UseNormals.Name = "checkBox_UseNormals";
            this.checkBox_UseNormals.Size = new System.Drawing.Size(93, 19);
            this.checkBox_UseNormals.TabIndex = 104;
            this.checkBox_UseNormals.Text = "Use Normals";
            this.checkBox_UseNormals.UseVisualStyleBackColor = true;
            this.checkBox_UseNormals.CheckedChanged += new System.EventHandler(this.checkBox_UseNormals_CheckedChanged);
            // 
            // button_ClearTexture
            // 
            this.button_ClearTexture.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_ClearTexture.Location = new System.Drawing.Point(33, 423);
            this.button_ClearTexture.Name = "button_ClearTexture";
            this.button_ClearTexture.Size = new System.Drawing.Size(96, 25);
            this.button_ClearTexture.TabIndex = 69;
            this.button_ClearTexture.Text = "Clear Texture";
            this.button_ClearTexture.UseVisualStyleBackColor = true;
            this.button_ClearTexture.Click += new System.EventHandler(this.button_ClearTexture_Click);
            // 
            // input_TextureBlend
            // 
            this.input_TextureBlend.CausesValidation = false;
            this.input_TextureBlend.DecimalPlaces = 2;
            this.input_TextureBlend.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.input_TextureBlend.Location = new System.Drawing.Point(99, 477);
            this.input_TextureBlend.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_TextureBlend.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.input_TextureBlend.Name = "input_TextureBlend";
            this.input_TextureBlend.Size = new System.Drawing.Size(56, 23);
            this.input_TextureBlend.TabIndex = 71;
            this.input_TextureBlend.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.input_TextureBlend.ValueChanged += new System.EventHandler(this.input_TextureBlend_ValueChanged);
            this.input_TextureBlend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            // 
            // input_TextureDistortionFactor
            // 
            this.input_TextureDistortionFactor.Location = new System.Drawing.Point(115, 569);
            this.input_TextureDistortionFactor.Name = "input_TextureDistortionFactor";
            this.input_TextureDistortionFactor.Size = new System.Drawing.Size(40, 23);
            this.input_TextureDistortionFactor.TabIndex = 97;
            this.input_TextureDistortionFactor.Text = "5";
            this.input_TextureDistortionFactor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_TextureDistortionFactor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_TextureDistortionFactor.Validating += new System.ComponentModel.CancelEventHandler(this.input_TextureDistortionFactor_Validating);
            this.input_TextureDistortionFactor.Validated += new System.EventHandler(this.input_TextureDistortionFactor_Validated);
            // 
            // label_TextureScale
            // 
            this.label_TextureScale.AutoSize = true;
            this.label_TextureScale.Location = new System.Drawing.Point(3, 506);
            this.label_TextureScale.Name = "label_TextureScale";
            this.label_TextureScale.Size = new System.Drawing.Size(42, 15);
            this.label_TextureScale.TabIndex = 92;
            this.label_TextureScale.Text = "Scale:*";
            this.label_TextureScale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_TextureScaleX
            // 
            this.input_TextureScaleX.Location = new System.Drawing.Point(69, 503);
            this.input_TextureScaleX.Name = "input_TextureScaleX";
            this.input_TextureScaleX.Size = new System.Drawing.Size(40, 23);
            this.input_TextureScaleX.TabIndex = 91;
            this.input_TextureScaleX.Text = "1";
            this.input_TextureScaleX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_TextureScaleX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_TextureScaleX.Validating += new System.ComponentModel.CancelEventHandler(this.input_TextureScaleX_Validating);
            this.input_TextureScaleX.Validated += new System.EventHandler(this.input_TextureScaleX_Validated);
            // 
            // input_TextureScaleY
            // 
            this.input_TextureScaleY.Location = new System.Drawing.Point(115, 503);
            this.input_TextureScaleY.Name = "input_TextureScaleY";
            this.input_TextureScaleY.Size = new System.Drawing.Size(40, 23);
            this.input_TextureScaleY.TabIndex = 93;
            this.input_TextureScaleY.Text = "1";
            this.input_TextureScaleY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_TextureScaleY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_TextureScaleY.Validating += new System.ComponentModel.CancelEventHandler(this.input_TextureScaleY_Validating);
            this.input_TextureScaleY.Validated += new System.EventHandler(this.input_TextureScaleY_Validated);
            // 
            // checkBox_UsePolarTextureCoordinates
            // 
            this.checkBox_UsePolarTextureCoordinates.AutoSize = true;
            this.checkBox_UsePolarTextureCoordinates.Location = new System.Drawing.Point(8, 530);
            this.checkBox_UsePolarTextureCoordinates.Name = "checkBox_UsePolarTextureCoordinates";
            this.checkBox_UsePolarTextureCoordinates.Size = new System.Drawing.Size(120, 19);
            this.checkBox_UsePolarTextureCoordinates.TabIndex = 101;
            this.checkBox_UsePolarTextureCoordinates.Text = "Polar Coordinates";
            this.checkBox_UsePolarTextureCoordinates.UseVisualStyleBackColor = true;
            this.checkBox_UsePolarTextureCoordinates.CheckedChanged += new System.EventHandler(this.checkBox_UsePolarTextureCoordinates_CheckedChanged);
            // 
            // checkBox_UseDistortedTexture
            // 
            this.checkBox_UseDistortedTexture.AutoSize = true;
            this.checkBox_UseDistortedTexture.Location = new System.Drawing.Point(8, 550);
            this.checkBox_UseDistortedTexture.Name = "checkBox_UseDistortedTexture";
            this.checkBox_UseDistortedTexture.Size = new System.Drawing.Size(115, 19);
            this.checkBox_UseDistortedTexture.TabIndex = 96;
            this.checkBox_UseDistortedTexture.Text = "Distorted Texture";
            this.checkBox_UseDistortedTexture.UseVisualStyleBackColor = true;
            this.checkBox_UseDistortedTexture.CheckedChanged += new System.EventHandler(this.checkBox_UseDistortedTexture_CheckedChanged);
            // 
            // label_TextureDistortionFactor
            // 
            this.label_TextureDistortionFactor.AutoSize = true;
            this.label_TextureDistortionFactor.Location = new System.Drawing.Point(3, 572);
            this.label_TextureDistortionFactor.Name = "label_TextureDistortionFactor";
            this.label_TextureDistortionFactor.Size = new System.Drawing.Size(103, 15);
            this.label_TextureDistortionFactor.TabIndex = 98;
            this.label_TextureDistortionFactor.Text = "Distortion Factor:*";
            this.label_TextureDistortionFactor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            this.colorDialog1.ShowHelp = true;
            // 
            // input_LockedZoom
            // 
            this.input_LockedZoom.Location = new System.Drawing.Point(288, 5);
            this.input_LockedZoom.Name = "input_LockedZoom";
            this.input_LockedZoom.Size = new System.Drawing.Size(45, 23);
            this.input_LockedZoom.TabIndex = 60;
            this.input_LockedZoom.Text = "0";
            this.input_LockedZoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_LockedZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_LockedZoom.Validating += new System.ComponentModel.CancelEventHandler(this.input_LockedZoom_Validating);
            this.input_LockedZoom.Validated += new System.EventHandler(this.input_LockedZoom_Validated);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            // 
            // label_CameraOrientation
            // 
            this.label_CameraOrientation.AutoSize = true;
            this.label_CameraOrientation.Location = new System.Drawing.Point(2, 35);
            this.label_CameraOrientation.Name = "label_CameraOrientation";
            this.label_CameraOrientation.Size = new System.Drawing.Size(70, 15);
            this.label_CameraOrientation.TabIndex = 62;
            this.label_CameraOrientation.Text = "Orientation:";
            this.label_CameraOrientation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_RiemannAngles
            // 
            this.input_RiemannAngles.Location = new System.Drawing.Point(358, 32);
            this.input_RiemannAngles.Name = "input_RiemannAngles";
            this.input_RiemannAngles.Size = new System.Drawing.Size(107, 23);
            this.input_RiemannAngles.TabIndex = 66;
            this.input_RiemannAngles.Text = "0, 0";
            this.input_RiemannAngles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_RiemannAngles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateMultipleDecimalChar);
            this.input_RiemannAngles.Validating += new System.ComponentModel.CancelEventHandler(this.input_RiemannAngles_Validating);
            this.input_RiemannAngles.Validated += new System.EventHandler(this.input_RiemannAngles_Validated);
            // 
            // label_RiemannAngles
            // 
            this.label_RiemannAngles.AutoSize = true;
            this.label_RiemannAngles.Location = new System.Drawing.Point(302, 35);
            this.label_RiemannAngles.Name = "label_RiemannAngles";
            this.label_RiemannAngles.Size = new System.Drawing.Size(57, 15);
            this.label_RiemannAngles.TabIndex = 67;
            this.label_RiemannAngles.Text = "Riemann:";
            this.label_RiemannAngles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // input_CameraAngles
            // 
            this.input_CameraAngles.Location = new System.Drawing.Point(168, 32);
            this.input_CameraAngles.Name = "input_CameraAngles";
            this.input_CameraAngles.Size = new System.Drawing.Size(69, 23);
            this.input_CameraAngles.TabIndex = 65;
            this.input_CameraAngles.Text = "-90, 0";
            this.input_CameraAngles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_CameraAngles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateMultipleDecimalChar);
            this.input_CameraAngles.Validating += new System.ComponentModel.CancelEventHandler(this.input_CameraAngles_Validating);
            this.input_CameraAngles.Validated += new System.EventHandler(this.input_CameraAngles_Validated);
            // 
            // input_CameraPosition
            // 
            this.input_CameraPosition.Location = new System.Drawing.Point(73, 32);
            this.input_CameraPosition.Name = "input_CameraPosition";
            this.input_CameraPosition.Size = new System.Drawing.Size(91, 23);
            this.input_CameraPosition.TabIndex = 68;
            this.input_CameraPosition.Text = "0, 0, 3";
            this.input_CameraPosition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_CameraPosition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateMultipleDecimalChar);
            this.input_CameraPosition.Validating += new System.ComponentModel.CancelEventHandler(this.input_CameraPosition_Validating);
            this.input_CameraPosition.Validated += new System.EventHandler(this.input_CameraPosition_Validated);
            // 
            // input_CameraRoll
            // 
            this.input_CameraRoll.Location = new System.Drawing.Point(240, 32);
            this.input_CameraRoll.Name = "input_CameraRoll";
            this.input_CameraRoll.Size = new System.Drawing.Size(45, 23);
            this.input_CameraRoll.TabIndex = 69;
            this.input_CameraRoll.Text = "0";
            this.input_CameraRoll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.control_FocusOnEnter);
            this.input_CameraRoll.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.control_ValidateDecimalChar);
            this.input_CameraRoll.Validating += new System.ComponentModel.CancelEventHandler(this.input_CameraRoll_Validating);
            this.input_CameraRoll.Validated += new System.EventHandler(this.input_CameraRoll_Validated);
            // 
            // panel_GeneralMenu
            // 
            this.panel_GeneralMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_GeneralMenu.AutoScroll = true;
            this.panel_GeneralMenu.Controls.Add(this.input_Zoom);
            this.panel_GeneralMenu.Controls.Add(this.input_CameraRoll);
            this.panel_GeneralMenu.Controls.Add(this.label_FractalCenter);
            this.panel_GeneralMenu.Controls.Add(this.input_CameraPosition);
            this.panel_GeneralMenu.Controls.Add(this.label_FractalZoom);
            this.panel_GeneralMenu.Controls.Add(this.input_RiemannAngles);
            this.panel_GeneralMenu.Controls.Add(this.label_RiemannAngles);
            this.panel_GeneralMenu.Controls.Add(this.input_LockedZoom);
            this.panel_GeneralMenu.Controls.Add(this.input_CameraAngles);
            this.panel_GeneralMenu.Controls.Add(this.checkBox_LockZoomFactor);
            this.panel_GeneralMenu.Controls.Add(this.label_CameraOrientation);
            this.panel_GeneralMenu.Controls.Add(this.input_Center);
            this.panel_GeneralMenu.Location = new System.Drawing.Point(12, 344);
            this.panel_GeneralMenu.Name = "panel_GeneralMenu";
            this.panel_GeneralMenu.Size = new System.Drawing.Size(500, 71);
            this.panel_GeneralMenu.TabIndex = 70;
            // 
            // panel_MenuSelect
            // 
            this.panel_MenuSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_MenuSelect.Controls.Add(this.button_Menu1);
            this.panel_MenuSelect.Controls.Add(this.button_Menu2);
            this.panel_MenuSelect.Controls.Add(this.button_Menu3);
            this.panel_MenuSelect.Controls.Add(this.button_Right);
            this.panel_MenuSelect.Controls.Add(this.button_Left);
            this.panel_MenuSelect.Controls.Add(this.button_Menu4);
            this.panel_MenuSelect.Location = new System.Drawing.Point(517, 344);
            this.panel_MenuSelect.Name = "panel_MenuSelect";
            this.panel_MenuSelect.Size = new System.Drawing.Size(161, 71);
            this.panel_MenuSelect.TabIndex = 71;
            // 
            // MainDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 414);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.panel_GeneralMenu);
            this.Controls.Add(this.panel_ColorMenu);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel_FormulaMenu);
            this.Controls.Add(this.panel_OrbitTrapMenu);
            this.Controls.Add(this.panel_MenuSelect);
            this.MinimumSize = new System.Drawing.Size(712, 453);
            this.Name = "MainDlg";
            this.Text = "FractalLive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDlg_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_MaxIterations)).EndInit();
            this.panel_FormulaMenu.ResumeLayout(false);
            this.panel_FormulaMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_CurrentMatingStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_MinIterations)).EndInit();
            this.panel_OrbitTrapMenu.ResumeLayout(false);
            this.panel_OrbitTrapMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_EditingBailoutTrap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_StartOrbit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_OrbitRange)).EndInit();
            this.panel_ColorMenu.ResumeLayout(false);
            this.panel_ColorMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_TextureBlend)).EndInit();
            this.panel_GeneralMenu.ResumeLayout(false);
            this.panel_GeneralMenu.PerformLayout();
            this.panel_MenuSelect.ResumeLayout(false);
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
        private System.Windows.Forms.Label label_OrbitTrapPosition;
        private System.Windows.Forms.Panel panel_OrbitTrapMenu;
        private System.Windows.Forms.Label label_OrbitTrapMenu;
        private System.Windows.Forms.Label label_Texture;
        private System.Windows.Forms.TextBox input_Texture;
        private System.Windows.Forms.CheckBox checkBox_LockZoomFactor;
        private System.Windows.Forms.Button button_RemoveBailoutTrap;
        private System.Windows.Forms.Button button_AddBailoutTrap;
        private System.Windows.Forms.TextBox input_ColorCycles;
        private System.Windows.Forms.Label label_ColorFactors;
        private System.Windows.Forms.TextBox input_ColorFactor;
        private System.Windows.Forms.NumericUpDown input_StartOrbit;
        private System.Windows.Forms.NumericUpDown input_EditingBailoutTrap;
        private System.Windows.Forms.NumericUpDown input_OrbitRange;
        private System.Windows.Forms.Label label_EditingOrbitBailout;
        private System.Windows.Forms.Label label_OrbitTrapFactors;
        private System.Windows.Forms.TextBox input_OrbitTrapBlendingFactor;
        private System.Windows.Forms.TextBox input_OrbitTrapThicknessFactor;
        private System.Windows.Forms.TextBox input_Center;
        private System.Windows.Forms.Label label_FractalCenter;
        private System.Windows.Forms.Label label_FractalZoom;
        private System.Windows.Forms.TextBox input_Zoom;
        private System.Windows.Forms.Panel panel_ColorMenu;
        private System.Windows.Forms.Label label_ColorMenu;
        private System.Windows.Forms.Label label_Coloring;
        private System.Windows.Forms.ComboBox input_Coloring;
        private System.Windows.Forms.ComboBox input_EditingColor;
        private System.Windows.Forms.Label label_EditingColor;
        private System.Windows.Forms.TextBox input_MaxDistanceEstimation;
        private System.Windows.Forms.TextBox input_DistanceEstimationFactor1;
        private System.Windows.Forms.Label label_DistanceEstimationMax;
        private System.Windows.Forms.Label label_DistanceEstimationFactors;
        private System.Windows.Forms.CheckBox checkBox_UseDistanceEstimation;
        private System.Windows.Forms.Button button_ClearTexture;
        private System.Windows.Forms.NumericUpDown input_TextureBlend;
        private System.Windows.Forms.CheckBox checkBox_UseCustomPalette;
        private System.Windows.Forms.Label label_OrbitTrapFactor;
        private System.Windows.Forms.TextBox input_OrbitTrapFactor;
        private System.Windows.Forms.Button button_Color1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button_Color6;
        private System.Windows.Forms.Button button_Color5;
        private System.Windows.Forms.Button button_Color4;
        private System.Windows.Forms.Button button_Color3;
        private System.Windows.Forms.Button button_Color2;
        private System.Windows.Forms.Label label_OrbitTrapCalculation;
        private System.Windows.Forms.ComboBox input_OrbitTrapCalculation;
        private System.Windows.Forms.TextBox input_StartDistance;
        private System.Windows.Forms.Label label_DomainCalculation;
        private System.Windows.Forms.ComboBox input_DomainCalculation;
        private System.Windows.Forms.Label label_BuddhabrotType;
        private System.Windows.Forms.ComboBox input_BuddhabrotType;
        private System.Windows.Forms.CheckBox checkBox_UseBuddhabrot;
        private System.Windows.Forms.TextBox input_LockedZoom;
        private System.Windows.Forms.NumericUpDown input_MinIterations;
        private System.Windows.Forms.CheckBox checkBox_UseConjugate;
        private System.Windows.Forms.CheckBox checkBox_UseDomainIteration;
        private System.Windows.Forms.CheckBox checkBox_UseSecondValue;
        private System.Windows.Forms.CheckBox checkBox_MatchOrbitTrap;
        private System.Windows.Forms.CheckBox checkBox_UseSecondDomainValue;
        private System.Windows.Forms.Label label_SecondValueFactors;
        private System.Windows.Forms.TextBox input_SecondValueFactor1;
        private System.Windows.Forms.TextBox input_SecondValueFactor2;
        private System.Windows.Forms.TextBox input_SecondDomainValueFactor2;
        private System.Windows.Forms.Label label_SecondDomainValueFactors;
        private System.Windows.Forms.TextBox input_SecondDomainValueFactor1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox input_TextureScaleY;
        private System.Windows.Forms.Label label_TextureScale;
        private System.Windows.Forms.TextBox input_TextureScaleX;
        private System.Windows.Forms.Label label_FoldOffset;
        private System.Windows.Forms.TextBox input_FoldOffsetY;
        private System.Windows.Forms.TextBox input_FoldOffsetX;
        private System.Windows.Forms.TextBox input_FoldAngle;
        private System.Windows.Forms.Label label_FoldAngle;
        private System.Windows.Forms.TextBox input_FoldCount;
        private System.Windows.Forms.Label label_CameraOrientation;
        private System.Windows.Forms.TextBox input_RiemannAngles;
        private System.Windows.Forms.Label label_RiemannAngles;
        private System.Windows.Forms.TextBox input_CameraAngles;
        private System.Windows.Forms.TextBox input_CameraPosition;
        private System.Windows.Forms.Label label_StripeDensity;
        private System.Windows.Forms.TextBox input_StripeDensity;
        private System.Windows.Forms.TextBox input_TextureDistortionFactor;
        private System.Windows.Forms.Label label_TextureDistortionFactor;
        private System.Windows.Forms.CheckBox checkBox_UseDistortedTexture;
        private System.Windows.Forms.Label label_JuliaPosition;
        private System.Windows.Forms.TextBox input_JuliaX;
        private System.Windows.Forms.TextBox input_JuliaY;
        private System.Windows.Forms.TextBox input_CameraRoll;
        private System.Windows.Forms.CheckBox checkBox_UsePolarTextureCoordinates;
        private System.Windows.Forms.TextBox input_DistanceEstimationFactor2;
        private System.Windows.Forms.CheckBox checkBox_UseNormals;
        private System.Windows.Forms.Panel panel_GeneralMenu;
        private System.Windows.Forms.TextBox input_StartPositionY;
        private System.Windows.Forms.TextBox input_StartPositionX;
        private System.Windows.Forms.Label label_StartPosition;
        private System.Windows.Forms.Panel panel_MenuSelect;
        private System.Windows.Forms.NumericUpDown input_CurrentMatingStep;
        private System.Windows.Forms.TextBox input_MatingSteps;
        private System.Windows.Forms.Label label_MatingSteps;
        private System.Windows.Forms.Label label_CurrentMatingStep;
    }
}

