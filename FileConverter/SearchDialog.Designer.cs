namespace FileConverter
{
    partial class SearchDialog
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearchNormal = new System.Windows.Forms.Button();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.btnSearchPrevious = new System.Windows.Forms.Button();
            this.btnSearchNext = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(29, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(297, 22);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearchNormal
            // 
            this.btnSearchNormal.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchNormal.Location = new System.Drawing.Point(332, 15);
            this.btnSearchNormal.Name = "btnSearchNormal";
            this.btnSearchNormal.Size = new System.Drawing.Size(99, 23);
            this.btnSearchNormal.TabIndex = 1;
            this.btnSearchNormal.Text = "Search";
            this.btnSearchNormal.UseVisualStyleBackColor = true;
            this.btnSearchNormal.Click += new System.EventHandler(this.btnSearchNormal_Click);
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMatchCase.Location = new System.Drawing.Point(29, 62);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(84, 19);
            this.chkMatchCase.TabIndex = 2;
            this.chkMatchCase.Text = "Match case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            this.chkMatchCase.CheckedChanged += new System.EventHandler(this.chkMatchCase_CheckedChanged);
            // 
            // btnSearchPrevious
            // 
            this.btnSearchPrevious.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchPrevious.Location = new System.Drawing.Point(122, 58);
            this.btnSearchPrevious.Name = "btnSearchPrevious";
            this.btnSearchPrevious.Size = new System.Drawing.Size(95, 23);
            this.btnSearchPrevious.TabIndex = 3;
            this.btnSearchPrevious.Text = "Find previous";
            this.btnSearchPrevious.UseVisualStyleBackColor = true;
            this.btnSearchPrevious.Click += new System.EventHandler(this.btnSearchPrevious_Click);
            // 
            // btnSearchNext
            // 
            this.btnSearchNext.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchNext.Location = new System.Drawing.Point(231, 58);
            this.btnSearchNext.Name = "btnSearchNext";
            this.btnSearchNext.Size = new System.Drawing.Size(95, 23);
            this.btnSearchNext.TabIndex = 4;
            this.btnSearchNext.Text = "Find next";
            this.btnSearchNext.UseVisualStyleBackColor = true;
            this.btnSearchNext.Click += new System.EventHandler(this.btnSearchNext_Click);
            // 
            // SearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 97);
            this.Controls.Add(this.btnSearchNext);
            this.Controls.Add(this.btnSearchPrevious);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.btnSearchNormal);
            this.Controls.Add(this.txtSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "SearchDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchDialog_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchDialog_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearchNormal;
        private System.Windows.Forms.CheckBox chkMatchCase;
        private System.Windows.Forms.Button btnSearchPrevious;
        private System.Windows.Forms.Button btnSearchNext;
    }
}