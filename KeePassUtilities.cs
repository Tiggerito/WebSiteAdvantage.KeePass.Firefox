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

namespace WebSiteAdvantage.KeePass.Firefox
{
	/// <summary>
	/// Some common methods to help doing keepass stuff
	/// </summary>
	public class KeePassUtilities
	{
        public static string Version = "2.28"; // [assembly: AssemblyFileVersion("2.21.0.0")]

		public static int AutoTypeTextSize = 15; // arbitrary size limit. titles change and its better you get multiple options by default than none

		/// <summary>
		/// Returns the text to use in an autotypewindow parameter
		/// </summary>
		/// <param name="title">title that would be on the matching window</param>
		/// <returns></returns>
		public static string AutoTypeWindow(string title)
		{
			string s = title;

			if (s.Length > AutoTypeTextSize)
				s = s.Substring(0, AutoTypeTextSize);

			return s + "*"; // starts with
		}

		/// <summary>
		/// Provides the standard value for the autotype sequence
		/// </summary>
		/// <returns></returns>
		public static string AutoTypeSequence()
		{
			return "{USERNAME}{TAB}{PASSWORD}{ENTER}";

			// suggested solution to some lost char issues...
			// return "{DELAY 50}1{DELAY 50}{BACKSPACE}{USERNAME}{TAB}{DELAY 50}1{DELAY 50}{BACKSPACE}{PASSWORD}{ENTER}";
		}

		#region Logging
		public static void LogMessage(string text)
		{
#if DEBUG
			try
			{
				FileStream stream = null;
				StreamWriter writer = null;
				try
				{
					stream = File.Open("WebSiteAdvantage.KeePass.Firefox.log", FileMode.Append, FileAccess.Write, FileShare.Read);
					writer = new StreamWriter(stream);

					writer.WriteLine(DateTime.Now.ToString()+": "+text);
				}
				finally
				{
					if (writer != null)
						writer.Close();

					if (stream != null)
						stream.Close();
				}
			}
			catch { }
#endif
        }
		/// <summary>
		/// Append an exceptions details to the log file
		/// </summary>
		/// <param name="ex"></param>
		public static void LogException(Exception ex)
		{
#if DEBUG
			try
			{
				FileStream stream = null;
				StreamWriter writer = null;
				try
				{
					stream = File.Open("WebSiteAdvantage.KeePass.Firefox.log", FileMode.Append, FileAccess.Write, FileShare.Read);
					writer = new StreamWriter(stream);

					WriteException(writer, ex);
				}
				finally
				{
					if (writer != null)
						writer.Close();

					if (stream != null)
						stream.Close();
				}
			}
			catch { }
#endif
        }
		/// <summary>
		/// Write an exceptions details. includes inner exceptions
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="ex"></param>
		public static void WriteException(StreamWriter writer, Exception ex)
		{
			_WriteException(writer, ex);
			writer.WriteLine("=========================================");
		}

		/// <summary>
		/// Recursivly write exception content and their inner exceptions
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="ex"></param>
		private static void _WriteException(StreamWriter writer, Exception ex)
		{

			writer.WriteLine("Time: " + DateTime.Now.ToString());
			writer.WriteLine("Message: " + ex.Message);

			if (ex.Data != null && ex.Data.Count > 0)
			{
				writer.WriteLine("Data:");
				foreach (object key in ex.Data)
					writer.WriteLine(key.ToString() + ": " + ex.Data[key].ToString());
			}

			writer.WriteLine("StackTrace:");
			writer.WriteLine(ex.StackTrace);

			writer.WriteLine("TargetSite: " + ex.TargetSite);
			writer.WriteLine("Source: " + ex.Source);

			if (ex.InnerException != null)
			{
				writer.WriteLine("-----------------------------------------");
				_WriteException(writer, ex.InnerException);
			}

		}
		#endregion


		public static bool Is64Bit
		{
			get
			{
                return IntPtr.Size == 8;
			}
		}
	}
}
