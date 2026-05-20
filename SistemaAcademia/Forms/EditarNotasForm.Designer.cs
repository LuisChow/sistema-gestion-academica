namespace SistemaAcademia
{
    partial class EditarNotasForm
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
            textBoxPorcentaje = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBoxNota = new TextBox();
            label4 = new Label();
            btnGuardar = new Button();
            comboBoxNumero = new ComboBox();
            SuspendLayout();
            // 
            // textBoxPorcentaje
            // 
            textBoxPorcentaje.Location = new Point(41, 556);
            textBoxPorcentaje.Name = "textBoxPorcentaje";
            textBoxPorcentaje.Size = new Size(340, 23);
            textBoxPorcentaje.TabIndex = 19;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Font = new Font("Segoe UI", 60F);
            label3.ForeColor = Color.FromArgb(170, 245, 219);
            label3.Location = new Point(46, 255);
            label3.Name = "label3";
            label3.Size = new Size(331, 124);
            label3.TabIndex = 17;
            label3.Text = "Nota:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.Font = new Font("Segoe UI", 60F);
            label2.ForeColor = Color.FromArgb(170, 245, 219);
            label2.Location = new Point(-9, 422);
            label2.Name = "label2";
            label2.Size = new Size(441, 124);
            label2.TabIndex = 16;
            label2.Text = "Porcentaje:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(46, -17);
            label1.Name = "label1";
            label1.Size = new Size(331, 124);
            label1.TabIndex = 15;
            label1.Text = "Editar";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBoxNota
            // 
            textBoxNota.Location = new Point(41, 396);
            textBoxNota.Name = "textBoxNota";
            textBoxNota.Size = new Size(340, 23);
            textBoxNota.TabIndex = 21;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.Font = new Font("Segoe UI", 60F);
            label4.ForeColor = Color.FromArgb(170, 245, 219);
            label4.Location = new Point(33, 117);
            label4.Name = "label4";
            label4.Size = new Size(357, 95);
            label4.TabIndex = 20;
            label4.Text = "Numero:";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(30, 30, 60);
            btnGuardar.BackgroundImage = Properties.Resources.Boton_de_Guardado;
            btnGuardar.BackgroundImageLayout = ImageLayout.Stretch;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(12, 623);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(384, 94);
            btnGuardar.TabIndex = 22;
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // comboBoxNumero
            // 
            comboBoxNumero.FormattingEnabled = true;
            comboBoxNumero.Location = new Point(41, 241);
            comboBoxNumero.Name = "comboBoxNumero";
            comboBoxNumero.Size = new Size(340, 23);
            comboBoxNumero.TabIndex = 23;
            // 
            // EditarNotasForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(414, 729);
            Controls.Add(comboBoxNumero);
            Controls.Add(btnGuardar);
            Controls.Add(textBoxNota);
            Controls.Add(label4);
            Controls.Add(textBoxPorcentaje);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditarNotasForm";
            Text = "EditarNotasForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxPorcentaje;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBoxNota;
        private Label label4;
        private Button btnGuardar;
        private ComboBox comboBoxNumero;
    }
}