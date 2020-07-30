﻿using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilkBot.Commands.GeneralCommands
{
    public class AvatarCommand : BaseCommandModule
    {
        [Command("Avatar")]
        public async Task GetAvatarAsync(CommandContext ctx)
        {
            await ctx.RespondAsync(embed: 
                new DiscordEmbedBuilder()
                .WithAuthor(ctx.Member.DisplayName, iconUrl: ctx.Member.AvatarUrl)
                .WithImageUrl(ctx.Member.AvatarUrl)
                .WithColor(DiscordColor.Green)
                .WithFooter("Silk", ctx.Client.CurrentUser.AvatarUrl)
                .WithTimestamp(DateTime.Now));
        }

        [Command("Avatar")]
        public async Task GetAvatarAsync(CommandContext ctx, DiscordMember user)
        {
            
            await ctx.RespondAsync(embed:
                new DiscordEmbedBuilder()
                .WithAuthor(ctx.Member.DisplayName, iconUrl: ctx.Member.AvatarUrl)
                .WithDescription($"{user.Mention}'s Avatar")
                .WithImageUrl(user.AvatarUrl)
                .WithColor(DiscordColor.CornflowerBlue)
                .WithFooter("Silk", ctx.Client.CurrentUser.AvatarUrl)
                .WithTimestamp(DateTime.Now));
        }


        [Command("Avatar")]
        [Priority(3)]
        public async Task GetAvatarAsync(CommandContext ctx, [RemainingText] string mention)
        {
            var user = ctx.Guild.Members.Where(m => m.Value.DisplayName.ToLower().StartsWith(mention.ToLower())).First().Value;

            await ctx.RespondAsync(embed:
                new DiscordEmbedBuilder()
                .WithAuthor(ctx.Member.DisplayName, iconUrl: ctx.Member.AvatarUrl)
                .WithDescription($"{user.Mention}'s Avatar")
                .WithImageUrl(user.AvatarUrl)
                .WithColor(DiscordColor.CornflowerBlue)
                .WithFooter("Silk", ctx.Client.CurrentUser.AvatarUrl)
                .WithTimestamp(DateTime.Now));
        }

    }
}