using System.ComponentModel;

namespace PurrBank.BusinessRules.Enums.Extensions;

public static class EnumExtensions
{
    public static string GetDescription<T>(this T @enum)
    {
        DescriptionAttribute[] description = (DescriptionAttribute[])@enum.GetType().GetField(@enum.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);

        return description.Length > 0 ? description[0].Description : string.Empty;
    }
}
