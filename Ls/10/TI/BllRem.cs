public class BllRem
{
    private readonly IDal _dal;

    public BllRem(IDal dal)
    {
        _dal = dal;
    }

    public void Remove(string table)
    {
        _dal.ExecComm($"DELETE * FROM {table}");
    }
}