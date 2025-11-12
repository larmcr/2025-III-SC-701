public class DalSql : IDal
{
    public void ExecComm(string command)
    {
        Console.WriteLine($"DalSql command: {command}");
    }
}