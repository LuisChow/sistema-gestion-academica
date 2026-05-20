namespace SistemaAcademia
{
    partial class CrearNotaForm
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
            BtnGuardar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxNota = new TextBox();
            textBoxPorcentaje = new TextBox();
            SuspendLayout();
            // 
            // BtnGuardar
            // 
            BtnGuardar.BackColor = Color.FromArgb(30, 30, 60);
            BtnGuardar.BackgroundImage = Properties.Resources.Boton_de_Guardado;
            BtnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
            BtnGuardar.FlatAppearance.BorderSize = 0;
            BtnGuardar.FlatStyle = FlatStyle.Flat;
            BtnGuardar.Location = new Point(18, 612);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Size = new Size(384, 94);
            BtnGuardar.TabIndex = 8;
            BtnGuardar.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(44, 9);
            label1.Name = "label1";
            label1.Size = new Size(331, 124);
            label1.TabIndex = 9;
            label1.Text = "Agregar";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.Font = new Font("Segoe UI", 60F);
            label2.ForeColor = Color.FromArgb(170, 245, 219);
            label2.Location = new Point(-11, 341);
            label2.Name = "label2";
            label2.Size = new Size(441, 124);
            label2.TabIndex = 10;
            label2.Text = "Porcentaje:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Font = new Font("Segoe UI", 60F);
            label3.ForeColor = Color.FromArgb(170, 245, 219);
            label3.Location = new Point(44, 164);
            label3.Name = "label3";
            label3.Size = new Size(331, 124);
            label3.TabIndex = 11;
            label3.Text = "Nota:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBoxNota
            // 
            textBoxNota.Location = new Point(39, 276);
            textBoxNota.Name = "textBoxNota";
            textBoxNota.Size = new Size(340, 23);
            textBoxNota.TabIndex = 12;
            // 
            // textBoxPorcentaje
            // 
            textBoxPorcentaje.Location = new Point(39, 477);
            textBoxPorcentaje.Name = "textBoxPorcentaje";
            textBoxPorcentaje.Size = new Size(340, 23);
            textBoxPorcentaje.TabIndex = 13;
            // 
            // AgregarNotaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(414, 729);
            Controls.Add(textBoxPorcentaje);
            Controls.Add(textBoxNota);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(BtnGuardar);
            Name = "AgregarNotaForm";
            Text = "AgregarNotaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnGuardar;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxNota;
        private TextBox textBoxPorcentaje;
    }
}