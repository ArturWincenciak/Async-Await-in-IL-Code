namespace Async_Await;

internal class Graham
{
    public async Task Example()
    {
        LocalLogicMethodFirst();
        await LogRunningMethodFirst();
        LocalLogicMethodSecond();
        await LogRunningMethodSecond();
        LocalLogicMethodThird();
    }

    private void LocalLogicMethodFirst() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(LocalLogicMethodFirst)}");

    private void LocalLogicMethodSecond() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(LocalLogicMethodSecond)}");
    
    private void LocalLogicMethodThird() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(LocalLogicMethodThird)}");
    
    private Task LogRunningMethodFirst() => 
        Task.Delay(TimeSpan.FromSeconds(3));
    
    private Task LogRunningMethodSecond() => 
        Task.Delay(TimeSpan.FromSeconds(3));
}