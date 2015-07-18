using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ImageLibrary;

namespace ImageTest
{
	[TestFixture]
	public class ImageTest
	{
		private ImageImpl _img;

		[SetUp]
		public void Setup()
		{
			
			_img = new ImageImpl ();
			_img._data = new ReadOnlyCollection<int>
				(new List<int> { 0,0,0,0,
								 1,1,1,0,
								 0,1,1,0,
								 0,0,0,0
					});
			_img.Height = 4;
			_img.Length = 4;

		}

		[TestCase (0,0, Result = 0)]
		[TestCase (1,1, Result = 1)]
		[TestCase (0,1, Result = 1)]
		[TestCase (1,0, Result = 0)]
		[TestCase (1,0, Result = 0)]
		[TestCase (-1,0,  ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase (1,-1,  ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase (9,0,  ExpectedException = typeof(ArgumentOutOfRangeException))]
		[TestCase (3,10,  ExpectedException = typeof(ArgumentOutOfRangeException))]
		public int GetPixelValueatTest(int x, int y)
		{
			return _img.GetPixelValueAt (x, y);

		}

	}
}

