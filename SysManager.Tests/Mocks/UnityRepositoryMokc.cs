using Moq;
using SysManager.Application.Contracts;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Test.Mocks
{
    public static class UnityRepositoryMokc
    {
        public static Mock<UnityRepository> MockGetBynameAsync(this Mock<UnityRepository> mock, UnityEntity response)
        {
            mock.Setup(x => x.GetUnityByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(response);

            return mock;
        }

        public static Mock<UnityRepository> MockPostAsync(this Mock<UnityRepository> mock, ResponseDefault response)
        {
            mock.Setup(x => x.PostAsync(It.IsAny<UnityEntity>()))
                .ReturnsAsync(response);

            return mock;
        }
    }
}
