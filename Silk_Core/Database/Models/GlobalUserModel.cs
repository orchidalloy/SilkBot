﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SilkBot.Database.Models
{
    public class GlobalUserModel
    {
        [Key]
        public ulong Id { get; set; }
        public int Cash { get; set; }
        public DateTime LastCashOut { get; set; }

    }
}
