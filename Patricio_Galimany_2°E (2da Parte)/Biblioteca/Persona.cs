using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Persona : Usuario
    {
        /// <summary>
        /// Atributo.
        /// </summary>
        private string nombre;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="nombre"> (String) Recibe un nombre. </param>
        /// <param name="usuario"> (String) Recibe un usuario. </param>
        /// <param name="contrasenia"> (String) Recibe una contrania. </param>
        /// <param name="tipoUsuario"> (TipoUsuario) Recibe un tipo de usuario. </param>
        public Persona(string nombre, string usuario, string contrasenia, TipoUsuario tipoUsuario) : base(usuario, contrasenia, tipoUsuario)
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Proopiedades.
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        /// <summary>
        /// Comprueba las contrasenias recibidas sin son iguales.
        /// </summary>
        /// <param name="c1"> (String) Recibe una contrasenia. </param>
        /// <param name="c2"> (String) Recibe una contrasenia. </param>
        /// <returns> Retorna True si son iguales, False si no es asi. </returns>
        public override bool ValidarContrasenia(string c1, string c2)
        {
            return c1 == c2;
        }
    }
}
