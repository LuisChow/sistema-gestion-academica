namespace SistemaAcademia
{
    partial class MantenimientoPersonaForm
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
            dataGridPersona = new DataGridView();
            CI = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            TipoPersona = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewImageColumn();
            BtnAdd = new Button();
            BtnFilter = new Button();
            BtnDelete = new Button();
            SearchBox = new TextBox();
            BtnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridPersona).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.Font = new Font("Segoe UI", 60F);
            label1.ForeColor = Color.FromArgb(170, 245, 219);
            label1.Location = new Point(193, 43);
            label1.Name = "label1";
            label1.Size = new Size(1000, 115);
            label1.TabIndex = 13;
            label1.Text = "Mantenimiento de Persona";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // dataGridPersona
            // 
            dataGridPersona.AllowUserToDeleteRows = false;
            dataGridPersona.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPersona.Columns.AddRange(new DataGridViewColumn[] { CI, Nombre, Apellido, TipoPersona, Edit });
            dataGridPersona.Location = new Point(386, 263);
            dataGridPersona.Name = "dataGridPersona";
            dataGridPersona.ReadOnly = true;
            dataGridPersona.Size = new Size(581, 348);
            dataGridPersona.TabIndex = 15;
            // 
            // CI
            // 
            CI.HeaderText = "Cédula Identidad";
            CI.Name = "CI";
            CI.ReadOnly = true;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            Apellido.HeaderText = "Apellido";
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            // 
            // TipoPersona
            // 
            TipoPersona.HeaderText = "TipoPersona";
            TipoPersona.Name = "TipoPersona";
            TipoPersona.ReadOnly = true;
            // 
            // Edit
            // 
            Edit.HeaderText = "Edit";
            Edit.Image = Properties.Resources.BotonEditar;
            Edit.Name = "Edit";
            Edit.ReadOnly = true;
            // 
            // BtnAdd
            // 
            BtnAdd.BackColor = Color.FromArgb(30, 30, 60);
            BtnAdd.BackgroundImage = Properties.Resources.BotonAdd;
            BtnAdd.BackgroundImageLayout = ImageLayout.Stretch;
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnAdd.FlatStyle = FlatStyle.Flat;
            BtnAdd.Location = new Point(859, 164);
            BtnAdd.Name = "BtnAdd";
            BtnAdd.Size = new Size(114, 93);
            BtnAdd.TabIndex = 16;
            BtnAdd.UseVisualStyleBackColor = false;
            BtnAdd.Click += BtnAdd_Click;
            // 
            // BtnFilter
            // 
            BtnFilter.BackColor = Color.FromArgb(30, 30, 60);
            BtnFilter.BackgroundImage = Properties.Resources.Boton_de_Filter;
            BtnFilter.BackgroundImageLayout = ImageLayout.Stretch;
            BtnFilter.FlatAppearance.BorderSize = 0;
            BtnFilter.FlatStyle = FlatStyle.Flat;
            BtnFilter.Location = new Point(730, 169);
            BtnFilter.Name = "BtnFilter";
            BtnFilter.Size = new Size(123, 83);
            BtnFilter.TabIndex = 18;
            BtnFilter.UseVisualStyleBackColor = false;
            BtnFilter.Click += BtnFilter_Click;
            // 
            // BtnDelete
            // 
            BtnDelete.BackColor = Color.FromArgb(30, 30, 60);
            BtnDelete.BackgroundImage = Properties.Resources.Boton_de_Borrar;
            BtnDelete.BackgroundImageLayout = ImageLayout.Stretch;
            BtnDelete.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatStyle = FlatStyle.Flat;
            BtnDelete.Location = new Point(601, 169);
            BtnDelete.Name = "BtnDelete";
            BtnDelete.Size = new Size(123, 83);
            BtnDelete.TabIndex = 19;
            BtnDelete.UseVisualStyleBackColor = false;
            BtnDelete.Click += BtnDelete_Click;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(386, 229);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(209, 23);
            SearchBox.TabIndex = 20;
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
            BtnBack.TabIndex = 22;
            BtnBack.UseVisualStyleBackColor = false;
            BtnBack.Click += BtnBack_Click;
            // 
            // MantenimientoPersonaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 60);
            ClientSize = new Size(1344, 729);
            Controls.Add(BtnBack);
            Controls.Add(SearchBox);
            Controls.Add(BtnDelete);
            Controls.Add(BtnFilter);
            Controls.Add(BtnAdd);
            Controls.Add(dataGridPersona);
            Controls.Add(label1);
            Name = "MantenimientoPersonaForm";
            Text = "MantenimientoPersonaForm";
            ((System.ComponentModel.ISupportInitialize)dataGridPersona).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridPersona;
        private Button BtnAdd;
        private Button BtnFilter;
        private Button BtnDelete;
        private TextBox SearchBox;
        private Button BtnBack;
        private DataGridViewTextBoxColumn CI;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn TipoPersona;
        private DataGridViewImageColumn Edit;
    }
}