namespace Parcial_y_TP
{
    partial class Estadistica
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
            this.cmbMaterias = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPromedioDeAlumnos = new System.Windows.Forms.Label();
            this.lblPromedioDeCadaMateria = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // cmbMaterias
            // 
            this.cmbMaterias.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.cmbMaterias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterias.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbMaterias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbMaterias.FormattingEnabled = true;
            this.cmbMaterias.Location = new System.Drawing.Point(12, 109);
            this.cmbMaterias.Name = "cmbMaterias";
            this.cmbMaterias.Size = new System.Drawing.Size(161, 23);
            this.cmbMaterias.TabIndex = 20;
            this.cmbMaterias.SelectedIndexChanged += new System.EventHandler(this.cmbMaterias_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 21;
            this.label1.Text = "Materias:";
            // 
            // lblPromedioDeAlumnos
            // 
            this.lblPromedioDeAlumnos.AutoSize = true;
            this.lblPromedioDeAlumnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPromedioDeAlumnos.ForeColor = System.Drawing.Color.White;
            this.lblPromedioDeAlumnos.Location = new System.Drawing.Point(201, 73);
            this.lblPromedioDeAlumnos.Name = "lblPromedioDeAlumnos";
            this.lblPromedioDeAlumnos.Size = new System.Drawing.Size(0, 15);
            this.lblPromedioDeAlumnos.TabIndex = 22;
            // 
            // lblPromedioDeCadaMateria
            // 
            this.lblPromedioDeCadaMateria.AutoSize = true;
            this.lblPromedioDeCadaMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPromedioDeCadaMateria.ForeColor = System.Drawing.Color.White;
            this.lblPromedioDeCadaMateria.Location = new System.Drawing.Point(201, 125);
            this.lblPromedioDeCadaMateria.Name = "lblPromedioDeCadaMateria";
            this.lblPromedioDeCadaMateria.Size = new System.Drawing.Size(0, 15);
            this.lblPromedioDeCadaMateria.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(201, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 15);
            this.label2.TabIndex = 24;
            this.label2.Text = "Promedio de Alumnos inscriptos por materia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(201, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(202, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Promedio de Nota de cada materia:";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(201, 88);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 2);
            this.label11.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(201, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 2);
            this.label4.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 31);
            this.label5.TabIndex = 44;
            this.label5.Text = "Estadisticas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 18);
            this.panel1.TabIndex = 45;
            // 
            // Estadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(466, 156);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPromedioDeCadaMateria);
            this.Controls.Add(this.lblPromedioDeAlumnos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbMaterias);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Estadistica";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Estadistica";
            this.Load += new System.EventHandler(this.Estadistica_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbMaterias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPromedioDeAlumnos;
        private System.Windows.Forms.Label lblPromedioDeCadaMateria;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}