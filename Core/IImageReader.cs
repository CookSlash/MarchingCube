using System.Collections.Generic;

namespace Core
{
    public interface IImageReader
    {
        IList<int> GetBitmapFromFile(string imgPath);
        int Width(string imgPath);
        int Heigth(string imgPath);
        IReadOnlyList<string> GetImageListInDir(string dummydir);
    }
}