using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core;
using Core.interfaces;
using NUnit.Framework;

namespace CoreTest
{
	[TestFixture]
	public class VolumeTest
	{
		private VolumeImpl _vol;
		[SetUp]
		public void Setup ()
		{
			var img0 = new ImageImpl ();
			img0._data = new ReadOnlyCollection<int>
				(new List<int> { 
					0,0,0,0,
					0,0,0,0,
					0,0,0,0,
					0,0,0,0
				});
			img0.Height = 4;
			img0.Length = 4;

			var img1 = new ImageImpl ();
			img1._data = new ReadOnlyCollection<int>
				(new List<int> { 
					0,0,0,0,
					0,1,1,0,
					0,1,1,0,
					0,0,0,0
				});
			img1.Height = 4;
			img1.Length = 4;

			var img2 = new ImageImpl ();
			img2._data = new ReadOnlyCollection<int>
				(new List<int> { 
					0,0,0,0,
					0,1,1,0,
					0,1,1,0,
					0,0,0,0
				});
			img2.Height = 4;
			img2.Length = 4;

			var img3 = new ImageImpl ();
			img3._data = new ReadOnlyCollection<int>
				(new List<int> { 
					0,0,0,0,
					1,0,0,0,
					0,0,0,0,
					0,0,0,0
				});
			img3.Height = 4;
			img3.Length = 4;

			_vol = new VolumeImpl ();
			((VolumeImpl)_vol)._data= new ReadOnlyCollection<IImage>
				(new List<IImage> {img0,img1,img2,img3});

			_vol.Depth = 4;
			_vol.Height = 4;
			_vol.Length = 4;
		}


		[TestCase (0,0,0, ExpectedResult = 0)]
		[TestCase (1,1,0, ExpectedResult = 0)]
		[TestCase (0,1,1, ExpectedResult = 0)]
		[TestCase (1,0,1, ExpectedResult = 0)]
		[TestCase (0,1,3, ExpectedResult = 1)]
		[TestCase (2,2,2, ExpectedResult = 1)]
		
		public int GetVoxelValueAtShouldReturnExpectedValue(int x, int y, int z)
		{
			return _vol.GetVoxelValueAt (x, y,z);

		}

        [TestCase(-1, 0, 0)]
        [TestCase(1, -1, 0)]
        [TestCase(9, 0, 0)]
        [TestCase(3, 10, 0)]
        [TestCase(2, 1, -9)]
        [TestCase(1, 1, 58)]
        public void GetVoxelValueAtShoulThrwsanOutofRangeException(int x, int y, int z)
        {
            
            Assert.Throws<ArgumentOutOfRangeException>(()=> _vol.GetVoxelValueAt(x, y, z));
        }
    }
}

