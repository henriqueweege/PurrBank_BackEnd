using System.ComponentModel;

namespace PurrBank.BusinessRules.Enums;

public enum ESuccessMessages
{
    [Description("Ok: Requisição completada com sucesso.")]
    OK_REQUISITON_COMPLETED_SUCCESSFULLY = 1,

    [Description("NoContent: Requisição completada com sucesso.")]
    NO_CONTENT_REQUISITON_COMPLETED_SUCCESSFULLY = 2,
    
    [Description("Ok: email já está cadastrado.")]
    EMAIL_ALREADY_REGISTERED = 3
}
