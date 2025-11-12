public class RandomTen : IRandom
{
    public int GetRandom()
    {
        return new Random().Next(10);
    }
}