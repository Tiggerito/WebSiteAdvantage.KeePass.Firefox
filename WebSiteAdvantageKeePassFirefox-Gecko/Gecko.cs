using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace WebSiteAdvantage.KeePass.Firefox.Gecko
{
    public class Gecko
    {
//        public static string Version = "NSS310";
        public static string Version
        {
            get
            {
				if (KeePassUtilities.Is64Bit)
					return "NSS64";

                return "NSS312";
            }
        }


    }
}
