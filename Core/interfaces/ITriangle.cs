using System.Drawing;
using Core.interfaces;

namespace Core.interfaces
{
    public interface ITriangle
    {
        I3DPoint Edge1 { get; set; }
        I3DPoint Edge2 { get; set; }
        I3DPoint Edge3 { get; set; }

        
    }

    public class Triangle : ITriangle
    {
        public I3DPoint Edge1 { get; set; }
        public I3DPoint Edge2 { get; set; }
        public I3DPoint Edge3 { get; set; }
    }
}