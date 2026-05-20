namespace SistemaAcademia
{
    partial class MenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            BtnNotas = new Button();
            BtnReportes = new Button();
            BtnInscripcion = new Button();
            BtnMantenimiento = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(273, 9);
            label1.Name = "label1";
            label1.Size = new Size(812, 219);
            label1.TabIndex = 0;
            label1.Text = "Bienvenido al Sistema de Academia";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnNotas
            // 
            BtnNotas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            BtnNotas.BackColor = Color.FromArgb(30, 30, 60);
            BtnNotas.BackgroundImage = Properties.Resources.BtnNotas;
            BtnNotas.BackgroundImageLayout = ImageLayout.Stretch;
            BtnNotas.FlatAppearance.BorderSize = 0;
            BtnNotas.FlatStyle = FlatStyle.Flat;
            BtnNotas.Location = new Point(567, 295);
            BtnNotas.Name = "BtnNotas";
            BtnNotas.Size = new Size(237, 91);
            BtnNotas.TabIndex = 1;
            BtnNotas.UseVisualStyleBackColor = false;
            BtnNotas.Click += BtnNotas_Click;
            // 
            // BtnReportes
            // 
            BtnReportes.BackColor = Color.FromArgb(30, 30, 60);
            BtnReportes.BackgroundImage = Properties.Resources.BtnReportes;
            BtnReportes.BackgroundImageLayout = ImageLayout.Stretch;
            BtnReportes.FlatAppearance.BorderSize = 0;
            BtnReportes.FlatStyle = FlatStyle.Flat;
            BtnReportes.Location = new Point(495, 394);
            BtnReportes.Name = "BtnReportes";
            BtnReportes.Size = new Size(381, 91);
            BtnReportes.TabIndex = 2;
            BtnReportes.UseVisualStyleBackColor = false;
            BtnReportes.Click += BtnReportes_Click;
            // 
            // BtnInscripcion
            // 
            BtnInscripcion.BackColor = Color.FromArgb(30, 30, 60);
            BtnInscripcion.BackgroundImage = Properties.Resources.BtnInscripcion;
            BtnInscripcion.BackgroundImageLayout = ImageLayout.Stretch;
            BtnInscripcion.FlatAppearance.BorderSize = 0;
            BtnInscripcion.FlatStyle = FlatStyle.Flat;
            BtnInscripcion.Location = new Point(412, 491);
            BtnInscripcion.Name = "BtnInscripcion";
            BtnInscripcion.Size = new Size(547, 91);
            BtnInscripcion.TabIndex = 3;
            BtnInscripcion.UseVisualStyleBackColor = false;
            BtnInscripcion.Click += BtnInscripcion_Click;
            // 
            // BtnMantenimiento
            // 
            BtnMantenimiento.BackColor = Color.FromArgb(30, 30, 60);
            BtnMantenimiento.BackgroundImage = Properties.Resources.BtnMantenimiento;
            BtnMantenimiento.BackgroundImageLayout = ImageLayout.Stretch;
            BtnMantenimiento.FlatAppearance.BorderSize = 0;
            BtnMantenimiento.FlatStyle = FlatStyle.Flat;
            BtnMantenimiento.Location = new Point(359, 593);
            BtnMantenimiento.Name = "BtnMantenimiento";
            BtnMantenimiento.Size = new Size(653, 91);
            BtnMantenimiento.TabIndex = 4;
            BtnMantenimiento.UseVisualStyleBackColor = false;
            BtnMantenimiento.Click += BtnMantenimiento_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1344, 729);
            Controls.Add(BtnMantenimiento);
            Controls.Add(BtnInscripcion);
            Controls.Add(BtnReportes);
            Controls.Add(BtnNotas);
            Controls.Add(label1);
            Name = "MenuPrincipal";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button BtnNotas;
        private Button BtnReportes;
        private Button BtnInscripcion;
        private Button BtnMantenimiento;
    }
}
