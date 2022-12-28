using System.Runtime.CompilerServices;

namespace Async_Await;

internal class PlanckIl
{
    public Task<float> Example()
    {
        var stateMachine = new ExampleStateMachine();
        stateMachine.Builder = AsyncTaskMethodBuilder<float>.Create();
        stateMachine.This = this;
        stateMachine.State = -1;
        stateMachine.Builder.Start(ref stateMachine);
        return stateMachine.Builder.Task;
    }

    private void MethodFirst(int methodFirstArg) => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFirst)} {methodFirstArg}");

    private void MethodSecond(int methodSecondArg) => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodSecond)} {methodSecondArg}");

    private void MethodThird(string methodThirdArg) => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodThird)} {methodThirdArg}");

    private void MethodFourth(int methodFourthArg) => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFourth)} {methodFourthArg}");

    private void MethodFifth(int methodFifthArg) => 
        Console.WriteLine($"{Log.TimeNow} {nameof(MethodFifth)} {methodFifthArg}");

    private Task<int> LongMethodFirst(int firstArg) => 
        Task.FromResult(firstArg + 100);

    private Task<string> LongMethodSecond(int secondArg) => 
        Task.FromResult((secondArg + 100).ToString());

    private Task<int> LongMethodThird(int thirdArg) => 
        Task.FromResult(thirdArg + 100);

    private Task<int> LongMethodFourth(int fourthArg) => 
        Task.FromResult(fourthArg + 100);

    private sealed class ExampleStateMachine : IAsyncStateMachine
    {
        private TaskAwaiter<int> _awaiterInt;
        private TaskAwaiter<string> _awaiterStr;

        private int _firstResult;
        private int _fourthResult;

        private int _r1;
        private string _r2;
        private int _r3;
        private int _r4;
        private string _secondResult;

        private int _startArg;
        private int _thirdResult;
        public AsyncTaskMethodBuilder<float> Builder;
        public int State;
        public PlanckIl This;

        public void MoveNext()
        {
            var num1 = State;
            float fourthResult;
            try
            {
                TaskAwaiter<int> awaiter1;
                int num2;
                TaskAwaiter<string> awaiter2;
                TaskAwaiter<int> awaiter3;
                TaskAwaiter<int> awaiter4;
                switch (num1)
                {
                    case 0:
                        awaiter1 = _awaiterInt;
                        _awaiterInt = new TaskAwaiter<int>();
                        State = num2 = -1;
                        break;
                    case 1:
                        awaiter2 = _awaiterStr;
                        _awaiterStr = new TaskAwaiter<string>();
                        State = num2 = -1;
                        goto label_1;
                    case 2:
                        awaiter3 = _awaiterInt;
                        _awaiterInt = new TaskAwaiter<int>();
                        State = num2 = -1;
                        goto label_2;
                    case 3:
                        awaiter4 = _awaiterInt;
                        _awaiterInt = new TaskAwaiter<int>();
                        State = num2 = -1;
                        goto label_3; 
                    default:
                        _startArg = 100;
                        This.MethodFirst(_startArg);
                        awaiter1 = This.LongMethodFirst(_startArg).GetAwaiter();
                        if (!awaiter1.IsCompleted)
                        {
                            State = num2 = 0;
                            _awaiterInt = awaiter1;
                            var stateMachine = this;
                            Builder.AwaitUnsafeOnCompleted(ref awaiter1, ref stateMachine);
                            return;
                        }

                        break;
                }

                _r1 = awaiter1.GetResult();
                _firstResult = _r1;
                This.MethodSecond(_firstResult);
                awaiter2 = This.LongMethodSecond(_firstResult).GetAwaiter();
                if (!awaiter2.IsCompleted)
                {
                    State = num2 = 1;
                    _awaiterStr = awaiter2;
                    var stateMachine = this;
                    Builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
                    return;
                }

                label_1:
                _r2 = awaiter2.GetResult();
                _secondResult = _r2;
                _r2 = null!;
                This.MethodThird(_secondResult);
                awaiter3 = This.LongMethodThird(int.Parse(_secondResult)).GetAwaiter();
                if (!awaiter3.IsCompleted)
                {
                    State = num2 = 2;
                    _awaiterInt = awaiter3;
                    var stateMachine = this;
                    Builder.AwaitUnsafeOnCompleted(ref awaiter3, ref stateMachine);
                    return;
                }

                label_2:
                _r3 = awaiter3.GetResult();
                _thirdResult = _r3;
                This.MethodFourth(_thirdResult);
                awaiter4 = This.LongMethodFourth(_thirdResult).GetAwaiter();
                if (!awaiter4.IsCompleted)
                {
                    State = num2 = 3;
                    _awaiterInt = awaiter4;
                    var stateMachine = this;
                    Builder.AwaitUnsafeOnCompleted(ref awaiter4, ref stateMachine);
                }
            
                label_3:
                _r4 = awaiter4.GetResult();
                _fourthResult = _r4;
                This.MethodFirst(_fourthResult);
                fourthResult = (float) _fourthResult;
            }
            catch (Exception ex)
            {
                State = -2;
                _secondResult = null!;
                Builder.SetException(ex);
                return;
            }

            State = -2;
            _secondResult = null!;
            Builder.SetResult(fourthResult);
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            
        }
    }
}