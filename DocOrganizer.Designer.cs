namespace DocOrganizer
{
    partial class DocOrganizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocOrganizer));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rescanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagSubtreeWithDirNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagSubtreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excludeSubtreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iconsList = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.bExpandAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textFilter = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeMain = new System.Windows.Forms.TreeView();
            this.gbFileDetails = new System.Windows.Forms.GroupBox();
            this.lTags = new System.Windows.Forms.Label();
            this.lLastModified = new System.Windows.Forms.Label();
            this.lSize = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbFileDetails.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rescanToolStripMenuItem,
            this.tagSubtreeWithDirNameToolStripMenuItem,
            this.tagSubtreeToolStripMenuItem,
            this.excludeSubtreeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(197, 92);
            // 
            // rescanToolStripMenuItem
            // 
            this.rescanToolStripMenuItem.Name = "rescanToolStripMenuItem";
            this.rescanToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.rescanToolStripMenuItem.Text = "Rescan subtree";
            this.rescanToolStripMenuItem.Click += new System.EventHandler(this.rescanToolStripMenuItem_Click);
            // 
            // tagSubtreeWithDirNameToolStripMenuItem
            // 
            this.tagSubtreeWithDirNameToolStripMenuItem.Name = "tagSubtreeWithDirNameToolStripMenuItem";
            this.tagSubtreeWithDirNameToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.tagSubtreeWithDirNameToolStripMenuItem.Text = "Tag subtree with dir name";
            this.tagSubtreeWithDirNameToolStripMenuItem.Click += new System.EventHandler(this.tagSubtreeWithDirNameToolStripMenuItem_Click);
            // 
            // tagSubtreeToolStripMenuItem
            // 
            this.tagSubtreeToolStripMenuItem.Name = "tagSubtreeToolStripMenuItem";
            this.tagSubtreeToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.tagSubtreeToolStripMenuItem.Text = "Tag subtree...";
            this.tagSubtreeToolStripMenuItem.Click += new System.EventHandler(this.tagSubtreeToolStripMenuItem_Click);
            // 
            // excludeSubtreeToolStripMenuItem
            // 
            this.excludeSubtreeToolStripMenuItem.Name = "excludeSubtreeToolStripMenuItem";
            this.excludeSubtreeToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.excludeSubtreeToolStripMenuItem.Text = "Exclude subtree";
            this.excludeSubtreeToolStripMenuItem.Click += new System.EventHandler(this.excludeSubtreeToolStripMenuItem_Click);
            // 
            // iconsList
            // 
            this.iconsList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconsList.ImageStream")));
            this.iconsList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconsList.Images.SetKeyName(0, "foldericon.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bExpandAll);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.textFilter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(967, 416);
            this.splitContainer1.SplitterDistance = 73;
            this.splitContainer1.TabIndex = 2;
            // 
            // bExpandAll
            // 
            this.bExpandAll.Location = new System.Drawing.Point(243, 39);
            this.bExpandAll.Name = "bExpandAll";
            this.bExpandAll.Size = new System.Drawing.Size(70, 20);
            this.bExpandAll.TabIndex = 2;
            this.bExpandAll.Text = "Expand All";
            this.bExpandAll.UseVisualStyleBackColor = true;
            this.bExpandAll.Click += new System.EventHandler(this.bExpandAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter";
            // 
            // textFilter
            // 
            this.textFilter.Location = new System.Drawing.Point(46, 39);
            this.textFilter.Name = "textFilter";
            this.textFilter.Size = new System.Drawing.Size(179, 20);
            this.textFilter.TabIndex = 0;
            this.textFilter.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeMain);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbFileDetails);
            this.splitContainer2.Size = new System.Drawing.Size(967, 339);
            this.splitContainer2.SplitterDistance = 563;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeMain
            // 
            this.treeMain.ContextMenuStrip = this.contextMenuStrip1;
            this.treeMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeMain.ImageIndex = 0;
            this.treeMain.ImageList = this.iconsList;
            this.treeMain.Location = new System.Drawing.Point(0, 0);
            this.treeMain.Name = "treeMain";
            this.treeMain.SelectedImageIndex = 0;
            this.treeMain.Size = new System.Drawing.Size(563, 339);
            this.treeMain.TabIndex = 2;
            this.treeMain.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeMain_NodeMouseDoubleClick);
            this.treeMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeMain_AfterSelect_1);
            this.treeMain.Leave += new System.EventHandler(this.treeMain_Leave);
            // 
            // gbFileDetails
            // 
            this.gbFileDetails.Controls.Add(this.lTags);
            this.gbFileDetails.Controls.Add(this.lLastModified);
            this.gbFileDetails.Controls.Add(this.lSize);
            this.gbFileDetails.Controls.Add(this.lName);
            this.gbFileDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFileDetails.Location = new System.Drawing.Point(0, 0);
            this.gbFileDetails.Name = "gbFileDetails";
            this.gbFileDetails.Size = new System.Drawing.Size(400, 339);
            this.gbFileDetails.TabIndex = 0;
            this.gbFileDetails.TabStop = false;
            this.gbFileDetails.Text = "File details";
            // 
            // lTags
            // 
            this.lTags.AutoEllipsis = true;
            this.lTags.AutoSize = true;
            this.lTags.Location = new System.Drawing.Point(6, 91);
            this.lTags.Name = "lTags";
            this.lTags.Size = new System.Drawing.Size(37, 13);
            this.lTags.TabIndex = 3;
            this.lTags.Text = "Tags: ";
            // 
            // lLastModified
            // 
            this.lLastModified.AutoSize = true;
            this.lLastModified.Location = new System.Drawing.Point(6, 69);
            this.lLastModified.Name = "lLastModified";
            this.lLastModified.Size = new System.Drawing.Size(73, 13);
            this.lLastModified.TabIndex = 2;
            this.lLastModified.Text = "Last Modified:";
            // 
            // lSize
            // 
            this.lSize.AutoSize = true;
            this.lSize.Location = new System.Drawing.Point(6, 47);
            this.lSize.Name = "lSize";
            this.lSize.Size = new System.Drawing.Size(33, 13);
            this.lSize.TabIndex = 1;
            this.lSize.Text = "Size: ";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Location = new System.Drawing.Point(6, 25);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(38, 13);
            this.lName.TabIndex = 0;
            this.lName.Text = "Name:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configrationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(967, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // configrationToolStripMenuItem
            // 
            this.configrationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.configrationToolStripMenuItem.Name = "configrationToolStripMenuItem";
            this.configrationToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.configrationToolStripMenuItem.Text = "Configuration";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.optionsToolStripMenuItem.Text = "Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DocOrganizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 416);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DocOrganizer";
            this.Text = "DocOrganizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocOrganizer_FormClosing);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.gbFileDetails.ResumeLayout(false);
            this.gbFileDetails.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem rescanToolStripMenuItem;
        private System.Windows.Forms.ImageList iconsList;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeMain;
        private System.Windows.Forms.GroupBox gbFileDetails;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lLastModified;
        private System.Windows.Forms.Label lSize;
        private System.Windows.Forms.Label lTags;
        private System.Windows.Forms.ToolStripMenuItem tagSubtreeWithDirNameToolStripMenuItem;
        private System.Windows.Forms.TextBox textFilter;
        private System.Windows.Forms.ToolStripMenuItem tagSubtreeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem excludeSubtreeToolStripMenuItem;
        private System.Windows.Forms.Button bExpandAll;
        private System.Windows.Forms.Timer timer1;
    }
}

