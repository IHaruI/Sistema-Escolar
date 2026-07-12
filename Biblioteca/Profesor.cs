using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Profesor : Persona
    {
        /// <summary>
        /// Atributo.
        /// </summary>
        private static List<Materias> listaDeMateriasAsignadas = new List<Materias>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="nombre"> (String) Recibe un nombre. </param>
        /// <param name="usuario"> (String) Recibe un usuario. </param>
        /// <param name="contrasenia"> (String) Recibe contrasenia. </param>
        /// <param name="tipoUsuario"> (String) Recibe un tipo de usuario. </param>
        public Profesor(string nombre, string usuario, string contrasenia, TipoUsuario tipoUsuario) : base(nombre, usuario, contrasenia, tipoUsuario)
        {
            
        }

        /// <summary>
        /// Agrega las materias del profesor ingresado a una nueva lista.
        /// </summary>
        /// <param name="profesor"> (Persona) Recibe un profesor. </param>
        /// <returns> Retorna lista con las materias asignadas del profesor. </returns>
        public static List<Materias> MateriasAsignadas(Profesor profesor)
        {
            listaDeMateriasAsignadas.Clear();

            foreach (var item in Sql.LeerInscripciones())
            {
                if (item == profesor && item.Estado.ToString() == "Regular" && item.Promedio <= 6)
                {
                    listaDeMateriasAsignadas.Add(item);
                }
            }
            return listaDeMateriasAsignadas;
        }

        /// <summary>
        /// Asignas las notas de los examenes.
        /// </summary>
        /// <param name="primeraNota"> (Double) Recibe la primera nota. </param>
        /// <param name="segundaNota"> (Double) Recibe la segunda nota. </param>
        /// <param name="profesor"> (Profesor) Revibe un profesor. </param>
        /// <param name="nombreMateria"> (String) Recibe el nombre de la materia. </param>
        /// <param name="nombreAlumno"> (String) Recibe el nombre del alumno. </param>
        /// <returns> Retorna el promedio de las notas. </returns>
        public double AsignarNotas(double primeraNota, double segundaNota, Profesor profesor, string nombreMateria, string nombreAlumno)
        {
            double promedio = (primeraNota + segundaNota) / 2;

            if (promedio != 0)
            {
                foreach (var item in Sql.LeerInscripciones())
                {
                    if (promedio > 6 && item == profesor && item.Nombre == nombreMateria && item.Alumno == nombreAlumno)
                    {
                        AgregarNota(item, primeraNota, segundaNota, promedio);
                        break;
                    }
                    else if (promedio < 7 && item == profesor && item.Nombre == nombreMateria && item.Alumno == nombreAlumno)
                    {
                        AgregarNota(item, primeraNota, segundaNota, promedio);
                        break;
                    }
                }
            }
            return promedio;
        }

        /// <summary>
        /// Agrega las notas de los parciales.
        /// </summary>
        /// <param name="n"> (Materias) Recibe una materia. </param>
        /// <param name="pN"> (Double) Recibe la primera nota. </param>
        /// <param name="sN"> (Double) Recibe la segunda nota.</param>
        /// <param name="p"> (Double) Recibe el promedio. </param>
        public void AgregarNota(Materias n, double pN, double sN, double p)
        {
            Sql.ModificarNotas(n, pN, sN, p);
        }

        /// <summary>
        /// Sobrecarga de operadores
        /// </summary>
        /// <param name="m"> (Materias) Recibe una Materia. </param>
        /// <param name="p"> (Profesor) Recibe un Profesor. </param>
        /// <returns> Retorna True si son iguales, False si es lo contrario. </returns>
        public static bool operator ==(Materias m, Profesor p)
        {
            return m.Profesor == p.Nombre;
        }
        public static bool operator !=(Materias m, Profesor p)
        {
            return !(m.Profesor == p.Nombre);
        }
    }
}
