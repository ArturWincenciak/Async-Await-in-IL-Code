using System.Runtime.CompilerServices;

namespace Async_Await;

internal class KnuthIl 
{
    public Task Example()
    {
        var stateMachine = new ExampleStateMachine();
        stateMachine.Builder = AsyncTaskMethodBuilder.Create();
        stateMachine.This = this;
        stateMachine.State = -1;
        stateMachine.Builder.Start(ref stateMachine);
        return stateMachine.Builder.Task;
    }
    
    private void MethodFirst() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFirst)}");

    private void MethodSecond() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodSecond)}");
    
    private Task LongMethod() => 
        Task.Delay(TimeSpan.FromSeconds(3));
    
    private class ExampleStateMachine : IAsyncStateMachine
    {
        public int State;
        public AsyncTaskMethodBuilder Builder;
        public KnuthIl This;
        private TaskAwaiter _awaiter;

        public void MoveNext()
        {
            int num1 = State;
            try
            {
                TaskAwaiter awaiter1;
                int num2;
                if (num1 != 0)
                {
                    This.MethodFirst();
                    awaiter1 = This.LongMethod().GetAwaiter();

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
                    awaiter1 = _awaiter;
                    _awaiter = new TaskAwaiter();
                    State = num2 = -1;
                }

                awaiter1.GetResult();
                This.MethodSecond();
            }
            catch (Exception ex)
            {
                State = -2;
                Builder.SetException(ex);
                return;
            }

            State = -2;
            Builder.SetResult();
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            
        }
    }
}