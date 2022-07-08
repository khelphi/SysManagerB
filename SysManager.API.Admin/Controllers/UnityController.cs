using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Helpers;
using SysManager.Application.Services;
using System;
using System.Threading.Tasks;

namespace SysManager.API.Admin.Controllers
{

    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UnityController
    {
        private readonly UnityService _unityService;
        public UnityController(UnityService unityService)
        {
            this._unityService = unityService;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Post([FromBody] UnityPostRequest request)
        {
            var response = await _unityService.PostAsync(request);
            return Utils.Convert(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put([FromBody] UnityPutRequest request)
        {
            var response = await _unityService.PutAsync(request);
            return Utils.Convert(response);
        }

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetByfilter([FromQuery] UnityGetFilterRequest request)
        {
            var response = await _unityService.GetFilterAsync(request);
            return Utils.Convert(response);
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var response = await _unityService.GetAsync(id);
            return Utils.Convert(response);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await _unityService.DeleteAsync(id);
            return Utils.Convert(response);
        }
    }
}
