public class BllGet
{
    private readonly DalNoSql _dal;

    public BllGet(DalNoSql dal)
    {
        _dal = dal;
    }

    public void Get(string table)
    {
        _dal.ExecComm($"SELECT * FROM {table}");
    }
}