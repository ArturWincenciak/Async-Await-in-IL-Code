Console.WriteLine("Alright Async Await!");

Console.WriteLine($"{Log.TimeNow} 01 Global");
var joy = new Joy();
await joy.Example();
Console.WriteLine($"{Log.TimeNow} 02 Global");

internal class Joy
{
    public async Task Example()
    {
        Console.WriteLine($"{Log.TimeNow} 01 {nameof(Example)}");
        await Task.Delay(TimeSpan.FromSeconds(5));
        Console.WriteLine($"{Log.TimeNow} 02 {nameof(Example)}");
    }
}

internal static class Log
{
    public static string TimeNow => 
        $"{DateTime.Now:HH:mm:ss.fff}";
}