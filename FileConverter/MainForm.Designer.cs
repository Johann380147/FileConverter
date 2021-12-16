namespace FileConverter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lstFileAccounts = new BrightIdeasSoftware.ObjectListView();
            this.Category = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Username = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Password = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.Extras = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SwapDrives = new System.Windows.Forms.Button();
            this.RefreshAccount = new System.Windows.Forms.Button();
            this.lblFilter = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AddAccount = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.roundedTextBox1 = new FileConverter.RoundedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.lstFileAccounts)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstFileAccounts
            // 
            this.lstFileAccounts.AllColumns.Add(this.Category);
            this.lstFileAccounts.AllColumns.Add(this.Username);
            this.lstFileAccounts.AllColumns.Add(this.Password);
            this.lstFileAccounts.AllColumns.Add(this.Extras);
            this.lstFileAccounts.AllowDrop = true;
            this.lstFileAccounts.AlternateRowBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lstFileAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstFileAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Category,
            this.Username,
            this.Password,
            this.Extras});
            this.lstFileAccounts.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstFileAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFileAccounts.EmptyListMsg = "Drag a file here";
            this.lstFileAccounts.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFileAccounts.FullRowSelect = true;
            this.lstFileAccounts.GridLines = true;
            this.lstFileAccounts.Location = new System.Drawing.Point(0, 0);
            this.lstFileAccounts.MultiSelect = false;
            this.lstFileAccounts.Name = "lstFileAccounts";
            this.lstFileAccounts.OwnerDraw = true;
            this.lstFileAccounts.ShowCommandMenuOnRightClick = true;
            this.lstFileAccounts.ShowGroups = false;
            this.lstFileAccounts.ShowItemToolTips = true;
            this.lstFileAccounts.Size = new System.Drawing.Size(764, 421);
            this.lstFileAccounts.TabIndex = 1;
            this.lstFileAccounts.UseAlternatingBackColors = true;
            this.lstFileAccounts.UseCompatibleStateImageBehavior = false;
            this.lstFileAccounts.UseFiltering = true;
            this.lstFileAccounts.UseHotItem = true;
            this.lstFileAccounts.UseTranslucentHotItem = true;
            this.lstFileAccounts.UseTranslucentSelection = true;
            this.lstFileAccounts.View = System.Windows.Forms.View.Details;
            this.lstFileAccounts.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFileAccounts_DragDrop);
            this.lstFileAccounts.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFileAccounts_DragEnter);
            this.lstFileAccounts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lstFileAccounts_MouseUp);
            // 
            // Category
            // 
            this.Category.AspectName = "Category";
            this.Category.Text = "Category";
            this.Category.Width = 100;
            // 
            // Username
            // 
            this.Username.AspectName = "Username";
            this.Username.Text = "Username";
            this.Username.Width = 100;
            // 
            // Password
            // 
            this.Password.AspectName = "Password";
            this.Password.Text = "Password";
            this.Password.Width = 100;
            // 
            // Extras
            // 
            this.Extras.AspectName = "Extras";
            this.Extras.FillsFreeSpace = true;
            this.Extras.Text = "Extras";
            this.Extras.Width = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstFileAccounts);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 421);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel2.Controls.Add(this.SwapDrives);
            this.panel2.Controls.Add(this.RefreshAccount);
            this.panel2.Controls.Add(this.lblFilter);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.AddAccount);
            this.panel2.Controls.Add(this.btnClearSearch);
            this.panel2.Controls.Add(this.elementHost1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(764, 40);
            this.panel2.TabIndex = 9;
            // 
            // SwapDrives
            // 
            this.SwapDrives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.SwapDrives.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.SwapDrives.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwapDrives.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SwapDrives.Image = global::FileConverter.Properties.Resources._1463742346_Exchange;
            this.SwapDrives.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SwapDrives.Location = new System.Drawing.Point(199, 10);
            this.SwapDrives.Name = "SwapDrives";
            this.SwapDrives.Size = new System.Drawing.Size(75, 22);
            this.SwapDrives.TabIndex = 13;
            this.SwapDrives.TabStop = false;
            this.SwapDrives.Text = "External";
            this.SwapDrives.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SwapDrives.UseVisualStyleBackColor = false;
            this.SwapDrives.Click += new System.EventHandler(this.SwapDrives_Click);
            // 
            // RefreshAccount
            // 
            this.RefreshAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.RefreshAccount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.RefreshAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshAccount.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshAccount.Image = global::FileConverter.Properties.Resources._1463383915_Refresh;
            this.RefreshAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RefreshAccount.Location = new System.Drawing.Point(118, 10);
            this.RefreshAccount.Name = "RefreshAccount";
            this.RefreshAccount.Size = new System.Drawing.Size(75, 22);
            this.RefreshAccount.TabIndex = 12;
            this.RefreshAccount.TabStop = false;
            this.RefreshAccount.Text = "Refresh";
            this.RefreshAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RefreshAccount.UseVisualStyleBackColor = false;
            this.RefreshAccount.Click += new System.EventHandler(this.RefreshAccount_Click);
            // 
            // lblFilter
            // 
            this.lblFilter.AutoSize = true;
            this.lblFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFilter.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.lblFilter.Location = new System.Drawing.Point(327, 13);
            this.lblFilter.Name = "lblFilter";
            this.lblFilter.Size = new System.Drawing.Size(0, 15);
            this.lblFilter.TabIndex = 11;
            this.lblFilter.TextChanged += new System.EventHandler(this.lblFilter_TextChanged);
            this.lblFilter.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(289, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Filter:";
            // 
            // AddAccount
            // 
            this.AddAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(222)))), ((int)(((byte)(0)))));
            this.AddAccount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(200)))), ((int)(((byte)(50)))));
            this.AddAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddAccount.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddAccount.Image = global::FileConverter.Properties.Resources._1463383879_plus_24;
            this.AddAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddAccount.Location = new System.Drawing.Point(14, 10);
            this.AddAccount.Name = "AddAccount";
            this.AddAccount.Size = new System.Drawing.Size(75, 22);
            this.AddAccount.TabIndex = 9;
            this.AddAccount.TabStop = false;
            this.AddAccount.Text = "Add";
            this.AddAccount.UseVisualStyleBackColor = false;
            this.AddAccount.Click += new System.EventHandler(this.AddAccount_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnClearSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnClearSearch.FlatAppearance.BorderSize = 0;
            this.btnClearSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnClearSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.btnClearSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearSearch.Image = global::FileConverter.Properties.Resources.x;
            this.btnClearSearch.Location = new System.Drawing.Point(725, 9);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(22, 22);
            this.btnClearSearch.TabIndex = 8;
            this.btnClearSearch.TabStop = false;
            this.btnClearSearch.UseVisualStyleBackColor = false;
            this.btnClearSearch.Visible = false;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // elementHost1
            // 
            this.elementHost1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.elementHost1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.elementHost1.Location = new System.Drawing.Point(502, 3);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(255, 39);
            this.elementHost1.TabIndex = 2;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.roundedTextBox1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 105);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Converter";
            ((System.ComponentModel.ISupportInitialize)(this.lstFileAccounts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView lstFileAccounts;
        private BrightIdeasSoftware.OLVColumn Category;
        private BrightIdeasSoftware.OLVColumn Username;
        private BrightIdeasSoftware.OLVColumn Password;
        private BrightIdeasSoftware.OLVColumn Extras;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private RoundedTextBox roundedTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button AddAccount;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RefreshAccount;
        private System.Windows.Forms.Button SwapDrives;
    }
}