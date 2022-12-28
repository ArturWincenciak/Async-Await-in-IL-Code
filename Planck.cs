namespace Async_Await;

internal class Planck
{
    public async Task<int> Example()
    {
        var startArg = 100;
        MethodFirst(startArg);
        var firstResult = await LongMethodFirst(startArg);
        MethodSecond(firstResult);
        var secondResult = await LongMethodSecond(firstResult);
        MethodThird(secondResult);
        var thirdResult = await LongMethodThird(secondResult);
        MethodFourth(thirdResult);
        var fifthResult = await LongMethodFourth(thirdResult);
        MethodFifth(fifthResult);
        return fifthResult;
    }

    private void MethodFirst(int methodFirstArg) =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFirst)} {methodFirstArg}");

    private void MethodSecond(int methodSecondArg) =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodSecond)} {methodSecondArg}");

    private void MethodThird(int methodThirdArg) =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodThird)} {methodThirdArg}");

    private void MethodFourth(int methodFourthArg) =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFourth)} {methodFourthArg}");

    private void MethodFifth(int methodFifthArg) =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFifth)} {methodFifthArg}");

    private Task<int> LongMethodFirst(int firstArg) => 
        Task.FromResult(firstArg + 100);

    private Task<int> LongMethodSecond(int secondArg) =>
        Task.FromResult(secondArg + 100);

    private Task<int> LongMethodThird(int thirdArg) =>
        Task.FromResult(thirdArg + 100);

    private Task<int> LongMethodFourth(int fourthArg) =>
        Task.FromResult(fourthArg + 100);
}