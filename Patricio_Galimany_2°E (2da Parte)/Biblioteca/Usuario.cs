using System;

namespace Biblioteca
{
    public abstract class Usuario
    {
        /// <summary>
        /// Atributos.
        /// </summary>
        private string usuario;
        private string contrasenia;
        private TipoUsuario tipoUsuario;


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="usuario"> (String) Recibe un usuario. </param>
        /// <param name="contrasenia"> (String) Recibe una contrasenia. </param>
        /// <param name="tipoUsuario"> (TipoUsuario) Recibe el tipo de usuario. </param>
        public Usuario(string usuario, string contrasenia, TipoUsuario tipoUsuario)
        {
            this.usuario = usuario;
            this.contrasenia = contrasenia;
            this.tipoUsuario = tipoUsuario;
        }

        /// <summary>
        /// Propiedades (Usuario, Contrasenia, TipoUsuario).
        /// </summary>
        public string Usuarios
        {
            get { return this.usuario; }
            set { this.usuario = value; }
        }
        public string Contrasenia
        {
            get { return this.contrasenia; }
            set { this.contrasenia = value; }
        }
        public TipoUsuario TipoUsuario
        {
            get { return this.tipoUsuario; }
            set { this.tipoUsuario = value; }
        }

        /// <summary>
        /// Valida la contrasenia.
        /// </summary>
        /// <param name="c1"> (String) Recibe una contrasenia. </param>
        /// <param name="c2"> (String) Recibe una contrasenia. </param>
        /// <returns> Retorna True si son iguales, False si es lo contrario. </returns>
        public abstract bool ValidarContrasenia(string c1, string c2);
    }
}
