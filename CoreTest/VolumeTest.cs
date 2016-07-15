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
	public class VolumeTest
	{
		private VolumeImpl _vol;
		[SetUp]
		public void Setup ()
		{
            Mock<IImageReader> imageReaderMock = new Mock<IImageReader>();
            imageReaderMock.Setup(x => x.Width("img0")).Returns(4);
            imageReaderMock.Setup(x => x.Heigth("img0")).Returns(4);
            imageReaderMock.Setup(x => x.GetBitmapFromFile("img0")).Returns(new ReadOnlyCollection<int>
                (new List<int> { 
					0,0,0,0,
					0,0,0,0,
					0,0,0,0,
					0,0,0,0
				}));


          
            imageReaderMock.Setup(x => x.Width("img1")).Returns(4);
            imageReaderMock.Setup(x => x.Heigth("img1")).Returns(4);
            imageReaderMock.Setup(x => x.GetBitmapFromFile("img1")).Returns(new ReadOnlyCollection<int>
                (new List<int> { 
					0,0,0,0,
					0,1,1,0,
					0,1,1,0,
					0,0,0,0
				}));


            
            imageReaderMock.Setup(x => x.Width("img2")).Returns(4);
            imageReaderMock.Setup(x => x.Heigth("img2")).Returns(4);
            imageReaderMock.Setup(x => x.GetBitmapFromFile("img2")).Returns(new ReadOnlyCollection<int>
                (new List<int> { 
					0,0,0,0,
					0,1,1,0,
					0,1,1,0,
					0,0,0,0
				}));


           
            imageReaderMock.Setup(x => x.Width("img3")).Returns(4);
            imageReaderMock.Setup(x => x.Heigth("img3")).Returns(4);
            imageReaderMock.Setup(x => x.GetBitmapFromFile("img3")).Returns(new ReadOnlyCollection<int>
                (new List<int> { 
					0,0,0,0,
					1,0,0,0,
					0,0,0,0,
					0,0,0,0
				}));

		    imageReaderMock.Setup(x => x.GetImageListInDir("dummyDir")).Returns(new []{"img0","img1","img2","img3"});



            _vol = new VolumeImpl ("dummyDir",imageReaderMock.Object);
			
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

