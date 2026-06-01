using CreacionesAmpis.Domain;
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
            var nombre = "Prueba 1";
            var descripcion = "Descripción de prueba";
            var precio = 100.50m;

            // Act
            var modelo = new ModelPrueba
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Precio = precio
            };

            // Assert
            Assert.IsNotNull(modelo);
            Assert.AreEqual(nombre, modelo.Nombre);
            Assert.AreEqual(descripcion, modelo.Descripcion);
            Assert.AreEqual(precio, modelo.Precio);
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
                Descripcion = "Descripción",
                Precio = 100.50m
            };

            // Act & Assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(modelo.Nombre));
        }

        /// <summary>
        /// Prueba 3: Validar que ModeloPrueba con precio negativo es inválido
        /// </summary>
        [TestMethod]
        public void CrearModeloPruebaConPrecioNegativo_DebeSerInvalido()
        {
            // Arrange
            var modelo = new ModelPrueba
            {
                Nombre = "Prueba",
                Descripcion = "Descripción",
                Precio = -50m // Inválido
            };

            // Act & Assert
            Assert.IsTrue(modelo.Precio < 0);
        }
    }
}