using System;                    
using System.Collections.Generic; 
using System.Linq;                
using System.Threading.Tasks;
using CreacionesAmpis.Application.DTOs;
using CreacionesAmpis.Application.Interfaces;
using CreacionesAmpis.Application.Services;
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
            var dto = new CreateModelPruebaDTO
            {
                Nombre = "Usuario Test",
                Email = "test@example.com",
                Contrasena = "123456",
                Rol = "Cliente"
            };

            var modeloEsperado = new ModelPrueba
            {
                Id = 1,
                Nombre = dto.Nombre,
                Email = dto.Email,
                Contrasena = dto.Contrasena,
                Rol = dto.Rol,
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            };

            _mockRepository.Setup(r => r.CreateAsync(It.IsAny<ModelPrueba>()))
                .ReturnsAsync(modeloEsperado);

            // Act
            var resultado = await _servicePrueba.CreateAsync(dto);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, resultado.Id);
            Assert.AreEqual(dto.Nombre, resultado.Nombre);
            _mockRepository.Verify(r => r.CreateAsync(It.IsAny<ModelPrueba>()), Times.Once);
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
                Nombre = "Usuario Existente",
                Email = "existente@example.com",
                Contrasena = "123456",
                Rol = "Administrador",
                Activo = true,
                FechaCreacion = DateTime.UtcNow
            };

            _mockRepository.Setup(r => r.GetByIdAsync(id))
                .ReturnsAsync(modeloEsperado);

            // Act
            var resultado = await _servicePrueba.GetByIdAsync(id);

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(id, resultado.Id);
            Assert.AreEqual("Usuario Existente", resultado.Nombre);
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
                new ModelPrueba { Id = 1, Nombre = "Usuario 1", Email = "user1@example.com", Rol = "Cliente", Activo = true },
                new ModelPrueba { Id = 2, Nombre = "Usuario 2", Email = "user2@example.com", Rol = "Administrador", Activo = true }
            };

            _mockRepository.Setup(r => r.GetAllAsync())
                .ReturnsAsync(modelos);

            // Act
            var resultado = await _servicePrueba.GetAllAsync();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(2, resultado.Count());
            _mockRepository.Verify(r => r.GetAllAsync(), Times.Once);
        }

        /// <summary>
        /// Prueba 7: Actualizar un ModeloPrueba existente
        /// </summary>
        [TestMethod]
        public async Task ActualizarModeloPrueba_DebeActualizarExitosamente()
        {
            // Arrange
            var id = 1;
            var dto = new UpdateModelPruebaDTO
            {
                Nombre = "Usuario Actualizado",
                Email = "actualizado@example.com",
                Rol = "Vendedor",
                Activo = true
            };

            _mockRepository.Setup(r => r.UpdateAsync(It.IsAny<ModelPrueba>()))
                .ReturnsAsync(true);

            // Act
            var resultado = await _servicePrueba.UpdateAsync(id, dto);

            // Assert
            Assert.IsTrue(resultado);
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
                .ReturnsAsync(true);

            // Act
            var resultado = await _servicePrueba.DeleteAsync(id);

            // Assert
            Assert.IsTrue(resultado);
            _mockRepository.Verify(r => r.DeleteAsync(id), Times.Once);
        }
    }
}