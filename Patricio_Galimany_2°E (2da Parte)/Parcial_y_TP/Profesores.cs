using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial_y_TP
{
    public partial class Profesores : Form
    {
        /// <summary>
        /// Atributos.
        /// </summary>
        private Profesor ? profesor;
        private int posicion;
        private string ? nombreMateria;
        private string ? nombreAlumno;

        public Profesores(Usuario profesors)
        {
            InitializeComponent();
            this.profesor = profesors as Profesor;
        }

        private void Profesores_Load(object sender, EventArgs e)
        {
            btnExamenes.Enabled = false;
            btnNota.Enabled = false;
            txtProfesor.Text = profesor.Nombre;
            dtpFecha.MinDate = DateTime.Now;
        }

        private void btnExamenes_Click(object sender, EventArgs e)
        {
            int n = dgvExamenes.Rows.Add();

            dgvExamenes.Rows[n].Cells[0].Value = dtpFecha.Value.ToString("dd-MM-yyyy");
            dgvExamenes.Rows[n].Cells[1].Value = txtNombre.Text;

            txtNombre.Text = "";

            btnNota.Enabled = true;
            btnExamenes.Enabled = false;

            dgvNotas.DataSource = null;
            dgvNotas.DataSource = Profesor.MateriasAsignadas(profesor);
            OcultarColumna();
        }

        private void btnNota_Click(object sender, EventArgs e)
        {
            if (txtPrimerParcial.Text != String.Empty && txtSegundoParcial.Text != String.Empty)
            {
                double primerParcial = double.Parse(txtPrimerParcial.Text);
                double segundoParcial = double.Parse(txtSegundoParcial.Text);

                if (primerParcial < 11 && segundoParcial < 11)
                {
                    dgvNotas[6, posicion].Value = txtPrimerParcial.Text;
                    dgvNotas[7, posicion].Value = txtSegundoParcial.Text;
                    dgvNotas[8, posicion].Value = profesor.AsignarNotas(primerParcial, segundoParcial, profesor, nombreMateria, nombreAlumno);

                    txtPrimerParcial.Text = "";
                    txtSegundoParcial.Text = "";
                }
                else
                {
                    MessageBox.Show("Error, Poner una nota valida.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Error, Llene todos los campos.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                e.Handled = true;
            }
            else
            {
                btnExamenes.Enabled = true;
            }
        }
        private void txtPrimerParcial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
        private void txtSegundoParcial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void dgvNotas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = dgvNotas.CurrentRow.Index;
            nombreMateria = dgvNotas[2, posicion].Value.ToString();
            nombreAlumno = dgvNotas[5, posicion].Value.ToString();
            txtPrimerParcial.Text = dgvNotas[6, posicion].Value.ToString();
            txtSegundoParcial.Text = dgvNotas[7, posicion].Value.ToString();
        }

        /// <summary>
        /// Oculta una columna irrelevante.
        /// </summary>
        private void OcultarColumna()
        {
            dgvNotas.Columns[0].Visible = false;
            dgvNotas.Columns[11].Visible = false;
        }
    }
}
