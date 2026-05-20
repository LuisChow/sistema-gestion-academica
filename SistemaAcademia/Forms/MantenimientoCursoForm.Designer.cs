namespace SistemaAcademia
{
    partial class MantenimientoCursoForm
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
            gridCursos = new DataGridView();
            IDMateria = new DataGridViewTextBoxColumn();
            Materia = new DataGridViewTextBoxColumn();
            Sección = new DataGridViewTextBoxColumn();
            Profesor = new DataGridViewTextBoxColumn();
            Periodo = new DataGridViewTextBoxColumn();
            Horario = new DataGridViewTextBoxColumn();
            Aula = new DataGridViewTextBoxColumn();
            Cupo = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewImageColumn();
            label1 = new Label();
            BtnDelete = new Button();
            BtnAdd = new Button();
            BtnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)gridCursos).BeginInit();
            SuspendLayout();
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(152, 192);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(209, 23);
            SearchBox.TabIndex = 42;
            // 
            // gridCursos
            // 
            gridCursos.AllowUserToDeleteRows = false;
            gridCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridCursos.Columns.AddRange(new DataGridViewColumn[] { IDMateria, Materia, Sección, Profesor, Periodo, Horario, Aula, Cupo, Edit });
            gridCursos.Location = new Point(152, 226);
            gridCursos.Name = "gridCursos";
            gridCursos.ReadOnly = true;
            gridCursos.RowTemplate.Height = 40;
            gridCursos.Size = new Size(933, 410);
            gridCursos.TabIndex = 38;
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
            // Sección
            // 
            Sección.HeaderText = "Sección";
            Sección.Name = "Sección";
            Sección.ReadOnly = true;
            // 
            // Profesor
            // 
            Profesor.HeaderText = "Profesor";
            Profesor.Name = "Profesor";
            Profesor.ReadOnly = true;
            // 
            // Periodo
            // 
            Periodo.HeaderText = "Periodo";
            Periodo.Name = "Periodo";
            Periodo.ReadOnly = true;
            // 
            // Horario
            // 
            Horario.HeaderText = "Horario";
            Horario.Name = "Horario";
            Horario.ReadOnly = true;
            // 
            // Aula
            // 
            Aula.HeaderText = "Aula";
            Aula.Name = "Aula";
            Aula.ReadOnly = true;
            // 
            // Cupo
            // 
            Cupo.HeaderText = "Cupo";
            Cupo.Name = "Cupo";
            Cupo.ReadOnly = true;
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
            label1.Location = new Point(194, 9);
            label1.Name = "label1";
            label1.Size = new Size(1000, 115);
            label1.TabIndex = 36;
            label1.Text = "Mantenimiento de Curso";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnDelete
            // 
            BtnDelete.BackColor = Color.FromArgb(30, 30, 60);
            BtnDelete.BackgroundImage = Properties.Resources.Boton_de_Borrar;
            BtnDelete.BackgroundImageLayout = ImageLayout.Stretch;
            BtnDelete.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatStyle = FlatStyle.Flat;
            BtnDelete.Location = new Point(896, 132);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(123, 83);
            BtnDelete.TabIndex = 46;
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
            BtnAdd.Location = new Point(1025, 127);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(114, 93);
            BtnAdd.TabIndex = 45;
            BtnAdd.UseVisualStyleBackColor = false;
            BtnAdd.Click += BtnAdd_Click;
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
            BtnBack.TabIndex = 44;
            BtnBack.UseVisualStyleBackColor = false;
            BtnBack.Click += BtnBack_Click;
            // 
            // MantenimientoCursoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1344, 729);
            Controls.Add(BtnDelete);
            Controls.Add(BtnAdd);
            Controls.Add(BtnBack);
            Controls.Add(SearchBox);
            Controls.Add(gridCursos);
            Controls.Add(label1);
            Name = "MantenimientoCursoForm";
            Text = "MantenimientoCursoForm";
            ((System.ComponentModel.ISupportInitialize)gridCursos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchBox;
        private DataGridView gridCursos;
        private Label label1;
        private Button BtnDelete;
        private Button BtnAdd;
        private Button BtnBack;
        private DataGridViewTextBoxColumn IDMateria;
        private DataGridViewTextBoxColumn Materia;
        private DataGridViewTextBoxColumn Sección;
        private DataGridViewTextBoxColumn Profesor;
        private DataGridViewTextBoxColumn Periodo;
        private DataGridViewTextBoxColumn Horario;
        private DataGridViewTextBoxColumn Aula;
        private DataGridViewImageColumn Edit;
        private DataGridViewTextBoxColumn Cupo;
    }
}