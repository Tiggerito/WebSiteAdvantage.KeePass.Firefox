using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WebSiteAdvantage.KeePass.Firefox
{
	/// <summary>
	/// data gathered from the profileIni file
	/// </summary>
	public class FirefoxProfileInfo
	{
		private string _Code;
		/// <summary>
		/// string from the header part of a profile definition. In []
		/// </summary>
		public string Code
		{
			get { return _Code; }
			set { _Code = value; }
		}

		private string _Name;
		/// <summary>
		/// name of the profile
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}


		private bool _IsRelative = true; // not sure wshat the default should be
		/// <summary>
		/// Is the path relative
		/// </summary>
		public bool IsRelative
		{
			get { return _IsRelative; }
			set { _IsRelative = value; }
		}


		private string _Path;
		/// <summary>
		/// path to the profile
		/// </summary>
		public string Path
		{
			get { return _Path; }
			set { _Path = value; }
		}

		private bool _Default = false;
		/// <summary>
		/// Is this the default profile
		/// </summary>
		public bool Default
		{
			get { return _Default; }
			set { _Default = value; }
		}

		private string _BasePath;
		public string BasePath
		{
			get { return _BasePath;}
			set { _BasePath = value;}
		}

		/// <summary>
		/// The full path which should be used as the ProfilePath when accessing the profile file
		/// </summary>
		public string AbsolutePath
		{
			get
			{
				if (this.IsRelative)
					return this.BasePath + "\\" + this.Path.Replace("/", "\\");
				else
					return this.Path.Replace("/", "\\");
			}
		}

		public static FirefoxProfileInfo FindPrimaryProfile()
		{
			return FindPrimaryProfile(FindFirefoxProfileInfos());
		}
		/// <summary>
		/// Either the first defualt profile or the first profile
		/// excludes any invalid profiles
		/// </summary>
		/// <param name="profiles"></param>
		/// <returns></returns>
		public static FirefoxProfileInfo FindPrimaryProfile(List<FirefoxProfileInfo> profiles)
		{
			foreach (FirefoxProfileInfo profile in profiles)
			{
				if (profile.Default && !String.IsNullOrEmpty(profile.Path))
				{
					return profile;
				}
			}

			foreach (FirefoxProfileInfo profile in profiles)
			{
				if (!String.IsNullOrEmpty(profile.Path))
				{
					return profile;
				}
			}

			return null;
		}

		#region Finding Profiles
		/// <summary>
		/// try and find the current users default profile
		/// searches for firefox application data in:
		/// LocalApplicationData
		/// ApplicationData
		/// CommonApplicationData
		/// </summary>
		/// <returns>full path to a profile</returns>
		public static List<FirefoxProfileInfo> FindFirefoxProfileInfos()
		{
			List<FirefoxProfileInfo> profiles = new List<FirefoxProfileInfo>();

			FindFirefoxProfileInfos(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), profiles);
			FindFirefoxProfileInfos(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), profiles);
			FindFirefoxProfileInfos(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), profiles);

			return profiles;
		}
		public static void FindFirefoxProfileInfos(string applicationsPath, List<FirefoxProfileInfo> profiles)
		{
			FindFirefoxProfileInfos(applicationsPath, "\\Mozilla\\Firefox", profiles);
			FindFirefoxProfileInfos(applicationsPath, "\\Thunderbird", profiles);
			FindFirefoxProfileInfos(applicationsPath, "\\Mozilla\\SeaMonkey", profiles);
			FindFirefoxProfileInfos(applicationsPath, "\\Mozilla", profiles);
		}
		/// <summary>
		/// look for a default firefox profile in the supplied application data path
		/// </summary>
		/// <param name="applicationPath">a path to application data</param>
		/// <returns>full path to a profile</returns>
		public static void FindFirefoxProfileInfos(string applicationsPath, string applicationPath, List<FirefoxProfileInfo> profiles)
		{
			string basePath = applicationsPath + applicationPath; // firefoxes relative path
			string profilesIni = basePath + "\\profiles.ini"; // file that contains data on the default profile

            FindFirefoxProfileInfosFromIniFile(profilesIni, profiles);
        }
        public static void FindFirefoxProfileInfosFromIniFile(string profilesIni, List<FirefoxProfileInfo> profiles)
        {

			// searcvh the profile for a profile entry that contains "Default=1"
			if (File.Exists(profilesIni))
			{
				KeePassUtilities.LogMessage("File exists at " + profilesIni);

				StreamReader reader = File.OpenText(profilesIni);

				try
				{

					FirefoxProfileInfo profile = null;

					string line = reader.ReadLine();
					while (line != null)
					{
						string lowerLine = line.ToLower().Replace(" ", "");
						if (lowerLine.StartsWith("[")) // new section
						{
							if (lowerLine.StartsWith("[profile")) // new section
							{
								profile = new FirefoxProfileInfo();

								profile.Code = line.Trim().TrimStart('[').TrimEnd(']');

                                profile.BasePath = profilesIni.Substring(0,profilesIni.LastIndexOf("\\"));

								profiles.Add(profile);
							}
							else
								profile = null;
						}

						if (profile != null)
						{
							if (lowerLine.StartsWith("name=")) // this is the default profile
								profile.Name = line.Substring(5);

							if (lowerLine.StartsWith("path=")) // this is the default profile
								profile.Path = line.Substring(5);

							if (lowerLine == "default=1") // this is the default profile
								profile.Default = true;

							if (lowerLine == "isrelative=1") // this is the default profile
								profile.IsRelative = true;

                            if (lowerLine == "isrelative=0") // this is the default profile
                                profile.IsRelative = false;
						}

						line = reader.ReadLine();
					}
				}
				finally
				{
					reader.Close();
				}
			}
			else
				KeePassUtilities.LogMessage("File does not exist at " + profilesIni);
		}
		#endregion

		public override string ToString()
		{
			return this.Name;
		}

	}
}
