﻿using System;

namespace SilkBot.Extensions
{
    public static class DateTimeExtensions
    {
        public static TimeSpan GetTime(this DateTime dt) => dt - DateTime.Now;
    }
}
