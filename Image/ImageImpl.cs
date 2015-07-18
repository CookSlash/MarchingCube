using System;
using System.Collections.Generic;
namespace ImageLibrary
{
	public class ImageImpl : IImage
	{
		internal IList<int> _data;
		internal ImageImpl ()
		{
		}

		public ImageImpl(string imgPath)
		{
			//var bmp = new Bitmap (imgPath);
			//TODO find appropriate library to read Inmg from file
		}

		public int GetPixelValueAt(int x, int y)
		{
			if (x > Length || y > Height || x < 0 || y < 0) 
			{
				throw new ArgumentOutOfRangeException ("the requested coordinate does not exists for this Image.");
			}
			return _data [Height * y + x];
		}
		public int Length{ get; internal set;}
		public int Height{ get; internal set;}
	}
}

