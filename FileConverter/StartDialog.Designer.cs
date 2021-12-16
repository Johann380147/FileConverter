namespace FileConverter
{
    partial class StartDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartDialog));
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnExternal = new System.Windows.Forms.Button();
            this.btnTreeForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLocal
            // 
            this.btnLocal.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocal.Location = new System.Drawing.Point(35, 47);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(137, 74);
            this.btnLocal.TabIndex = 0;
            this.btnLocal.Text = "Local Drive";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnExternal
            // 
            this.btnExternal.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExternal.Location = new System.Drawing.Point(204, 47);
            this.btnExternal.Name = "btnExternal";
            this.btnExternal.Size = new System.Drawing.Size(137, 74);
            this.btnExternal.TabIndex = 1;
            this.btnExternal.Text = "External Drive";
            this.btnExternal.UseVisualStyleBackColor = true;
            this.btnExternal.Click += new System.EventHandler(this.btnExternal_Click);
            // 
            // btnTreeForm
            // 
            this.btnTreeForm.Font = new System.Drawing.Font("Maiandra GD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTreeForm.Location = new System.Drawing.Point(287, 141);
            this.btnTreeForm.Name = "btnTreeForm";
            this.btnTreeForm.Size = new System.Drawing.Size(79, 28);
            this.btnTreeForm.TabIndex = 2;
            this.btnTreeForm.Text = "Tree";
            this.btnTreeForm.UseVisualStyleBackColor = true;
            this.btnTreeForm.Click += new System.EventHandler(this.btnTreeForm_Click);
            // 
            // StartDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 173);
            this.Controls.Add(this.btnTreeForm);
            this.Controls.Add(this.btnExternal);
            this.Controls.Add(this.btnLocal);
            this.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Start";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDialog_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.StartDialog_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StartDialog_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnExternal;
        private System.Windows.Forms.Button btnTreeForm;
    }
}