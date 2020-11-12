﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SilkBot.Commands.Miscellaneous
{
    public class NicknameCommand : BaseCommandModule
    {
        private readonly ILogger<NicknameCommand> _logger;

        public NicknameCommand(ILogger<NicknameCommand> logger)
        {
            _logger = logger;
        }

        [Command("nickname")]
        [Aliases("nick")]
        public async Task SetNickName(CommandContext ctx, DiscordMember target, [RemainingText] string nick)
        {
            await ctx.Message.DeleteAsync();
            if (nick.Length > 32)
            {
                await ctx.RespondAsync("Nickname out of bounds! Limit: 32 characters");
                return;
            }
            try
            {
                await target.ModifyAsync(t => t.Nickname = nick);
            }
            catch (Exception e)
            {
                await ctx.RespondAsync("Could not set nickname!");
                _logger.LogWarn($"Attempted to modify {target.Username} ({target.Nickname} -> {nick}), but an exception was thrown.");
            }

        }
    }
}