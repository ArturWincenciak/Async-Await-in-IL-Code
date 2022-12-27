using System.Runtime.CompilerServices;

namespace Async_Await;

internal class JoyIl 
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
    
    private void LocalLogicMethodFirst() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(LocalLogicMethodFirst)}");

    private void LocalLogicMethodSecond() => 
        Console.WriteLine($"{Log.TimeNow} {nameof(LocalLogicMethodSecond)}");
    
    private Task LogRunningMethod() => 
        Task.Delay(TimeSpan.FromSeconds(30));
    
    private class ExampleStateMachine : IAsyncStateMachine
    {
        public int State;
        public AsyncTaskMethodBuilder Builder;
        public JoyIl This;
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
                    This.LocalLogicMethodFirst();
                    awaiter1 = This.LogRunningMethod().GetAwaiter();

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
                This.LocalLogicMethodSecond();
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