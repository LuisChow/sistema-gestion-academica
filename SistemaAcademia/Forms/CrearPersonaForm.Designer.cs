namespace SistemaAcademia
{
    partial class CrearPersonaForm
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
            ComboTipo = new ComboBox();
            labelTipo = new Label();
            txtCi = new TextBox();
            labelCI = new Label();
            txtNombre = new TextBox();
            labelNombre = new Label();
            label1 = new Label();
            BtnSave = new Button();
            txtApellido = new TextBox();
            labelApellido = new Label();
            SuspendLayout();
            // 
            // ComboTipo
            // 
            ComboTipo.FormattingEnabled = true;
            ComboTipo.Location = new Point(41, 562);
            ComboTipo.Name = "ComboTipo";
            ComboTipo.Size = new Size(337, 23);
            ComboTipo.TabIndex = 36;
            // 
            // labelTipo
            // 
            labelTipo.Anchor = AnchorStyles.Top;
            labelTipo.Font = new Font("Segoe UI", 35F);
            labelTipo.ForeColor = Color.FromArgb(170, 245, 219);
            labelTipo.Location = new Point(22, 469);
            labelTipo.Name = "labelTipo";
            labelTipo.Size = new Size(374, 74);
            labelTipo.TabIndex = 34;
            labelTipo.Text = "Tipo de Persona:";
            labelTipo.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtCi
            // 
            txtCi.Location = new Point(39, 202);
            txtCi.Name = "txtCi";
            txtCi.Size = new Size(340, 23);
            txtCi.TabIndex = 33;
            // 
            // labelCI
            // 
            labelCI.Anchor = AnchorStyles.Top;
            labelCI.Font = new Font("Segoe UI", 35F);
            labelCI.ForeColor = Color.FromArgb(170, 245, 219);
            labelCI.Location = new Point(31, 127);
            labelCI.Name = "labelCI";
            labelCI.Size = new Size(357, 56);
            labelCI.TabIndex = 32;
            labelCI.Text = "Ci:";
            labelCI.TextAlign = ContentAlignment.TopCenter;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(39, 321);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(340, 23);
            txtNombre.TabIndex = 31;
            // 
            // labelNombre
            // 
            labelNombre.Anchor = AnchorStyles.Top;
            labelNombre.Font = new Font("Segoe UI", 35F);
            labelNombre.ForeColor = Color.FromArgb(170, 245, 219);
            labelNombre.Location = new Point(36, 244);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(347, 58);
            labelNombre.TabIndex = 30;
            labelNombre.Text = "Nombre:";
            labelNombre.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(80, 4);
            label1.Name = "label1";
            label1.Size = new Size(258, 115);
            label1.TabIndex = 29;
            label1.Text = "Crear";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // BtnSave
            // 
            BtnSave.BackColor = Color.FromArgb(30, 30, 60);
            BtnSave.BackgroundImage = Properties.Resources.Boton_de_Guardado;
            BtnSave.BackgroundImageLayout = ImageLayout.Stretch;
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnSave.FlatStyle = FlatStyle.Flat;
            BtnSave.Location = new Point(17, 623);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new Size(384, 94);
            BtnSave.TabIndex = 37;
            BtnSave.UseVisualStyleBackColor = false;
            BtnSave.Click += BtnSave_Click;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(37, 437);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(340, 23);
            txtApellido.TabIndex = 39;
            // 
            // labelApellido
            // 
            labelApellido.Anchor = AnchorStyles.Top;
            labelApellido.Font = new Font("Segoe UI", 35F);
            labelApellido.ForeColor = Color.FromArgb(170, 245, 219);
            labelApellido.Location = new Point(34, 360);
            labelApellido.Name = "labelApellido";
            labelApellido.Size = new Size(347, 58);
            labelApellido.TabIndex = 38;
            labelApellido.Text = "Apellido:";
            labelApellido.TextAlign = ContentAlignment.TopCenter;
            // 
            // CrearPersonaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(414, 729);
            Controls.Add(txtApellido);
            Controls.Add(labelApellido);
            Controls.Add(BtnSave);
            Controls.Add(ComboTipo);
            Controls.Add(labelTipo);
            Controls.Add(txtCi);
            Controls.Add(labelCI);
            Controls.Add(txtNombre);
            Controls.Add(labelNombre);
            Controls.Add(label1);
            Name = "CrearPersonaForm";
            Text = "CrearPersonaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ComboTipo;
        private Label labelTipo;
        private TextBox txtCi;
        private Label labelCI;
        private TextBox txtNombre;
        private Label labelNombre;
        private Label label1;
        private Button BtnSave;
        private TextBox txtApellido;
        private Label labelApellido;
    }
}