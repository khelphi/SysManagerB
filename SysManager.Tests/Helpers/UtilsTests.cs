using SysManager.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SysManager.Test.Helpers
{
    public class UtilsTests
    {
        [Fact(DisplayName = "Teste de conversão para base64")]
        public void Base64_Conversion_Success()
        {
            //Arrange
            var text = "texto de teste";
            var textBase64 = "dGV4dG8gZGUgdGVzdGU=";

            //Action
            var result = text.ToBase64Encode();

            //Assert
            Assert.Equal(textBase64, result);
        }

    }
}
