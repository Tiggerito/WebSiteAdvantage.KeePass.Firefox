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
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WebSiteAdvantage.KeePass.Firefox.Gecko;
using System.Reflection;

namespace WebSiteAdvantage.KeePass.Firefox
{
	/// <summary>
	/// Represents a user profile in Firefox
	/// </summary>
	public class FirefoxProfile
	{

		#region Constructors
		/// <summary>
		/// Create a profile based on a profile info object
		/// </summary>
		/// <param name="profile"></param>
		public FirefoxProfile(FirefoxProfileInfo profile)
		{
			ProfilePath = profile.AbsolutePath;
		}

		/// <summary>
		/// Creates a profile related to the supplied profile path
		/// </summary>
		/// <param name="profilePath"></param>
		public  FirefoxProfile(string profilePath)
		{
			ProfilePath = profilePath;
		}

		/// <summary>
		/// Creates a profile related to the default firefox profile
		/// </summary>
		public  FirefoxProfile()
		{
			// find it!

			FirefoxProfileInfo profile = FirefoxProfileInfo.FindPrimaryProfile();


			if (profile == null)
				throw new Exception("Could not find a Firefox profile");
			ProfilePath = profile.AbsolutePath;
		}
		#endregion

		#region Initialising the Profile
		/// <summary>
		/// Sets NSS to use this profile
		/// </summary>
		public void Init()
		{
			if (this.ProfilePath == null)
				throw new Exception("Failed to determine the location of the default Firefox Profile");

            SECStatus initStatus = NSS3.NSS_Init(this.ProfilePath);

            if (initStatus != SECStatus.Success)
            {
                Int32 error = NSPR4.PR_GetError();
                string errorName = NSPR4.PR_ErrorToName(error);
                throw new Exception("Failed to initialise profile at " + this.ProfilePath + " reason " + errorName);
            }

		}

		/// <summary>
		/// init this profile and validate its password
		/// </summary>
		/// <param name="password"></param>
		public void Login(string password)
		{
			if (this.ProfilePath == null)
				throw new Exception("Failed to determine the location of the default Firefox Profile");

            SECStatus initStatus = NSS3.NSS_Init(this.ProfilePath);

            if (initStatus != SECStatus.Success)
            {
                Int32 error = NSPR4.PR_GetError();
                string errorName = NSPR4.PR_ErrorToName(error);
                throw new Exception("Failed to initialise profile for login at " + this.ProfilePath + " reason (" + error.ToString() + ") " + errorName);
            }

            

			SECStatus resultStatus = NSS3.CheckUserPassword(password);

            if (resultStatus != SECStatus.Success)
            {
                Int32 error = NSPR4.PR_GetError();
                string errorName = NSPR4.PR_ErrorToName(error);
                throw new Exception("Failed to Validate Password: (" + error.ToString() + ") " + errorName);
            }
		}

		#endregion

		#region Profile Data
		private string _ProfilePath;
		/// <summary>
		/// The location of the Firefox profile this relates to
		/// </summary>
		public string ProfilePath
		{
			get { return _ProfilePath; }
			set { _ProfilePath = value; }
		}

		private FirefoxSignonsFile _SignonsFile = null;
		/// <summary>
		/// loaded data from the profiles signonfile
		/// </summary>
		public FirefoxSignonsFile GetSignonsFile(string password)
		{

			if (_SignonsFile == null)
			{
				_SignonsFile = FirefoxSignonsFile.Create(this, password);
			}

			return _SignonsFile;
		}
		#endregion



	}
}
