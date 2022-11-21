using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Materias
    {
        /// <summary>
        /// Atributos.
        /// </summary>
        private int id;
        private Estado estado;
        private string nombre;
        private string cuatrimestre;
        private string profesor;
        private string? alumno;
        private double? primerParcial;
        private double? segundoParcial;
        private double? promedio;
        private string correlativa;
        private string? asistencia;
        private string materiaCorrelativa;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="estado"> (Estado) Recibe un estado. </param>
        /// <param name="nombre"> (String) Recibe un nombre. </param>
        /// <param name="cuatrimestre"> (String) Recibe un cuatrimestre. </param>
        /// <param name="profesor"> (String) Recibe un profesor. </param>
        /// <param name="alumno"> (String) Recibe un alumno. </param>
        /// <param name="primerParcial"> (Float) Recibe nota del primer parcial. </param>
        /// <param name="segundoParcial"> (Float) Recibe nota del segundo parcial. </param>
        /// <param name="promedio"> (Float) Recibe el promedio de los parciales. </param>
        /// <param name="correlativa"> (String) Recibe una correlativa. </param>
        /// <param name="asistencia"> (String) Recibe la asistencia. </param>
        /// <param name="materiaCorrelativa"> (String) Recibe la materia correlativa. </param>
        public Materias(int id, Estado estado, string nombre, string cuatrimestre, string profesor, string? alumno, double? primerParcial, double? segundoParcial, double? promedio, string correlativa, string? asistencia, string materiaCorrelativa)
        {
            this.id = id;
            this.estado = estado;
            this.nombre = nombre;
            this.cuatrimestre = cuatrimestre;
            this.profesor = profesor;
            this.alumno = alumno;
            this.primerParcial = primerParcial;
            this.segundoParcial = segundoParcial;
            this.promedio = promedio;
            this.correlativa = correlativa;
            this.asistencia = asistencia;
            this.materiaCorrelativa = materiaCorrelativa;
        }

        /// <summary>
        /// Propiedades (Estado, Nombre, Cuatrimestre, Profesor, Alumno, PrimeroParcial, SegundoParcial, Promedio, Correlativa, Asistencia y MateriaCorrelativa.).
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }
        public Estado Estado
        {
            get { return this.estado; }
        }
        public string Nombre
        {
            get { return this.nombre; }
        }
        public string Cuatrimestre
        {
            get { return this.cuatrimestre; }
        }
        public string Profesor
        {
            get { return this.profesor; }
        }
        public string? Alumno
        {
            get { return this.alumno; }
        }
        public double? PrimerParcial
        {
            get { return this.primerParcial; }
            set { this.primerParcial = value; }
        }
        public double? SegundoParcial
        {
            get { return this.segundoParcial; }
            set { this.segundoParcial = value; }
        }
        public double? Promedio
        {
            get { return this.promedio; }
            set { this.promedio = value; }
        }
        public string Correlativa
        {
            get { return this.correlativa; }
            set { this.correlativa = value; }
        }
        public string? Asistencia
        {
            get { return this.asistencia; }
        }
        public string MateriaCorrelativa
        {
            get { return this.materiaCorrelativa; }
        }
    }
}
