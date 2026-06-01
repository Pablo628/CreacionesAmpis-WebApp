using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Application.Services;
using CreacionesAmpis.Domain;
using CreacionesAmpis.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CreacionesAmpis.Tests
{
    [TestClass]
    public class ServicePruebaTests
    {
        private Mock<IModelPruebaRepository> _mockRepository;
        private ServicePrueba _servicePrueba;

        [TestInitialize]
        public void Setup()
        {
            _mockRepository = new Mock<IModelPruebaRepository>();
            _servicePrueba = new ServicePrueba(_mockRepository.Object);
        }

        /// <summary>
        /// Prueba 4: Crear un ModeloPrueba exitosamente en el servicio
        /// </summary>
        [TestMethod]
        public async Task CrearModeloPruebaExitoso_DebeRetornarTrue()
        {
            // Arrange
            var modelo = new ModelPrueba
            {
                Nombre = "Producto Test",
                Descripcion = "Descripción Test",
                Precio = 150.00m
            };

            _mockRepository.Setup(r => r.AddAsync(It.IsAny<ModelPrueba>()))
                .Returns(Task.CompletedTask);

            // Act
            await _servicePrueba.AddAsync(modelo);

            // Assert
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<ModelPrueba>()), Times.Once);
        }

        /// <summary>
        /// Prueba 5: Obtener un ModeloPrueba existente por ID
        /// </summary>
        [TestMethod]
        public async Task ObtenerModeloPruebaExistente_DebeRetornarElModelo()
        {
            // Arrange
            var id = 1;
            var modeloEsperado = new ModelPrueba
            {
                Id = id,
                Nombre = "Producto Existente",
                Descripcion = "Descripción",
                Precio = 200.00m
            };

            _mockRepository.Setup(r => r.GetByIdAsync(id))
                .ReturnsAsync(modeloEsperado);

            // Act
            var resultado = await _servicePrueba.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(id, resultado.Id);
            Assert.AreEqual("Producto Existente", resultado.Nombre);
            _mockRepository.Verify(r => r.GetByIdAsync(id), Times.Once);
        }

        /// <summary>
        /// Prueba 6: Obtener todos los ModelosPrueba
        /// </summary>
        [TestMethod]
        public async Task ObtenerTodosLosModelos_DebeRetornarLista()
        {
            // Arrange
            var modelos = new List<ModelPrueba>
            {
                new ModelPrueba { Id = 1, Nombre = "Producto 1", Precio = 100m },
                new ModelPrueba { Id = 2, Nombre = "Producto 2", Precio = 200m }
            };

            _mockRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(modelos);

            // Act
            var resultado = await _servicePrueba.GetAllAsync();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count);
            _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }

        /// <summary>
        /// Prueba 7: Actualizar un ModeloPrueba existente
        /// </summary>
        [TestMethod]
        public async Task ActualizarModeloPrueba_DebeActualizarExitosamente()
        {
            // Arrange
            var modelo = new ModelPrueba
            {
                Id = 1,
                Nombre = "Producto Actualizado",
                Descripcion = "Nueva descripción",
                Precio = 250.00m
            };

            _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<ModelPrueba>()))
                .Returns(Task.CompletedTask);

            // Act
            await _servicePrueba.UpdateAsync(modelo);

            // Assert
            _mockRepository.Verify(r => r.UpdateAsync(It.IsAny<ModelPrueba>()), Times.Once);
        }

        /// <summary>
        /// Prueba 8: Eliminar un ModeloPrueba por ID
        /// </summary>
        [TestMethod]
        public async Task EliminarModeloPrueba_DebeEliminarExitosamente()
        {
            // Arrange
            var id = 1;
            _mockRepository.Setup(r => r.DeleteAsync(id))
                .Returns(Task.CompletedTask);

            // Act
            await _servicePrueba.DeleteAsync(id);

            // Assert
            _mockRepository.Verify(r => r.DeleteAsync(id), Times.Once);
        }
    }
}