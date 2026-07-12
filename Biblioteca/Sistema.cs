using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class Sistema
    {
        /// <summary>
        /// Verifica al usuario que intenta ingresar al sistema.
        /// </summary>
        /// <param name="usuario"> (String) Recibe un usuario. </param>
        /// <param name="contrasenia"> (String) Recibe una contrasenia. </param>
        /// <returns> Retorna al usuario, si no existe retorna null. </returns>
        public static Persona ValidarUsuario(string usuario, string contrasenia)
        {
            Persona retorno = null;

            foreach (KeyValuePair<string, Persona> user in Sql.LeerUsuarios())
            {
                if (user.Key == usuario && user.Value.ValidarContrasenia(contrasenia, user.Value.Contrasenia))
                {
                    retorno = user.Value;
                    break;
                }
            }
            return retorno;
        }
    }
}
