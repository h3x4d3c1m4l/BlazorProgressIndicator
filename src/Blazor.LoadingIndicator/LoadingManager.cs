using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Blazor.LoadingIndicator
{
    public static class LoadingManager
    {
        private class TaskContext
        {
            public List<RunningTask> Tasks = new List<RunningTask>();
            public EventHandler Changed;
        }

        private static ConcurrentDictionary<string, TaskContext> _dict = new ConcurrentDictionary<string, TaskContext>();

        public static IRunningTask Loading(string context = "", string maintext = null, string subtext = null)
        {
            if (context == null)
                context = string.Empty;

            var task = new RunningTask(context) { Maintext = maintext, Subtext = subtext };
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
                c.Changed?.Invoke(null, null);
            }

            return task;
        }

        public static void SubscribeToEvents(string context, Action<IRunningTask> action)
        {
            if (!_dict.TryGetValue(context, out TaskContext c))
            {
                c = new TaskContext();
                _dict.TryAdd(context, c);
            }
            c.Changed += (_, __) => action(c.Tasks.LastOrDefault());
        }

        public static void DesubscribeToEvents(string context, Action action)
        {
            if (_dict.TryGetValue(context, out TaskContext c))
            {
                c.Changed -= (_, __) => action();
            }
        }

        private class RunningTask : IRunningTask
        {
            private string _context;

            private double? _progress;

            private string _maintext;

            private string _subtext;

            public RunningTask(string context)
            {
                _context = context;
            }

            public double? Progress
            {
                get => _progress;
                set
                {
                    _progress = value;
                    var c = _dict[_context];
                    c.Changed?.Invoke(null, null);
                }
            }

            public string Maintext
            {
                get => _maintext;
                set
                {
                    _maintext = value;
                    var c = _dict[_context];
                    c.Changed?.Invoke(null, null);
                }
            }

            public string Subtext
            {
                get => _subtext;
                set
                {
                    _subtext = value;
                    var c = _dict[_context];
                    c.Changed?.Invoke(null, null);
                }
            }

            public void Dispose()
            {
                var c = _dict[_context];
                lock (c)
                {
                    c.Tasks.Remove(this);
                }
                c.Changed?.Invoke(null, null);
            }
        }
    }
}
