namespace BootzorComponents.ZorEnums;

public static class ExtensionMetodsEnums
{
    private const string PREFIX = "Zor";

    /// <summary>
    /// Convert a type of the enum a string CSS adding Zor as a prefix
    /// </summary>
    /// <typeparam name="T">Enum type to use in css</typeparam>
    /// <param name="enumType">Concrete Enum</param>
    /// <returns>string of the complete name of the enum</returns>
    //TODO delete NOTE to the readers: enums implement IConvertible
    public static string GetNameClassCss<T>(this T enumType) 
        where T : struct, IConvertible 
    {
        try
        {
            return PREFIX  + typeof(T).Name + enumType.ToString();
        }
        catch
        {
            return PREFIX + typeof(T).Name + Position.Top.ToString();
        }
    }

    /// <summary>
    /// Obtener el tipo de enum
    /// </summary>
    /// <typeparam name="T">Enum type to use in css</typeparam>
    /// <param name="cssWitEnum">string con el prefijo del enum</param>
    /// <returns>Enum</returns>
    public static T GetEnumType<T>(this string cssWitEnum)
        where T : struct, IConvertible
    {
        try
        {
            var pos = cssWitEnum.Substring(2, (typeof(T).Name.Length + cssWitEnum.Length));
            return Enum.Parse<T>(pos);
        }
        catch 
        {
            return default;
        }
    }
}
