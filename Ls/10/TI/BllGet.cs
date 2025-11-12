public class BllGet
{
    private readonly IDal _dal;
    private readonly IRandom _random;

    public BllGet(IDal dal, IRandom random)
    {
        _dal = dal;
        _random = random;
    }

    public void Get(string table)
    {
        _dal.ExecComm($"SELECT * FROM {table} WHERE id = {_random.GetRandom()}");
    }
}