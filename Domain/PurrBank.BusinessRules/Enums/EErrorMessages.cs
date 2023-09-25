using System.ComponentModel;

namespace PurrBank.BusinessRules.Enums;

public enum EErrorMessages
{
    [Description("InternalServerError: algum erro ocorreu.")]
    INTERNAL_SERVER_ERROR = 1,

    [Description("BadRequest: requisição inválida.")]
    BAD_REQUEST = 2,

    [Description("BadRequest: email é inválido.")]
    BAD_REQUEST_INVALID_EMAIL = 3,

}
