namespace Test
{
    partial class frmEmployees
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
            this.dtgListado = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cmbUsers = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListado)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgListado
            // 
            this.dtgListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListado.Location = new System.Drawing.Point(10, 135);
            this.dtgListado.Name = "dtgListado";
            this.dtgListado.Size = new System.Drawing.Size(402, 207);
            this.dtgListado.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Usuario";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(16, 106);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(402, 23);
            this.btnCrear.TabIndex = 5;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(64, 36);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(348, 20);
            this.txtName.TabIndex = 6;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(62, 59);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(348, 20);
            this.txtLastName.TabIndex = 7;
            // 
            // cmbUsers
            // 
            this.cmbUsers.FormattingEnabled = true;
            this.cmbUsers.Location = new System.Drawing.Point(62, 82);
            this.cmbUsers.Name = "cmbUsers";
            this.cmbUsers.Size = new System.Drawing.Size(350, 21);
            this.cmbUsers.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(62, 13);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(350, 20);
            this.txtId.TabIndex = 10;
            // 
            // frmEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 354);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbUsers);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgListado);
            this.Name = "frmEmployees";
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.frmEmployees_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgListado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.ComboBox cmbUsers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtId;
    }
}