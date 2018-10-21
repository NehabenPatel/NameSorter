using name_sorter.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter.Logic
{
    public class SortNamesService : ISortNamesService
    {
        private readonly IFileService _fileService;

        public SortNamesService(IFileService FileService)
        {
            _fileService = FileService;
        }

        public IEnumerable<string> GetUnsortedNames(string path)
        {
            return _fileService.ReadLines(path);
        }

        public IEnumerable<string> SortNames(List<string> namelist)
        {
            return namelist.OrderBy(name =>
            {
                string[] names = name.Split(' ');
                if (names.Length > 4 || names.Length == 0)
                {
                    throw new ArgumentException($"Invalid Name: '{name}'");
                }
                string lastname = names.Last();
                string othernames = String.Join(" ", names.Take(names.Length - 1).ToArray());
                return lastname + " " + othernames;

            }).AsEnumerable();
        }

        public void WriteSortedNames(string path, List<string> contents)
        {
            _fileService.WriteAllLines(path, contents);
        }

        public bool ValidateFile(string[] args)
        {
            if (!_fileService.IsValidPath(args[0].ToString()))
                return false;
            else
                return true;
        }
    }
}
