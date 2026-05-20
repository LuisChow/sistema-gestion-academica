namespace SistemaAcademia
{
    partial class MantenimientoSeccionForm
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
            gridSeccion = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Seccion = new DataGridViewTextBoxColumn();
            label1 = new Label();
            BtnDelete = new Button();
            BtnBack = new Button();
            BtnSave = new Button();
            txtNombreSeccion = new TextBox();
            label3 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)gridSeccion).BeginInit();
            SuspendLayout();
            // 
            // gridSeccion
            // 
            gridSeccion.AllowUserToDeleteRows = false;
            gridSeccion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridSeccion.Columns.AddRange(new DataGridViewColumn[] { ID, Seccion });
            gridSeccion.Location = new Point(367, 236);
            gridSeccion.Name = "gridSeccion";
            gridSeccion.ReadOnly = true;
            gridSeccion.Size = new Size(242, 388);
            gridSeccion.TabIndex = 31;
            // 
            // ID
            // 
            ID.HeaderText = "ID Sección";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Seccion
            // 
            Seccion.HeaderText = "Sección";
            Seccion.Name = "Seccion";
            Seccion.ReadOnly = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(211, 27);
            label1.Name = "label1";
            label1.Size = new Size(1000, 115);
            label1.TabIndex = 29;
            label1.Text = "Mantenimiento de Sección";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnDelete
            // 
            BtnDelete.BackColor = Color.FromArgb(30, 30, 60);
            BtnDelete.BackgroundImage = Properties.Resources.Boton_de_Borrar;
            BtnDelete.BackgroundImageLayout = ImageLayout.Stretch;
            BtnDelete.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatStyle = FlatStyle.Flat;
            BtnDelete.Location = new Point(367, 145);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(123, 83);
            BtnDelete.TabIndex = 39;
            BtnDelete.UseVisualStyleBackColor = false;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnBack
            // 
            BtnBack.BackColor = Color.FromArgb(30, 30, 60);
            BtnBack.BackgroundImage = Properties.Resources.Boton_de_Retroceso;
            BtnBack.BackgroundImageLayout = ImageLayout.Stretch;
            BtnBack.FlatAppearance.BorderSize = 0;
            BtnBack.FlatStyle = FlatStyle.Flat;
            BtnBack.Location = new Point(12, 633);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(104, 84);
            BtnBack.TabIndex = 37;
            BtnBack.UseVisualStyleBackColor = false;
            BtnBack.Click += BtnRetroceso_Click;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(30, 30, 60);
            BtnSave.BackgroundImage = Properties.Resources.Boton_de_Guardado;
            BtnSave.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Location = new Point(977, 602);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(355, 115);
            BtnSave.TabIndex = 36;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // txtNombreSeccion
            // 
            txtNombreSeccion.Location = new Point(977, 427);
            txtNombreSeccion.Name = "txtNombreSeccion";
            txtNombreSeccion.Size = new Size(355, 23);
            txtNombreSeccion.TabIndex = 51;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Font = new Font("Segoe UI", 35F);
            label3.ForeColor = Color.FromArgb(170, 245, 219);
            label3.Location = new Point(976, 355);
            label3.Name = "label3";
            label3.Size = new Size(357, 115);
            label3.TabIndex = 50;
            label3.Text = "Seccion:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.Font = new Font("Segoe UI", 60F);
            label5.ForeColor = Color.FromArgb(170, 245, 219);
            label5.Location = new Point(1025, 170);
            label5.Name = "label5";
            label5.Size = new Size(258, 115);
            label5.TabIndex = 49;
            label5.Text = "Crear";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // MantenimientoSeccionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1344, 729);
            Controls.Add(txtNombreSeccion);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(BtnDelete);
            Controls.Add(BtnBack);
            Controls.Add(BtnSave);
            Controls.Add(gridSeccion);
            Controls.Add(label1);
            Name = "MantenimientoSeccionForm";
            Text = "MantenimientoSeccionForm";
            ((System.ComponentModel.ISupportInitialize)gridSeccion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView gridSeccion;
        private Label label1;
        private Button BtnDelete;
        private Button BtnBack;
        private Button BtnSave;
        private TextBox txtNombreSeccion;
        private Label label3;
        private Label label5;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Seccion;
    }
}