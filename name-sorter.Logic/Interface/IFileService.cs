using System.Collections.Generic;

namespace name_sorter.Logic.Interface
{
    public interface IFileService
    {
        IEnumerable<string> ReadLines(string path);
        void WriteAllLines(string path, List<string> contents);
        bool IsValidPath(string path);
    }
}
