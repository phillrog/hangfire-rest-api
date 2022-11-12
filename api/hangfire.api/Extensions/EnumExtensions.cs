using System.ComponentModel;
using System.Reflection;

namespace hangfire.api.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description;
        }

        public static string GetValueFromDescription(this Type @enum, string description)
        {
            foreach (var field in @enum.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute == null) continue;

                if (attribute.Description == description)
                {
                    return ((int)field.GetValue(null)).ToString();
                }
            }

            return string.Empty;
        }

        public static int ToInt(this Enum enumerable)
        {
            return (int)(object)enumerable;
        }

        public static IDictionary<int, string> ToEnumList(this Type enumType)
        {
            var lista = Enum.GetValues(enumType).Cast<int>()
            .ToDictionary(e => e, e => ((Enum)Enum.Parse(enumType, Enum.GetName(enumType, e))).GetDescription());

            return lista;
        }
    }
}
