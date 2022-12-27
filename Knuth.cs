namespace Async_Await;

internal class Knuth
{
    public async Task Example()
    {
        MethodFirst();
        await LongMethod();
        MethodSecond();
    }

    private void MethodFirst() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFirst)}");

    private void MethodSecond() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodSecond)}");
    
    private Task LongMethod() => 
        Task.Delay(TimeSpan.FromSeconds(3));
}