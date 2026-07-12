namespace Parcial_y_TP
{
    partial class AdicionarMateria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdicionarMateria));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNuevaMateria = new System.Windows.Forms.TextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.cmbProfesores = new System.Windows.Forms.ComboBox();
            this.cmbCuatrimestre = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCorrelativa = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(301, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Profesor/a:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(301, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Cuatrimestre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(301, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre de la nueva materia:";
            // 
            // txtNuevaMateria
            // 
            this.txtNuevaMateria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.txtNuevaMateria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNuevaMateria.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNuevaMateria.ForeColor = System.Drawing.Color.White;
            this.txtNuevaMateria.Location = new System.Drawing.Point(490, 80);
            this.txtNuevaMateria.Name = "txtNuevaMateria";
            this.txtNuevaMateria.PlaceholderText = "Nueva Materia";
            this.txtNuevaMateria.Size = new System.Drawing.Size(149, 15);
            this.txtNuevaMateria.TabIndex = 10;
            this.txtNuevaMateria.TextChanged += new System.EventHandler(this.txtNuevaMateria_TextChanged);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(536, 304);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(75, 23);
            this.btnCrear.TabIndex = 16;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // cmbProfesores
            // 
            this.cmbProfesores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.cmbProfesores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesores.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbProfesores.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbProfesores.FormattingEnabled = true;
            this.cmbProfesores.Location = new System.Drawing.Point(493, 171);
            this.cmbProfesores.Name = "cmbProfesores";
            this.cmbProfesores.Size = new System.Drawing.Size(149, 25);
            this.cmbProfesores.TabIndex = 17;
            this.cmbProfesores.SelectedIndexChanged += new System.EventHandler(this.cmbProfesores_SelectedIndexChanged);
            // 
            // cmbCuatrimestre
            // 
            this.cmbCuatrimestre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.cmbCuatrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuatrimestre.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCuatrimestre.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCuatrimestre.FormattingEnabled = true;
            this.cmbCuatrimestre.Items.AddRange(new object[] {
            "Primero",
            "Segundo",
            "Tercero"});
            this.cmbCuatrimestre.Location = new System.Drawing.Point(493, 124);
            this.cmbCuatrimestre.Name = "cmbCuatrimestre";
            this.cmbCuatrimestre.Size = new System.Drawing.Size(149, 25);
            this.cmbCuatrimestre.TabIndex = 18;
            this.cmbCuatrimestre.SelectedIndexChanged += new System.EventHandler(this.cmdCuatrimestre_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 18);
            this.panel1.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(301, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 32);
            this.label4.TabIndex = 20;
            this.label4.Text = "Nueva Materia";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(272, 285);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(490, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(149, 2);
            this.label5.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(301, 270);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 17);
            this.label7.TabIndex = 57;
            this.label7.Text = "Materia Correlativa:";
            // 
            // cmbMaterias
            // 
            this.cmbMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.cmbMaterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterias.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMaterias.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbMaterias.FormattingEnabled = true;
            this.cmbMaterias.Items.AddRange(new object[] {
            "Programacion I",
            "Programacion II",
            "Ingles I",
            "Sistemas Operativos I"});
            this.cmbMaterias.Location = new System.Drawing.Point(493, 267);
            this.cmbMaterias.Name = "cmbMaterias";
            this.cmbMaterias.Size = new System.Drawing.Size(149, 25);
            this.cmbMaterias.TabIndex = 56;
            this.cmbMaterias.SelectedIndexChanged += new System.EventHandler(this.cmbMaterias_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(301, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 55;
            this.label6.Text = "Correlativa:";
            // 
            // cmbCorrelativa
            // 
            this.cmbCorrelativa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.cmbCorrelativa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCorrelativa.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbCorrelativa.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbCorrelativa.FormattingEnabled = true;
            this.cmbCorrelativa.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cmbCorrelativa.Location = new System.Drawing.Point(493, 219);
            this.cmbCorrelativa.Name = "cmbCorrelativa";
            this.cmbCorrelativa.Size = new System.Drawing.Size(149, 25);
            this.cmbCorrelativa.TabIndex = 54;
            this.cmbCorrelativa.SelectedIndexChanged += new System.EventHandler(this.cmbCorrelativa_SelectedIndexChanged);
            // 
            // AdicionarMateria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(654, 339);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbMaterias);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbCorrelativa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbCuatrimestre);
            this.Controls.Add(this.cmbProfesores);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNuevaMateria);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdicionarMateria";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdicionarMateria";
            this.Load += new System.EventHandler(this.AdicionarMateria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNuevaMateria;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.ComboBox cmbProfesores;
        private System.Windows.Forms.ComboBox cmbCuatrimestre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbMaterias;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCorrelativa;
    }
}