using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Alumno : Persona
    {
        /// <summary>
        /// Atributos.
        /// </summary>
        private List<Materias> materiasAprobadas;
        private List<Materias> inscripciones;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="nombre"> (String) Recibe un nombre. </param>
        /// <param name="usuario"> (String) Recibe un usuario. </param>
        /// <param name="contrasenia"> (String) Recibe una contrasenia. </param>
        /// <param name="tipoUsuario"> (TipoUsuario) Recibe un tipo de usuario. </param>
        public Alumno(string nombre, string usuario, string contrasenia, TipoUsuario tipoUsuario) : base(nombre, usuario, contrasenia, tipoUsuario)
        {
            this.materiasAprobadas = new List<Materias>();
            this.inscripciones = new List<Materias>();
        }

        /// <summary>
        /// Propiedades.
        /// </summary>
        public List<Materias> MateriasAprobadas
        {
            get { return this.materiasAprobadas; }
        }

        public List<Materias> Inscripciones
        {
            get { return this.inscripciones; }
        }

        /// <summary>
        /// Obtiene las materias del alumno registrado.
        /// </summary>
        /// <param name="alumno"> (Alumno) Recibe el alumno ingresado. </param>
        public void ObtenerMaterias(Alumno alumno)
        {
            materiasAprobadas.Clear();
            inscripciones.Clear();

            foreach (var item in Sql.LeerInscripciones())
            {
                if (item.Alumno == alumno.Nombre)
                {
                    materiasAprobadas.Add(item);
                }
            }
            
            int aux = 0;

            string[] materias = new string[materiasAprobadas.Count];

            foreach (var item in materiasAprobadas)
            {
                materias[aux] = item.Nombre;
                aux++;
            }

            foreach (var item in Sql.LeerMaterias())
            {
                if (!materias.Contains(item.Nombre) && item.Id != 10)
                {
                    inscripciones.Add(item);
                }
            }
        }

        /// <summary>
        /// Inscribe a el alumno a las materias.
        /// </summary>
        /// <param name="nombreMateria"> (String) Recibe una materia. </param>
        /// <param name="alumno"> (String) Recibe un alumno. </param>
        /// <param name="asistencia"> (String) Recibe una asistencia. </param>
        /// <param name="cuatrimestre"> (String) Recibe un cuatrimestre. </param>
        /// <param name="correlativa"> (String) Recibe la correlativa. </param>
        /// <returns> Retorna diferentes valores dependiendo de las materias nuevas o si ha aprobado las correlativas. </returns>
        public int InscripcionesAMaterias(string nombreMateria, string alumno, string asistencia, string cuatrimestre,  string correlativa)
        {
            int retorno = 0;
            int aux = 1;
            string materiaCorrelativa = "Ninguna";

            foreach (var item in Inscripciones)
            {
                if (item.Nombre == nombreMateria)
                {
                    materiaCorrelativa = item.MateriaCorrelativa;
                    break;
                }
            }

            if (MateriasAprobadas.Count != 0)
            {
                foreach (var item in MateriasAprobadas)
                {
                    if (item.Nombre == materiaCorrelativa && item.Promedio > 6)
                    {
                        retorno = AsignacionAMaterias(nombreMateria, alumno, asistencia, materiaCorrelativa, correlativa);
                        break;
                    }
                    else if (item.Nombre == materiaCorrelativa && item.Promedio <= 6)
                    {
                        retorno = 2;
                        break;
                    }
                    else if (MateriasAprobadas.Count == aux && item.Nombre != nombreMateria && cuatrimestre == "Primero")
                    {
                        retorno = AsignacionAMaterias(nombreMateria, alumno, asistencia, materiaCorrelativa, correlativa);
                        break;
                    }
                    else if (MateriasAprobadas.Count == aux && item.Nombre != nombreMateria && cuatrimestre != "Primero")
                    {
                        retorno = AsignacionAMaterias(nombreMateria, alumno, asistencia, materiaCorrelativa, correlativa);
                    }
                    aux++;
                }
            }
            else
            {
                foreach(var item in Inscripciones)
                {
                    if (item.MateriaCorrelativa == "Ninguna" && cuatrimestre == "Primero" && item.Nombre == nombreMateria)
                    {
                        retorno = AsignacionAMaterias(nombreMateria, alumno, asistencia, materiaCorrelativa, correlativa);
                    }
                }
            }

            return retorno;
        }

        /// <summary>
        /// Asigna a el alumno a una materia.
        /// </summary>
        /// <param name="nombreMateria"> (String) Recibe una materia. </param>
        /// <param name="alumno"> (String) Recibe un alumno. </param>
        /// <param name="asistencia"> (String) Recibe una asistencia. </param>
        /// <param name="materiaCorrelativa"> (String) Recibe la materia correlativa. </param>
        /// <param name="correlativa"> (String) Recibe la correlativa. </param>
        /// <returns> Retorna 1 si se ha inscripto a la materia, 0 si no. </returns>
        public int AsignacionAMaterias(string nombreMateria, string alumno, string asistencia, string materiaCorrelativa, string correlativa)
        {
            int retorno = 0;

            foreach (var item in Inscripciones)
            {
                if (item.Nombre == nombreMateria)
                {
                    Inscribir(item, alumno, asistencia, materiaCorrelativa, correlativa);
                    retorno = 1;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Inscribe al alumno a la materia.
        /// </summary>
        /// <param name="item"> (Materias) Recibe una Materia. </param>
        /// <param name="alumno"> (String) Recibe un alumno. </param>
        /// <param name="asistencia"> (String) Recibe una asistencia. </param>
        /// <param name="correlativa"> (String) Recibe la correlativa. </param>
        /// <param name="materiaCorrelativa"> (Materias) Recibe la materia correlativa. </param>
        public void Inscribir(Materias item, string alumno, string asistencia, string materiaCorrelativa, string correlativa)
        {
            Sql sql = new Sql();

            sql.GuardarDatos("Regular", item.Nombre, item.Cuatrimestre, item.Profesor, alumno, correlativa, asistencia, materiaCorrelativa, item.Id);
        }

        /// <summary>
        /// Valida si se ha llenado todos los campos.
        /// </summary>
        /// <param name="materia"> (String) Recibe una materia. </param>
        /// <param name="cuatrimestre"> (String) Recibe un cuatrimestre. </param>
        /// <param name="profesor"> (String) Recibe un profesor. </param>
        /// <param name="asistencia"> (String) Recibe una asistencia. </param>
        /// <returns> Retorna True si se llenaron los campos, False si no fue asi. </returns>
        public bool ValidarCampo(string materia, string cuatrimestre, string profesor, string asistencia)
        {
            return !string.IsNullOrEmpty(materia) && !string.IsNullOrEmpty(cuatrimestre) && !string.IsNullOrEmpty(profesor) && !string.IsNullOrEmpty(asistencia);
        }
    }
}
