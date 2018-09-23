# Firefox to KeePass Password Importer

**Unfortunately I am no longer able to provide support for this tool.**

## What is the Firefox to KeePass Importer?
Firefox KeePass Importer
It's a free way to import passwords exported from a Firefox Web Browser into KeePass . It should also work with Thunderbird , Flock and Songbird !

## Who would use it?
For people who have just started using KeePass and have passwords stored in Firefox , this free plugin can save hours in entering passwords.

## What are the requirements?
A Windows PC With XP, Vista or Windows 7 should work just fine.

This Firefox to KeePass Importer is written and compiled in .Net 4.0 and therefore required Windows XP or later, and the .Net 4.0 Framework installed (Standard in Windows 7). The version for KeePass 1.x also requires the XML Import plugin to be installed.

## How do I use it?
### INSTALLATION
1. Download the latest version from GitHub
1. Un-zip and place the contained files and folders into the KeePass Program Folder e.g. at C:\Program Files (x86)\KeePass Password Safe 2 .
#### XML Import plugin (for KeePass 1.x)
If you're using KeePass 1.x then you will also need to install the [KeePass XML Import plugin](https://keepass.info/plugins.html#xmlimport). This is not needed for KeePass 2.x users:

1. Download the [KeePass XML Import plugin](https://keepass.info/plugins.html#xmlimport). Make sure it is the same version as your KeePass.
1. Install it by placing it in the KeePass Program Folder.
1. Restart KeePass so it picks up the plugin.
1. Select Tools-->Plugins
1. Enable the plugin by right clicking on it and selecting enable.
1. Restart KeePass so the plugin can initialise itself.

Note: For the portable version copy the KeePass XML Import plugin to your thumb drive. i.e. m:\PortableApps\KeePassPortable\App\keepass

### IMPORTING TO KEEPASS 2.X
1. Start KeePass 2 and open the database to import to
1. If you use the View->Always On Top option, then switch it off
1. Select the menu option File->Import
1. Select the Firefox option from the bottom of the list
1. Select OK
1. Alter any settings as required
1. Select Start

### IMPORTING TO KEEPASS 1.X
1. Make sure you have installed the XML Import plugin (see installation section related to the XML Import plugin)
1. Start the WebSiteAdvantageKeePassFirefoxConverter.exe program that should be in your KeePass Program Folder
1. Alter settings as required
1. Click Start
1. Select the destination file to save the passwords to (e.g., "KP-IN.XML")
1. Wait for it to complete
1. Close the program
1. Open KeePass
1. Make sure you have a database opened in KeePass (File->New or File->Open)
1. Select File->Import From->Import KeePass XML (If you don't see this option, re-read the installation section related to the XML Import plugin, If it is shaded then you need to open a database)
1. Select the file to be imported (as prepared just before, e.g., "KP-IN.XML")
1. Follow the instructions

Then it is recommended you remove/shred/destroy/wipe any Firefox or KeePass xml files produced! (e.g. using FileShredder )

### Trouble Shooting
Upgrades early in 2012 seem to have caused a lot of problems for people. Here are some possible ways to fix them. If a solution works, to help me and others out please post a quick message in the comment section at the end.

#### Could not load file or assembly 'System.Web...
Some installations do not grant the application enough authority to access the web/internet. This is for security reasons. If you get this message it means you cannot use the "Get Titles from the websites" and must switch it off.

#### Have you copied ALL the files in the installation
The download zip contains several files and folders. They are all required for the tool to work.

#### Try the stand alone version.
Try importing via the stand alone tool (WebSiteAdvantageKeePassFirefoxConverter.exe). Does it have the same problem?

#### Ensure all Versions Match
KeePass can be very fussy that the version of any plugin exactly matches the version of KeePass. So make sure they are the same.

#### Install .Net 4.0 Framework
The application is compiled in .Net 4.0 and requires the [.Net 4.0 Framework](https://www.microsoft.com/en-us/download/details.aspx?id=17718).

#### Install SQLite
If the error message is related to SQLite then it may be fixed by fully installing the package. "setup for 32-bit Windows and .Net Framework 4.0" has been known to fix problems (thanks Pete).
[SQLite Download Page](http://system.data.sqlite.org/index.html/doc/trunk/www/downloads.wiki)

#### Install the C++ 2010 Redistributable Package
The latest version of SQLite requires this package. Many computers already have it installed, but if you don't, go here:
* [Microsoft Visual C++ 2010 Redistributable Package x86](https://www.microsoft.com/en-us/download/details.aspx?id=5555)
* [Microsoft Visual C++ 2010 Redistributable Package x64](https://www.microsoft.com/en-us/download/details.aspx?id=14632)

#### Do you use special characters in your passwords?
Sometimes the Password Exporter includes poorly encoded characters which makes the xml file invalid. The solution is to edit the file and remove those characters.

#### Importing via Justin Scott's Password Exporter Extension
Previous versions imported passwords through the output from this Firefox Password Exporter Extension. This version still supports it as an option.

The Password Exporter Extension has several issues with Firefox compatibility and the handling of foreign characters which is why I developed an alternate way to acquire the Firefox passwords. However, if you cant get the direct importing to work you might find switching to use this method may solve your problems.

1. [Justin Scott's Password Exporter Extension](https://addons.mozilla.org/en-US/firefox/addon/password-exporter/) into Firefox.
1. Restart Firefox
1. In Firefox go to Tools->Options and select the Security Tab
1. Click Import/Export Passwords
1. Click Export
1. Follow the instructions to save the passwords to an XML file, e.g., "FF-OUT.XML" (Remember where it is for later use)
1. Follow the appropriate Importing instructions...
1. For 2.x use the Firefox XML importer (See Note 1)
1. For 1.x select the option to use this extensions output

Note 1: It seems that KeePass 2.0 now has a built in importer option called "Password Exporter XML" that can directly import these XML file without the need for this tool.

Note 2: For other applications such as Thunderbird the process of installing and using the Exporter may vary. More information may be found on the Password Exporter website.
