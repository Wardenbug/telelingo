partial class Program
{
    public static Dictionary<string, string> words = new Dictionary<string, string>();
    public static KeyValuePair<string, string> valuePair = new KeyValuePair<string, string>();
    public static int messageId = default;

    public static void MyMethod(ConainerProps containerProps)
    {
        bool flag2 = containerProps is { Exists: true };

    }
}

public class ConainerProps
{
    public bool Exists { get; set; } = false;
}