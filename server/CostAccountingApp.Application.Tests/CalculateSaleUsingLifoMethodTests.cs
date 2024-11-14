using AutoMapper;
using CostAccountingApp.ApplicationCore.Exceptions;
using CostAccountingApp.ApplicationCore.Interfaces;
using CostAccountingApp.ApplicationCore.Models.DTO;
using CostAccountingApp.ApplicationCore.Models.Entities;
using CostAccountingApp.ApplicationCore.Services;
using CostAccountingApp.TestData.Models.Data;
using Moq;

namespace CostAccountingApp.Application.Tests;

public class Tests
{
    private CostAccountingService _sut;
    private Mock<IMapper> _mapperMock;
    private Mock<IPurchaseLotRepository> _repositoryMock;
    
    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IPurchaseLotRepository>();
        _mapperMock = new Mock<IMapper>();
        _sut = new CostAccountingService(_repositoryMock.Object, _mapperMock.Object);
        
        var data = new List<PurchaseLot>
        {
            TestData.DataFactory.TestData.Create.PurchaseLot(new DateTime(2023, 1, 1), 100, 20),
            TestData.DataFactory.TestData.Create.PurchaseLot(new DateTime(2023, 2, 1), 150, 30),
            TestData.DataFactory.TestData.Create.PurchaseLot(new DateTime(2023, 3, 1), 120),
        };

        var mapperData = MapDataToDTO(data);
        
        _repositoryMock.Setup(x => x.ListAll()).Returns(data);
        _mapperMock.Setup(x => x.Map<List<PurchaseLotDTO>>(It.IsAny<List<PurchaseLot>>())).Returns(mapperData);
    }

    [Test]
    public void WhenTestingCalculateSaleUsingLifoMethodAndDataCorrect_ShouldReturnExpectedResult()
    {
        // Arrange
        int sharesToSell = 10;
        decimal salePricePerShare = 20;
        
        // Act
        var result = _sut.CalculateSaleUsingLifoMethod(sharesToSell, salePricePerShare);
        
        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result?.RemainingShares, Is.EqualTo(360));
        Assert.That(result?.SoldCostBasis, Is.EqualTo(20));
        Assert.That(result?.RemainingCostBasis, Is.InRange(20, 21));
        Assert.That(result?.Profit, Is.EqualTo(0));
    }
    
    [TestCase(-1, 20)]
    [TestCase(0, 20)]
    [TestCase(10, 0)]
    [TestCase(10, -2)]
    [TestCase(-1, -2)]
    public void WhenTestingCalculateSaleUsingLifoMethodAndDataNotCorrect_ShouldReturnNull(
        int sharesToSell, decimal salePricePerShare)
    {
        // Arrange
        var exceptionMessage = "Invalid request data";

        // Assert
        var ex = Assert.Throws<CostAccountingAppException>(() =>
            _sut.CalculateSaleUsingLifoMethod(sharesToSell, salePricePerShare));

        Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
    }

    private List<PurchaseLotDTO> MapDataToDTO(List<PurchaseLot> data)
    {
        return data.Select(x => new PurchaseLotDTO {Shares = x.Shares, PurchaseDate = x.PurchaseDate, PricePerShare = x.PricePerShare}).ToList();
    }
}