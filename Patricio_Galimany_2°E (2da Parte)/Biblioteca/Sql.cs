using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Sql : IDatos
    {
        /// <summary>
        /// Atributos.
        /// </summary>
        private static SqlConnection sqlConnection;
        private static SqlCommand sqlCommand;

        /// <summary>
        /// Constructor estatico.
        /// </summary>
        static Sql()
        {
            sqlConnection = new SqlConnection(@"Data Source = .; Database = Parcial_Dos; Trusted_Connection = True;");
            sqlCommand = new SqlCommand();

            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = System.Data.CommandType.Text;
        }

        /// <summary>
        /// Trae de la base de datos a todos los usuarios.
        /// </summary>
        /// <returns> Retorna una lista de clave/valor de los usuarios. </returns>
        public static Dictionary<string, Persona> LeerUsuarios()
        {
            Dictionary<string, Persona> list = new Dictionary<string, Persona>();

            try
            {
                sqlCommand.CommandText = "select * from Usuarios";
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    string nombre = dataReader.GetString(1);
                    string usuario = dataReader.GetString(2);
                    string contrasenia = dataReader.GetString(3);
                    string tipoUsuario = dataReader.GetString(4);

                    if (tipoUsuario == "Admin")
                    {
                        //list.Add(usuario, new Admin(nombre, usuario, contrasenia, TipoUsuario.Admin));

                        AsisgnandoUsuarios<Admin> admin = new AsisgnandoUsuarios<Admin>();
                        admin.agregar(new Admin(nombre, usuario, contrasenia, TipoUsuario.Admin));
                        list.Add(usuario, admin.getEmpleado());
                    }
                    else if (tipoUsuario == "Profesor")
                    {
                        //list.Add(usuario, new Profesor(nombre, usuario, contrasenia, TipoUsuario.Profesor));

                        AsisgnandoUsuarios<Profesor> profesor = new AsisgnandoUsuarios<Profesor>();
                        profesor.agregar(new Profesor(nombre, usuario, contrasenia, TipoUsuario.Profesor));
                        list.Add(usuario, profesor.getEmpleado());
                    }
                    else if (tipoUsuario == "Alumno")
                    {
                        //list.Add(usuario, new Alumno(nombre, usuario, contrasenia, TipoUsuario.Alumno));

                        AsisgnandoUsuarios<Alumno> alumno = new AsisgnandoUsuarios<Alumno>();
                        alumno.agregar(new Alumno(nombre, usuario, contrasenia, TipoUsuario.Alumno));
                        list.Add(usuario, alumno.getEmpleado());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return list;
        }

        /// <summary>
        /// Trae de la base de datos todas las inscripciones.
        /// </summary>
        /// <returns> Retorna una lista de todas las inscripciones. </returns>
        public static List<Materias> LeerInscripciones()
        {
            List<Materias> list = new List<Materias>();

            try
            {
                sqlCommand.CommandText = "select Id, I.Estados, I.Cuatrimestre, I.Profesor, Alumno, I.PrimerParcial, I.SegundoParcial, " +
                    "I.Promedio, I.Correlativa, I.Asistencia, I.MateriaCorrelativa, I.Id_Materias, M.Id_Materias, M.Nombre from " +
                    "Inscripcion I inner join Materias M on I.Id_Materias = M.Id_Materias";

                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                list = LeerDatos(dataReader);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return list;
        }

        /// <summary>
        /// Trae de la base de datos las inscripciones de la materia buscada.
        /// </summary>
        /// <param name="nombreMateria"> (String) Recibe la materia a buscar. </param>
        /// <returns> Retorna una lista de las materias que se esta buscando. </returns>
        public static List<Materias> LeerInscripcionesPorMateria(string nombreMateria)
        {
            List<Materias> list = new List<Materias>();

            try
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();
                sqlCommand.CommandText = "select Id, I.Estados, I.Cuatrimestre, I.Profesor, Alumno, I.PrimerParcial, I.SegundoParcial, " +
                    "I.Promedio, I.Correlativa, I.Asistencia, I.MateriaCorrelativa, I.Id_Materias, M.Id_Materias, M.Nombre from " +
                    "Inscripcion I inner join Materias M on I.Id_Materias = M.Id_Materias where M.Nombre = @nombreMateria";

                sqlCommand.Parameters.AddWithValue("@nombreMateria", nombreMateria);

                sqlCommand.ExecuteNonQuery();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                list = LeerDatos(dataReader);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return list;
        }

        /// <summary>
        /// Lee los datos de la base de datos.
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns> Retorna una lista con los datos de las inscripciones. </returns>
        public static List<Materias> LeerDatos(SqlDataReader dataReader)
        {
            List<Materias> list = new List<Materias>();

            while (dataReader.Read())
            {
                int id = dataReader.GetInt32(0);
                Estado estado = TipoDeEstado(dataReader.GetString(1));
                string cuatrimestre = dataReader.GetString(2);
                string profesor = dataReader.GetString(3);
                string alumno = dataReader.GetString(4);
                double primerParcial = dataReader.GetDouble(5);
                double segundoParcial = dataReader.GetDouble(6);
                double promedio = dataReader.GetDouble(7);
                string correlativa = dataReader.GetString(8);
                string asistencia = dataReader.GetString(9);
                string materiaCorrelativa = dataReader.GetString(10);
                string nombre = dataReader.GetString(13);

                Materias materias = new Materias(id, estado, nombre, cuatrimestre, profesor, alumno, primerParcial, segundoParcial, promedio, correlativa, asistencia, materiaCorrelativa);

                list.Add(materias);
            }
            return list;
        }

        /// <summary>
        /// Cambia el estado en la base de datos.
        /// </summary>
        /// <param name="estado"> (String) Recibe un estado. </param>
        /// <param name="id"> (Int) Recibe un id. </param>
        public static void CambiarEstados(string estado, int id)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();

                sqlCommand.CommandText = "update Inscripcion set Estados = @estado where Id = @id";
                sqlCommand.Parameters.AddWithValue("@estado", estado);
                sqlCommand.Parameters.AddWithValue("@id", id);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Trae de la base de datos todas las materias.
        /// </summary>
        /// <returns> Retorna una lista de todas las materias. </returns>
        public static List<Materias> LeerMaterias()
        {
            List<Materias> list = new List<Materias>();

            try
            {
                sqlCommand.CommandText = "select * from Materias";
                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    int id = dataReader.GetInt32(0);
                    Estado estado = TipoDeEstado(dataReader.GetString(1));
                    string nombre = dataReader.GetString(2);
                    string cuatrimestre = dataReader.GetString(3);
                    string profesor = dataReader.GetString(4);
                    string correlativa = dataReader.GetString(9);
                    string materiaCorrelativa = dataReader.GetString(11);

                    string? alumno = null;
                    double? primerParcial = null;
                    double? segundoParcial = null;
                    double? promedio = null;
                    string? asistencia = null;

                    if (dataReader["Alumnos"] != DBNull.Value)
                    {
                        alumno = dataReader.GetString(5);
                    }

                    if (dataReader["PrimerParcial"] != DBNull.Value)
                    {
                        primerParcial = dataReader.GetDouble(6);
                    }

                    if (dataReader["SegundoParcial"] != DBNull.Value)
                    {
                        segundoParcial = dataReader.GetDouble(7);
                    }

                    if (dataReader["Promedio"] != DBNull.Value)
                    {
                        promedio = dataReader.GetDouble(8);
                    }

                    if (dataReader["Asistencia"] != DBNull.Value)
                    {
                        asistencia = dataReader.GetString(10);
                    }

                    Materias materias = new Materias(id, estado, nombre, cuatrimestre, profesor, alumno, primerParcial, segundoParcial, promedio, correlativa, asistencia, materiaCorrelativa);

                    list.Add(materias);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
            return list;
        }

        /// <summary>
        /// Define el tipo de estado que le corresponde a cada inscripcion.
        /// </summary>
        /// <param name="estado"> (String) Recibe un estado. </param>
        /// <returns> Retorna un Estado. </returns>
        public static Estado TipoDeEstado(string estado)
        {
            Estado? retorno = null;

            switch (estado)
            {
                case "Regular":
                    retorno = Estado.Regular;
                    break;

                case "Libre":
                    retorno = Estado.Libre;
                    break;

                case "Pendiente":
                    retorno = Estado.Pendiente;
                    break;
            }
            return (Estado)retorno;
        }

        /// <summary>
        /// Guarda en la base de datos una nueva materia.
        /// </summary>
        /// <param name="estado"> (String) Recibe un estado. </param>
        /// <param name="nuevaMateria"> (String) Recibe una nueva materia</param>
        /// <param name="cuatrimestre"> (String) Recibe un cuatrimestre. </param>
        /// <param name="profesor"> (String) Recibe un profesor. </param>
        /// <param name="alumno"> (String) Recibe una alumno. </param>
        /// <param name="correlativa"> (String) Recibe una correlativa. </param>
        /// <param name="asistencia"> (String) Recibe una asistencia. </param>
        /// <param name="materiaCorrelativa"> (String) Recibe una materia correlativa. </param>
        public void GuardarDatos(string estado, string nuevaMateria, string cuatrimestre, string profesor, string alumno, string correlativa, string asistencia, string materiaCorrelativa)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();

                sqlCommand.CommandText = "insert into Materias (Estados, Nombre, Cuatrimestre, Profesor, Alumnos, PrimerParcial, " +
                    "SegundoParcial, Promedio, Correlativa, Asistencia, MateriaCorrelativa) values (@estado, @nuevaMateria, @cuatrimestre, " +
                    "@profesor, @alumno, null, null, null, @correlativa, @asistencia, @materiaCorrelativa)";

                sqlCommand.Parameters.AddWithValue("@estado", estado);
                sqlCommand.Parameters.AddWithValue("@nuevaMateria", nuevaMateria);
                sqlCommand.Parameters.AddWithValue("@cuatrimestre", cuatrimestre);
                sqlCommand.Parameters.AddWithValue("@profesor", profesor);
                sqlCommand.Parameters.AddWithValue("@alumno", alumno);
                sqlCommand.Parameters.AddWithValue("@correlativa", correlativa);
                sqlCommand.Parameters.AddWithValue("@asistencia", asistencia);
                sqlCommand.Parameters.AddWithValue("@materiaCorrelativa", materiaCorrelativa);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Guarda en la base de datos una nueva inscripcion.
        /// </summary>
        /// <param name="estado"> (String) Recibe un estado. </param>
        /// <param name="nuevaMateria"> (String) Recibe una nueva materia. </param>
        /// <param name="cuatrimestre"> (String) Recibe un cuatrimestre. </param>
        /// <param name="profesor"> (String) Recibe un profesor. </param>
        /// <param name="alumno"> (String) Recibe un alumno. </param>
        /// <param name="correlativa"> (String) Recibe una correlativa. </param>
        /// <param name="asistencia"> (String) Recibe una asistencia. </param>
        /// <param name="materiaCorrelativa"> (String) Recibe una materia correlativa. </param>
        /// <param name="id"> (String) Recibe un id. </param>
        public void GuardarDatos(string estado, string nuevaMateria, string cuatrimestre, string profesor, string alumno, string correlativa, string asistencia, string materiaCorrelativa, int id)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();

                sqlCommand.CommandText = "insert into Inscripcion (Estados, Cuatrimestre, Profesor, Alumno, PrimerParcial, " +
                    "SegundoParcial, Promedio, Correlativa, Asistencia, MateriaCorrelativa, Id_Materias) values (@estado, @cuatrimestre," +
                    "@profesor, @alumno, 0, 0, 0, @correlativa, @asistencia, @materiaCorrelativa, @id)";

                sqlCommand.Parameters.AddWithValue("@estado", estado);
                sqlCommand.Parameters.AddWithValue("@cuatrimestre", cuatrimestre);
                sqlCommand.Parameters.AddWithValue("@profesor", profesor);
                sqlCommand.Parameters.AddWithValue("@alumno", alumno);
                sqlCommand.Parameters.AddWithValue("@correlativa", correlativa);
                sqlCommand.Parameters.AddWithValue("@asistencia", asistencia);
                sqlCommand.Parameters.AddWithValue("@materiaCorrelativa", materiaCorrelativa);
                sqlCommand.Parameters.AddWithValue("@id", id);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Crea un nuevo usuario en la base de datos.
        /// </summary>
        /// <param name="nombreyApelldio"> (String) Recibe un nombre y apellido. </param>
        /// <param name="usuario"> (String) Recibe un usuario. </param>
        /// <param name="contrasenia"> (String) Recibe una contrasenia. </param>
        /// <param name="tipoUsuario"> (String) Recibe un tipo de usuario. </param>
        public static void CrearUsuario(string nombreyApelldio, string usuario, string contrasenia, string tipoUsuario)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();

                sqlCommand.CommandText = "insert into Usuarios (Nombre_Y_Apellido, Usuario, Contraseña, TipoUsuario) values (@nombreyApelldio, @usuario, @contrasenia, @tipoUsuario)";

                sqlCommand.Parameters.AddWithValue("@nombreyApelldio", nombreyApelldio);
                sqlCommand.Parameters.AddWithValue("@usuario", usuario);
                sqlCommand.Parameters.AddWithValue("@contrasenia", contrasenia);
                sqlCommand.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        /// <summary>
        /// Modifica las notas de la base de datos.
        /// </summary>
        /// <param name="n"> (Materias) Recibe una Materia. </param>
        /// <param name="pN"> (Double) Recibe la primera nota. </param>
        /// <param name="sN"> (Double) Recibe la segunda nota. </param>
        /// <param name="p"> (Double) Recibe el promedio. </param>
        public static void ModificarNotas(Materias n, double pN, double sN, double p)
        {
            try
            {
                sqlCommand.Parameters.Clear();
                sqlConnection.Open();

                sqlCommand.CommandText = "update Inscripcion set PrimerParcial = @pN, SegundoParcial = @sN, Promedio = @p where Id = @id";
                sqlCommand.Parameters.AddWithValue("@pN", pN);
                sqlCommand.Parameters.AddWithValue("@sN", sN);
                sqlCommand.Parameters.AddWithValue("@p", p);
                sqlCommand.Parameters.AddWithValue("@id", n.Id);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlConnection.State == System.Data.ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
