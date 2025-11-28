using Transportation.Interfaces;

namespace Transportation.Services;

public class Airbus : IAirplanes
{
    public string GetBrand => "Airbus";
    public string[] GetModels => ["A320", "A350", "A380"];
}