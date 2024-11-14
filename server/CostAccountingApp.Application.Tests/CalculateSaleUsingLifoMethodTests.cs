using CostAccountingApp.ApplicationCore.Interfaces;
using CostAccountingApp.ApplicationCore.Models;
using CostAccountingApp.ApplicationCore.Services;
using CostAccountingApp.TestData.Models.Data;
using Moq;

namespace CostAccountingApp.Application.Tests;

public class Tests
{
    private CostAccountingService _sut;
    private Mock<IPurchaseLotRepository> _repositoryMock;
    
    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IPurchaseLotRepository>();
        _sut = new CostAccountingService(_repositoryMock.Object);
    }

    [Test]
    public void WhenTestingCalculateSaleUsingLifoMethodAndDataCorrect_ShouldReturnExpectedResult()
    {
        // Arrange
        int sharesToSell = 10;
        decimal salePricePerShare = 20;
        var data = new List<PurchaseLot>
        {
            TestData.DataFactory.TestData.Create.PurchaseLot(new DateTime(2023, 1, 1), 100, 20),
            TestData.DataFactory.TestData.Create.PurchaseLot(new DateTime(2023, 2, 1), 150, 30),
            TestData.DataFactory.TestData.Create.PurchaseLot(new DateTime(2023, 3, 1), 120),
        };
        
        _repositoryMock.Setup(x => x.ListAll()).Returns(data);
        
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
        var data = new List<PurchaseLot>
        {
            TestData.DataFactory.TestData.Create.PurchaseLot(new DateTime(2023, 1, 1), 100, 20),
            TestData.DataFactory.TestData.Create.PurchaseLot(new DateTime(2023, 2, 1), 150, 30),
            TestData.DataFactory.TestData.Create.PurchaseLot(new DateTime(2023, 3, 1), 120),
        };
        
        _repositoryMock.Setup(x => x.ListAll()).Returns(data);
        
        // Act
        var result = _sut.CalculateSaleUsingLifoMethod(sharesToSell, salePricePerShare);
        
        // Assert
        Assert.That(result, Is.Null);
    }
}