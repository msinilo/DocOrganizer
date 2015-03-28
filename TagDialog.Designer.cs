namespace DocOrganizer
{
    partial class TagDialog
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
            this.textTag = new System.Windows.Forms.TextBox();
            this.butOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textTag
            // 
            this.textTag.Location = new System.Drawing.Point(41, 13);
            this.textTag.Name = "textTag";
            this.textTag.Size = new System.Drawing.Size(87, 20);
            this.textTag.TabIndex = 0;
            // 
            // butOK
            // 
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Location = new System.Drawing.Point(145, 13);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(39, 22);
            this.butOK.TabIndex = 1;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            // 
            // TagDialog
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 45);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.textTag);
            this.Name = "TagDialog";
            this.Text = "TagDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textTag;
        private System.Windows.Forms.Button butOK;
    }
}