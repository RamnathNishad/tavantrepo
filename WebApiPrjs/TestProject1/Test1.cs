using xUnitDemoLib;

namespace TestProject1;


public class Test1
{
    //[Fact]
    [Theory]
    [InlineData(10,20,30)]
    [InlineData(100, 200, 300)]
    [InlineData(5, 8, 13)]
    public void TestMethod_Add(int a,int b,int expected)
    {
        //Arrange
        var demo = new Demo();
        //Act
        var actual=demo.Add(a,b);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TestMethod_Divide()
    {
        var demo = new Demo();
        int a = 10, b = 0;
        Assert.Throws<DivideByZeroException>(()=> demo.Divide(a,b));
    }
}
