using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core;
using Core.interfaces;
using Moq;
using NUnit.Framework;

namespace CoreTest
{
	[TestFixture]
	public class ImageTest
	{
		private Image _img;

		[SetUp]
		public void Setup()
		{
			
			
            Mock<IImageReader> imageReaderMock = new Mock<IImageReader>();
		    imageReaderMock.Setup(x => x.Width(It.IsAny<string>())).Returns(4);
		    imageReaderMock.Setup(x => x.Heigth(It.IsAny<string>())).Returns(4);
		    imageReaderMock.Setup(x => x.GetBitmapFromFile(It.IsAny<string>())).Returns(new ReadOnlyCollection<int>
		        (new List<int>
		        {
		            0,
		            0,
		            0,
		            0,
		            1,
		            1,
		            1,
		            0,
		            0,
		            1,
		            1,
		            0,
		            0,
		            0,
		            0,
		            0
		        }));
			

            _img = new Image("DumbPath",imageReaderMock.Object);
            

		}

		[TestCase (0,0, ExpectedResult = 0)]
		[TestCase (1,1, ExpectedResult = 1)]
		[TestCase (0,1, ExpectedResult = 1)]
		[TestCase (1,0, ExpectedResult = 0)]
		[TestCase (1,0, ExpectedResult = 0)]
		
		public int GetPixelValueAtShouldReturnExpectedResult(int x, int y)
		{
			return   _img.GetPixelValueAt (x, y);
            
		}

        [TestCase (-1,0)]
		[TestCase (1,-1)]
		[TestCase (9,0)]
		[TestCase (3,10)]
        public void GetPixelValueAtShouldThrowsArgumentOutOfRangeException(int x, int y)
        {
            Assert.Throws<ArgumentOutOfRangeException>(()=> _img.GetPixelValueAt(x, y)) ;

        }

    }
}

