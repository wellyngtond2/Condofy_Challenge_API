using System;
using System.Text.RegularExpressions;

namespace condofy_challenge_API.Shared.Functions
{
    public static class StringFunctions
    {
        public static int ToInt(this string inputData)
        {
            if (string.IsNullOrEmpty(inputData) || !Regex.IsMatch(inputData, @"^[0-9]+$"))
                return 0;

            return Convert.ToInt32(inputData);
        }
        public static decimal ToDecimal(this string inputData)
        {
            if (string.IsNullOrEmpty(inputData) || !Regex.IsMatch(inputData, @"^[0-9]+$"))
                return 0M;

            return Convert.ToDecimal(inputData);
        }

        public static DateTime ToDate(this string inputData)
        {
            var dateTimeRegex = @"^\d\d\d\d-(0?[1-9]|1[0-2])-(0?[1-9]|[12][0-9]|3[01]) (00|[0-9]|1[0-9]|2[0-3]):([0-9]|[0-5][0-9]):([0-9]|[0-5][0-9])$";
            var dateUS = @"^\d\d\d\d-(0?[1-9]|1[0-2])-(0?[1-9]|[12][0-9]|3[01])";
            var dateBR = @"^(0?[1-9]|[12][0-9]|3[01])-(0?[1-9]|1[0-2])-\d\d\d\d";

            if (string.IsNullOrEmpty(inputData.StandardizeDate()) || (!Regex.IsMatch(inputData.StandardizeDate(), dateTimeRegex) && !Regex.IsMatch(inputData.StandardizeDate(), dateUS) && !Regex.IsMatch(inputData.StandardizeDate(), dateBR)))
                return new DateTime(1900, 01, 01);

            return Convert.ToDateTime(inputData).Date;
        }

        private static string StandardizeDate(this string inputData)
        {
            if (string.IsNullOrEmpty(inputData))
                return "";
            return inputData.Replace("/", "-");
        }

        public static string IsValid(this string inputData)
        {
            if (string.IsNullOrEmpty(inputData))
                return "";

            return inputData.Trim();
        }
    }
}
