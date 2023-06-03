namespace Aviatia.Data.Extentions;

public static class StringExtension
{
    public static string ToSnakeCase(this String str)
    {
        return string.Join("_", string.Concat(string.Join("_", str.Split(new char[] {},
                        StringSplitOptions.RemoveEmptyEntries))
                    .Select(c => char.IsUpper(c)
                        ? $"_{c}".ToLower()
                        : $"{c}"))
                .Split(new[] {'_'}, StringSplitOptions.RemoveEmptyEntries));
    }
}