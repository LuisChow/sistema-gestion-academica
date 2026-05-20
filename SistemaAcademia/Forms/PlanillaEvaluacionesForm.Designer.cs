namespace SistemaAcademia
{
    partial class PlanillaEvaluacionesForm
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
            N1 = new DataGridViewTextBoxColumn();
            N2 = new DataGridViewTextBoxColumn();
            N3 = new DataGridViewTextBoxColumn();
            N4 = new DataGridViewTextBoxColumn();
            N5 = new DataGridViewTextBoxColumn();
            N6 = new DataGridViewTextBoxColumn();
            N7 = new DataGridViewTextBoxColumn();
            N8 = new DataGridViewTextBoxColumn();
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
            label1.Location = new Point(222, 30);
            label1.Name = "label1";
            label1.Size = new Size(881, 115);
            label1.TabIndex = 3;
            label1.Text = "Planilla de Evaluaciones";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Materia, N1, N2, N3, N4, N5, N6, N7, N8 });
            dataGridView1.Location = new Point(191, 187);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(942, 464);
            dataGridView1.TabIndex = 10;
            // 
            // Materia
            // 
            Materia.HeaderText = "Materia";
            Materia.Name = "Materia";
            Materia.ReadOnly = true;
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
            // N7
            // 
            N7.HeaderText = "N7";
            N7.Name = "N7";
            N7.ReadOnly = true;
            // 
            // N8
            // 
            N8.HeaderText = "N8";
            N8.Name = "N8";
            N8.ReadOnly = true;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(191, 148);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(209, 23);
            SearchBox.TabIndex = 11;
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
            BtnBack.TabIndex = 12;
            BtnBack.UseVisualStyleBackColor = false;
            BtnBack.Click += BtnBack_Click;
            // 
            // PlanillaEvaluacionesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1344, 729);
            Controls.Add(BtnBack);
            Controls.Add(SearchBox);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "PlanillaEvaluacionesForm";
            Text = "PlanillaEvaluacionesForm";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Materia;
        private DataGridViewTextBoxColumn N1;
        private DataGridViewTextBoxColumn N2;
        private DataGridViewTextBoxColumn N3;
        private DataGridViewTextBoxColumn N4;
        private DataGridViewTextBoxColumn N5;
        private DataGridViewTextBoxColumn N6;
        private DataGridViewTextBoxColumn N7;
        private DataGridViewTextBoxColumn N8;
        private TextBox SearchBox;
        private Button BtnBack;
    }
}