using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ClockWork.KeePass.Firefox.Gecko.NSS310
{
    public static class NSPR4
    {
        [DllImport("Gecko\\NSS310\\nspr4.dll")] //, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 PR_GetError();

        [DllImport("Gecko\\NSS310\\nspr4.dll")]
        public static extern string PR_ErrorToName(Int32 code);
    }
}

