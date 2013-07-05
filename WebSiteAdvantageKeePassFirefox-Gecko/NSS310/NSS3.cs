/*	ClockWork KeePass to Firefox 
 *	Copyright (C) 2008 - 2010  Anthony James McCreath
 *
 *	This library is free software; you can redistribute it and/or
 *	modify it under the terms of the GNU Lesser General Public
 *	License as published by the Free Software Foundation; either
 *	version 2.1 of the License, or (at your option) any later version.
 *
 *	This library is distributed in the hope that it will be useful,
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *	Lesser General Public License for more details.
 *
 *	You should have received a copy of the GNU Lesser General Public
 *	License along with this library; if not, write to the Free Software
 *	Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ClockWork.KeePass.Firefox.Gecko.NSS310
{
	/// <summary>
	/// provides access to the nss3 dll
	/// </summary>
	public static class NSS3
	{
        public static void LoadDependencies()
        {
        }

		#region DLL Methods
        [DllImport("Gecko\\NSS310\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SECStatus NSS_Init([MarshalAs(UnmanagedType.LPStr)]  string profilePath);

        [DllImport("Gecko\\NSS310\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SECStatus NSS_Shutdown();

        [DllImport("Gecko\\NSS310\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr PK11_GetInternalKeySlot();

        [DllImport("Gecko\\NSS310\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void PK11_FreeSlot(IntPtr slot);

        [DllImport("Gecko\\NSS310\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SECStatus PK11_CheckUserPassword(IntPtr slot, string password);

        [DllImport("Gecko\\NSS310\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SECStatus PK11_Authenticate(IntPtr slot, bool loadCerts, IntPtr wincx);

        [DllImport("Gecko\\NSS310\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern SECStatus PK11SDR_Decrypt(IntPtr encryptedItem, ref SECItem text, IntPtr cx);

        [DllImport("Gecko\\NSS310\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NSSBase64_DecodeBuffer(IntPtr p1, IntPtr p2, string encoded, int encoded_len);

        [DllImport("Gecko\\NSS310\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SECITEM_FreeItem(ref SECItem item, int bDestroy);

        [DllImport("Gecko\\NSS310\\nss3.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern void SECITEM_FreeItem(IntPtr item, int bDestroy);
		#endregion

	}
}
