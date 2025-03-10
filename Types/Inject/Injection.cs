namespace Types;

public interface IInject
{
    public string InjectMessage(string msg);
}

public class Inject : IInject
{
    public string InjectMessage(string msg)
    {
        return $"Inject: {msg}";
    }
}
