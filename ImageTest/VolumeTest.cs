using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ImageLibrary;

namespace ImageTest
{
	[TestFixture]
	public class VolumeTest
	{
		private IVolume _vol;
		[SetUp]
		public void Setup ()
		{
			var _img0 = new ImageImpl ();
			_img0._data = new ReadOnlyCollection<int>
				(new List<int> { 
					0,0,0,0,
					0,0,0,0,
					0,0,0,0,
					0,0,0,0
				});
			_img0.Height = 4;
			_img0.Length = 4;

			var _img1 = new ImageImpl ();
			_img1._data = new ReadOnlyCollection<int>
				(new List<int> { 
					0,0,0,0,
					0,1,1,0,
					0,1,1,0,
					0,0,0,0
				});
			_img1.Height = 4;
			_img1.Length = 4;

			var _img2 = new ImageImpl ();
			_img2._data = new ReadOnlyCollection<int>
				(new List<int> { 
					0,0,0,0,
					0,1,1,0,
					0,1,1,0,
					0,0,0,0
				});
			_img2.Height = 4;
			_img2.Length = 4;

			var _img3 = new ImageImpl ();
			_img3._data = new ReadOnlyCollection<int>
				(new List<int> { 
					0,0,0,0,
					1,0,0,0,
					0,0,0,0,
					0,0,0,0
				});
			_img3.Height = 4;
			_img3.Length = 4;

			_vol = new VolumeImpl ();
			((VolumeImpl)_vol)._data= new ReadOnlyCollection<IImage>
				(new List<IImage> {_img0,_img1,_img2,_img3});

			/*_vol.Depth = 4;
			_vol.Height = 4;
			_vol.Length = 4;*/
		}


		[TestCase (0,0,0, ExpectedResult = 0)]
		[TestCase (1,1,0, ExpectedResult = 0)]
		[TestCase (0,1,1, ExpectedResult = 1)]
		[TestCase (1,0,1, ExpectedResult = 0)]
		[TestCase (0,1,3, ExpectedResult = 1)]
		/*[TestCase (-1,0,0,  ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase (1,-1,0,  ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase (9,0,0,  ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase (3,10,0,  ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase (2,1,-9,  ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase (1,1,58,  ExpectedException = typeof(ArgumentOutOfRangeException))]*/
		public int GetVoxelValueatTest(int x, int y, int z)
		{
			return _vol.GetVoxelValueAt (x, y,z);

		}
	}
}

