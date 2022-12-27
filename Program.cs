Console.WriteLine("Alright Async Await!");

Console.WriteLine($"01 {DateTime.Now:O} Global");
var joy = new Joy();
await joy.Example();
Console.WriteLine($"02 {DateTime.Now:O} Global");

internal class Joy
{
    public async Task Example()
    {
        Console.WriteLine($"01 {DateTime.Now:O} {nameof(Example)}");
        await Task.Delay(TimeSpan.FromSeconds(5));
        Console.WriteLine($"02 {DateTime.Now:O} {nameof(Example)}");
    }
}