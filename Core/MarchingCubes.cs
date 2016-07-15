using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.interfaces;

namespace Core
{
    public class MarchingCubes : IMarchingCubes
    {
        #region Singleton
        private static readonly Lazy<IMarchingCubes> lazy =
        new Lazy<IMarchingCubes>(() => new MarchingCubes());

        public static IMarchingCubes Instance => lazy.Value;

        private MarchingCubes()
        {
        }
        #endregion

        IReadOnlyList<ITriangle> IMarchingCubes.GetTriangles(IVolume vol, int threshold, int gridSize)
        {
            throw new NotImplementedException();
        }
    }
}
