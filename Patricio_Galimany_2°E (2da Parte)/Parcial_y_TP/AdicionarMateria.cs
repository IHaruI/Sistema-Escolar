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
    public partial class AdicionarMateria : Form
    {
        /// <summary>
        /// Atributos.
        /// </summary>
        private string nuevaMateria;
        private string? profesor;
        private string? cuatrimestre;
        private string? correlativa;
        private string? materiaCorrelativa;
        List<Materias> materia = new List<Materias>();

        public AdicionarMateria()
        {
            InitializeComponent();
        }

        private void AdicionarMateria_Load(object sender, EventArgs e)
        {
            btnCrear.Enabled = false;
            cmbMaterias.Enabled = false;
            cmbCorrelativa.Enabled = false;

            foreach (var item in Sql.LeerUsuarios())
            {
                if (item.Value.TipoUsuario == TipoUsuario.Profesor)
                {
                    cmbProfesores.Items.Add(item.Value.Nombre);
                }
            }

            foreach (var item in Sql.LeerInscripciones())
            {
                if (!cmbMaterias.Items.Contains(item.Nombre))
                {
                    AdicionarMaterias(item.Nombre);
                }
            }

            materia = Sql.LeerMaterias();

            foreach (var item in materia)
            {
                if (!cmbMaterias.Items.Contains(item.Nombre))
                {
                    AdicionarMaterias(item.Nombre);
                }
            }
        }

        /// <summary>
        /// Adiciona las materias al combobox.
        /// </summary>
        /// <param name="nombreMateria"></param>
        public void AdicionarMaterias(string nombreMateria)
        {
            cmbMaterias.Items.Add(nombreMateria);
        }

        /// <summary>
        /// Propiedad.
        /// </summary>
        public string NuevaMateria
        {
            get { return this.nuevaMateria; }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (Admin.ValidarCadena(txtNuevaMateria.Text))
            {
                if (Admin.ValidarMateria(txtNuevaMateria.Text))
                {
                    this.nuevaMateria = txtNuevaMateria.Text;
                    Task tarea = Task.Run(() => Admin.CreacionDeMateria(txtNuevaMateria.Text, cuatrimestre, profesor, correlativa, materiaCorrelativa));

                    tarea.Wait();
                    MessageBox.Show("Se ha creado la nueva materia", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error. Esa materia ya existe.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error. Ingrese solo letras.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNuevaMateria_TextChanged(object sender, EventArgs e)
        {
            btnCrear.Enabled = Admin.ValidarCampo(txtNuevaMateria.Text, cmbCuatrimestre.Text, cmbProfesores.Text, correlativa, materiaCorrelativa);
        }

        private void cmdCuatrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCuatrimestre.Items.ToString() != String.Empty)
            {
                GuardarDatos("Cuatrimestre");

                if (cuatrimestre == "Primero")
                {
                    cmbCorrelativa.Enabled = false;
                    cmbMaterias.Enabled = false;
                    correlativa = "No";
                    materiaCorrelativa = "Ninguna";
                }
                else
                {
                    cmbCorrelativa.Enabled = true;
                    cmbMaterias.Enabled = Bloquear();
                }
            }

            btnCrear.Enabled = Admin.ValidarCampo(txtNuevaMateria.Text, cmbCuatrimestre.Text, cmbProfesores.Text, correlativa, materiaCorrelativa);
        }

        private void cmbProfesores_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCrear.Enabled = Admin.ValidarCampo(txtNuevaMateria.Text, cmbCuatrimestre.Text, cmbProfesores.Text, correlativa, materiaCorrelativa);

            if (cmbProfesores.Items.ToString() != String.Empty)
            {
                GuardarDatos("Profesor");
            }
        }

        private void cmbCorrelativa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCorrelativa.Items.ToString() != String.Empty)
            {
                GuardarDatos("Correlativa");

                if (Bloquear())
                {
                    cmbMaterias.Enabled = true;
                }
                else
                {
                    cmbMaterias.Enabled = false;
                    materiaCorrelativa = "Ninguna";
                }
            }

            btnCrear.Enabled = Admin.ValidarCampo(txtNuevaMateria.Text, cmbCuatrimestre.Text, cmbProfesores.Text, correlativa, materiaCorrelativa);
        }

        private void cmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterias.Items.ToString() != String.Empty)
            {
                GuardarDatos("materiaCorrelativa");
            }

            btnCrear.Enabled = Admin.ValidarCampo(txtNuevaMateria.Text, cmbCuatrimestre.Text, cmbProfesores.Text, correlativa, materiaCorrelativa);
        }

        /// <summary>
        /// Guarda el Profesor o Cuatrimestre seleccionado en el ComboBox.
        /// </summary>
        /// <param name="dato"> (string) Recibe que tipo de comboBox fue seleccionado. </param>
        private void GuardarDatos(string dato)
        {
            int indice;

            switch (dato)
            {
                case "Cuatrimestre":
                    indice = cmbCuatrimestre.SelectedIndex;
                    cuatrimestre = cmbCuatrimestre.Items[indice].ToString();
                    break;
                case "Profesor":
                    indice = cmbProfesores.SelectedIndex;
                    profesor = cmbProfesores.Items[indice].ToString();
                    break;
                case "Correlativa":
                    indice = cmbCorrelativa.SelectedIndex;
                    correlativa = cmbCorrelativa.Items[indice].ToString();
                    break;
                case "materiaCorrelativa":
                    indice = cmbMaterias.SelectedIndex;
                    materiaCorrelativa = cmbMaterias.Items[indice].ToString();
                    break;
            }
        }

        /// <summary>
        /// Bloquea un boton depemdiendo de los cuatrimestres.
        /// </summary>
        /// <returns></returns>
        public bool Bloquear()
        {
            if (correlativa == "Si")
            {
                return true;
            }
            return false;
        }
    }
}
