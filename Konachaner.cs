
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;

namespace Quickchan
{
	public class Konachaner
	{
		#region Consts
		
		const string UnsafePostsUrl = "http://konachan.com/post?page=";
		const string SafePostsUrl = "http://konachan.net/post?page=";
		
		#endregion
		
		#region Properties
		
		string PageUrl
		{ get
		{	
			if (SafeMode)
				return Filters.Count > 0 ? SafePostsUrl + Page + "&tags=" + string.Join("+", Filters) :
					SafePostsUrl + Page;
			else
				return Filters.Count > 0 ? UnsafePostsUrl + Page + "&tags=" + string.Join("+", Filters) :
					UnsafePostsUrl + Page;
		} }
		
		public int Page
		{
			get { return _Page; }
			set { _Page = value > 0 ? value : 1; }
		}
		
		public int PageCount 
		{
			get { return _PageCount; }
			set
			{
				if (_PageCount != value)
				{
					_PageCount = value;
					if (OnGetPageCount != null)
						OnGetPageCount();
				}
			}
		}
		
		#endregion
		
		#region Variables
		
		int _Page = 1;
		int _PageCount = -1;
		public bool SafeMode = true;
		
		readonly List<string> Filters = new List<string>();
		
		#endregion
		
		#region Delegates and events
		
		public delegate void EmptyDelegate();
		public delegate void KonImgDelegate(KonImage konImg);
		
		public event KonImgDelegate OnKonImg;
		public event EmptyDelegate OnGetPageCount;
		public event EmptyDelegate NoResults;
		
		#endregion
		
		#region Public methods
		
		public void AddFilter(string filter) { Filters.Add(filter); }
		public void DeleteFilter(string filter) { Filters.Remove(filter); }
		public void ClearFilters() { Filters.Clear(); }
		
		public void GetPreviews()
		{
			using (var wc = new WebClient())
			{
				wc.DownloadStringAsync(new Uri(PageUrl));
				wc.DownloadStringCompleted += (s, e) => AnalyseHTML(e.Result);
			}
		}
		
		#endregion
		
		#region Private methods
		
		void AnalyseHTML(string html)
		{
			const string s1 = "<ul id=\"post-list-posts\">";
			const string s2 = "</ul>";
			const string s3 = "<img src=\"";
			const string s4 = "<a class=\"directlink largeimg\" href=\"";
			const string s5 = "<a class=\"directlink smallimg\" href=\"";
			
			const string pc1 = "</a> <a class=\"next_page\"";
			
			if (!html.Contains(s4) && !html.Contains(s5))
			{
				NoResults();
				return; // No images found
			}
			
			var pcspl = html
				.Split(new String[] { pc1 }, StringSplitOptions.None)[0]
				.Split('>');
			
			int pc = PageCount;
			int.TryParse(pcspl[pcspl.Length - 1], out pc);
			PageCount = pc;
			
			var images = html
				.Split(new String[] { s1 }, StringSplitOptions.None)[1]
				.Split(new String[] { s2 }, StringSplitOptions.None)[0]
				.Trim()
				.Split(new String[] { s3 }, StringSplitOptions.None);
			
			var konimgs = new KonImage[images.Length - 1];
			var wcs = new AsyncWebClient[images.Length - 1];
			
			for (int i = 1; i < images.Length; i++)
			{	
				var image = images[i].Split('"')[0];
				
				var url = images[i].Contains(s4) ? images[i]
					.Split(new String[] { s4 }, StringSplitOptions.None)[1]
					.Split('"')[0]
					
					: images[i]
					.Split(new String[] { s5 }, StringSplitOptions.None)[1]
					.Split('"')[0];
				
				wcs[i - 1] = new AsyncWebClient(image, url, Page);
				wcs[i - 1].NotifyDone += (d, f, p) =>
					OnKonImg(new KonImage(d, f, p));
			}
		}
		
		#endregion
	}
}
