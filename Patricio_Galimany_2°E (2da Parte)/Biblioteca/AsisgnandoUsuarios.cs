using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class AsisgnandoUsuarios<T>
    {
        /// <summary>
        /// Atributos.
        /// </summary>
        private T datos;

        /// <summary>
        /// Agrega un tipo.
        /// </summary>
        /// <param name="obj"></param>
        public void agregar(T obj)
        {
            datos = obj;
        }

        /// <summary>
        /// Obtiene un tipo.
        /// </summary>
        /// <returns></returns>
        public T getEmpleado()
        {
            return datos;
        }
    }
}
