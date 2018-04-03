using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetIncident.Core.Tools
{
    public static class Convert
    {
        public static byte[] Base64StringToBytes(string base64String, string defaultString = "")
        {
            if (string.IsNullOrEmpty(base64String)) base64String = defaultString;
            if (string.IsNullOrEmpty(base64String)) return new byte[] { };
            return System.Convert.FromBase64String(base64String);
        }

        public static string BytesToBase64String(byte[] bytes)
        {
            if (bytes == null) return "";
            if (bytes.Length == 0) return "";
            return System.Convert.ToBase64String(bytes);
        }
    }
}
