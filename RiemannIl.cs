using System.Runtime.CompilerServices;

namespace Async_Await;

internal class RiemannIl
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

    private void MethodThird() =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodThird)}");

    private void MethodFourth() =>
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFourth)}");

    private Task LongMethodFirst() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private Task LongMethodSecond() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private Task LongMethodThird() =>
        Task.Delay(TimeSpan.FromSeconds(3));
    
    private class ExampleStateMachine : IAsyncStateMachine
    {
        public int State;
        public AsyncTaskMethodBuilder Builder;
        public RiemannIl This;
        private TaskAwaiter _awaiter;
        
        public void MoveNext()
        {
            int num1 = State;
            try
            {
                TaskAwaiter awaiter1;
                int num2;
                TaskAwaiter awaiter2;
                TaskAwaiter awaiter3;

                switch (num1)
                {
                    case 0:
                        awaiter1 = _awaiter;
                        _awaiter = new TaskAwaiter();
                        State = num2 = -1;
                        break;
                    case 1:
                        awaiter2 = _awaiter;
                        _awaiter = new TaskAwaiter();
                        State = num2 = -1;
                        goto label_1;
                    case 2:
                        awaiter3 = _awaiter;
                        _awaiter = new TaskAwaiter();
                        State = -1;
                        goto label_2;
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
                
                label_1:
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
                
                label_2:
                awaiter3.GetResult();
                This.MethodFourth();
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