using System.Runtime.CompilerServices;

namespace Async_Await;

internal class ConwayCleanCode
{
    public Task Example()
    {
        var stateMachine = new ExampleStateMachine(this);
        return stateMachine.Execute();
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
        Task.CompletedTask;

    private Task LongMethodSecond() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private Task LongMethodThird() =>
        Task.CompletedTask;

    private Task LongMethodFourth() =>
        Task.Delay(TimeSpan.FromSeconds(3));

    private class ExampleStateMachine : IAsyncStateMachine
    {
        private int _state;
        private AsyncTaskMethodBuilder _builder;
        private readonly ConwayCleanCode _target;
        private TaskAwaiter _awaiter;

        public ExampleStateMachine(ConwayCleanCode target)
        {
            _target = target;
            _builder = AsyncTaskMethodBuilder.Create();
            _state = -1;
        }

        public Task Execute()
        {
            var stateMachine = this;
            _builder.Start(ref stateMachine);
            return _builder.Task;
        }

        public void MoveNext()
        {
            try
            {
                switch (_state)
                {
                    case -1:
                    {
                        _state = 0;
                        _target.MethodFirst();
                        _awaiter = _target.LongMethodFirst().GetAwaiter();
                        if (!_awaiter.IsCompleted)
                        {
                            var stateMachine = this;
                            _builder.AwaitUnsafeOnCompleted(ref _awaiter, ref stateMachine);
                        }
                        else
                        {
                            MoveNext();
                        }
                        break;
                    }
                    case 0:
                    {
                        _state = 1;
                        _awaiter.GetResult();
                        _target.MethodSecond();
                        _awaiter = _target.LongMethodSecond().GetAwaiter();
                        if (!_awaiter.IsCompleted)
                        {
                            var stateMachine = this;
                            _builder.AwaitUnsafeOnCompleted(ref _awaiter, ref stateMachine);
                        }
                        else
                        {
                            MoveNext();
                        }
                        break;
                    }
                    case 1:
                    {
                        _state = 2;
                        _awaiter.GetResult();
                        _target.MethodThird();
                        _awaiter = _target.LongMethodThird().GetAwaiter();
                        if (!_awaiter.IsCompleted)
                        {
                            var stateMachine = this;
                            _builder.AwaitUnsafeOnCompleted(ref _awaiter, ref stateMachine);
                        }
                        else
                        {
                            MoveNext();
                        }
                        break;
                    }
                    case 2:
                    {
                        _state = 3;
                        _awaiter.GetResult();
                        _target.MethodFourth();
                        _awaiter = _target.LongMethodFourth().GetAwaiter();
                        if (!_awaiter.IsCompleted)
                        {
                            var stateMachine = this;
                            _builder.AwaitUnsafeOnCompleted(ref _awaiter, ref stateMachine);
                        }
                        else
                        {
                            MoveNext();
                        }
                        break;
                    }
                    case 3:
                    {
                        _awaiter.GetResult();
                        _target.MethodFifth();
                        
                        _state = -2;
                        _builder.SetResult();
                        break;
                    }
                    default:
                    {
                        throw new InvalidOperationException($"State equals {_state}");
                    }
                }
            }
            catch (Exception ex)
            {
                _state = -2;
                _builder.SetException(ex);
            }
        }

        public void SetStateMachine(IAsyncStateMachine stateMachine)
        {
            
        }
    }
}