using System.Globalization;
using Transportation.Models;

namespace Transportation.Tests;

public class ShipsUnitTests
{
    [Fact]
    public void TitanicSankSpecificYear()
    {
        var expected = 1912;
        var ships = new Ships();
        var actual = ships.EndOfTitanic().Year;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void TitanicSankSpecificIsoDate()
    {
        var expected = "1912-04-15";
        var ships = new Ships();
        var actual = ships.EndOfTitanic().ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BritannicSankSpecificMonth()
    {
        var expected = 11;
        var ships = new Ships();
        var actual = ships.EndOfBritannic().Day;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BrittanicSankSpecificYearsAgo()
    {
        var current = DateTime.Now.Year;
        var expected = current - 1916;
        var ships = new Ships();
        var actual = current - ships.EndOfBritannic().Year;
        Assert.Equal(expected, actual);
    }
}