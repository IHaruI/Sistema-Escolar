using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    /// <summary>
    /// Interfases
    /// </summary>
    public interface IDatos
    {
        public void GuardarDatos(string estado, string nuevaMateria, string cuatrimestre, string profesor, string alumno, string correlativa, string asistencia, string materiaCorrelativa);
        public void GuardarDatos(string estado, string nuevaMateria, string cuatrimestre, string profesor, string alumno, string correlativa, string asistencia, string materiaCorrelativa, int id);
    }
}
