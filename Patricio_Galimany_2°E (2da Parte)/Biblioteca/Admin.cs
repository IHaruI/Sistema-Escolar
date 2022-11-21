using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Admin : Persona
    {
        public delegate void ExportarDatos(string path, string contenido);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="nombre"> (String) Recibe un nombre. </param>
        /// <param name="usuario"> (String) Recibe un usuario. </param>
        /// <param name="contrasenia"> (String) Recibe una contrasenia. </param>
        /// <param name="tipoUsuario"> (TipoUsuario) Recibe el tipo de usuario. </param>
        public Admin(string nombre, string usuario, string contrasenia, TipoUsuario tipoUsuario) : base(nombre, usuario, contrasenia, tipoUsuario)
        {

        }

        /// <summary>
        /// Valida si la nueva materia esta registrada en el sistema.
        /// </summary>
        /// <param name="nuevaMateria"> (String) Recibe la nueva materia. </param>
        /// <returns> Retorna True si no existe la nueva materia, False si existe. </returns>
        public static bool ValidarMateria(string nuevaMateria)
        {
            bool retorno = true;

            foreach (var item in Sql.LeerInscripciones())
            {
                if (item.Nombre == nuevaMateria)
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Crea una materia.
        /// </summary>
        /// <param name="nuevaMateria"> (String) Recibe una nueva materia. </param>
        /// <param name="cuatrimestre"> (String) Recibe un cuatrimestre. </param>
        /// <param name="profesor"> (String) Recibe un profesor. </param>
        /// <param name="correlativa"> (String) Recibe una correlativa. </param>
        /// <param name="materiaCorrelativa"> (String) Recibe la materia correlativa. </param>
        public static void CreacionDeMateria(string nuevaMateria, string cuatrimestre, string profesor, string correlativa, string materiaCorrelativa)
        {
            Sql sql = new Sql();

            sql.GuardarDatos("Pendiente", nuevaMateria, cuatrimestre, profesor, string.Empty, correlativa, string.Empty, materiaCorrelativa);
        }

        /// <summary>
        /// Valida que se haya ingresado datos.
        /// </summary>
        /// <param name="nombreyApellido"> (String)  Recibe una nueva materia. </param>
        /// <param name="usuario"> (String) Recibe el cuatrimestre. </param>
        /// <param name="contrasenia"> (String) Recibe un profesor. </param>
        /// <param name="tipoUsuario"> (String) Recibe el tipo de usuario. </param>
        /// <returns> Retorna True si se ha llenado todos los campos, False se es lo contrario. </returns>
        public static bool ValidarCampo(string nombreyApellido, string usuario, string contrasenia, string tipoUsuario)
        {
            return !string.IsNullOrEmpty(nombreyApellido) && !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contrasenia) && !string.IsNullOrEmpty(tipoUsuario);
        }

        /// <summary>
        /// Valida que se haya ingresado datos.
        /// </summary>
        /// <param name="nuevaMateria"> (String) Recibe una nueva materia. </param>
        /// <param name="cuatrimestre"> (String) Recibe el cuatrimestre. </param>
        /// <param name="profesor"> (String) Recibe un profesor. </param>
        /// <param name="correlativa"> (String) Recibe una correlativa. </param>
        /// <param name="materiaCorrelativa"> (String) Recibe la materia correlativa. </param>
        /// <returns> Retorna True si se ha llenado todos los campos, False se es lo contrario. </returns>
        public static bool ValidarCampo(string nuevaMateria, string cuatrimestre, string profesor, string correlativa, string materiaCorrelativa)
        {
            return !string.IsNullOrEmpty(nuevaMateria) && !string.IsNullOrEmpty(cuatrimestre) && !string.IsNullOrEmpty(profesor) && !string.IsNullOrEmpty(correlativa) && !string.IsNullOrEmpty(materiaCorrelativa);
        }

        /// <summary>
        /// Valida que se haya ingresado solo letras.
        /// </summary>
        /// <param name="mensaje"> (String) Recibe el mensaje a validar. </param>
        /// <returns> Retorna True si son letras, False si no es asi. </returns>
        public static bool ValidarCadena(string mensaje)
        {
            bool retorno = true;

            for (int i = 0; i < mensaje.Length; i++)
            {
                //A = 65 Z = 90 y a = 97 z = 122

                if (((int)mensaje[i] < 65 || ((int)mensaje[i] > 90) && ((int)mensaje[i] < 97) || (int)mensaje[i] > 122) && ((int)mensaje[i] != 32))
                {
                    retorno = false;
                }
            }
            return retorno;

            // Otra forma.

            // return mensaje.All(char.IsLetter);
        }

        /// <summary>
        /// Valida que no se repita el usuario a registrarse.
        /// </summary>
        /// <param name="usuario"> (String) Recibe un usuario. </param>
        /// <returns> Retorna True si no se repite, False si ya existe ese usuario. </returns>
        public static bool ValidarUsuario(string usuario)
        {
            bool retorno = true;

            foreach (KeyValuePair<string, Persona> item in Sql.LeerUsuarios())
            {
                if (item.Value.Usuarios == usuario)
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Crear un nuevo usuario.
        /// </summary>
        /// <param name="nombreyApelldio"> (String) Recibe un nombre y apellido.</param>
        /// <param name="usuario"> (String) Recibe un usuario. </param>
        /// <param name="contrasenia"> (String) Recibe una contrasenia. </param>
        /// <param name="tipoUsuario"> (String) Recibe el tipo de usuario. </param>
        public static void CreacionDeNuevoUsuario(string nombreyApelldio, string usuario, string contrasenia, string tipoUsuario)
        {
            switch (tipoUsuario)
            {
                case "Administrador":
                    Sql.CrearUsuario(nombreyApelldio, usuario, contrasenia, tipoUsuario);
                    break;
                case "Profesor":
                    Sql.CrearUsuario(nombreyApelldio, usuario, contrasenia, tipoUsuario);
                    break;
                case "Alumno":
                    Sql.CrearUsuario(nombreyApelldio, usuario, contrasenia, tipoUsuario);
                    break;
            }
        }

        /// <summary>
        /// Exporta los datos a JSON
        /// </summary>
        /// <param name="materia"> (List<Materias>) Recibe una lista de materia. </param>
        /// <param name="path"> (String) recibe una ruta. </param>
        public static void ExportarMateria(List<Materias> materia, string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    ExportarDatos exportarDatos = Guardar;

                    JsonSerializerOptions options = new JsonSerializerOptions();
                    options.WriteIndented = true;

                    string json = JsonSerializer.Serialize(materia, options);

                    exportarDatos(path, json);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Guarda el contenido.
        /// </summary>
        /// <param name="path"> (String) Recibe una ruta. </param>
        /// <param name="contenido"> (String) Recibe un contenido. </param>
        public static void Guardar(string path, string contenido)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(path);
                sw.WriteLine(contenido);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sw is not null)
                {
                    sw.Close();
                }
            }
        }
    }
}
