namespace Async_Await;

internal class Conway
{
    public async Task Example()
    {
        MethodFirst();
        await LongMethodFirst();
        MethodSecond();
        await LongMethodSecond();
        MethodThird();
        await LongMethodThird();
        MethodFourth();
        await LongMethodFourth();
        MethodFifth();
    }

    private void MethodFirst() =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFirst)}");

    private void MethodSecond() =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodSecond)}");

    private void MethodThird() =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodThird)}");

    private void MethodFourth() =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFourth)}");
    
    private void MethodFifth() =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFifth)}");

    private Task LongMethodFirst() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private Task LongMethodSecond() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private Task LongMethodThird() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private Task LongMethodFourth() =>
        Task.Delay(TimeSpan.FromSeconds(3));
}