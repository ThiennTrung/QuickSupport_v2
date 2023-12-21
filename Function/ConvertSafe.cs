using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSupport.Function
{
    public class ConvertSafe
    {
        public static Boolean ToBoolean(object value) { return SafeCall(Convert.ToBoolean, value); }
        public static Byte ToByte(object value) { return SafeCall(Convert.ToByte, value); }
        public static Char ToChar(object value) { return SafeCall(Convert.ToChar, value); }
        public static Decimal ToDecimal(object value) { return SafeCall(Convert.ToDecimal, value); }
        public static Double ToDouble(object value) { return SafeCall(Convert.ToDouble, value); }
        public static Int16 ToInt16(object value) { return SafeCall(Convert.ToInt16, value); }
        public static Int32 ToInt32(object value) { return SafeCall(Convert.ToInt32, value); }
        public static Int64 ToInt64(object value) { return SafeCall(Convert.ToInt64, value); }
        public static SByte ToSByte(object value) { return SafeCall(Convert.ToSByte, value); }
        public static Single ToSingle(object value) { return SafeCall(Convert.ToSingle, value); }
        public static String ToString(object value) { return SafeCall(Convert.ToString, value, string.Empty); }
        public static UInt16 ToUInt16(object value) { return SafeCall(Convert.ToUInt16, value); }
        public static UInt32 ToUInt32(object value) { return SafeCall(Convert.ToUInt32, value); }
        public static UInt64 ToUInt64(object value) { return SafeCall(Convert.ToUInt64, value); }


        public static object NullWhenEmpty(object value)
        {
            var text = ToString(value);
            if (string.IsNullOrEmpty(text))
                return null;

            return value;
        }


        private static T SafeCall<T>(Func<object, T> convertFunc, object value)
        {
            if (value == null)
                return default(T);

            if (value + "" == "")
                return default(T);

            return SafeCall(convertFunc, value, default(T));
        }


        private static T SafeCall<T>(Func<object, T> convertFunc, object value, T @default)
        {
            if (value == null)
                return @default;

            if (value + "" == "")
                return @default;

            try
            {
                return convertFunc(value);
            }
            catch
            {
            }

            return @default;
        }


        public static DateTime? ToDateTime(object value)
        {
            if (value == null)
                return null;

            if (value + "" == "")
                return null;

            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
            }

            return null;
        }

        public static DateTime ToDateTime(object value, DateTime @default)
        {
            if (value == null)
                return @default;

            if (value + "" == "")
                return @default;

            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
            }

            return @default;
        }

        public static TimeSpan ToTimeSpan(object value)
        {
            try
            {
                return TimeSpan.Parse(value.ToString());
            }
            catch
            {
            }

            return new TimeSpan();
        }
    }
}
