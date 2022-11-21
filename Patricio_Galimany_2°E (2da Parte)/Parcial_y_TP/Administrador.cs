using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;
using static System.Environment;
using Biblioteca;

namespace Parcial_y_TP
{
    public partial class Administrador : Form
    {
        /// <summary>
        /// Atributos.
        /// </summary>
        List<Materias> lista2 = new List<Materias>();
        private int indice1;
        private int indice2;
        private Admin admin;
        private SaveFileDialog saveFileDialog;

        public Administrador(Usuario administrador)
        {
            InitializeComponent();
            this.admin = administrador as Admin;

        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            btnInscribirAlumnos.Enabled = false;
            btnExportar.Enabled = false;
            txtAdministrador.Text = admin.Nombre;

            foreach (var item in Sql.LeerInscripciones())
            {
                if (!cmbMaterias.Items.Contains(item.Nombre))
                {
                    cmbMaterias.Items.Add(item.Nombre);
                }
            }

            foreach (KeyValuePair<string, Persona> item in Sql.LeerUsuarios())
            {
                if (!cmbAlumnos.Items.Contains(item.Value.Nombre) && item.Value.TipoUsuario == TipoUsuario.Alumno)
                {
                    cmbAlumnos.Items.Add(item.Value.Nombre);
                }
            }
        }

        private void cmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExportar.Enabled = true;
            indice1 = cmbMaterias.SelectedIndex;

            string? nombre = cmbMaterias.Items[indice1].ToString();
            dgvDatos.DataSource = null;
            lista2 = Sql.LeerInscripcionesPorMateria(nombre);
            dgvDatos.DataSource = lista2;
            OcultarColumnas();
        }

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string nuevoEstado = Microsoft.VisualBasic.Interaction.InputBox("Ingrese nuevo estado", "Cambio de estado");

                if (nuevoEstado != "" && (nuevoEstado == "Regular" || nuevoEstado == "Libre"))
                {
                    int id = Convert.ToInt32(dgvDatos.Rows[e.RowIndex].Cells[0].Value);
                    Sql.CambiarEstados(nuevoEstado, id);
                }
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarMateria adicionar = new AdicionarMateria();

            DialogResult resultado = adicionar.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                cmbMaterias.Items.Add(adicionar.NuevaMateria);
            }
            else
            {
                MessageBox.Show("Se ha candelado el registro de la nueva materia.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCrearUsuarios_Click(object sender, EventArgs e)
        {
            NuevosUsuarios nuevosUsuarios = new NuevosUsuarios();

            DialogResult resultado = nuevosUsuarios.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                MessageBox.Show("Se ha agregado un nuevo usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Se ha candelado el registro del nuevo usuario.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnInscribirAlumnos_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, Persona> item in Sql.LeerUsuarios())
            {
                if (item.Value.Nombre == cmbAlumnos.Items[indice2].ToString())
                {
                    Alumnos alumnos = new Alumnos(item.Value);
                    alumnos.ShowDialog();
                    break;
                }
            }
        }

        private void cmbAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            indice2 = cmbAlumnos.SelectedIndex;
            btnInscribirAlumnos.Enabled = true;
        }

        /// <summary>
        /// Oculta una columna irrelevante.
        /// </summary>
        private void OcultarColumnas()
        {
            dgvDatos.Columns[0].Visible = false;
            dgvDatos.Columns[11].Visible = false;
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Estadistica estadisticas = new Estadistica();

            estadisticas.ShowDialog();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo JSON |*.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;
                Admin.ExportarMateria(lista2, path);
                MessageBox.Show("Se ha exportado correctamente.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
