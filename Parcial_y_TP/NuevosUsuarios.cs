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
    public partial class NuevosUsuarios : Form
    {
        /// <summary>
        /// Atributo.
        /// </summary>
        private string? tipoUsuario;

        public NuevosUsuarios()
        {
            InitializeComponent();
        }

        private void NuevosUsuarios_Load(object sender, EventArgs e)
        {
            btnCrearUsuario.Enabled = false;
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (Admin.ValidarCadena(txtNombreYApellido.Text))
            {
                if (Admin.ValidarUsuario(txtUsuario.Text))
                {
                    Task tarea = Task.Run(() => Admin.CreacionDeNuevoUsuario(txtNombreYApellido.Text, txtUsuario.Text, txtContraseña.Text, tipoUsuario));
                    tarea.Wait();

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error. Ya hay un usuario registrado con ese nombre.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Error. Ingrese un nombre valido.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtNombreYApellido_TextChanged(object sender, EventArgs e)
        {
            btnCrearUsuario.Enabled = Admin.ValidarCampo(txtNombreYApellido.Text, txtUsuario.Text, txtContraseña.Text, cmdTipoDeUsuario.Text);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            btnCrearUsuario.Enabled = Admin.ValidarCampo(txtNombreYApellido.Text, txtUsuario.Text, txtContraseña.Text, cmdTipoDeUsuario.Text);
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            btnCrearUsuario.Enabled = Admin.ValidarCampo(txtNombreYApellido.Text, txtUsuario.Text, txtContraseña.Text, cmdTipoDeUsuario.Text);
        }

        private void cmdTipoDeUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCrearUsuario.Enabled = Admin.ValidarCampo(txtNombreYApellido.Text, txtUsuario.Text, txtContraseña.Text, cmdTipoDeUsuario.Text);

            if (cmdTipoDeUsuario.Items.ToString() != String.Empty)
            {
                int indice = cmdTipoDeUsuario.SelectedIndex;
                tipoUsuario = cmdTipoDeUsuario.Items[indice].ToString();
            }
        }
    }
}
