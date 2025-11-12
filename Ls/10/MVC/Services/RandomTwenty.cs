using MVC.Interfaces;

namespace MVC.Services;

public class RandomTwenty : IRandom
{
    public int GetRandom()
    {
        return new Random().Next(20);
    }
}