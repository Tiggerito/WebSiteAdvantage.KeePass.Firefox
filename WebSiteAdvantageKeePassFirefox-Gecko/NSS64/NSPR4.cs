using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WebSiteAdvantage.KeePass.Firefox.Gecko.NSS64
{
    public static class NSPR4
    {
        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nspr4.dll")] //, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 PR_GetError();

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nspr4.dll")]
        public static extern string PR_ErrorToName(Int32 code);
    }
}

