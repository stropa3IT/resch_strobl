namespace Resthome_Database
{
    partial class FormVisitor
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadTable = new System.Windows.Forms.Button();
            this.dgvShowData = new System.Windows.Forms.DataGridView();
            this.cbTables = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadTable
            // 
            this.btnLoadTable.Location = new System.Drawing.Point(430, 25);
            this.btnLoadTable.Name = "btnLoadTable";
            this.btnLoadTable.Size = new System.Drawing.Size(149, 36);
            this.btnLoadTable.TabIndex = 0;
            this.btnLoadTable.Text = "Load Table";
            this.btnLoadTable.UseVisualStyleBackColor = true;
            this.btnLoadTable.Click += new System.EventHandler(this.btnLoadTable_Click);
            // 
            // dgvShowData
            // 
            this.dgvShowData.AllowUserToAddRows = false;
            this.dgvShowData.AllowUserToDeleteRows = false;
            this.dgvShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvShowData.Location = new System.Drawing.Point(3, 92);
            this.dgvShowData.Name = "dgvShowData";
            this.dgvShowData.ReadOnly = true;
            this.dgvShowData.Size = new System.Drawing.Size(943, 348);
            this.dgvShowData.TabIndex = 1;
            // 
            // cbTables
            // 
            this.cbTables.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTables.FormattingEnabled = true;
            this.cbTables.Location = new System.Drawing.Point(263, 34);
            this.cbTables.Name = "cbTables";
            this.cbTables.Size = new System.Drawing.Size(128, 21);
            this.cbTables.TabIndex = 3;
            this.cbTables.SelectedIndexChanged += new System.EventHandler(this.cbTables_SelectedIndexChanged);
            // 
            // FormVisitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 541);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cbTables);
            this.Controls.Add(this.dgvShowData);
            this.Controls.Add(this.btnLoadTable);
            this.Name = "FormVisitor";
            this.Text = "Visitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadTable;
        private System.Windows.Forms.DataGridView dgvShowData;
        private System.Windows.Forms.ComboBox cbTables;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
    }
}

