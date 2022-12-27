namespace Async_Await;

internal class Joy
{
    public async Task Example()
    {
        LocalLogicMethodFirst();
        await LogRunningMethod();
        LocalLogicMethodSecond();
    }

    private void LocalLogicMethodFirst() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(LocalLogicMethodFirst)}");

    private void LocalLogicMethodSecond() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(LocalLogicMethodSecond)}");
    
    private Task LogRunningMethod() => 
        Task.Delay(TimeSpan.FromSeconds(3));
}