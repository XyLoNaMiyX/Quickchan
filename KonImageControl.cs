
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Quickchan
{
	public class KonImageControl : PictureBox
	{
		public delegate void VoidDelegate();
		public event VoidDelegate DownloadStarted;
		public event VoidDelegate DownloadCompleted;
		
		public string Title { get { return konImage.Name; } }
		
		readonly KonImage konImage;
		readonly string SaveTo;
		
		int Biggy = -1;
		
		readonly WebClient wc = new WebClient();
		
		public KonImageControl(KonImage konImage, int size, string saveTo)
		{
			Image = konImage.Preview;
			this.konImage = konImage;
			SizeMode = PictureBoxSizeMode.StretchImage;
			Height = size;
			
			SaveTo = saveTo;
			
			wc.DownloadFileCompleted += (sender, e) => DownloadCompleted();
		}
		
		public new int Height 
		{
			get { return base.Height; }
			set 
			{
				base.Height = value;
				Width = (int)((float)Image.Width / (float)Image.Height * (float)value);
			}
		}
		
		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (Biggy == -1)
				{
					Biggy = Height;
					Height = 500;
				}
				else
				{
					Height = Biggy;
					Biggy = -1;
				}
				
				return;
			}
				
			if (string.IsNullOrEmpty(SaveTo))
			{
				using (var sfd = new SaveFileDialog { FileName = konImage.Name })
					if (sfd.ShowDialog() == DialogResult.OK)
					{
						wc.DownloadFileAsync(konImage.FullSizeUrl, sfd.FileName);
						if (DownloadStarted != null)
							DownloadStarted();
					}
			}
			else
			{
				wc.DownloadFileAsync(konImage.FullSizeUrl, Path.Combine(SaveTo, konImage.Name));
						if (DownloadStarted != null)
				DownloadStarted();
			}
				
			base.OnClick(e);
		}
	}
}
