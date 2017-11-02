
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Quickchan
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{	
		[STAThread]
		private static void Main(string[] args)
		{
			Settings.Init("LonamiWebs\\Quickchan", new Dictionary<string, dynamic>
			              {
			              	{ "safeMode", true },
			              	{ "dynamic", true },
			              	{ "size", 100 },
			              	{ "width", 600 },
			              	{ "height", 400 },
			              	{ "maximized", false },
			              	{ "viewedSmaller", true },
			              });
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
