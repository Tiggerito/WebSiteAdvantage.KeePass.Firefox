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

namespace WebSiteAdvantage.KeePass.Firefox
{
	/// <summary>
	/// saved site information from Firefox's signon file
	/// </summary>
	public class FirefoxSignonSite
	{
		private string _Site;
		/// <summary>
		/// site with a saved password
		/// </summary>
		public string Site
		{
			get { return _Site; }
			set { _Site = value; }
		}

		private List<FirefoxSignon> _Signons = new List<FirefoxSignon>();
		/// <summary>
		/// collection of signons for this site
		/// </summary>
		public List<FirefoxSignon> Signons
		{
			get { return _Signons; }
		}




	}
}
