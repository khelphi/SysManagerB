using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Contracts.Users.Response;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;
using SysManager.Application.Validators.User.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<ResultData> PostLoginAsync(UserPostLoginRequest request)
        {
            var openData = request.Email + ":" + request.Password + ":" + Utils.GetDateExpired(10);
            var dataBytes = Utils.ToBase64Encode(openData);
            var getuser = await _userRepository.GetUserByCredentialsAsync(request.Email, request.Password);
            if (getuser != null)
            {
                var response = new AccountResponse
                {
                    Id = getuser.Id.ToString(),
                    Message = "Token successful",
                    Token = dataBytes
                };
                return Utils.SuccessData(response);
            }
            return Utils.ErrorData(new AccountResponse { Message = "Token Fail" });
        }

        public async Task<UserEntity> Authenticate(string email, string password)
        {
            var userExists = await _userRepository.GetUserByCredentialsAsync(email, password);
            return userExists;
        }

        public async Task<ResultData> PostAsync(UserPostRequest request)
        {
            var validator = new UserPostRequestValidator(_userRepository);
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorCodeList());

            var entity = new UserEntity(request);
            return Utils.SuccessData(await this._userRepository.PostAsync(entity));
        }

        public async Task<ResultData> PutAsync(UserPutRequest request)
        {
            var validator = new UserPutRequestValidator(_userRepository);
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid)
                return Utils.ErrorData(validationResult.Errors.ToErrorCodeList());

            var userExists = await _userRepository.GetUserByUserNameAndEmailAsync(request.UserName, request.Email);

            return Utils.SuccessData(await _userRepository.RecoveryAsync(userExists.Id, request.NewPassword));

        }
    }
}
