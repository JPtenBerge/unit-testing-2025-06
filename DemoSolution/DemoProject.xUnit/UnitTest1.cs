namespace DemoProject.xUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(42, 42);
            Assert.Equal("hoi", "doei");
        }
    }
}