using AutoMapper;
using Moq;
using Product.Application;
using Product.Application.GetAll;
using Product.Domain.Entity;
using Product.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Product.UnitTest
{
    [TestFixture]
    public class GetAllProductUnitTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<IProductRepository> _productRepositoryMock;
        private GetAllQueryHandler _handlerMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _productRepositoryMock = new Mock<IProductRepository>();
            _handlerMock = new GetAllQueryHandler(_productRepositoryMock.Object,_mapperMock.Object);
        }

        [Test]
        public async Task GetAllProductsQueryHandler_ReturnsProductDtoList()
        {
            // Arrange
            var query = new GetAllQuery();
            var expectedProducts = new List<ProductEntity>
            {
                new ProductEntity { Id = 1, Name = "Product A", Price = 100.0m },
                new ProductEntity { Id = 2, Name = "Product B", Price = 200.0m },
                new ProductEntity { Id = 3, Name = "Product C", Price = 300.0m },
            };

            // DTO dự kiến
            var expectedDto = expectedProducts.Select(entity => new ProductDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            }).ToList();

            // Mock repository trả về danh sách sản phẩm
            _productRepositoryMock
                .Setup(x => x.GetProductsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedProducts);

            _mapperMock.Setup(m => m.Map<List<ProductDTO>>(It.IsAny<List<ProductEntity>>()))
                .Returns(expectedDto);

            // Act
            var result = await _handlerMock.Handle(query, CancellationToken.None);

            // Assert
            Assert.AreEqual(expectedDto.Count, result.Count);

            for (int i = 0; i < expectedDto.Count; i++)
            {
                Assert.AreEqual(expectedDto[i].Id, result[i].Id);
                Assert.AreEqual(expectedDto[i].Name, result[i].Name);
                Assert.AreEqual(expectedDto[i].Price, result[i].Price);
            }
        }
    }
}
