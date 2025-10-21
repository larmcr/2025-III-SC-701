namespace MVC.Models;

public class TheModel
{
    public string Phrase { get; set; }

    public Dictionary<char, int> Counts { get; set; } = [];

    public string Lower { get; set; }

    public string Upper { get; set; }
}
