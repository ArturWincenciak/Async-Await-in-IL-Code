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
            try
            {
                switch (State)
                {
                    case -1:
                    {
                        This.MethodFirst();
                        State = 0;
                        _awaiter = This.LongMethodFirst().GetAwaiter();
                        if (!_awaiter.IsCompleted)
                        {
                            var stateMachine = this;
                            Builder.AwaitUnsafeOnCompleted(ref _awaiter, ref stateMachine);
                            return;
                        }

                        break;
                    }
                    case 0:
                    {
                        _awaiter.GetResult();
                        This.MethodSecond();
                        State = 1;
                        _awaiter = This.LongMethodSecond().GetAwaiter();
                        if (!_awaiter.IsCompleted)
                        {
                            var stateMachine = this;
                            Builder.AwaitUnsafeOnCompleted(ref _awaiter, ref stateMachine);
                            return;
                        }
                        break;
                    }
                    case 1:
                    {
                        _awaiter.GetResult();
                        This.MethodThird();
                        State = 2;
                        _awaiter = This.LongMethodThird().GetAwaiter();
                        if (!_awaiter.IsCompleted)
                        {
                            var stateMachine = this;
                            Builder.AwaitUnsafeOnCompleted(ref _awaiter, ref stateMachine);
                            return;
                        }
                        break;
                    }
                    case 2:
                    {
                        _awaiter.GetResult();
                        This.MethodFourth();
                        State = 3;
                        _awaiter = This.LongMethodFourth().GetAwaiter();
                        if (!_awaiter.IsCompleted)
                        {
                            var stateMachine = this;
                            Builder.AwaitUnsafeOnCompleted(ref _awaiter, ref stateMachine);
                            return;
                        }
                        break;
                    }
                    case 3:
                    {
                        _awaiter.GetResult();
                        This.MethodFifth();
                        break;
                    }
                    default:
                    {
                        throw new InvalidOperationException($"State equals {State}");
                    }
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