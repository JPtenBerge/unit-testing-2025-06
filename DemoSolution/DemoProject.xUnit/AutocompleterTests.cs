using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;

namespace DemoProject.xUnit;

public class AutocompleterTests
{
    List<Car> _cars = null!;
    INavigateService _navigateServiceMock = null!;

    public AutocompleterTests()
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

        _navigateServiceMock = A.Fake<INavigateService>();
        A.CallTo(() => _navigateServiceMock.Next(A<List<Car>>._, A<int?>._)).Returns(4);
    }

    [Fact] // xUnit
    public void Next_UsesNavigateService()
    {
        var sut = new Autocompleter<Car>(_navigateServiceMock)
        {
            Query = "g",
            Data = _cars
        };
        sut.Autocomplete();
        sut.Next();

        A.CallTo(() => _navigateServiceMock.Next(A<List<Car>>._, A<int?>._)).MustHaveHappenedOnceExactly();
    }
}
