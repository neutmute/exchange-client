using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

static class SecureStringExtensions
{
    public static string ToUnsecureString(this SecureString secureString)
    {
        if (secureString == null) throw new ArgumentNullException(nameof(secureString));

        var unmanagedString = IntPtr.Zero;
        try
        {
            unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
            return Marshal.PtrToStringUni(unmanagedString);
        }
        finally
        {
            Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
        }
    }

    public static SecureString ToSecureString(this string unsecureString)
    {
        if (unsecureString == null) throw new ArgumentNullException(nameof(unsecureString));

        return unsecureString.Aggregate(new SecureString(), AppendChar, MakeReadOnly);
    }

    private static SecureString MakeReadOnly(SecureString ss)
    {
        ss.MakeReadOnly();
        return ss;
    }

    private static SecureString AppendChar(SecureString ss, char c)
    {
        ss.AppendChar(c);
        return ss;
    }
}