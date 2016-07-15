namespace Core.interfaces
{
	public interface IVolume
	{
		int GetVoxelValueAt (int x, int y, int z);
		int Width { get;}
		int Height { get;}
		int Depth { get;}
	}
}

