﻿using System;

namespace Image
{
	//Interface for a 2D image with integer values
	public interface IImage
	{
		
		int GetValueAt(int x, int y);
		int Length{ get;}
		int Height{ get;}

	}
}
