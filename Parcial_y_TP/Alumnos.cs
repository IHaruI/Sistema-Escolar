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
    public partial class Alumnos : Form
    {
        /// <summary>
        /// Atributos.
        /// </summary>
        private Alumno alumno;
        private int limite = 0;
        private int posicion;
        private string? asistencia;
        private string? correlativa;
        
        public Alumnos(Usuario alumno)
        {
            InitializeComponent();
            this.alumno = alumno as Alumno;
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {
            Materias();
            MateriasAInscribirse();

            txtAlumno.Text = alumno.Nombre;
            btnInscripcion.Enabled = false;
        }

        /// <summary>
        /// Carga las materias del usuario registrado.
        /// </summary>
        public void Materias()
        {
            alumno.ObtenerMaterias(alumno);

            dgvMateriasAprobadas.DataSource = null;
            dgvMateriasAprobadas.DataSource = alumno.MateriasAprobadas;
            OcultarColumnas(dgvMateriasAprobadas);
        }

        /// <summary>
        /// Carga las materias disponibles a registrarse.
        /// </summary>
        public void MateriasAInscribirse()
        {
            dgvInscripciones.DataSource = null;
            dgvInscripciones.DataSource = alumno.Inscripciones;
            OcultarColumnas(dgvInscripciones);
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            int i = -1;

            if (limite < 2)
            {
                Task task = Task.Run(() => i = alumno.InscripcionesAMaterias(txtMateria.Text, txtAlumno.Text, asistencia, txtCuatrimestre.Text, correlativa));

                task.Wait();
            }
            else
            {
                MessageBox.Show("Limite alcanzado.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                i = -1;
            }
            if (i == 0)
            {
                MessageBox.Show("Aun no se ha inscripto a su correlativa.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (i == 1)
            {
                MessageBox.Show("Se ha inscripto correctamente.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Materias();
                MateriasAInscribirse();
                Limpiar();
                limite++;
            }
            else if (i == 2)
            {
                MessageBox.Show("Error. Primero debe haber aprobado su correlativa.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Limpia los textBoxs.
        /// </summary>
        public void Limpiar()
        {
            txtMateria.Text = "";
            txtCuatrimestre.Text = "";
            txtProfesor.Text = "";
            btnInscripcion.Enabled = false;
        }

        private void dgvInscripciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posicion = dgvInscripciones.CurrentRow.Index;

            txtMateria.Text = dgvInscripciones[2, posicion].Value.ToString();
            txtCuatrimestre.Text = dgvInscripciones[3, posicion].Value.ToString();
            txtProfesor.Text = dgvInscripciones[4, posicion].Value.ToString();
            correlativa = dgvInscripciones[9, posicion].Value.ToString();

            btnInscripcion.Enabled = alumno.ValidarCampo(txtMateria.Text, txtCuatrimestre.Text, txtProfesor.Text, cmbAsistencia.Text);
        }

        private void cmbAsistencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnInscripcion.Enabled = alumno.ValidarCampo(txtMateria.Text, txtCuatrimestre.Text, txtProfesor.Text, cmbAsistencia.Text);

            if (cmbAsistencia.Items.ToString() != String.Empty)
            {
                int indice = cmbAsistencia.SelectedIndex;
                asistencia = cmbAsistencia.Items[indice].ToString();
            }
        }

        /// <summary>
        /// Oculta una columna irrelevante.
        /// </summary>
        /// <param name="dataGridView"> (DataGridView) Recibe un datagridview. </param>
        public void OcultarColumnas(DataGridView dataGridView)
        {
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[11].Visible = false;
        }
    }
}
