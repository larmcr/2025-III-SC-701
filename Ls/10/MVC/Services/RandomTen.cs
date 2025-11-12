using MVC.Interfaces;

namespace MVC.Services;

public class RandomTen : IRandom
{
    public int GetRandom()
    {
        return new Random().Next(10);
    }
}