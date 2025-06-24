

namespace Implementation.UnitTest.Utility;

public class AgeCalculatorTests
{
    [Fact]
    public void Calculate_ReferenceIsBeforeDateOfBirth_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            AgeCalculator.Calculate(DateTime.MaxValue, DateTime.MinValue);
        });
    }

    [Fact]
    public void Calculate_OneMonthBefore32ndBirthDate_Returns31()
    {
        int age = AgeCalculator.Calculate(new DateTime(1978, 9, 27), new DateTime(2010, 8, 27));
        Assert.Equal(31, age);
    }

    [Fact]
    public void Calculate_DayBefore32ndBirthDate_Returns31()
    {
        int age = AgeCalculator.Calculate(new DateTime(1978, 9, 27), new DateTime(2010, 9, 26));
        Assert.Equal(31, age);
    }

    [Fact]
    public void Calculate_On32ndBirthDay_Returns32()
    {
        int age = AgeCalculator.Calculate(new DateTime(1978, 9, 27), new DateTime(2010, 9, 27));
        Assert.Equal(32, age);
    }

    [Fact]
    public void Calculate_OneMonthAfter32ndBirthDay_Returns32()
    {
        int age = AgeCalculator.Calculate(new DateTime(1978, 9, 27), new DateTime(2010, 10, 27));
        Assert.Equal(32, age);
    }
}