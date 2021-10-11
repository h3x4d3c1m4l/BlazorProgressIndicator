using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3x.BlazorProgressIndicator
{
    public class IndicatorService : IIndicatorService
    {
        private static ConcurrentDictionary<string, TaskContext> _dict = new ConcurrentDictionary<string, TaskContext>();

        public bool DumpExceptionsToConsole { get; set; }

        public IndicatorOptions Options { get; set; }

        public async Task StartTaskAsync(Func<ITaskStatus, Task> action, string context = null, string maintext = null, string subtext = null)
        {
            if (context == null)
                context = string.Empty;

            using var task = new RunningTask(context, maintext, subtext);
            if (!_dict.TryGetValue(context, out TaskContext c))
            {
                c = new TaskContext
                {
                    Tasks = { task }
                };
                _dict.TryAdd(context, c);
            }
            else
            {
                lock (c)
                {
                    c.Tasks.Add(task);
                }
                c.FireChanged();
            }

            try
            {
                await action(task);
            }
            catch (Exception ex)
            {
                task.Exception = ex;
                if (DumpExceptionsToConsole)
                {
                    Console.Error.Write(ex);
                }
            }
        }

        public void SubscribeToTaskProgressChanged(string context, Func<ITaskStatus, Task> action)
        {
            if (!_dict.TryGetValue(context, out TaskContext c))
            {
                c = new TaskContext();
                _dict.TryAdd(context, c);
            }

            c.Changed += action;
            c.FireChanged();
        }

        public void UnsubscribeFromTaskProgressChanged(string context, Func<ITaskStatus, Task> action)
        {
            if (_dict.TryGetValue(context, out TaskContext c))
            {
                c.Changed -= action;
            }
        }

        private class TaskContext
        {
            public List<RunningTask> Tasks = new List<RunningTask>();
            public event Func<ITaskStatus, Task> Changed;

            public void FireChanged()
            {
                Changed?.Invoke(Tasks.LastOrDefault());
            }
        }

        private class RunningTask : ITaskStatus
        {
            private string _context;

            private double? _progressValue;

            private double? _progressMax;

            private string _maintext;

            private string _subtext;

            private Exception _exception;

            private TaskStatus _status;

            public RunningTask(string context, string maintext, string subtext)
            {
                _context = context;
                _maintext = maintext;
                _subtext = subtext;
            }

            public void DismissException()
            {
                if (_exception != null)
                    Dispose();
            }

            public double? ProgressValue
            {
                get => _progressValue;
                set
                {
                    _progressValue = value;
                    var c = _dict[_context];
                    c.FireChanged();
                }
            }

            public double? ProgressMax
            {
                get => _progressMax;
                set
                {
                    _progressMax = value;
                    var c = _dict[_context];
                    c.FireChanged();
                }
            }

            public string Maintext
            {
                get => _maintext;
                set
                {
                    _maintext = value;
                    var c = _dict[_context];
                    c.FireChanged();
                }
            }

            public string Subtext
            {
                get => _subtext;
                set
                {
                    _subtext = value;
                    var c = _dict[_context];
                    c.FireChanged();
                }
            }

            public Exception Exception
            {
                get => _exception;
                set
                {
                    _exception = value;
                    var c = _dict[_context];
                    c.FireChanged();
                }
            }

            public TaskStatus Status
            {
                get => _status;
                set
                {
                    _status = value;
                    var c = _dict[_context];
                    c.FireChanged();
                }
            }

            public void Dispose()
            {
                var c = _dict[_context];
                lock (c)
                {
                    c.Tasks.Remove(this);
                }
                c.FireChanged();
            }
        }
    }
}
