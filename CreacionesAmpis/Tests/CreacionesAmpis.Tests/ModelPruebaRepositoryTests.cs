using CreacionesAmpis.Domain;
using CreacionesAmpis.Domain.Entities;
using CreacionesAmpis.Infrastructure.Persistence.Repositories;
using CreacionesAmpis.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CreacionesAmpis.Tests
{
    [TestClass]
    public class ModelPruebaRepositoryTests
    {
        private Mock<CreacionesAmpisContext> _mockContext;
        private Mock<DbSet<ModelPrueba>> _mockDbSet;
        private ModelPruebaRepository _repository;

        [TestInitialize]
        public void Setup()
        {
            _mockContext = new Mock<CreacionesAmpisContext>();
            _mockDbSet = new Mock<DbSet<ModelPrueba>>();
            _mockContext.Setup(c => c.Set<ModelPrueba>()).Returns(_mockDbSet.Object);
            _repository = new ModelPruebaRepository(_mockContext.Object);
        }

        /// <summary>
        /// Prueba 9: Insertar un ModeloPrueba en la base de datos
        /// </summary>
        [TestMethod]
        public async Task InsertarModeloPruebaEnBD_DebeGuardarExitosamente()
        {
            // Arrange
            var modelo = new ModelPrueba
            {
                Nombre = "Producto BD Test",
                Descripcion = "Test de inserción",
                Precio = 300.00m
            };

            _mockDbSet.Setup(d => d.AddAsync(It.IsAny<ModelPrueba>(), CancellationToken.None))
                .Returns(new ValueTask<EntityEntry<ModelPrueba>>(Task.FromResult<EntityEntry<ModelPrueba>>(null)));

            _mockContext.Setup(c => c.SaveChangesAsync(CancellationToken.None))
                .ReturnsAsync(1);

            // Act
            await _repository.AddAsync(modelo);

            // Assert
            _mockDbSet.Verify(d => d.AddAsync(It.IsAny<ModelPrueba>(), CancellationToken.None), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        /// <summary>
        /// Prueba 10: Obtener todos los registros de ModeloPrueba de la base de datos
        /// </summary>
        [TestMethod]
        public async Task ObtenerTodosLosRegistrosDeModelos_DebeRetornarLista()
        {
            // Arrange
            var modelos = new List<ModelPrueba>
            {
                new ModelPrueba { Id = 1, Nombre = "Producto 1", Precio = 100m },
                new ModelPrueba { Id = 2, Nombre = "Producto 2", Precio = 200m },
                new ModelPrueba { Id = 3, Nombre = "Producto 3", Precio = 300m }
            }.AsQueryable();

            var mockData = modelos.BuildMockDbSet();

            _mockContext.Setup(c => c.Set<ModelPrueba>()).Returns(mockData);

            // Act
            var resultado = await _repository.GetAllAsync();

            // Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(3, resultado.Count);
        }
    }
}