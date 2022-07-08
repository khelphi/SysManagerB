using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Contracts.Users.Request
{
    /// <summary>
    /// Classe de contrato responsável pela requisição de cadastro de usuário
    /// </summary>
    public class UserPostRequest
    {
        /// <summary>
        /// Propriedade referente ao nome de usuário do contrato
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Propriedade referente ao emai de usuário do contrato
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Propriedade referente a senha de usuário do contrato
        /// </summary>
        public string Password { get; set; }
    }
}
