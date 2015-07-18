using System;

namespace ImageLibrary
{
	public interface IVolume
	{
		int GetVoxelValueAt (int x, int y, int z);
		int Length { get;}
		int Height { get;}
		int Depth { get;}
	}
}

