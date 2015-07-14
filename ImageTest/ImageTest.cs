using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Image;

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
								 0,1,1,0,
								 0,1,1,0,
								 0,0,0,0
					});
			_img.Height = 4;
			_img.Length = 4;

		}



	}
}

