using Moq;
using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Data.MySql;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Helpers;
using SysManager.Application.Services;
using SysManager.Test.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SysManager.Test.Services
{
    public class UnityServiceTests
    {
        private UnityService _service;
        private readonly Mock<UnityRepository> _mockRepository;


        public UnityServiceTests()
        {
            _mockRepository = new Mock<UnityRepository>(new MySqlContext());
        }

        [Fact(DisplayName = "Criando uma unidade de medida")]
        public async Task Unit_Post_Success()
        {
            //Arrange
            _service = new UnityService(_mockRepository.Object);
            
            var request = new UnityPostRequest
            {
                Name = "PÇ",
                Active = true
            };

            var response = new ResponseDefault(Guid.NewGuid().ToString(), "", true);
            _mockRepository.MockGetBynameAsync(null).MockPostAsync(response);

            //Action
            var result = await _service.PostAsync(request);

            //Assert
            Assert.True(result.Success);
            Assert.Equal(response.ToJson(),result.Data.ToJson());
            //Assert.Equal(response.ToJson(),result.Data.ToJson());
        }
    }

}
