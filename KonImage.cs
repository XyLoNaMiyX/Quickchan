
using System;
using System.Drawing;
using System.IO;

namespace Quickchan
{
	public class KonImage
	{
		public readonly Image Preview;
		public readonly Uri FullSizeUrl;
		
		public readonly string Name;
		public string ID { get { return Name.Split('-')[1].Trim().Split(' ')[0]; } }
		
		public readonly int PageNumber;
		
		public KonImage(byte[] data, string fullSizeUrl, int pageNumber)
		{
			Preview = ImgFromArray(data);
			FullSizeUrl = new Uri(fullSizeUrl);
			
			var spl = fullSizeUrl.Split('/');
			Name = UnparseUrl(spl[spl.Length - 1]);
			
			PageNumber = pageNumber;
		}
		
		static Image ImgFromArray(byte[] array)
		{
			Image image;
			using (var ms = new MemoryStream(array))
			    using (Image img = Image.FromStream(ms))
			        image = new Bitmap(img);
			return image;
		}
		
		static string UnparseUrl(string url)
		{
			return url.Replace("%20", " ").Replace("%21", "!").Replace("%22", "\"")
				.Replace("%23", "#").Replace("%24", "$").Replace("%25", "%").Replace("%26", "&")
				.Replace("%27", "'").Replace("%28", "(").Replace("%29", ")");
		}
	}
}
