using System;
using System.Collections.Generic;
using Core.interfaces;

namespace Core
{
	public class ImageImpl : IImage
	{
		internal IList<int> _data;
		

		public ImageImpl(string imgPath, IImageReader imageReader)
		{

		    _data = imageReader.GetBitmapFromFile(imgPath);
		    Width = imageReader.Width(imgPath);
		    Height = imageReader.Heigth(imgPath);
		}

		public int GetPixelValueAt(int x, int y)
		{
			if (x > Width || y > Height || x < 0 || y < 0) 
			{
				throw new ArgumentOutOfRangeException ("the requested coordinate does not exists for this Image.");
			}
			return _data [Height * y + x];
		}
		public int Width{ get; internal set;}
		public int Height{ get; internal set;}
	}
}

