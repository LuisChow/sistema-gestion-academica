namespace SistemaAcademia
{
    partial class ReportesForm
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
            BtnPlanillaNotas = new Button();
            BtnPlanillaEvaluaciones = new Button();
            BtnRetroceso = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(495, 27);
            label1.Name = "label1";
            label1.Size = new Size(359, 109);
            label1.TabIndex = 1;
            label1.Text = "Reportes";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnPlanillaNotas
            // 
            BtnPlanillaNotas.BackColor = Color.FromArgb(30, 30, 60);
            BtnPlanillaNotas.BackgroundImage = Properties.Resources.Boton_de_Planilla_de_Notas;
            BtnPlanillaNotas.BackgroundImageLayout = ImageLayout.Stretch;
            BtnPlanillaNotas.FlatAppearance.BorderSize = 0;
            BtnPlanillaNotas.FlatStyle = FlatStyle.Flat;
            BtnPlanillaNotas.Location = new Point(225, 235);
            BtnPlanillaNotas.Name = "BtnPlanillaNotas";
            BtnPlanillaNotas.Size = new Size(862, 126);
            BtnPlanillaNotas.TabIndex = 2;
            BtnPlanillaNotas.UseVisualStyleBackColor = false;
            BtnPlanillaNotas.Click += BtnPlanillaNotas_Click;
            // 
            // BtnPlanillaEvaluaciones
            // 
            BtnPlanillaEvaluaciones.BackColor = Color.FromArgb(30, 30, 60);
            BtnPlanillaEvaluaciones.BackgroundImage = Properties.Resources.Boton_PlanillaEvaluaciones;
            BtnPlanillaEvaluaciones.BackgroundImageLayout = ImageLayout.Stretch;
            BtnPlanillaEvaluaciones.FlatAppearance.BorderSize = 0;
            BtnPlanillaEvaluaciones.FlatStyle = FlatStyle.Flat;
            BtnPlanillaEvaluaciones.Location = new Point(225, 473);
            BtnPlanillaEvaluaciones.Name = "BtnPlanillaEvaluaciones";
            BtnPlanillaEvaluaciones.Size = new Size(862, 126);
            BtnPlanillaEvaluaciones.TabIndex = 3;
            BtnPlanillaEvaluaciones.UseVisualStyleBackColor = false;
            BtnPlanillaEvaluaciones.Click += BtnPlanillaEvaluaciones_Click;
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
            BtnRetroceso.TabIndex = 7;
            BtnRetroceso.UseVisualStyleBackColor = false;
            BtnRetroceso.Click += BtnRetroceso_Click;
            // 
            // ReportesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1344, 729);
            Controls.Add(BtnRetroceso);
            Controls.Add(BtnPlanillaEvaluaciones);
            Controls.Add(BtnPlanillaNotas);
            Controls.Add(label1);
            Name = "ReportesForm";
            Text = "ReportesForm";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button BtnPlanillaNotas;
        private Button BtnPlanillaEvaluaciones;
        private Button BtnRetroceso;
    }
}