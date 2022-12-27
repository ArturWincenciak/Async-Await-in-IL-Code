using System.Runtime.CompilerServices;

namespace Async_Await;

internal class GrahamIl
{
    public Task Example()
    {
        var stateMachine = new ExampleStateMachine();
        stateMachine.Builder = AsyncTaskMethodBuilder.Create();
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

    private Task LongMethodFirst() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private Task LongMethodSecond() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private class ExampleStateMachine : IAsyncStateMachine
    {
        public int State;
        public AsyncTaskMethodBuilder Builder;
        public GrahamIl This;
        private TaskAwaiter _awaiter;

        public void MoveNext()
        {
            int num1 = State;
            try
            {
                TaskAwaiter awaiter1;
                int num2;
                TaskAwaiter awaiter2;
                if (num1 != 0)
                {
                    if (num1 != 1)
                    {
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
                    }
                    else
                    {
                        awaiter2 = _awaiter;
                        _awaiter = new TaskAwaiter();
                        State = num2 = -1;
                        goto label;
                    }
                }
                else
                {
                    awaiter1 = _awaiter;
                    _awaiter = new TaskAwaiter();
                    State = num2 = -1;
                }
                
                awaiter1.GetResult();
                This.LongMethodSecond();
                awaiter2 = This.LongMethodSecond().GetAwaiter();
                if (!awaiter2.IsCompleted)
                {
                    State = num2 = 1;
                    _awaiter = awaiter2;
                    var stateMachine = this;
                    Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
                    return;
                }

                label:
                awaiter2.GetResult();
                This.MethodThird();
            }
            catch (Exception ex)
            {
                State = -2;
                Builder.SetException(ex);
            }

            State = -1;
            Builder.SetResult();
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {

        }
    }
}