namespace SistemaAcademia
{
    partial class FiltroPersonaForm
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
            comboTipo = new ComboBox();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            comboSeccion = new ComboBox();
            comboMateria = new ComboBox();
            BtnSaveFilter = new Button();
            SuspendLayout();
            // 
            // comboTipo
            // 
            comboTipo.FormattingEnabled = true;
            comboTipo.Location = new Point(36, 476);
            comboTipo.Name = "comboTipo";
            comboTipo.Size = new Size(337, 23);
            comboTipo.TabIndex = 44;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.Font = new Font("Segoe UI", 35F);
            label2.ForeColor = Color.FromArgb(170, 245, 219);
            label2.Location = new Point(16, 391);
            label2.Name = "label2";
            label2.Size = new Size(376, 65);
            label2.TabIndex = 42;
            label2.Text = "Tipo de Persona:";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.Font = new Font("Segoe UI", 35F);
            label4.ForeColor = Color.FromArgb(170, 245, 219);
            label4.Location = new Point(26, 142);
            label4.Name = "label4";
            label4.Size = new Size(357, 57);
            label4.TabIndex = 40;
            label4.Text = "Materia:";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.Font = new Font("Segoe UI", 35F);
            label3.ForeColor = Color.FromArgb(170, 245, 219);
            label3.Location = new Point(26, 262);
            label3.Name = "label3";
            label3.Size = new Size(357, 66);
            label3.TabIndex = 38;
            label3.Text = "Sección:";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(75, 4);
            label1.Name = "label1";
            label1.Size = new Size(258, 115);
            label1.TabIndex = 37;
            label1.Text = "Filtro";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // comboSeccion
            // 
            comboSeccion.FormattingEnabled = true;
            comboSeccion.Location = new Point(36, 348);
            comboSeccion.Name = "comboSeccion";
            comboSeccion.Size = new Size(337, 23);
            comboSeccion.TabIndex = 45;
            // 
            // comboMateria
            // 
            comboMateria.FormattingEnabled = true;
            comboMateria.Location = new Point(36, 219);
            comboMateria.Name = "comboMateria";
            comboMateria.Size = new Size(337, 23);
            comboMateria.TabIndex = 46;
            // 
            // BtnSaveFilter
            // 
            BtnSaveFilter.BackColor = Color.FromArgb(30, 30, 60);
            BtnSaveFilter.BackgroundImage = Properties.Resources.Boton_de_Guardado;
            BtnSaveFilter.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSaveFilter.FlatAppearance.BorderSize = 0;
            BtnSaveFilter.FlatStyle = FlatStyle.Flat;
            BtnSaveFilter.Location = new Point(12, 623);
            BtnSaveFilter.Name = "BtnSaveFilter";
            BtnSaveFilter.Size = new Size(384, 94);
            BtnSaveFilter.TabIndex = 47;
            BtnSaveFilter.UseVisualStyleBackColor = false;
            BtnSaveFilter.Click += BtnSaveFilter_Click;
            // 
            // FiltroPersonaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(414, 729);
            Controls.Add(BtnSaveFilter);
            Controls.Add(comboMateria);
            Controls.Add(comboSeccion);
            Controls.Add(comboTipo);
            Controls.Add(label2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "FiltroPersonaForm";
            Text = "FiltroPersonaForm";
            ResumeLayout(false);
        }

        #endregion

        private Label label2;
        private Label label4;
        private Label label3;
        private Label label1;
        private Button BtnSaveFilter;
        private ComboBox comboMateria;
        private ComboBox comboSeccion;
        private ComboBox comboTipo;
    }
}