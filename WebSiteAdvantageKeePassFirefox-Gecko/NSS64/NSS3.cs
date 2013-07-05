/*    WebSiteAdvantage KeePass to Firefox 
 *    Copyright (C) 2008 - 2012  Anthony James McCreath
 *
 *    This library is free software; you can redistribute it and/or
 *    modify it under the terms of the GNU Lesser General Public
 *    License as published by the Free Software Foundation; either
 *    version 2.1 of the License, or (at your option) any later version.
 *
 *    This library is distributed in the hope that it will be useful,
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *    Lesser General Public License for more details.
 *
 *    You should have received a copy of the GNU Lesser General Public
 *    License along with this library; if not, write to the Free Software
 *    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace WebSiteAdvantage.KeePass.Firefox.Gecko.NSS64
{
	/// <summary>
	/// provides access to the nss3 dll
	/// </summary>
	public static class NSS3
	{
		private static bool _Loaded = false;
		public static void LoadDependencies()
		{
			if (!_Loaded)
			{
				_Loaded = true;
				// before it works
				int i = 0;

                if (!File.Exists("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\mozcrt19.dll"))
                    throw new Exception("Failed to find WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\mozcrt19.dll Please re-check the installation process");

                if (!File.Exists("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\sqlite3.dll"))
                    throw new Exception("Failed to find WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\sqlite3.dll Please re-check the installation process");

                i = LoadLibrary("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\mozcrt19.dll"); // needed
				if (i == 0)
                    throw new Exception("Failed to load WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\mozcrt19.dll");  // GetLastError for details

                i = LoadLibrary("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\sqlite3.dll");// needed
				if (i == 0)
                    throw new Exception("Failed to load WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\sqlite3.dll");
			}
		}

		#region DLL Methods
		//[DllImport("kernel64.dll", EntryPoint = "LoadLibraryA")]
		[DllImport("kernel32.dll", EntryPoint = "LoadLibraryA")] // Fix from Theo
		public static extern int LoadLibrary(string lpLibFileName);

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SECStatus NSS_Init([MarshalAs(UnmanagedType.LPStr)]  string profilePath);

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SECStatus NSS_Shutdown();

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr PK11_GetInternalKeySlot();

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void PK11_FreeSlot(IntPtr slot);

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SECStatus PK11_CheckUserPassword(IntPtr slot, string password);

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SECStatus PK11_Authenticate(IntPtr slot, bool loadCerts, IntPtr wincx);

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SECStatus PK11SDR_Decrypt(IntPtr encryptedItem, ref SECItem text, IntPtr cx);

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NSSBase64_DecodeBuffer(IntPtr p1, IntPtr p2, string encoded, int encoded_len);

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SECITEM_FreeItem(ref SECItem item, int bDestroy);

        [DllImport("WebSiteAdvantageKeePassFirefox-Gecko\\NSS64\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SECITEM_FreeItem(IntPtr item, int bDestroy);
		#endregion


	}
}
