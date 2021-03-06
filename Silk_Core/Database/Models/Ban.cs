﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SilkBot.Models
{
    public class Ban
    {
        public int Id { get; set; }
        [Required]
        public UserModel UserInfo { get; set; }
        public GuildModel Guild { get; set; }
        public string GuildId { get; set; }
        public string Reason { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
