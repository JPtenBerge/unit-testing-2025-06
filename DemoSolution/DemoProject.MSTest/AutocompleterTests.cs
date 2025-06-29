﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;

namespace DemoProject.MSTest;

[TestClass]
public class AutocompleterTests
{
    List<Car> _cars = null!;
    Mock<INavigateService> _navigateServiceMock = null!;

    [TestInitialize]
    public void Init()
    {
        _cars = new List<Car>
        {
            new() { Make = "Volvo", Model = "XC40", YearOfBuild = 2007 },
            new() { Make = "Volvo", Model = "V40", YearOfBuild = 1976 },
            new() { Make = "Peugeot", Model = "e208", YearOfBuild = 2018 },
            new() { Make = "Mitsubishi", Model = "Outlander", YearOfBuild = 2007 },
            new() { Make = "Kia", Model = "e-Niro", YearOfBuild = 2013 },
            new() { Make = "Audi", Model = "E-tron", YearOfBuild = 2015 },
            new() { Make = "Tesla", Model = "Model 3", YearOfBuild = 2016},
            new() { Make = "Renault", Model = "Megane", YearOfBuild = 2009 },
            new() { Make = "Renault", Model = "Twingo", YearOfBuild = 1998 },
        };

        _navigateServiceMock = new Mock<INavigateService>();
        _navigateServiceMock.Setup(x => x.Next(It.IsAny<List<Car>>(), It.IsAny<int?>())).Returns(4);
    }

    [TestMethod]
    public void Autocomplete_BasicQueryThatHandlesMultipleDataTypse_GiveSuggestions()
    {
        _navigateServiceMock.Setup(x => x.Next(It.IsAny<List<Car>>(), It.IsAny<int?>())).Returns(42);

        // Arrange
        var sut = new Autocompleter<Car>(_navigateServiceMock.Object)
        {
            Query = "g",
            Data = _cars
        };

        // Act
        sut.Autocomplete();

        // Assert
        Assert.AreEqual(3, sut.Suggestions!.Count);
    }

    [TestMethod]
    //[ExpectedException(typeof(ArgumentException))]
    public void Autocomplete_NoData_Throws()
    {
        var sut = new Autocompleter<Car>(_navigateServiceMock.Object)
        {
            Query = "g",
            Data = null!
        };
        var act = () => sut.Autocomplete();
        Assert.ThrowsException<NotSupportedException>(act);
    }

    [TestMethod]
    //[ExpectedException(typeof(ArgumentException))]
    public void Autocomplete_NullInData_IgnoresNullAndGiveSuggestions()
    {
        _cars[2] = null!;
        var sut = new Autocompleter<Car>(_navigateServiceMock.Object)
        {
            Query = "g",
            Data = _cars
        };
        sut.Autocomplete();
        Assert.AreEqual(2, sut.Suggestions!.Count);
    }

    [TestMethod]
    public void Next_UsesNavigateService()
    {
        var sut = new Autocompleter<Car>(_navigateServiceMock.Object)
        {
            Query = "g",
            Data = _cars
        };
        sut.Autocomplete();
        sut.Next();

        //_navigateServiceMock.Verify(x => x.Next(It.IsAny<List<Car>>(), It.IsAny<int?>()), Times.AtLeast(2));
        _navigateServiceMock.Verify(x => x.Next(It.IsAny<List<Car>>(), null), Times.Once);
    }
}
