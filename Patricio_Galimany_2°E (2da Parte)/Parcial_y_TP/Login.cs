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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void btnAdministrador_Click_1(object sender, EventArgs e)
        {
            txtUsuario.Text = "Admin";
            txtContraseña.Text = "12345";
        }

        private void btnProfesor_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "Robin001";
            txtContraseña.Text = "1234";
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "AndreaR";
            txtContraseña.Text = "123";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = Sistema.ValidarUsuario(txtUsuario.Text, txtContraseña.Text);

                if (usuario.TipoUsuario == TipoUsuario.Admin)
                {
                    Administrador admin = new Administrador(usuario);
                    admin.ShowDialog();
                }
                else if (usuario.TipoUsuario == TipoUsuario.Profesor)
                {
                    Profesores profesores = new Profesores(usuario);
                    profesores.ShowDialog();
                }
                else if (usuario.TipoUsuario == TipoUsuario.Alumno)
                {
                    Alumnos alumnos = new Alumnos(usuario);
                    alumnos.ShowDialog();
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("No se ha encontrado al usuario.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
