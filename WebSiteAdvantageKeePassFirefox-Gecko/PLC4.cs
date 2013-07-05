/*	WebSiteAdvantage KeePass to Firefox 
 *	Copyright (C) 2008 - 2012  Anthony James McCreath
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

namespace WebSiteAdvantage.KeePass.Firefox.Gecko
{
	/// <summary>
	/// provides access to the plc4 library
	/// </summary>
	public class PLC4
	{
		#region DLL Methods
        public static string PL_Base64Decode(string src, Int32 srclen, char[] dest)
        {
            switch (Gecko.Version)
            {
				//case "NSS310":
				//    return NSS310.PLC4.PL_Base64Decode(src, srclen, dest);
                case "NSS312":
                    return NSS312.PLC4.PL_Base64Decode(src, srclen, dest);
                case "NSS64":
                    return NSS64.PLC4.PL_Base64Decode(src, srclen, dest);
                default:
                    throw new Exception("Not Supported");
            }
        }
		#endregion
	}
}
