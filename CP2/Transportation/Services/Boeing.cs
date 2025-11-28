using Transportation.Interfaces;

namespace Transportation.Services;

public class Boeing : IAirplanes
{
    public string GetBrand => "Boeing";
    public string[] GetModels => ["737", "747", "777"];
}