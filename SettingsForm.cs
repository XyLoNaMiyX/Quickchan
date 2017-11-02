using System;
using System.Linq;
using System.Windows.Forms;

namespace Quickchan
{
	public partial class SettingsForm : Form
	{
		public SettingsForm()
		{
			InitializeComponent();
			
			viewedSmallerCB.Checked = Settings.GetValue<bool>("viewedSmaller");
			safeModeCB.Checked = Settings.GetValue<bool>("safeMode");
			
			if (Settings.GetValue<bool>("dynamic"))
				chooseDynamicallyRB.Checked = true;
			else
				folderRB.Checked = true;
			
			folderTB.Text = Settings.GetValue<string>("defaultFolder");
		}
		
		void FolderRBCheckedChanged(object sender, EventArgs e)
		{ folderTB.Enabled = searchB.Enabled = folderRB.Checked; }
		
		void SearchBClick(object sender, EventArgs e)
		{
			if (fbd.ShowDialog() == DialogResult.OK)
				folderTB.Text = fbd.SelectedPath;
		}
		
		void AcceptBClick(object sender, EventArgs e)
		{
			Settings.SetValue<bool>("viewedSmaller", viewedSmallerCB.Checked);
			Settings.SetValue<bool>("safeMode", safeModeCB.Checked);
			Settings.SetValue<bool>("dynamic", chooseDynamicallyRB.Checked);
			Settings.SetValue<string>("defaultFolder", folderTB.Text);
			
			((MainForm)Application.OpenForms["MainForm"]).CheckSettings();
			
			Close();
		}
	}
}
