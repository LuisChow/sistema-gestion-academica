namespace SistemaAcademia
{
    partial class MantenimientoForm
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
            BtnPersona = new Button();
            BtnMateria = new Button();
            BtnSeccion = new Button();
            BtnCurso = new Button();
            BtnRetroceso = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(410, 25);
            label1.Name = "label1";
            label1.Size = new Size(617, 115);
            label1.TabIndex = 12;
            label1.Text = "Mantenimiento";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnPersona
            // 
            BtnPersona.BackColor = Color.FromArgb(30, 30, 60);
            BtnPersona.BackgroundImage = Properties.Resources.Boton_de_Persona;
            BtnPersona.BackgroundImageLayout = ImageLayout.Stretch;
            BtnPersona.FlatAppearance.BorderSize = 0;
            BtnPersona.FlatStyle = FlatStyle.Flat;
            BtnPersona.Location = new Point(67, 243);
            BtnPersona.Name = "BtnPersona";
            BtnPersona.Size = new Size(560, 135);
            BtnPersona.TabIndex = 13;
            BtnPersona.UseVisualStyleBackColor = false;
            BtnPersona.Click += BtnPersona_Click;
            // 
            // BtnMateria
            // 
            BtnMateria.BackColor = Color.FromArgb(30, 30, 60);
            BtnMateria.BackgroundImage = Properties.Resources.Boton_de_Materia;
            BtnMateria.BackgroundImageLayout = ImageLayout.Stretch;
            BtnMateria.FlatAppearance.BorderSize = 0;
            BtnMateria.FlatStyle = FlatStyle.Flat;
            BtnMateria.Location = new Point(773, 243);
            BtnMateria.Name = "BtnMateria";
            BtnMateria.Size = new Size(560, 135);
            BtnMateria.TabIndex = 14;
            BtnMateria.UseVisualStyleBackColor = false;
            BtnMateria.Click += BtnMateria_Click;
            // 
            // BtnSeccion
            // 
            BtnSeccion.BackColor = Color.FromArgb(30, 30, 60);
            BtnSeccion.BackgroundImage = Properties.Resources.Boton_de_Sección;
            BtnSeccion.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSeccion.FlatAppearance.BorderSize = 0;
            BtnSeccion.FlatStyle = FlatStyle.Flat;
            BtnSeccion.Location = new Point(67, 475);
            BtnSeccion.Name = "BtnSeccion";
            BtnSeccion.Size = new Size(560, 135);
            BtnSeccion.TabIndex = 15;
            BtnSeccion.UseVisualStyleBackColor = false;
            BtnSeccion.Click += BtnSeccion_Click;
            // 
            // BtnCurso
            // 
            BtnCurso.BackColor = Color.FromArgb(30, 30, 60);
            BtnCurso.BackgroundImage = Properties.Resources.Boton_de_Curso;
            BtnCurso.BackgroundImageLayout = ImageLayout.Stretch;
            BtnCurso.FlatAppearance.BorderSize = 0;
            BtnCurso.FlatStyle = FlatStyle.Flat;
            BtnCurso.Location = new Point(773, 475);
            BtnCurso.Name = "BtnCurso";
            BtnCurso.Size = new Size(560, 135);
            BtnCurso.TabIndex = 16;
            BtnCurso.UseVisualStyleBackColor = false;
            BtnCurso.Click += BtnCurso_Click;
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
            BtnRetroceso.TabIndex = 17;
            BtnRetroceso.UseVisualStyleBackColor = false;
            BtnRetroceso.Click += BtnRetroceso_Click;
            // 
            // MantenimientoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1353, 729);
            Controls.Add(BtnRetroceso);
            Controls.Add(BtnCurso);
            Controls.Add(BtnSeccion);
            Controls.Add(BtnMateria);
            Controls.Add(BtnPersona);
            Controls.Add(label1);
            Name = "MantenimientoForm";
            Text = "MantenimientoForm";
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Button BtnPersona;
        private Button BtnMateria;
        private Button BtnSeccion;
        private Button BtnCurso;
        private Button BtnRetroceso;
    }
}