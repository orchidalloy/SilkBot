﻿using ConcurrentCollections;
using System;
using System.Linq;
using System.Timers;

namespace SilkBot.Tools
{
    public class TimedEventService
    {
        public ConcurrentHashSet<ITimedEvent> Events { get; } = new ConcurrentHashSet<ITimedEvent>();

        private Timer _timer = new Timer(60000);

        public TimedEventService()
        {
            _timer.Start();
            _timer.Elapsed += (s, o) => Events.ToList().ForEach(e => { if (DateTime.Now > e.Expiration) e.Callback.Invoke(e); });
        }
    }
}
