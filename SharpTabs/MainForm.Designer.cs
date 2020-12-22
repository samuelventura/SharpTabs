namespace SharpTabs
{
    partial class MainForm
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
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cloneToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.setupToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.renameToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.shiftLeftToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.shiftRightToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.exportSelectedToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.importToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tryoutToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.cloneToolStripButton,
            this.setupToolStripButton,
            this.renameToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator3,
            this.shiftLeftToolStripButton,
            this.shiftRightToolStripButton,
            this.toolStripSeparator1,
            this.exportAllToolStripButton,
            this.exportSelectedToolStripButton,
            this.importToolStripButton,
            this.toolStripSeparator2,
            this.removeToolStripButton,
            this.tryoutToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(784, 25);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(35, 22);
            this.newToolStripButton.Text = "New";
            this.newToolStripButton.ToolTipText = "Create New Empty Session";
            this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripButton_Click);
            // 
            // cloneToolStripButton
            // 
            this.cloneToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cloneToolStripButton.Name = "cloneToolStripButton";
            this.cloneToolStripButton.Size = new System.Drawing.Size(42, 22);
            this.cloneToolStripButton.Text = "Clone";
            this.cloneToolStripButton.ToolTipText = "Clone Selected Session";
            this.cloneToolStripButton.Click += new System.EventHandler(this.CloneToolStripButton_Click);
            // 
            // setupToolStripButton
            // 
            this.setupToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.setupToolStripButton.Name = "setupToolStripButton";
            this.setupToolStripButton.Size = new System.Drawing.Size(41, 22);
            this.setupToolStripButton.Text = "Setup";
            this.setupToolStripButton.ToolTipText = "Setup Selected Session";
            this.setupToolStripButton.Click += new System.EventHandler(this.SetupToolStripButton_Click);
            // 
            // renameToolStripButton
            // 
            this.renameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.renameToolStripButton.Name = "renameToolStripButton";
            this.renameToolStripButton.Size = new System.Drawing.Size(54, 22);
            this.renameToolStripButton.Text = "Rename";
            this.renameToolStripButton.ToolTipText = "Rename Selected Session";
            this.renameToolStripButton.Click += new System.EventHandler(this.RenameToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(35, 22);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.ToolTipText = "Save All Sessions";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // shiftLeftToolStripButton
            // 
            this.shiftLeftToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.shiftLeftToolStripButton.Name = "shiftLeftToolStripButton";
            this.shiftLeftToolStripButton.Size = new System.Drawing.Size(42, 22);
            this.shiftLeftToolStripButton.Text = "< Left";
            this.shiftLeftToolStripButton.ToolTipText = "Shift Left";
            this.shiftLeftToolStripButton.Click += new System.EventHandler(this.ShiftLeftToolStripButton_Click);
            // 
            // shiftRightToolStripButton
            // 
            this.shiftRightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.shiftRightToolStripButton.Name = "shiftRightToolStripButton";
            this.shiftRightToolStripButton.Size = new System.Drawing.Size(50, 22);
            this.shiftRightToolStripButton.Text = "Right >";
            this.shiftRightToolStripButton.ToolTipText = "Shift Right";
            this.shiftRightToolStripButton.Click += new System.EventHandler(this.ShiftRightToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // exportAllToolStripButton
            // 
            this.exportAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exportAllToolStripButton.Name = "exportAllToolStripButton";
            this.exportAllToolStripButton.Size = new System.Drawing.Size(62, 22);
            this.exportAllToolStripButton.Text = "Export All";
            this.exportAllToolStripButton.ToolTipText = "Export All Sessions to File";
            this.exportAllToolStripButton.Click += new System.EventHandler(this.ExportAllToolStripButton_Click);
            // 
            // exportSelectedToolStripButton
            // 
            this.exportSelectedToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exportSelectedToolStripButton.Name = "exportSelectedToolStripButton";
            this.exportSelectedToolStripButton.Size = new System.Drawing.Size(92, 22);
            this.exportSelectedToolStripButton.Text = "Export Selected";
            this.exportSelectedToolStripButton.ToolTipText = "Export Selected Session to File";
            this.exportSelectedToolStripButton.Click += new System.EventHandler(this.ExportSelectedToolStripButton_Click);
            // 
            // importToolStripButton
            // 
            this.importToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.importToolStripButton.Name = "importToolStripButton";
            this.importToolStripButton.Size = new System.Drawing.Size(47, 22);
            this.importToolStripButton.Text = "Import";
            this.importToolStripButton.ToolTipText = "Import Sessions from File";
            this.importToolStripButton.Click += new System.EventHandler(this.ImportToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // removeToolStripButton
            // 
            this.removeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.removeToolStripButton.Name = "removeToolStripButton";
            this.removeToolStripButton.Size = new System.Drawing.Size(54, 22);
            this.removeToolStripButton.Text = "Remove";
            this.removeToolStripButton.ToolTipText = "Remove Selected Session";
            this.removeToolStripButton.Click += new System.EventHandler(this.RemoveToolStripButton_Click);
            // 
            // tryoutToolStripButton
            // 
            this.tryoutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tryoutToolStripButton.Name = "tryoutToolStripButton";
            this.tryoutToolStripButton.Size = new System.Drawing.Size(44, 22);
            this.tryoutToolStripButton.Text = "Tryout";
            this.tryoutToolStripButton.ToolTipText = "Tryout Action";
            this.tryoutToolStripButton.Click += new System.EventHandler(this.TryoutToolStripButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 539);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusTrip1";
            this.statusStrip.ShowItemToolTips = true;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            this.toolStripStatusLabel.ToolTipText = "Click to copy path to clipboard";
            this.toolStripStatusLabel.Click += new System.EventHandler(this.ToolStripStatusLabel_Click);
            // 
            // tabControl
            // 
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 514);
            this.tabControl.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton cloneToolStripButton;
        private System.Windows.Forms.ToolStripButton renameToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton shiftLeftToolStripButton;
        private System.Windows.Forms.ToolStripButton shiftRightToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton exportAllToolStripButton;
        private System.Windows.Forms.ToolStripButton exportSelectedToolStripButton;
        private System.Windows.Forms.ToolStripButton importToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.ToolStripButton setupToolStripButton;
        private System.Windows.Forms.ToolStripButton tryoutToolStripButton;
    }
}