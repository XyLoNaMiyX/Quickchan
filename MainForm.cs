using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Quickchan
{
	public partial class MainForm : Form
	{
		readonly Konachaner k = new Konachaner();
		readonly Dictionary<int, List<KonImage>> konImages = new Dictionary<int, List<KonImage>>();
		readonly HashSet<string> viewed = new HashSet<string>();
		
		const string AppName = "Quickchan";
		static readonly string ViewedFile = Path.Combine(
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
			"LonamiWebs\\Quickchan\\viewed.qc");
		
		string SaveTo;
		
		int _RemainingDownloads;
		int RemainingDownloads
		{
			get { return _RemainingDownloads; }
			set
			{
				_RemainingDownloads = value;
				downloadingL.Text = value + " downloading";
			}
		}
		
		readonly bool Loaded;
		public MainForm()
		{
			InitializeComponent();
			
			Width = Settings.GetValue<int>("width");
			Height = Settings.GetValue<int>("height");
			
			sizeTB.Value = Settings.GetValue<int>("size");
			
			k.OnKonImg += k_OnKonImg;
			k.OnGetPageCount += RefreshTitle;
			k.NoResults += k_NoResults; 
			
			if (File.Exists(ViewedFile))
				foreach (var line in File.ReadAllLines(ViewedFile))
					viewed.Add(line);
			else
				File.WriteAllText(ViewedFile, "", Encoding.UTF8);
			
			CheckSettings();
			
			Loaded = true;
		}
		
		public void CheckSettings()
		{
			var safeMode = Settings.GetValue<bool>("safeMode");
			
			k.SafeMode = safeMode;
			konImagesFLP.Controls.Clear();
			konImages.Clear();
			k.GetPreviews();
			
			var saveTo = Settings.GetValue<string>("defaultFolder");
			if (!Directory.Exists(saveTo))
				saveTo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			
			SaveTo = Settings.GetValue<bool>("dynamic") ? "" : saveTo;
		}

		void k_OnKonImg(KonImage konImg)
		{	
			konImagesFLP.BackColor = Color.White;
			
			if (!konImages.ContainsKey(konImg.PageNumber))
				konImages.Add(konImg.PageNumber, new List<KonImage>());
			
			konImages[konImg.PageNumber].Add(konImg);
			
			if (konImg.PageNumber == k.Page)
				AddKonImg(konImg);
		}

		void k_NoResults()
		{
			Text = AppName + " - No results found";
			konImagesFLP.BackColor = Color.Salmon;
		}
		
		void PrevPageBClick(object sender, EventArgs e) { ChangePage(-1); }
		void NextPageBClick(object sender, EventArgs e) { ChangePage(1); }
		
		void ChangePage(int amount)
		{
			k.Page += amount;
			if (!konImages.ContainsKey(k.Page))
			{
				konImages.Add(k.Page, new List<KonImage>());
				k.GetPreviews();
			}
			RefreshPage();
			
			RefreshTitle();
		}
		
		void RefreshPage()
		{
			pageTB.Text = k.Page.ToString();
			
			konImagesFLP.SuspendLayout();
			
			konImagesFLP.Controls.Clear();
			if (konImages.ContainsKey(k.Page))
				foreach (var konImg in konImages[k.Page])
					AddKonImg(konImg);
			
			
			konImagesFLP.ResumeLayout();
		}
		
		void RefreshTitle() { Text = AppName + " - " + k.Page + "/" + k.PageCount; }
		
		void AddKonImg(KonImage konImg)
		{
			var kic = new KonImageControl(
				konImg,
				Viewed(konImg.ID) ? (int)sizeTB.Value / 4 : (int)sizeTB.Value,
	            SaveTo);
			kic.DownloadStarted += () => RemainingDownloads++;
			kic.DownloadCompleted += () => RemainingDownloads--;
			kic.MouseEnter += (sender, e) => Text = kic.Title;
			kic.MouseLeave += (sender, e) => RefreshTitle();
			konImagesFLP.Controls.Add(kic);
			
			viewed.Add(konImg.ID);
			File.WriteAllLines(ViewedFile, viewed);
		}
		
		void SettingsBClick(object sender, EventArgs e)
		{
			var f = Application.OpenForms["SettingsForm"];
			if (f == null)
				new SettingsForm().Show();
			else
				f.Activate();
		}
		
		void FilterTBKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = e.SuppressKeyPress = true;
				
				k.ClearFilters();
				foreach (var f in filterTB.Text.Split(' '))
					k.AddFilter(f);
				
				konImages.Clear();
				konImagesFLP.Controls.Clear();
				
				k.GetPreviews();
			}
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (RemainingDownloads > 0 && e.CloseReason == CloseReason.UserClosing)
			{
				e.Cancel = 
					MessageBox.Show("There are some pending downloads. Do you want to exit and cancel them?",
	                "Pending downloads", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
					== DialogResult.No;
			}
		}
		
		void PageTBKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.Handled = e.SuppressKeyPress = true;
				int increment = 0;
				int.TryParse(pageTB.Text, out increment);
				increment = increment - k.Page;
				ChangePage(increment);
			}
		}
		
		void KonImagesFLPMouseEnter(object sender, EventArgs e)
		{ konImagesFLP.Focus(); }
		
		void PageTBMouseEnter(object sender, EventArgs e)
		{ pageTB.Focus(); pageTB.SelectAll(); }
		
		void FilterTBMouseEnter(object sender, EventArgs e)
		{ filterTB.Focus(); }
		
		void SizeTBScroll(object sender, EventArgs e)
		{
			konImagesFLP.SuspendLayout();
			foreach (KonImageControl kic in konImagesFLP.Controls)
				kic.Height = (int)sizeTB.Value;
			konImagesFLP.ResumeLayout();
			
			if (Loaded)
				Settings.SetValue<int>("size", (int)sizeTB.Value);
		}
		
		void MainFormResizeEnd(object sender, EventArgs e)
		{
			if (Loaded)
			{
				Settings.SetValue<int>("width", Width);
				Settings.SetValue<int>("height", Height);
				Settings.SetValue<bool>("maximized", WindowState == FormWindowState.Maximized);
			}
		}
		
		bool Viewed(string id)
		{ return Settings.GetValue<bool>("viewedSmaller") && viewed.Contains(id); }
	}
}
