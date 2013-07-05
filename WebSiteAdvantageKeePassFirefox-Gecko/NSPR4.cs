using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WebSiteAdvantage.KeePass.Firefox.Gecko
{
    public static class NSPR4
    {
        
        public static Int32 PR_GetError()
        {
            switch (Gecko.Version)
            {
				//case "NSS310":
				//    return NSS310.NSPR4.PR_GetError();
                case "NSS312":
                    return NSS312.NSPR4.PR_GetError();
                case "NSS64":
                    return NSS64.NSPR4.PR_GetError();
                default:
                    throw new Exception("Not Supported");
            }
        }

        public static string PR_ErrorToName(Int32 code)
        {
            switch (Gecko.Version)
            {
				//case "NSS310":
				//    return NSS310.NSPR4.PR_ErrorToName(code);
                case "NSS312":
                    return NSS312.NSPR4.PR_ErrorToName(code);
                case "NSS64":
                    return NSS64.NSPR4.PR_ErrorToName(code);
                default:
                    throw new Exception("Not Supported");
            }
        }
    }
}

