public class DalNoSql : IDal
{
    public void ExecComm(string command)
    {
        Console.WriteLine($"DalNoSql command: {command}");
    }
}