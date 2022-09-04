using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CutelynTrees.BinaryTrees;

namespace Testing.BinaryTree
{
    internal class SearchTests
    {
        [Test]
        public void CheckSearchFound()
        {
            var binaryTree = ConstructorTests.Create();

            searchThenCheck(8);
            searchThenCheck(5);
            searchThenCheck(3);
            searchThenCheck(12);
            searchThenCheck(10);
            searchThenCheck(9);
            searchThenCheck(14);

            void searchThenCheck(int value) {
                var searchResult = binaryTree.Search(value);
                Assert.That(searchResult, Is.Not.Null);
                Assert.That(searchResult.Value, Is.EqualTo(value));
            }
        }

        [Test]
        public void CheckSearchDidntFind()
        {
            var binaryTree = ConstructorTests.Create();

            searchThenCheck(1);
            searchThenCheck(2);
            searchThenCheck(4);
            searchThenCheck(6);
            searchThenCheck(7);
            searchThenCheck(11);
            searchThenCheck(13);
            searchThenCheck(15);

            void searchThenCheck(int value)
            {
                var searchResult = binaryTree.Search(value);
                Assert.That(searchResult, Is.Null);
            }
        }
    }
}
