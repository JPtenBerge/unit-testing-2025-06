namespace Implementation.UnitTest;

public class UserTest 
{

    [Fact]
    public void Age_WithValidDateOfBirth_ShouldCalculateAge() 
    {
        var sut = new User("", DateTime.Now.AddYears(-18).AddDays(-1), "");
        Assert.Equal(18, sut.Age);
    }
}