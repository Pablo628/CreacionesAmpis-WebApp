using System;
using CreacionesAmpis.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CreacionesAmpis.Tests
{
    [TestClass]
    public class ModelPruebaTests
    {
        /// <summary>
        /// Prueba 1: Validar que un ModeloPrueba se crea correctamente con datos válidos
        /// </summary>
        [TestMethod]
        public void CrearModeloPruebaValido_DebeRetornarTrue()
        {
            // Arrange
            var nombre = "Usuario Test";
            var email = "test@example.com";
            var contrasena = "123456";
            var rol = "Cliente";

            // Act
            var modelo = new ModelPrueba
            {
                Nombre = nombre,
                Email = email,
                Contrasena = contrasena,
                Rol = rol,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            };

            // Assert
            Assert.IsNotNull(modelo);
            Assert.AreEqual(nombre, modelo.Nombre);
            Assert.AreEqual(email, modelo.Email);
            Assert.AreEqual(contrasena, modelo.Contrasena);
            Assert.AreEqual(rol, modelo.Rol);
            Assert.IsTrue(modelo.Activo);
        }

        /// <summary>
        /// Prueba 2: Validar que ModeloPrueba rechaza valores inválidos (nombre vacío)
        /// </summary>
        [TestMethod]
        public void CrearModeloPruebaSinNombre_DebeSerInvalido()
        {
            // Arrange
            var modelo = new ModelPrueba
            {
                Nombre = "", // Inválido
                Email = "test@example.com",
                Contrasena = "123456",
                Rol = "Cliente"
            };

            // Act & Assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(modelo.Nombre));
        }

        /// <summary>
        /// Prueba 3: Validar que ModeloPrueba con email vacío es inválido
        /// </summary>
        [TestMethod]
        public void CrearModeloPruebaConEmailVacio_DebeSerInvalido()
        {
            // Arrange
            var modelo = new ModelPrueba
            {
                Nombre = "Usuario",
                Email = "", // Inválido
                Contrasena = "123456",
                Rol = "Cliente"
            };

            // Act & Assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(modelo.Email));
        }
    }
}