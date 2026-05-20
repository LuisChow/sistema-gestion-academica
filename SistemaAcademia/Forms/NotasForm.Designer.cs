using Npgsql;
using System.Data;

namespace SistemaAcademia
{
    partial class NotasForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void LoadComboBoxes()
        {
            // Consulta para materias
            string sqlMateria = loader.BuildSql("combo_materias"); // desde JSON si prefieres
            DataTable dtMateria;
            try
            {
                dtMateria = db.ExecuteQuery(sqlMateria);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar materias: {ex.Message}");
                return;
            }

            comboBoxMateria.DataSource = dtMateria;
            comboBoxMateria.DisplayMember = "nombre";
            comboBoxMateria.ValueMember = "id";

            // Consulta para secciones
            string sqlSeccion = loader.BuildSql("combo_secciones"); // desde JSON si prefieres
            DataTable dtSeccion;
            try
            {
                dtSeccion = db.ExecuteQuery(sqlSeccion);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar secciones: {ex.Message}");
                return;
            }

            comboBoxSeccion.DataSource = dtSeccion;
            comboBoxSeccion.DisplayMember = "nombre";
            comboBoxSeccion.ValueMember = "id";
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            comboBoxMateria = new ComboBox();
            comboBoxSeccion = new ComboBox();
            BtnGuardar = new Button();
            dataGridView1 = new DataGridView();
            BtnRetroceso = new Button();
            Estudiante = new DataGridViewTextBoxColumn();
            CI = new DataGridViewTextBoxColumn();
            NotaFinal = new DataGridViewTextBoxColumn();
            Seccion = new DataGridViewTextBoxColumn();
            N1 = new DataGridViewTextBoxColumn();
            N2 = new DataGridViewTextBoxColumn();
            N3 = new DataGridViewTextBoxColumn();
            N4 = new DataGridViewTextBoxColumn();
            N5 = new DataGridViewTextBoxColumn();
            N6 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(553, 9);
            label1.Name = "label1";
            label1.Size = new Size(274, 117);
            label1.TabIndex = 1;
            label1.Text = "Notas";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.Font = new Font("Segoe UI", 60F);
            label2.ForeColor = Color.FromArgb(170, 245, 219);
            label2.Location = new Point(34, 78);
            label2.Name = "label2";
            label2.Size = new Size(332, 113);
            label2.TabIndex = 2;
            label2.Text = "Materia:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Font = new Font("Segoe UI", 60F);
            label3.ForeColor = Color.FromArgb(170, 245, 219);
            label3.Location = new Point(982, 78);
            label3.Name = "label3";
            label3.Size = new Size(350, 116);
            label3.TabIndex = 3;
            label3.Text = "Sección:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboBoxMateria
            // 
            comboBoxMateria.FormattingEnabled = true;
            comboBoxMateria.Location = new Point(55, 182);
            comboBoxMateria.Name = "comboBoxMateria";
            comboBoxMateria.Size = new Size(278, 23);
            comboBoxMateria.TabIndex = 4;
            comboBoxMateria.SelectedIndexChanged += ComboBoxes_SelectionChanged;
            // 
            // comboBoxSeccion
            // 
            comboBoxSeccion.FormattingEnabled = true;
            comboBoxSeccion.Location = new Point(1015, 182);
            comboBoxSeccion.Name = "comboBoxSeccion";
            comboBoxSeccion.Size = new Size(278, 23);
            comboBoxSeccion.TabIndex = 5;
            comboBoxSeccion.SelectedIndexChanged += ComboBoxes_SelectionChanged;
            // 
            // BtnGuardar
            // 
            BtnGuardar.BackColor = Color.FromArgb(30, 30, 60);
            BtnGuardar.BackgroundImage = Properties.Resources.Boton_de_Guardado;
            BtnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
            BtnGuardar.FlatAppearance.BorderSize = 0;
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Location = new Point(513, 642);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(355, 75);
            BtnGuardar.TabIndex = 7;
            BtnGuardar.UseVisualStyleBackColor = false;
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(168, 190, 239);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Estudiante, CI, NotaFinal, Seccion, N1, N2, N3, N4, N5, N6 });
            dataGridView1.Location = new Point(52, 241);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1243, 350);
            dataGridView1.TabIndex = 8;
            // 
            // BtnRetroceso
            // 
            BtnRetroceso.BackColor = Color.FromArgb(30, 30, 60);
            BtnRetroceso.BackgroundImage = Properties.Resources.Boton_de_Retroceso;
            BtnRetroceso.BackgroundImageLayout = ImageLayout.Stretch;
            BtnRetroceso.FlatAppearance.BorderSize = 0;
            BtnRetroceso.FlatStyle = FlatStyle.Flat;
            BtnRetroceso.Location = new Point(12, 633);
            BtnRetroceso.Name = "BtnRetroceso";
            BtnRetroceso.Size = new Size(104, 84);
            BtnRetroceso.TabIndex = 9;
            BtnRetroceso.UseVisualStyleBackColor = false;
            BtnRetroceso.Click += BtnRetroceso_Click;
            // 
            // Estudiante
            // 
            Estudiante.HeaderText = "Estudiante";
            Estudiante.Name = "Estudiante";
            Estudiante.ReadOnly = true;
            // 
            // CI
            // 
            CI.HeaderText = "Cédula Identidad";
            CI.Name = "CI";
            CI.ReadOnly = true;
            // 
            // NotaFinal
            // 
            NotaFinal.HeaderText = "Nota";
            NotaFinal.Name = "NotaFinal";
            NotaFinal.ReadOnly = true;
            // 
            // Seccion
            // 
            Seccion.HeaderText = "Sec";
            Seccion.Name = "Seccion";
            Seccion.ReadOnly = true;
            // 
            // N1
            // 
            N1.HeaderText = "N1";
            N1.Name = "N1";
            N1.ReadOnly = true;
            // 
            // N2
            // 
            N2.HeaderText = "N2";
            N2.Name = "N2";
            N2.ReadOnly = true;
            // 
            // N3
            // 
            N3.HeaderText = "N3";
            N3.Name = "N3";
            N3.ReadOnly = true;
            // 
            // N4
            // 
            N4.HeaderText = "N4";
            N4.Name = "N4";
            N4.ReadOnly = true;
            // 
            // N5
            // 
            N5.HeaderText = "N5";
            N5.Name = "N5";
            N5.ReadOnly = true;
            // 
            // N6
            // 
            N6.HeaderText = "N6";
            N6.Name = "N6";
            N6.ReadOnly = true;
            // 
            // NotasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1344, 729);
            Controls.Add(BtnRetroceso);
            Controls.Add(dataGridView1);
            Controls.Add(BtnGuardar);
            Controls.Add(comboBoxSeccion);
            Controls.Add(comboBoxMateria);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "NotasForm";
            Text = "NotasForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox comboBoxMateria;
        private ComboBox comboBoxSeccion;
        private Button BtnGuardar;
        private DataGridView dataGridView1;
        private Button BtnRetroceso;
        private DataGridViewTextBoxColumn Estudiante;
        private DataGridViewTextBoxColumn CI;
        private DataGridViewTextBoxColumn Seccion;
        private DataGridViewTextBoxColumn N1;
        private DataGridViewTextBoxColumn N2;
        private DataGridViewTextBoxColumn N3;
        private DataGridViewTextBoxColumn N4;
        private DataGridViewTextBoxColumn N5;
        private DataGridViewTextBoxColumn N6;
        private DataGridViewTextBoxColumn NotaFinal;
    }
}