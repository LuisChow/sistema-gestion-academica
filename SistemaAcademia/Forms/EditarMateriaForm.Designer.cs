namespace SistemaAcademia
{
    partial class EditarMateriaForm
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
            txtHC = new TextBox();
            txtTrimestre = new TextBox();
            labelTrimestre = new Label();
            BtnSave = new Button();
            label2 = new Label();
            txtCodigo = new TextBox();
            label4 = new Label();
            txtMateria = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(75, 4);
            label1.Name = "label1";
            label1.Size = new Size(258, 115);
            label1.TabIndex = 29;
            label1.Text = "Editar";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtHC
            // 
            txtHC.Location = new Point(38, 458);
            txtHC.Name = "txtHC";
            txtHC.Size = new Size(340, 23);
            txtHC.TabIndex = 58;
            // 
            // txtTrimestre
            // 
            txtTrimestre.Location = new Point(38, 575);
            txtTrimestre.Name = "txtTrimestre";
            txtTrimestre.Size = new Size(340, 23);
            txtTrimestre.TabIndex = 57;
            // 
            // labelTrimestre
            // 
            labelTrimestre.Anchor = AnchorStyles.Top;
            labelTrimestre.Font = new Font("Segoe UI", 35F);
            labelTrimestre.ForeColor = Color.FromArgb(170, 245, 219);
            labelTrimestre.Location = new Point(30, 493);
            labelTrimestre.Name = "labelTrimestre";
            labelTrimestre.Size = new Size(357, 62);
            labelTrimestre.TabIndex = 56;
            labelTrimestre.Text = "Trimestre:";
            labelTrimestre.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(30, 30, 60);
            BtnSave.BackgroundImage = Properties.Resources.Boton_de_Guardado;
            BtnSave.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Location = new Point(15, 620);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(384, 94);
            BtnSave.TabIndex = 55;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.Font = new Font("Segoe UI", 35F);
            label2.ForeColor = Color.FromArgb(170, 245, 219);
            label2.Location = new Point(30, 379);
            label2.Name = "label2";
            label2.Size = new Size(357, 59);
            label2.TabIndex = 54;
            label2.Text = "HC:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(38, 207);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(340, 23);
            txtCodigo.TabIndex = 53;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.Font = new Font("Segoe UI", 35F);
            label4.ForeColor = Color.FromArgb(170, 245, 219);
            label4.Location = new Point(30, 125);
            label4.Name = "label4";
            label4.Size = new Size(357, 62);
            label4.TabIndex = 52;
            label4.Text = "ID:";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtMateria
            // 
            txtMateria.Location = new Point(38, 336);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(340, 23);
            txtMateria.TabIndex = 51;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Font = new Font("Segoe UI", 35F);
            label3.ForeColor = Color.FromArgb(170, 245, 219);
            label3.Location = new Point(30, 250);
            label3.Name = "label3";
            label3.Size = new Size(357, 66);
            label3.TabIndex = 50;
            label3.Text = "Materia:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // EditarMateriaForm
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
            Controls.Add(label1);
            Name = "EditarMateriaForm";
            Text = "EditarMateriaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TextBox txtHC;
        private TextBox txtTrimestre;
        private Label labelTrimestre;
        private Button BtnSave;
        private Label label2;
        private TextBox txtCodigo;
        private Label label4;
        private TextBox txtMateria;
        private Label label3;
    }
}