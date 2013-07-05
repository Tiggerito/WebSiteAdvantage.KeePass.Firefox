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
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;

namespace WebSiteAdvantage.KeePass.Firefox
{
	/// <summary>
	/// utilities to help gathering information from the internet
	/// </summary>
	public class InternetAccessor
	{

		// Regex expressions to scrape the title from a web page
		private static Regex _TitleOpenRegex = new Regex("^.*< *title.*?>(.*)$");              // matches a title tag <title>...
		private static Regex _TitleCloseRegex = new Regex("^(.*)< */ *title.*>.*$");           // matches a closing title tag ...</title>
		private static Regex _TitleRegex = new Regex("^.*< *title.*?>(.*)< */ *title.*>.*$");  // matches a single line with title tags <title>....</title>


		// cache captured titlesw
		private Dictionary<string, string> _TitleCache = new Dictionary<string, string>();

		/// <summary>
		/// finds the contents of the title tag of a page
		/// results are cached based on the supplied result
		/// </summary>
		/// <param name="url">page to scrape</param>
		/// <returns>title</returns>
		public string ScrapeTitle(string url)
		{
			try
			{
				if (_TitleCache.ContainsKey(url.ToLower()))
					return _TitleCache[url.ToLower()];

				_TitleCache[url.ToLower()] = null; // so dont repeat failures

				string title = null;

				WebRequest request = WebRequest.Create(url);
				request.Timeout = 10 * 1000; // ms

				WebResponse response = request.GetResponse(); // makes request

				Stream s = response.GetResponseStream();
				TextReader tr = new StreamReader(s);

				string titleBlock = "";

				try
				{
					// read in all text from a line with the start title tag <title> to a line with the end title tag </title>
					// limit to 5 lines between the tags incase its invalid html!

					bool titleFound = false; // tracks if we have hit the opening tag

					string line = null; // current line

					int lines = 0; // number of title lines so far

					// this gathers all the required lines as one line. it includes the tags ond other outer info which will be stripped later
					while ((line = tr.ReadLine()) != null && lines < 5)
					{
						if (_TitleOpenRegex.IsMatch(line)) // has an opening tag
							titleFound = true;

						if (titleFound) // store all lines as a single trimmed line
						{
							titleBlock += " " + line.Trim();
							lines++;
						}

						if (_TitleCloseRegex.IsMatch(line)) // has a closing tag so stop
							break;
					}
				}
				finally
				{
					tr.Close();
					s.Close();
					response.Close();
				}

				titleBlock = titleBlock.Trim();

				if (titleBlock.Length > 0)
				{
					// now capture the part of the titleBlick which is inside the title tags
					Match match = _TitleRegex.Match(titleBlock);
					if (match.Success)
					{
						title = HttpUtility.HtmlDecode(match.Groups[1].Captures[0].Value.Trim());
						_TitleCache[url.ToLower()] = title;
					}
				}

				return title;
			}
			catch(Exception ex)
			{
				KeePassUtilities.LogException(ex);
				return null;
			}

		}
	}
}
