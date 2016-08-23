using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.interfaces;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;
using Core;

namespace CoreTest
{
    [TestFixture]
    class MarchingCubesTest
    {
        private const int FullBlack = 256;
        private const int Threshold = 128;
        private const int GridSize = 1;

        //case list available at http://users.polytech.unice.fr/~lingrand/MarchingCubes/algo.html
        [Test]
        public void BasicCase0ShouldReturnBasicTriangles()
        {
            var vol1 = new Mock<IVolume>();
            vol1.SetupAllProperties();
            vol1.Setup(x => x.Height).Returns(1);
            vol1.Setup(x => x.Depth).Returns(1);
            vol1.Setup(x => x.Width).Returns(1);



            var expected = new List<ITriangle>();

            Assert.AreEqual(expected, MarchingCubes.Instance.GetTriangles(vol1.Object, Threshold, GridSize));
        }

        [Test]
        public void BasicCase1ShouldReturnBasicTriangles()
        {
            var vol1 = new Mock<IVolume>();
            vol1.SetupAllProperties();
            vol1.Setup(x => x.Height).Returns(1);
            vol1.Setup(x => x.Depth).Returns(1);
            vol1.Setup(x => x.Width).Returns(1);
            vol1.Setup(x => x.GetVoxelValueAt(0, 0, 0)).Returns(FullBlack);

            var t = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 0.0, Y = 0.5, Z = 0.0 },
                Edge3 = new Point3D { X = 0.0, Y = 0.0, Z = 0.5 }
            };
            var expected = new List<ITriangle> { t };

            Assert.AreEqual(expected, MarchingCubes.Instance.GetTriangles(vol1.Object, Threshold, GridSize));
        }


        [Test]
        public void BasicCase2ShouldReturnBasicTriangles()
        {
            var vol1 = new Mock<IVolume>();
            vol1.SetupAllProperties();
            vol1.Setup(x => x.Height).Returns(1);
            vol1.Setup(x => x.Depth).Returns(1);
            vol1.Setup(x => x.Width).Returns(1);
            vol1.Setup(x => x.GetVoxelValueAt(0, 0, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(0, 1, 0)).Returns(FullBlack);

            var t1 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 0.0, Y = 0.5, Z = 1.0 },
                Edge3 = new Point3D { X = 0.5, Y = 1.0, Z = 0.5 }
            };
            var t2 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 0.0, Y = 0.0, Z = 0.5 },
                Edge3 = new Point3D { X = 0.5, Y = 1.0, Z = 0.5 }
            };
            var expected = new List<ITriangle> { t1, t2 };

            Assert.AreEqual(expected, MarchingCubes.Instance.GetTriangles(vol1.Object, Threshold, GridSize));
        }

        [Test]
        public void BasicCase3ShouldReturnBasicTriangles()
        {
            var vol1 = new Mock<IVolume>();
            vol1.SetupAllProperties();
            vol1.Setup(x => x.Height).Returns(1);
            vol1.Setup(x => x.Depth).Returns(1);
            vol1.Setup(x => x.Width).Returns(1);
            vol1.Setup(x => x.GetVoxelValueAt(0, 0, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(0, 1, 1)).Returns(FullBlack);

            var t1 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 0.0, Y = 0.5, Z = 0.0 },
                Edge3 = new Point3D { X = 0.0, Y = 0.0, Z = 0.5 }
            };
            var t2 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 1.0 },
                Edge2 = new Point3D { X = 0.5, Y = 0.5, Z = 1.0 },
                Edge3 = new Point3D { X = 1.0, Y = 0.0, Z = 0.5 }
            };
            var expected = new List<ITriangle> { t1, t2 };

            Assert.AreEqual(expected, MarchingCubes.Instance.GetTriangles(vol1.Object, Threshold, GridSize));
        }


        [Test]
        public void BasicCase4ShouldReturnBasicTriangles()
        {
            var vol1 = new Mock<IVolume>();
            vol1.SetupAllProperties();
            vol1.Setup(x => x.Height).Returns(1);
            vol1.Setup(x => x.Depth).Returns(1);
            vol1.Setup(x => x.Width).Returns(1);
            vol1.Setup(x => x.GetVoxelValueAt(0, 0, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(1, 1, 1)).Returns(FullBlack);

            var t1 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 0.0, Y = 0.5, Z = 0.0 },
                Edge3 = new Point3D { X = 0.0, Y = 0.0, Z = 0.5 }
            };
            var t2 = new Triangle
            {
                Edge1 = new Point3D { X = 1.0, Y = 1.0, Z = 0.5 },
                Edge2 = new Point3D { X = 0.5, Y = 0.5, Z = 1.0 },
                Edge3 = new Point3D { X = 1.0, Y = 0.5, Z = 1.0 }
            };
            var expected = new List<ITriangle> { t1, t2 };

            Assert.AreEqual(expected, MarchingCubes.Instance.GetTriangles(vol1.Object, Threshold, GridSize));
        }

        [Test]
        public void BasicCase5ShouldReturnBasicTriangles()
        {
            var vol1 = new Mock<IVolume>();
            vol1.SetupAllProperties();
            vol1.Setup(x => x.Height).Returns(1);
            vol1.Setup(x => x.Depth).Returns(1);
            vol1.Setup(x => x.Width).Returns(1);
            vol1.Setup(x => x.GetVoxelValueAt(0, 1, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(1, 1, 1)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(1, 0, 0)).Returns(FullBlack);

            var t1 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 0.0, Y = 0.5, Z = 0.0 },
                Edge3 = new Point3D { X = 0.0, Y = 1.0, Z = 0.5 }
            };
            var t2 = new Triangle
            {
                Edge1 = new Point3D { X = 1.0, Y = 1.0, Z = 0.5 },
                Edge2 = new Point3D { X = 0.5, Y = 0.5, Z = 1.0 },
                Edge3 = new Point3D { X = 1.0, Y = 0.5, Z = 1.0 }
            };
            var t3 = new Triangle
            {
                Edge1 = new Point3D { X = 1.0, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 0.0, Y = 1.0, Z = 0.5 },
                Edge3 = new Point3D { X = 1.0, Y = 1.0, Z = 0.5 }
            };
            var expected = new List<ITriangle> { t1, t2, t3 };

            Assert.AreEqual(expected, MarchingCubes.Instance.GetTriangles(vol1.Object, Threshold, GridSize));
        }

        [Test]
        public void BasicCase6ShouldReturnBasicTriangles()
        {
            var vol1 = new Mock<IVolume>();
            vol1.SetupAllProperties();
            vol1.Setup(x => x.Height).Returns(1);
            vol1.Setup(x => x.Depth).Returns(1);
            vol1.Setup(x => x.Width).Returns(1);
            vol1.Setup(x => x.GetVoxelValueAt(0, 0, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(1, 1, 1)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(0, 1, 0)).Returns(FullBlack);

            var t1 = new Triangle
            {
                Edge1 = new Point3D { X = 1.0, Y = 1.0, Z = 0.5 },
                Edge2 = new Point3D { X = 0.5, Y = 0.5, Z = 1.0 },
                Edge3 = new Point3D { X = 1.0, Y = 0.5, Z = 1.0 }
            };
            var t2 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 0.0, Y = 0.5, Z = 1.0 },
                Edge3 = new Point3D { X = 0.5, Y = 1.0, Z = 0.5 }
            };
            var t3 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 0.0, Y = 0.0, Z = 0.5 },
                Edge3 = new Point3D { X = 0.5, Y = 1.0, Z = 0.5 }
            };
            var expected = new List<ITriangle> { t1, t2, t3 };

            Assert.AreEqual(expected, MarchingCubes.Instance.GetTriangles(vol1.Object, Threshold, GridSize));
        }


        [Test]
        public void BasicCase7ShouldReturnBasicTriangles()
        {
            var vol1 = new Mock<IVolume>();
            vol1.SetupAllProperties();
            vol1.Setup(x => x.Height).Returns(1);
            vol1.Setup(x => x.Depth).Returns(1);
            vol1.Setup(x => x.Width).Returns(1);
            vol1.Setup(x => x.GetVoxelValueAt(0, 0, 1)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(1, 1, 1)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(0, 1, 0)).Returns(FullBlack);

            var t1 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 1.0, Y = 0.0, Z = 0.5 },
                Edge3 = new Point3D { X = 1.0, Y = 0.5, Z = 0.0 }
            };
            var t2 = new Triangle
            {
                Edge1 = new Point3D { X = 0.0, Y = 0.0, Z = 0.5 },
                Edge2 = new Point3D { X = 0.0, Y = 0.5, Z = 1.0 },
                Edge3 = new Point3D { X = 0.5, Y = 0.0, Z = 1.0 }
            };
            var t3 = new Triangle
            {
                Edge1 = new Point3D { X = 1.0, Y = 0.5, Z = 1.0 },
                Edge2 = new Point3D { X = 0.0, Y = 0.0, Z = 0.5 },
                Edge3 = new Point3D { X = 0.5, Y = 1.0, Z = 0.5 }
            };
            var expected = new List<ITriangle> { t1, t2, t3 };

            Assert.AreEqual(expected, MarchingCubes.Instance.GetTriangles(vol1.Object, Threshold, GridSize));
        }

        [Test]
        public void BasicCase8ShouldReturnBasicTriangles()
        {
            var vol1 = new Mock<IVolume>();
            vol1.SetupAllProperties();
            vol1.Setup(x => x.Height).Returns(1);
            vol1.Setup(x => x.Depth).Returns(1);
            vol1.Setup(x => x.Width).Returns(1);
            vol1.Setup(x => x.GetVoxelValueAt(0, 0, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(0, 1, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(1, 1, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(1, 0, 0)).Returns(FullBlack);

            var t1 = new Triangle
            {
                Edge1 = new Point3D { X = 0.0, Y = 0.0, Z = 0.5 },
                Edge2 = new Point3D { X = 0.0, Y = 1.0, Z = 0.5 },
                Edge3 = new Point3D { X = 1.0, Y = 1.0, Z = 0.5 }
            };
            var t2 = new Triangle
            {
                Edge1 = new Point3D { X = 0.0, Y = 0.0, Z = 0.5 },
                Edge2 = new Point3D { X = 1.0, Y = 0.0, Z = 0.5 },
                Edge3 = new Point3D { X = 1.0, Y = 1.0, Z = 0.5 }
            };

            var expected = new List<ITriangle> { t1, t2 };

            Assert.AreEqual(expected, MarchingCubes.Instance.GetTriangles(vol1.Object, Threshold, GridSize));
        }


        [Test]
        public void BasicCase9ShouldReturnBasicTriangles()
        {
            var vol1 = new Mock<IVolume>();
            vol1.SetupAllProperties();
            vol1.Setup(x => x.Height).Returns(1);
            vol1.Setup(x => x.Depth).Returns(1);
            vol1.Setup(x => x.Width).Returns(1);
            vol1.Setup(x => x.GetVoxelValueAt(0, 0, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(0, 1, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(1, 1, 0)).Returns(FullBlack);
            vol1.Setup(x => x.GetVoxelValueAt(0, 1, 1)).Returns(FullBlack);

            var t1 = new Triangle
            {
                Edge1 = new Point3D { X = 0.0, Y = 0.0, Z = 0.5 },
                Edge2 = new Point3D { X = 0.0, Y = 0.5, Z = 1.0 },
                Edge3 = new Point3D { X = 0.5, Y = 1.0, Z = 1.0 }
            };
            var t2 = new Triangle
            {
                Edge1 = new Point3D { X = 0.0, Y = 0.5, Z = 1.0 },
                Edge2 = new Point3D { X = 0.5, Y = 1.0, Z = 1.0 },
                Edge3 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 }
            };

            var t3 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 1.0, Z = 1.0 },
                Edge2 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge3 = new Point3D { X = 1.0, Y = 1.0, Z = 0.5 }
            };
            var t4 = new Triangle
            {
                Edge1 = new Point3D { X = 0.5, Y = 0.0, Z = 0.0 },
                Edge2 = new Point3D { X = 1.0, Y = 1.0, Z = 0.5 },
                Edge3 = new Point3D { X = 1.0, Y = 0.5, Z = 0.0 }
            };
            var expected = new List<ITriangle> { t1, t2,t3,t4 };

            Assert.AreEqual(expected, MarchingCubes.Instance.GetTriangles(vol1.Object, Threshold, GridSize));
        }
    }
}
