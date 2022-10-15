using System.Text.RegularExpressions;

namespace VivaBillingNewWeb
{
    public static class StaticFunctions
    {
        public static string ConvertToTitleCase(string str)
        {
            str = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
            return str;
        }
        public static string getValidString(string str, bool allowSingleSpace,bool isEmail)
        {
            if(allowSingleSpace)
                str = Regex.Replace(str, @"\s+", " ").ToLower().Trim();
            else
                str = Regex.Replace(str, @"\s+", "").ToLower().Trim();
            if (!isEmail)
                str=ConvertToTitleCase(str);
            return str;
           
        }

        public static string getValidEmail(string str)
        {
            return Regex.Replace(str, @"\s+", "").ToLower().Trim();
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsValidMobile(string mobile)
        {
            try
            {
                if (mobile.Length != 10)
                    return false;
                Regex regex = new Regex("[^0-9]");
                if (regex.IsMatch(mobile))
                    return false;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}