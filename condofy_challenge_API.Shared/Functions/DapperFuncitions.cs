using System.Text.RegularExpressions;

namespace condofy_challenge_API.Shared.Functions
{
    public static class DapperFuncitions
    {
        public static string FillLikeOperator(this string field)
        {
            if (string.IsNullOrEmpty(field))
                field = "";

            field = Regex.IsMatch(field, @"^[a-zA-Z0-9 ]+$") ? field : "";
            return "%" + field + "%";
        }

        public static string ExistsWhere(string sql)
        {
            if (string.IsNullOrEmpty(sql))
                return "";

            if (!sql.Contains("select") || !sql.Contains("from"))
                return "";

            return sql.ToLower().Contains("where") ? "and" : "where";
        }
    }
}
