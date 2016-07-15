using System;
using System.Collections.Generic;
using Core.interfaces;

namespace Core
{
	public class VolumeImpl:IVolume
	{
		internal IList<IImage> _data= new List<IImage>();
		internal VolumeImpl (string dir, IImageReader imgReader)
		{
            //TODO: remove coupling with IImage
            //TODO: throw exception for different sizes img in list
            var imgList = imgReader.GetImageListInDir(dir);
		    foreach (var imgPath in imgList)
		    {
               _data.Add(new ImageImpl(imgPath,imgReader));
		        Length = imgReader.Width(imgPath);
		        Height = imgReader.Heigth(imgPath);
		    }
		    Depth = imgList.Count;
		}

		#region IVolume implementation

		public int GetVoxelValueAt (int x, int y, int z)
		{
			if (x > Length || y > Height || z> Depth || x < 0 || y < 0 || z< 0) 
			{
				throw new ArgumentOutOfRangeException ("the requested coordinate does not exists for this Volume.");
			}
			return _data [z].GetPixelValueAt (x, y);
		}

		public int Length {
			get ;
			internal set;
		}

		public int Height {
			get ;
			internal set;
		}

		public int Depth {
			get ;
			internal set;
		}

		#endregion
	}
}

