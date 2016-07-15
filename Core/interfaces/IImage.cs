namespace Core.interfaces
{
	//Interface for a 2D image with integer values
	public interface IImage
	{
		
		int GetPixelValueAt(int x, int y);
		int Width{ get;}
		int Height{ get;}

	}
}

