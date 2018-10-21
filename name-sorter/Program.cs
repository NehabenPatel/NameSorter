using Autofac;
using name_sorter.Logic.Infrastructure;
using name_sorter.Logic.Interface;
using System;
using System.Linq;

namespace name_sorter
{
    public class Program
    {
        private const string SORTED_FILEPATH = "./sorted-names-list.txt";

        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Invalid Usage.");
                Console.Error.WriteLine("Usage:  name-sorter <filepath> ");
                Console.Error.WriteLine("eg. name-sorter ./unsorted-names-list.txt");
                Environment.Exit(-1);
            }

            try
            {
                var container = DependencyRegister.Register();
                using (var scope = container.BeginLifetimeScope())
                {
                    var sortNameService = scope.Resolve<ISortNamesService>();
                    if (sortNameService.ValidateFile(args))
                    {
                        string unsortedFilePath = args[0].ToString();
                        var nameList = sortNameService.GetUnsortedNames(unsortedFilePath).ToList();

                        if (nameList.Count > 0)
                        {
                            var sortedName = sortNameService.SortNames(nameList).ToList();

                            Console.WriteLine("=================");
                            Console.WriteLine("SORTED NAME LIST:");
                            Console.WriteLine("=================");
                            Console.WriteLine(string.Join("\n", sortedName));

                            sortNameService.WriteSortedNames(SORTED_FILEPATH, sortedName);
                        }
                        else
                        {
                            Console.Error.WriteLine("Empty input file.");
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine("Invalid Usage.");
                        Console.Error.WriteLine("Usage:  name-sorter <filepath> ");
                        Console.Error.WriteLine("eg. name-sorter ./unsorted-names-list.txt");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}
