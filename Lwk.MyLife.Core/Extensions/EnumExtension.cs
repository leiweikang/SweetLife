using System.ComponentModel;

namespace Lwk.MyLife.Core.Extensions
{
    /// <summary>
    /// 枚举拓展类
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取到对应枚举的描述-没有描述信息，返回枚举值
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetEnumDescription(this Enum someEnum)
        {
            var type = someEnum.GetType();
            if (!type.IsEnum)
            {
                throw new Exception("传入类型不是枚举类型！");
            }
            var name = Enum.GetName(type, someEnum);
            if (name == null)
            {
                return string.Empty;
            }
            var field = type.GetField(name);
            if (field == null)
            {
                throw new Exception("传入类型不是枚举类型！");
            }
            if (!(Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute))
            {
                return name;
            }
            return attribute.Description;
        }

        /// <summary>
        /// 获取到对应枚举的名称
        /// </summary>
        /// <param name="enum"></param>
        /// <returns>成功：枚举名称；失败：获取枚举名称失败</returns>
        public static string GetEnumName(this Enum someEnum)
        {
            var type = someEnum.GetType();
            if (!type.IsEnum)
            {
                throw new Exception("传入类型不是枚举类型！");
            }
            var test = type.GetEnumName(someEnum);
            return type.GetEnumName(someEnum) ?? "获取枚举名称失败";
        }

        /// <summary>
        /// 获取到对应枚举的枚举值--整型
        /// </summary>
        /// <param name="enum"></param>
        /// <returns>枚举哈希值</returns>
        public static int GetEnumIntValue(this Enum someEnum)
        {
            var type = someEnum.GetType();
            if (!type.IsEnum)
            {
                throw new Exception("传入类型不是枚举类型！");
            }
            return someEnum.GetHashCode();
        }

        /// <summary>
        /// 获取到对应枚举的枚举值--字符串
        /// </summary>
        /// <param name="enum"></param>
        /// <returns>成功：枚举值；失败：获取枚举值（字符串）失败</returns>
        public static string GetEnumStringValue(this Enum someEnum)
        {
            var type = someEnum.GetType();
            if (!type.IsEnum)
            {
                throw new Exception("传入类型不是枚举类型！");
            }
            return someEnum.GetHashCode().ToString();
        }
    }
}
