using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core;
using NUnit.Framework;

namespace CoreTest
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

		[TestCase (0,0, ExpectedResult = 0)]
		[TestCase (1,1, ExpectedResult = 1)]
		[TestCase (0,1, ExpectedResult = 1)]
		[TestCase (1,0, ExpectedResult = 0)]
		[TestCase (1,0, ExpectedResult = 0)]
		/*[TestCase (-1,0,  Assert.Throws = typeof(ArgumentOutOfRangeException))]
		[TestCase (1,-1,  Assert.Throws = typeof(ArgumentOutOfRangeException))]
		[TestCase (9,0,  Assert.Throws = typeof(ArgumentOutOfRangeException))]
		[TestCase (3,10,  Assert.Throws = typeof(ArgumentOutOfRangeException))]*/
		public int GetPixelValueatTest(int x, int y)
		{
			return _img.GetPixelValueAt (x, y);

		}

	}
}

