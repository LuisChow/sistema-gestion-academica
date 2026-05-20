namespace SistemaAcademia
{
    partial class InscripcionesForm
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
            label1 = new Label();
            dataGridCursos = new DataGridView();
            Trimestre = new DataGridViewTextBoxColumn();
            ID = new DataGridViewTextBoxColumn();
            Materia = new DataGridViewTextBoxColumn();
            Seccion = new DataGridViewTextBoxColumn();
            HC = new DataGridViewTextBoxColumn();
            Cupo = new DataGridViewTextBoxColumn();
            Docente = new DataGridViewTextBoxColumn();
            dataGridHorario = new DataGridView();
            BtnBack = new Button();
            SearchBox = new TextBox();
            BtnGuardar = new Button();
            Lunes = new DataGridViewTextBoxColumn();
            Martes = new DataGridViewTextBoxColumn();
            Miércoles = new DataGridViewTextBoxColumn();
            Jueves = new DataGridViewTextBoxColumn();
            Viernes = new DataGridViewTextBoxColumn();
            Sábado = new DataGridViewTextBoxColumn();
            Domingo = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridCursos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridHorario).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(452, -20);
            label1.Name = "label1";
            label1.Size = new Size(504, 115);
            label1.TabIndex = 2;
            label1.Text = "Inscripciones";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // dataGridCursos
            // 
            dataGridCursos.AllowUserToDeleteRows = false;
            dataGridCursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCursos.Columns.AddRange(new DataGridViewColumn[] { Trimestre, ID, Materia, Seccion, HC, Cupo, Docente });
            dataGridCursos.Location = new Point(157, 132);
            dataGridCursos.Name = "dataGridCursos";
            dataGridCursos.ReadOnly = true;
            dataGridCursos.Size = new Size(899, 284);
            dataGridCursos.TabIndex = 11;
            // 
            // Trimestre
            // 
            Trimestre.HeaderText = "Semestre";
            Trimestre.Name = "Trimestre";
            Trimestre.ReadOnly = true;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Materia
            // 
            Materia.HeaderText = "Materia";
            Materia.Name = "Materia";
            Materia.ReadOnly = true;
            // 
            // Seccion
            // 
            Seccion.HeaderText = "Sección";
            Seccion.Name = "Seccion";
            Seccion.ReadOnly = true;
            // 
            // HC
            // 
            HC.HeaderText = "HC";
            HC.Name = "HC";
            HC.ReadOnly = true;
            // 
            // Cupo
            // 
            Cupo.HeaderText = "Cupo";
            Cupo.Name = "Cupo";
            Cupo.ReadOnly = true;
            // 
            // Docente
            // 
            Docente.HeaderText = "Profesor";
            Docente.Name = "Docente";
            Docente.ReadOnly = true;
            // 
            // dataGridHorario
            // 
            dataGridHorario.AllowUserToDeleteRows = false;
            dataGridHorario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridHorario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridHorario.Columns.AddRange(new DataGridViewColumn[] { Lunes, Martes, Miércoles, Jueves, Viernes, Sábado, Domingo });
            dataGridHorario.Location = new Point(157, 424);
            dataGridHorario.Name = "dataGridHorario";
            dataGridHorario.ReadOnly = true;
            dataGridHorario.Size = new Size(899, 283);
            dataGridHorario.TabIndex = 12;
            // 
            // BtnBack
            // 
            BtnBack.BackColor = Color.FromArgb(30, 30, 60);
            BtnBack.BackgroundImage = Properties.Resources.Boton_de_Retroceso;
            BtnBack.BackgroundImageLayout = ImageLayout.Stretch;
            BtnBack.FlatAppearance.BorderSize = 0;
            BtnBack.FlatStyle = FlatStyle.Flat;
            BtnBack.Location = new Point(12, 623);
            BtnBack.Name = "BtnBack";
            BtnBack.Size = new Size(104, 84);
            BtnBack.TabIndex = 13;
            BtnBack.UseVisualStyleBackColor = false;
            BtnBack.Click += BtnBack_Click;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(157, 98);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(209, 23);
            SearchBox.TabIndex = 14;
            // 
            // BtnGuardar
            // 
            BtnGuardar.BackColor = Color.FromArgb(30, 30, 60);
            BtnGuardar.BackgroundImage = Properties.Resources.Boton_de_Guardado;
            BtnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
            BtnGuardar.FlatAppearance.BorderSize = 0;
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Location = new Point(1102, 604);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(210, 86);
            BtnGuardar.TabIndex = 15;
            BtnGuardar.UseVisualStyleBackColor = false;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // Lunes
            // 
            Lunes.HeaderText = "Lunes";
            Lunes.Name = "Lunes";
            Lunes.ReadOnly = true;
            // 
            // Martes
            // 
            Martes.HeaderText = "Martes";
            Martes.Name = "Martes";
            Martes.ReadOnly = true;
            // 
            // Miércoles
            // 
            Miércoles.HeaderText = "Miércoles";
            Miércoles.Name = "Miércoles";
            Miércoles.ReadOnly = true;
            // 
            // Jueves
            // 
            Jueves.HeaderText = "Jueves";
            Jueves.Name = "Jueves";
            Jueves.ReadOnly = true;
            // 
            // Viernes
            // 
            Viernes.HeaderText = "Viernes";
            Viernes.Name = "Viernes";
            Viernes.ReadOnly = true;
            // 
            // Sábado
            // 
            Sábado.HeaderText = "Sábado";
            Sábado.Name = "Sábado";
            Sábado.ReadOnly = true;
            // 
            // Domingo
            // 
            Domingo.HeaderText = "Domingo";
            Domingo.Name = "Domingo";
            Domingo.ReadOnly = true;
            // 
            // InscripcionesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1344, 719);
            Controls.Add(BtnGuardar);
            Controls.Add(SearchBox);
            Controls.Add(BtnBack);
            Controls.Add(dataGridHorario);
            Controls.Add(dataGridCursos);
            Controls.Add(label1);
            Name = "InscripcionesForm";
            Text = "InscripcionesForm";
            ((System.ComponentModel.ISupportInitialize)dataGridCursos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridHorario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridCursos;
        private DataGridView dataGridHorario;
        private Button BtnBack;
        private TextBox SearchBox;
        private Button BtnGuardar;
        private DataGridViewTextBoxColumn Trimestre;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Materia;
        private DataGridViewTextBoxColumn Seccion;
        private DataGridViewTextBoxColumn HC;
        private DataGridViewTextBoxColumn Cupo;
        private DataGridViewTextBoxColumn Docente;
        private DataGridViewTextBoxColumn Lunes;
        private DataGridViewTextBoxColumn Martes;
        private DataGridViewTextBoxColumn Miércoles;
        private DataGridViewTextBoxColumn Jueves;
        private DataGridViewTextBoxColumn Viernes;
        private DataGridViewTextBoxColumn Sábado;
        private DataGridViewTextBoxColumn Domingo;
    }
}