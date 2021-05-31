using System;
using System.Data;

namespace MMTShop.Common.ExtensionMethods
{
    public static class DataRowExtensions
    {
        public static string GetSafeString(this DataRow row, string columnName)
        {
            return !row.IsNull(columnName)
                ? row[columnName].ToString()
                : null;
        }

        public static int GetSafeInt(this DataRow row, string columnName)
        {
            return !row.IsNull(columnName)
                ? Int32.Parse(row[columnName].ToString())
                : 0;
        }

        public static bool GetSafeBool(this DataRow row, string columnName)
        {
            return !row.IsNull(columnName) && bool.Parse(row[columnName].ToString());
        }

        public static decimal GetSafeDecimal(this DataRow row, string columnName)
        {
            return !row.IsNull(columnName)
                ? decimal.Parse(row[columnName].ToString())
                : 0;
        }
    }
}
