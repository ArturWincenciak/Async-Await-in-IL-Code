using System.Runtime.CompilerServices;

namespace Async_Await;

internal class ConwayCleanCode
{
    public Task Example()
    {
        var stateMachine = new ExampleStateMachine();
        stateMachine.Builder = AsyncTaskMethodBuilder.Create();
        stateMachine.State = -1;
        stateMachine.This = this;
        stateMachine.Builder.Start(ref stateMachine);
        return stateMachine.Builder.Task;
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
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFourth)}");

    private Task LongMethodFirst() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private Task LongMethodSecond() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private Task LongMethodThird() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private Task LongMethodFourth() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private class ExampleStateMachine : IAsyncStateMachine
    {
        public int State;
        public AsyncTaskMethodBuilder Builder;
        public ConwayCleanCode This;
        private TaskAwaiter _awaiter;
        
        public void MoveNext()
        {
            int num1 = State;
            try
            {
                int num2;
                TaskAwaiter awaiter1;
                TaskAwaiter awaiter2;
                TaskAwaiter awaiter3;
                TaskAwaiter awaiter4;
                switch (num1)
                {
                    case 0:
                        awaiter1 = _awaiter;
                        _awaiter = new TaskAwaiter();
                        State = num2 = -1;
                        awaiter1.GetResult();
                        This.MethodSecond();
                        awaiter2 = This.LongMethodSecond().GetAwaiter();
                        if (!awaiter2.IsCompleted)
                        {
                            State = num2 = 1;
                            _awaiter = awaiter2;
                            var stateMachine = this;
                            Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
                            return;
                        }
                        break;
                    case 1:
                        awaiter2 = _awaiter;
                        _awaiter = new TaskAwaiter();
                        State = num2 = -1;
                        awaiter2.GetResult();
                        This.MethodThird();
                        awaiter3 = This.LongMethodThird().GetAwaiter();
                        if (!awaiter3.IsCompleted)
                        {
                            State = num2 = 2;
                            _awaiter = awaiter3;
                            var stateMachine = this;
                            Builder.AwaitUnsafeOnCompleted(ref awaiter3, ref stateMachine);
                            return;
                        }
                        break;
                    case 2:
                        awaiter3 = _awaiter;
                        _awaiter = new TaskAwaiter();
                        State = num2 = -1;
                        awaiter3.GetResult();
                        This.MethodFourth();
                        awaiter4 = This.LongMethodFourth().GetAwaiter();
                        if (!awaiter4.IsCompleted)
                        {
                            State = num2 = 3;
                            _awaiter = awaiter4;
                            var stateMachine = this;
                            Builder.AwaitUnsafeOnCompleted(ref awaiter4, ref stateMachine);
                            return;
                        }
                        break;
                    case 3:
                        awaiter4 = _awaiter;
                        _awaiter = new TaskAwaiter();
                        State = num2 = -1;
                        awaiter4.GetResult();
                        This.MethodFifth();
                        break;
                    default:
                        This.MethodFirst();
                        awaiter1 = This.LongMethodFirst().GetAwaiter();
                        if (!awaiter1.IsCompleted)
                        {
                            State = num2 = 0;
                            _awaiter = awaiter1;
                            var stateMachine = this;
                            Builder.AwaitUnsafeOnCompleted(ref awaiter1, ref stateMachine);
                            return;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                State = -2;
                Builder.SetException(ex);
            }

            State = -2;
            Builder.SetResult();
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            
        }
    }
}