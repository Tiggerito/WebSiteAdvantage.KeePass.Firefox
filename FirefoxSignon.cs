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
	/// saved sign on information from Firefox's signon file
	/// </summary>
	public class FirefoxSignon
	{

		private string _UserNameField;
		/// <summary>
		/// name of HTML user name field or blank for HTTP authentication
		/// </summary>
		public string UserNameField
		{
			get { return _UserNameField; }
			set { _UserNameField = value; }
		}

		private string _PasswordField;
		/// <summary>
		/// name of HTML password field or blank for HTTP authentication
		/// </summary>
		public string PasswordField
		{
			get { return _PasswordField; }
			set { _PasswordField = value; }
		}

		private string _UserName;
		/// <summary>
		/// user name
		/// </summary>
		public string UserName
		{
			get { return _UserName; }
			set { _UserName = value; }
		}

		private string _Password;
		/// <summary>
		/// password
		/// </summary>
		public string Password
		{
			get { return _Password; }
			set { _Password = value; }
		}

		private string _LoginFormDomain;
		/// <summary>
		/// the domain of the log in form
		/// </summary>
		public string LoginFormDomain
		{
			get { return _LoginFormDomain; }
			set { _LoginFormDomain = value; }
		}

	}
}
