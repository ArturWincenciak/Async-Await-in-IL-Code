namespace Async_Await;

internal class Graham
{
    public async Task Example()
    {
        MethodFirst();
        await LongMethodFirst();
        MethodSecond();
        await LongMethodSecond();
        MethodThird();
    }

    private void MethodFirst() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFirst)}");

    private void MethodSecond() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodSecond)}");
    
    private void MethodThird() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodThird)}");
    
    private Task LongMethodFirst() => 
        Task.Delay(TimeSpan.FromSeconds(3));
    
    private Task LongMethodSecond() => 
        Task.Delay(TimeSpan.FromSeconds(3));
}