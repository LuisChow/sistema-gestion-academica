namespace SistemaAcademia
{
    partial class MantenimientoMateriaForm
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
            SearchBox = new TextBox();
            gridMaterias = new DataGridView();
            IDMateria = new DataGridViewTextBoxColumn();
            Materia = new DataGridViewTextBoxColumn();
            HC = new DataGridViewTextBoxColumn();
            Trimestre = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewImageColumn();
            label1 = new Label();
            BtnBack = new Button();
            BtnDelete = new Button();
            BtnAdd = new Button();
            ((System.ComponentModel.ISupportInitialize)gridMaterias).BeginInit();
            SuspendLayout();
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(405, 184);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(209, 23);
            SearchBox.TabIndex = 28;
            // 
            // gridMaterias
            // 
            gridMaterias.AllowUserToDeleteRows = false;
            gridMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMaterias.Columns.AddRange(new DataGridViewColumn[] { IDMateria, Materia, HC, Trimestre, Edit });
            gridMaterias.Location = new Point(405, 223);
            gridMaterias.Name = "gridMaterias";
            gridMaterias.ReadOnly = true;
            gridMaterias.Size = new Size(589, 399);
            gridMaterias.TabIndex = 23;
            // 
            // IDMateria
            // 
            IDMateria.HeaderText = "ID de Materia";
            IDMateria.Name = "IDMateria";
            IDMateria.ReadOnly = true;
            // 
            // Materia
            // 
            Materia.HeaderText = "Materia";
            Materia.Name = "Materia";
            Materia.ReadOnly = true;
            // 
            // HC
            // 
            HC.HeaderText = "HC";
            HC.Name = "HC";
            HC.ReadOnly = true;
            // 
            // Trimestre
            // 
            Trimestre.HeaderText = "Trimestre";
            Trimestre.Name = "Trimestre";
            Trimestre.ReadOnly = true;
            // 
            // Edit
            // 
            Edit.HeaderText = "Edit";
            Edit.Image = Properties.Resources.BotonEditar;
            Edit.Name = "Edit";
            Edit.ReadOnly = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(211, 27);
            label1.Name = "label1";
            label1.Size = new Size(1000, 115);
            label1.TabIndex = 21;
            label1.Text = "Mantenimiento de Materia";
            label1.TextAlign = ContentAlignment.TopCenter;
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
            BtnBack.TabIndex = 30;
            BtnBack.UseVisualStyleBackColor = false;
            BtnBack.Click += BtnRetroceso_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.BackColor = Color.FromArgb(30, 30, 60);
            BtnDelete.BackgroundImage = Properties.Resources.Boton_de_Borrar;
            BtnDelete.BackgroundImageLayout = ImageLayout.Stretch;
            BtnDelete.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatStyle = FlatStyle.Flat;
            BtnDelete.Location = new Point(740, 134);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(123, 83);
            BtnDelete.TabIndex = 32;
            BtnDelete.UseVisualStyleBackColor = false;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // BtnAdd
            // 
            BtnAdd.BackColor = Color.FromArgb(30, 30, 60);
            BtnAdd.BackgroundImage = Properties.Resources.BotonAdd;
            BtnAdd.BackgroundImageLayout = ImageLayout.Stretch;
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnAdd.FlatStyle = FlatStyle.Flat;
            BtnAdd.Location = new Point(881, 129);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(114, 93);
            BtnAdd.TabIndex = 31;
            BtnAdd.UseVisualStyleBackColor = false;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // MantenimientoMateriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1344, 729);
            Controls.Add(BtnDelete);
            Controls.Add(BtnAdd);
            Controls.Add(BtnBack);
            Controls.Add(SearchBox);
            Controls.Add(gridMaterias);
            Controls.Add(label1);
            Name = "MantenimientoMateriaForm";
            Text = "MantenimientoMateriaForm";
            ((System.ComponentModel.ISupportInitialize)gridMaterias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchBox;
        private DataGridView gridMaterias;
        private Label label1;
        private Button BtnBack;
        private Button BtnDelete;
        private Button BtnAdd;
        private DataGridViewTextBoxColumn IDMateria;
        private DataGridViewTextBoxColumn Materia;
        private DataGridViewTextBoxColumn HC;
        private DataGridViewTextBoxColumn Trimestre;
        private DataGridViewImageColumn Edit;
    }
}