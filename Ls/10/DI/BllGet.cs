public class BllGet
{
    private readonly IDal _dal;

    public BllGet(IDal dal)
    {
        _dal = dal;
    }

    public void Get(string table)
    {
        _dal.ExecComm($"SELECT * FROM {table}");
    }
}