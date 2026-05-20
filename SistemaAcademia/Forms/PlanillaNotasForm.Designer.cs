namespace SistemaAcademia
{
    partial class PlanillaNotasForm
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
            dataGridView1 = new DataGridView();
            Materia = new DataGridViewTextBoxColumn();
            Seccion = new DataGridViewTextBoxColumn();
            Realizadas = new DataGridViewTextBoxColumn();
            PuntosAcumulados = new DataGridViewTextBoxColumn();
            PorcentajeEvaluado = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            SearchBox = new TextBox();
            BtnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(353, 25);
            label1.Name = "label1";
            label1.Size = new Size(638, 115);
            label1.TabIndex = 2;
            label1.Text = "Planilla de Notas";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Materia, Seccion, Realizadas, PuntosAcumulados, PorcentajeEvaluado, Estado });
            dataGridView1.Location = new Point(350, 193);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(641, 464);
            dataGridView1.TabIndex = 9;
            // 
            // Materia
            // 
            Materia.HeaderText = "Materia";
            Materia.Name = "Materia";
            Materia.ReadOnly = true;
            // 
            // Seccion
            // 
            Seccion.HeaderText = "Sec";
            Seccion.Name = "Seccion";
            Seccion.ReadOnly = true;
            // 
            // Realizadas
            // 
            Realizadas.HeaderText = "Realizadas";
            Realizadas.Name = "Realizadas";
            Realizadas.ReadOnly = true;
            // 
            // PuntosAcumulados
            // 
            PuntosAcumulados.HeaderText = "Puntos Acumulados";
            PuntosAcumulados.Name = "PuntosAcumulados";
            PuntosAcumulados.ReadOnly = true;
            // 
            // PorcentajeEvaluado
            // 
            PorcentajeEvaluado.HeaderText = "% Evaluado";
            PorcentajeEvaluado.Name = "PorcentajeEvaluado";
            PorcentajeEvaluado.ReadOnly = true;
            // 
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.Name = "Estado";
            Estado.ReadOnly = true;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(353, 164);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(209, 23);
            SearchBox.TabIndex = 10;
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
            BtnBack.TabIndex = 11;
            BtnBack.UseVisualStyleBackColor = false;
            BtnBack.Click += BtnBack_Click;
            // 
            // PlanillaNotasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1344, 729);
            Controls.Add(BtnBack);
            Controls.Add(SearchBox);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "PlanillaNotasForm";
            Text = "PlanillaNotasForm";
            Click += BtnBack_Click;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private TextBox SearchBox;
        private Button BtnBack;
        private DataGridViewTextBoxColumn Materia;
        private DataGridViewTextBoxColumn Seccion;
        private DataGridViewTextBoxColumn Realizadas;
        private DataGridViewTextBoxColumn PuntosAcumulados;
        private DataGridViewTextBoxColumn PorcentajeEvaluado;
        private DataGridViewTextBoxColumn Estado;
    }
}