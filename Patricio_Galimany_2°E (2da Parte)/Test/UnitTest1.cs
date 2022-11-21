using Microsoft.VisualStudio.TestTools.UnitTesting;
using Biblioteca;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test
        /// </summary>
        [TestMethod]
        public void Test_Validar_Materia()
        {
            // Arrange
            string nuevaMateria = "Mate";

            // Act
            bool resultado = Admin.ValidarMateria(nuevaMateria);

            // Assert
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void Test_Validar_UsuarioARegistrarse()
        {
            // Arrange
            string usuario = "NicoTas";

            // Act
            bool resultado = Admin.ValidarUsuario(usuario);

            // Assert
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void Test_Validar_UsuarioEnLogin()
        {
            // Arrange
            string usuario = "NicoTas";
            string contrasenia = "546";

            // Act
            Usuario resultado = Sistema.ValidarUsuario(usuario, contrasenia);

            // Assert
            Assert.AreEqual(null, resultado);
        }
    }
}
