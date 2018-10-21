using System.Collections.Generic;

namespace name_sorter.Logic.Interface
{
    public interface ISortNamesService
    {
        IEnumerable<string> GetUnsortedNames(string path);
        IEnumerable<string> SortNames(List<string> namelist);     
        void WriteSortedNames(string path, List<string> contents);
        bool ValidateFile(string[] args);
    }
}
