namespace SistemaAcademia
{
    partial class CrearMateriaForm
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
            label2 = new Label();
            txtCodigo = new TextBox();
            label4 = new Label();
            txtMateria = new TextBox();
            label3 = new Label();
            label5 = new Label();
            BtnSave = new Button();
            txtTrimestre = new TextBox();
            labelTrimestre = new Label();
            txtHC = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(72, -263);
            label1.Name = "label1";
            label1.Size = new Size(258, 115);
            label1.TabIndex = 37;
            label1.Text = "Editar";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.Font = new Font("Segoe UI", 35F);
            label2.ForeColor = Color.FromArgb(170, 245, 219);
            label2.Location = new Point(33, 382);
            label2.Name = "label2";
            label2.Size = new Size(357, 59);
            label2.TabIndex = 43;
            label2.Text = "HC:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(41, 210);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(340, 23);
            txtCodigo.TabIndex = 42;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.Font = new Font("Segoe UI", 35F);
            label4.ForeColor = Color.FromArgb(170, 245, 219);
            label4.Location = new Point(33, 128);
            label4.Name = "label4";
            label4.Size = new Size(357, 62);
            label4.TabIndex = 41;
            label4.Text = "ID:";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtMateria
            // 
            txtMateria.Location = new Point(41, 339);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(340, 23);
            txtMateria.TabIndex = 40;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Font = new Font("Segoe UI", 35F);
            label3.ForeColor = Color.FromArgb(170, 245, 219);
            label3.Location = new Point(33, 253);
            label3.Name = "label3";
            label3.Size = new Size(357, 66);
            label3.TabIndex = 39;
            label3.Text = "Materia:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.Font = new Font("Segoe UI", 60F);
            label5.ForeColor = Color.FromArgb(170, 245, 219);
            label5.Location = new Point(77, 9);
            label5.Name = "label5";
            label5.Size = new Size(258, 115);
            label5.TabIndex = 38;
            label5.Text = "Crear";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(30, 30, 60);
            BtnSave.BackgroundImage = Properties.Resources.Boton_de_Guardado;
            BtnSave.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Location = new Point(18, 623);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(384, 94);
            BtnSave.TabIndex = 46;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // txtTrimestre
            // 
            txtTrimestre.Location = new Point(41, 578);
            txtTrimestre.Name = "txtTrimestre";
            txtTrimestre.Size = new Size(340, 23);
            txtTrimestre.TabIndex = 48;
            // 
            // labelTrimestre
            // 
            labelTrimestre.Anchor = AnchorStyles.Top;
            labelTrimestre.Font = new Font("Segoe UI", 35F);
            labelTrimestre.ForeColor = Color.FromArgb(170, 245, 219);
            labelTrimestre.Location = new Point(33, 496);
            labelTrimestre.Name = "labelTrimestre";
            labelTrimestre.Size = new Size(357, 62);
            labelTrimestre.TabIndex = 47;
            labelTrimestre.Text = "Trimestre:";
            labelTrimestre.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtHC
            // 
            txtHC.Location = new Point(41, 461);
            txtHC.Name = "txtHC";
            txtHC.Size = new Size(340, 23);
            txtHC.TabIndex = 49;
            // 
            // CrearMateriaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(414, 729);
            Controls.Add(txtHC);
            Controls.Add(txtTrimestre);
            Controls.Add(labelTrimestre);
            Controls.Add(BtnSave);
            Controls.Add(label2);
            Controls.Add(txtCodigo);
            Controls.Add(label4);
            Controls.Add(txtMateria);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label1);
            Name = "CrearMateriaForm";
            Text = "CrearMateriaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCodigo;
        private Label label4;
        private TextBox txtMateria;
        private Label label3;
        private Label label5;
        private Button BtnSave;
        private TextBox txtTrimestre;
        private Label labelTrimestre;
        private TextBox txtHC;
    }
}