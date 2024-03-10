using Account.Apis.Errors;
using Account.Core.Dtos.Account;
using Account.Core.Models.Account;
using Account.Core.Models.Identity;
using Account.Core.Services;
using Account.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Account.Apis.Controllers
{
    public class AccountController : ApiBaseController
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _TokenService;
        private readonly UserManager<AppUser> _userManager;


        public AccountController(IAccountService accountService,ITokenService tokenService, UserManager<AppUser> userManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _TokenService = tokenService;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(Register model)
        {

            var result = await _accountService.RegisterAsync(model, GenerateCallBackUrl);
            
            var User = await _userManager.FindByEmailAsync(model.Email);
            if (User is not null)
            {
                return BadRequest(new ApiResponse(400, "Something went wrong"));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(new ApiResponse(404));
            }
           
            return Ok(new UserDto()
            {
                DisplayName = model.DisplayName,
                Email = model.Email,
                Token = await _TokenService.CreateTokenAsync(User) //"this will be atoken" 
            });

        }
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmUserEmail(string userId, string confirmationToken)
        {
            var result = await _accountService.ConfirmUserEmailAsync(userId!, confirmationToken!);
            if (result)
                return RedirectPermanent(@"https://www.google.com/webhp?authuser=0");

            return BadRequest(result);
        }
        private string GenerateCallBackUrl(string token, string userId)
        {
            var encodedToken = Uri.EscapeDataString(token);
            var encodedUserId = Uri.EscapeDataString(userId);
            var callBackUrl = $"{Request.Scheme}://{Request.Host}/api/Account/confirm-email?userId={encodedUserId}&confirmationToken={encodedToken}";
            return callBackUrl;
        }
    }
}
