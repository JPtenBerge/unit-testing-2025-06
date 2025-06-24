using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AwesomeAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoProject.MSTest;

[TestClass]
public class AwesomeTests
{
    [TestMethod]
    public void AwesomeAssert()
    {
        Assert.AreEqual(18, 18);

        var actual = 18;

        //actual.Should().Be(42);
        //"hoi".Should().Be("doei");


        var car1 = new Car { Make = "a", Model = "b", YearOfBuild = 2014 };
        var car2 = new Car { Make = "a", Model = "b", YearOfBuild = 2018 };

        
        car1.Should().BeEquivalentTo(car2, options => options.Excluding(x => x.YearOfBuild));

        //CollectionAssert.

        //Assert.AreEqual(car1, car2);
    }
}
