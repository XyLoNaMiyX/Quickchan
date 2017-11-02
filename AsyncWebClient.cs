
using System;
using System.Net;

namespace Quickchan
{
	public class AsyncWebClient
	{
		public delegate void NotifyDoneDelegate(byte[] result, string fullUrl, int page);
		public event NotifyDoneDelegate NotifyDone;
		
		public bool Done { get; private set; }
		
		public AsyncWebClient(string uri, string fullUrl, int page)
		{
			var wc = new WebClient();
			wc.DownloadDataCompleted += (s, e) => 
			{
				Done = true;
				NotifyDone(e.Result, fullUrl, page);
				wc.Dispose();
			};
			wc.DownloadDataAsync(new Uri(uri));
		}
	}
}
