using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SysManager.Application.Errors
{
    public enum SysManagerErrors
    {

        [Description("É necessário informar a propriedade UserName")]
        User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar a propriedade Email")]
        User_Post_BadRequest_Email_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar a propriedade Password")]
        User_Post_BadRequest_Password_Cannot_Be_Null_Or_Empty,
        [Description("Já Existe um usuário cadastrado com esse e-mail")]
        User_Post_BadRequest_Email_Cannot_Duplicate,

        [Description("Usuário ou e-mail invalidos, verifique")]
        User_Put_BadRequest_Email_Or_UserNameInvalid_Or_Inexistent,

        [Description("É necessário informar a propriedade UserName")]
        User_Put_BadRequest_UserName_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar a propriedade Email")]
        User_Put_BadRequest_Email_Cannot_Be_Null_Or_Empty,
        [Description("É necessário informar a propriedade Password")]
        User_Put_BadRequest_NewPassword_Cannot_Be_Null_Or_Empty,



        [Description("É necessário informar o nome da unidade de medida")]
        Unity_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar se a unidade é ativa ou inativa")]
        Unity_Post_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,

        [Description("Já existe uma unidade de medida com esse nome")]
        Unity_Post_BadRequest_Name_Cannot_Be_Duplicated,


        [Description("É necessário informar o id da unidade de medida")]
        Unity_Put_BadRequest_Id_Cannot_Be_Null_Or_Empty,

        [Description("Unidade de medida inválida ou inexistente")]
        Unity_Put_BadRequest_Id_Is_Invalid_Or_Inexistent,

        [Description("É necessário informar o nome da unidade de medida")]
        Unity_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty,

        [Description("É necessário informar se a unidade é ativa ou inativa")]
        Unity_Put_BadRequest_Active_Cannot_Be_Diferent_True_Or_False,

        [Description("Já existe uma unidade de medida com esse nome")]
        Unity_Put_BadRequest_Name_Cannot_Be_Duplicated,

        [Description("Unidade de medida inválida ou inexistente")]
        Unity_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent,



    }
}
