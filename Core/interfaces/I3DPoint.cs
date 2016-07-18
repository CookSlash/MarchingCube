using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.interfaces
{
    public interface I3DPoint
    {
        Double X { get; set; }
        Double Y { get; set; }
        Double Z { get; set; }
    }

    public class Point3D : I3DPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
