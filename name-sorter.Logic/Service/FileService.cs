using name_sorter.Logic.Interface;
using System.Collections.Generic;
using System.IO;

namespace name_sorter.Logic.Service
{
    public class FileService : IFileService
    {
        public virtual IEnumerable<string> ReadLines(string path)
        {
            if (IsValidPath(path))
            {
                return File.ReadLines(path);
            }
            return null;
        }

        public virtual void WriteAllLines(string path, List<string> contents)
        {
            File.WriteAllLines(path, contents);
        }

        public virtual bool IsValidPath(string path)
        {
            return File.Exists(path);
        }
    }
}
