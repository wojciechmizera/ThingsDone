using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ThingsDone
{
    public static class SecureStringHelpers
    {
        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null) return string.Empty;

            //return new System.Net.NetworkCredential()


            IntPtr unmanaged = IntPtr.Zero;

            try
            {
                unmanaged = Marshal.SecureStringToGlobalAllocUnicode(secureString);

                // TODO fix
                return Marshal.PtrToStringUni(unmanaged);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanaged);
            }
        }
    }
}
