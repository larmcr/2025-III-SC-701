public class BllRem
{
    private readonly DalNoSql _dal;

    public BllRem(DalNoSql dal)
    {
        _dal = dal;
    }

    public void Remove(string table)
    {
        _dal.ExecComm($"DELETE * FROM {table}");
    }
}