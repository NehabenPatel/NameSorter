using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter.Logic.Infrastructure;
using name_sorter.Logic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace name_sorter.Test
{
    [TestClass]
    public class SortNameServiceTest
    {
        private ISortNamesService _sortNamesService;

        [TestInitialize]
        public void TestInitialize()
        {
            var container = DependencyRegister.Register();
            using (var scope = container.BeginLifetimeScope())
            {
                _sortNamesService = scope.Resolve<ISortNamesService>();
            }
        }

        [TestMethod]
        public void TestSortSingleName()
        {
            List<string> names = new List<string> { "Neha" };
            Assert.AreEqual("Neha", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 1);
        }

        [TestMethod]
        public void TestSortSimpleNames()
        {
            List<string> names = new List<string> { "Neha", "Ayesha" };
            Assert.AreEqual("Ayesha Neha", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 2);
        }

        [TestMethod]
        //Sort order by last name. 
        public void TestSortNames_WithFirstAndLastName()
        {
            List<string> names = new List<string> { "Neha Patel", "Ayesha Zulka" };
            Assert.AreEqual("Neha Patel Ayesha Zulka", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 2);
        }

        [TestMethod]
        public void TestSortNames_WithFirstAndLastNameAgainInReverseOrder()
        {
            List<string> names = new List<string> { "Ayesha Zulka", "Neha Patel" };
            Assert.AreEqual("Neha Patel Ayesha Zulka", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 2);
        }

        [TestMethod]
        public void TestSortNames_WithFirstMiddleLastName()
        {
            List<string> names = new List<string> { "Orson Milka Iddins", "Erna Dorey Battelle"};
            Assert.AreEqual("Erna Dorey Battelle Orson Milka Iddins", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 2);
        }

        [TestMethod]
        public void TestSortNames_WithLongName()
        {
            List<string> names = new List<string> { "Selle Dellison", "Leonerd Adda Mitchell Monaghan", "Erna Dorey Battelle" };
            Assert.AreEqual("Erna Dorey Battelle Selle Dellison Leonerd Adda Mitchell Monaghan", String.Join(" ", _sortNamesService.SortNames(names)));
            Assert.IsTrue(names.Count() == 3);
        }

    }
}
