using System;
using System.ComponentModel;
using System.Reflection;

namespace usantatecla.utils
{

    public static class EnumExtension{

        public static string GetDescription(this Enum enumeration){
            Type genericEnumType = enumeration.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(enumeration.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((_Attribs != null && _Attribs.Length > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)_Attribs[0]).Description;
                }
            }
            return enumeration.ToString();
        }

        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach(var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }
    }
}
