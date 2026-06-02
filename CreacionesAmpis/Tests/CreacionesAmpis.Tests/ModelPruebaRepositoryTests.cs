using System.Collections.Generic; 
using System.Linq;                
using System.Threading.Tasks;
using CreacionesAmpis.Domain.Entities;
using CreacionesAmpis.Infrastructure.Persistence;
using CreacionesAmpis.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data;

namespace CreacionesAmpis.Tests
{
    [TestClass]
    public class ModelPruebaRepositoryTests
    {
        private Mock<IDapperCreacionesAmpis> _mockDapper;
        private ModelPruebaRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _mockDapper = new Mock<IDapperCreacionesAmpis>();
            _repository = new ModelPruebaRepository(_mockDapper.Object);
        }

        [TestMethod]
        public async Task GetAllAsync_DebeRetornarListaDeUsuarios()
        {
            // Arrange
            var usuariosFake = new List<ModelPrueba> { new ModelPrueba { Id = 1, Nombre = "Test" } };
            _mockDapper.Setup(d => d.QueryAsync<ModelPrueba>(It.IsAny<string>(), null, CommandType.Text))
                       .ReturnsAsync(usuariosFake);

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            _mockDapper.Verify(d => d.QueryAsync<ModelPrueba>(It.IsAny<string>(), null, CommandType.Text), Times.Once);
        }

        [TestMethod]
        public async Task GetByIdAsync_DebeRetornarUsuario_CuandoExiste()
        {
            // Arrange
            var usuarioFake = new ModelPrueba { Id = 1, Nombre = "Test" };
            _mockDapper.Setup(d => d.QueryFirstOrDefaultAsync<ModelPrueba>(It.IsAny<string>(), It.IsAny<object>(), CommandType.Text))
                       .ReturnsAsync(usuarioFake);

            // Act
            var result = await _repository.GetByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public async Task CreateAsync_DebeRetornarEntidadCreada()
        {
            // Arrange
            var nuevaEntity = new ModelPrueba { Nombre = "Nuevo" };
            var entityResult = new ModelPrueba { Id = 99, Nombre = "Nuevo" };

            _mockDapper.Setup(d => d.QueryFirstAsync<ModelPrueba>(It.IsAny<string>(), It.IsAny<object>(), CommandType.Text))
                       .ReturnsAsync(entityResult);

            // Act
            var result = await _repository.CreateAsync(nuevaEntity);

            // Assert
            Assert.AreEqual(99, result.Id);
            _mockDapper.Verify(d => d.QueryFirstAsync<ModelPrueba>(It.IsAny<string>(), It.IsAny<object>(), CommandType.Text), Times.Once);
        }

        [TestMethod]
        public async Task UpdateAsync_DebeRetornarTrue_SiSeActualiza()
        {
            // Arrange
            _mockDapper.Setup(d => d.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), CommandType.Text))
                       .ReturnsAsync(1); // 1 fila afectada

            // Act
            var result = await _repository.UpdateAsync(new ModelPrueba { Id = 1 });

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task DeleteAsync_DebeRetornarTrue_SiSeElimina()
        {
            // Arrange
            _mockDapper.Setup(d => d.ExecuteAsync(It.IsAny<string>(), It.IsAny<object>(), CommandType.Text))
                       .ReturnsAsync(1);

            // Act
            var result = await _repository.DeleteAsync(1);

            // Assert
            Assert.IsTrue(result);
        }
    }
}