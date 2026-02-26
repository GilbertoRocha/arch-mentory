namespace Hotline.Tool.Migrations;

public static class ConsoleColorized
{
    private const string Reset = "\x1b[0m";
    private const string Red = "\x1b[31m";
    private const string Green = "\x1b[32m";
    private const string Yellow = "\x1b[33m";
    private const string Blue = "\x1b[34m";
    private const string Cyan = "\x1b[36m";

    public static void Info(string msg) => Console.WriteLine($"{Blue}[INFO]{Reset} {msg}");
    public static void Success(string msg) => Console.WriteLine($"{Green}[SUCCESS]{Reset} {msg}");
    public static void Warning(string msg) => Console.WriteLine($"{Yellow}[WARN]{Reset} {msg}");
    public static void Error(string msg) => Console.WriteLine($"{Red}[ERROR]{Reset} {msg}");
    public static void Step(string msg) => Console.WriteLine($"{Cyan}{msg}{Reset}");
    
}