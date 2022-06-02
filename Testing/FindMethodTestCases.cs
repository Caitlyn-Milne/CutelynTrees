using CutelynTrees.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    internal class FindMethodTestCases
    {
        [Test]
        public void CheckFullTraversal()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var descendants = tree.FindDecendants().Select(n => n.Value);
            Assert.That(descendants, Is.EqualTo(new int[] { 1, 2, 3, 4, 5, 6, 7 }));

            descendants = tree.FindDecendants(TreeTraversalMethod.POST_ORDER).Select(n => n.Value);
            Assert.That(descendants, Is.EqualTo(new int[] { 3, 4, 2, 6, 7, 5, 1 }));

            var leaves = tree.FindLeaves().Select(n => n.Value);
            Assert.That(new int[] { 3, 4, 6, 7 }, Is.EqualTo(leaves));

            descendants = tree.FindDecendants(TreeTraversalMethod.IN_ORDER).Select(d => d.Value);
            Assert.That(new int[] { 3, 2, 4, 1, 6, 5, 7 }, Is.EqualTo(descendants));
        }

        [Test]
        public void TestFindMethodsLinq()
        {
            var tree = TreeFactory.CreateViaConstructor();
            var descendants = tree.FindDecendants();

            var firstEven = descendants.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(2));

            var evenNums = descendants.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 2, 4, 6 }));

            Assert.That(descendants.Any(n => n.Value == 5), Is.True);
        }
    }
}
