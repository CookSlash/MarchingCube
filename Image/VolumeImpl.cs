using System;
using System.Collections.Generic;
namespace ImageLibrary
{
	public class VolumeImpl:IVolume
	{
		internal IList<IImage> _data;
		internal VolumeImpl ()
		{
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

