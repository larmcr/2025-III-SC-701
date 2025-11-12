public class BllRem
{
    private readonly IDal _dal;
    private readonly IRandom _random;

    public BllRem(IDal dal, IRandom random)
    {
        _dal = dal;
        _random = random;
    }

    public void Remove(string table)
    {
        _dal.ExecComm($"DELETE * FROM {table} WHERE id = {_random.GetRandom()}");
    }
}