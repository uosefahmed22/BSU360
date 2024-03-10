using Account.Apis.Errors;
using Account.Core.Models.Account;
using Account.Core.Models.Identity;
using Account.Core.Services;
using Account.Reposatory.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using BNS360.Core.CustemExceptions;
using Account.Core.Dtos.Account;

namespace Account.Reposatory.Reposatories
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly MailSettings _mailSettings;
        public AccountService(UserManager<AppUser> userManager,
            IOptionsMonitor<MailSettings> options
            )
        {
            _userManager = userManager;
            _mailSettings = options.CurrentValue;
        }

        public async Task<ApiResponse> RegisterAsync(Register dto, Func<string, string, string> generateCallBackUrl)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);

            if (user is not null)
            {
                return new ApiResponse(400, "User with this email already exists.");
            }

            user = new AppUser
            {
                DisplayName = dto.DisplayName,
                UserName = dto.DisplayName,
                Email = dto.Email,
                EmailConfirmed = false
            };

            var Result = await _userManager.CreateAsync(user, dto.Password);


            if (!Result.Succeeded)
            {
                return new ApiResponse(400, "Something went wrong with the data you entered");
            }

            await _userManager.AddToRoleAsync(user, "User");

            var EmailConfirmation = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callBackUrl = generateCallBackUrl(EmailConfirmation, user.Id);
            var emailBody = $"<h1>Dear {user.UserName}! Welcome To BNS360.</h1><p>Please <a href='{callBackUrl}'>Click Here</a> To Confirm Your Email.</p>";

            await SendEmailAsync(user.Email, "Email Confirmation", emailBody);

            return new ApiResponse(200);

        }



        public async Task SendEmailAsync(string To, string Subject, string Body, CancellationToken Cancellation = default)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_mailSettings.DisplayedName, _mailSettings.Email));
            message.To.Add(new MailboxAddress("", To));
            message.Subject = Subject;

            message.Body = new TextPart("html")
            {
                Text = Body
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                await client.ConnectAsync(_mailSettings.SmtpServer, _mailSettings.Port,
                    SecureSocketOptions.StartTls, Cancellation);
                await client.AuthenticateAsync(_mailSettings.Email, _mailSettings.Password, Cancellation);
                await client.SendAsync(message, Cancellation);
                await client.DisconnectAsync(true, Cancellation);
            }
        }
        public async Task<bool> ConfirmUserEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            ItemNotFoundException.ThrowIfNull(user, nameof(user));

            var confirmed = await _userManager.ConfirmEmailAsync(user, token);

            if (confirmed.Succeeded)
                return true;

            return false;
        }
    }
}
