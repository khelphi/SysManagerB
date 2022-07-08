using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Helpers;
using SysManager.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SysManager.API.Admin.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AccountController
    {

        private readonly UserService _userService;
        public AccountController(UserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserPostLoginRequest request)
        {
            var response = await _userService.PostLoginAsync(request);
            return Utils.Convert(response);
        }

        [HttpPost("create-account")]
        public async Task<IActionResult> Post([FromBody] UserPostRequest request)
        {
            var response = await _userService.PostAsync(request);
            return Utils.Convert(response);
        }

        [HttpPut("recovery-account")]
        public async Task<IActionResult> Put([FromBody] UserPutRequest request)
        {
            var response = await _userService.PutAsync(request);
            return Utils.Convert(response);
        }


    }
}
