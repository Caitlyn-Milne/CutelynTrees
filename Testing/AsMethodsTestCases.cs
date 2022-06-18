using CutelynTrees.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    public class AsMethodsTestCases
    {
        [Test]
        public void CheckFullTraversal()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var traversal = tree.AsTraversal().Select(n => n.Value);
            Assert.That(traversal, Is.EqualTo(new int[] { 1, 2, 3, 4, 5, 6, 7 }));

            traversal = tree.AsTraversal(TreeTraversalMethod.POST_ORDER).Select(n => n.Value);
            Assert.That(traversal, Is.EqualTo(new int[] { 3, 4, 2, 6, 7, 5, 1 }));

        }

        [Test]
        public void CheckPreOrderLinqTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var travseral = tree.AsTraversal();

            var firstEven = travseral.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(2));

            var evenNums = travseral.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 2, 4, 6 }));

            Assert.That(travseral.Any(n => n.Value == 5), Is.True);
        }

        [Test]
        public void CheckPostOrderLinqTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var traversal = tree.AsTraversal(TreeTraversalMethod.POST_ORDER);

            var firstEven = traversal.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(4));

            var evenNums = traversal.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 4, 2, 6 }));

            Assert.That(traversal.Any(n => n.Value == 5), Is.True);
        }

        [Test]
        public void CheckDescendantsTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var results = tree.AsDescendants().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 2, 3, 4, 5, 6, 7 }));

            results = tree.AsDescendants(TreeTraversalMethod.POST_ORDER).Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 3, 4, 2, 6, 7, 5 }));

            results = tree[1].AsDescendants().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 6, 7 }));

            results = tree[1].AsDescendants(TreeTraversalMethod.POST_ORDER).Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 6, 7 }));

        }

        [Test]
        public void CheckDescendantsLinqTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var leaves = tree.AsLeaves();

            var firstEven = leaves.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(4));

            var evenNums = leaves.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 4, 6 }));

            Assert.That(leaves.Any(n => n.Value == 5), Is.False);

            Assert.That(leaves.Any(n => n.Value == 3), Is.True);
        }


        [Test]
        public void CheckLeavesTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var results = tree.AsLeaves().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 3, 4, 6, 7 }));

            results = tree[1].AsLeaves().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 6, 7 }));

            results = tree[1][1].AsLeaves().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 7 }));
        }

        [Test]
        public void CheckLeavesLinqTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var leaves = tree.AsLeaves();

            var firstEven = leaves.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(4));

            var evenNums = leaves.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 4, 6 }));

            Assert.That(leaves.Any(n => n.Value == 5), Is.False);

            Assert.That(leaves.Any(n => n.Value == 3), Is.True);
        }

        [Test]
        public void CheckAncestorsTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var results = tree[0][0].AsAncestors().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { 2, 1 }));

            results = tree.AsAncestors().Select(n => n.Value);
            Assert.That(results, Is.EqualTo(new int[] { }));
        }

        [Test]
        public void CheckAncestorsLinqTests()
        {
            var tree = TreeFactory.CreateViaConstructor();

            var ancestors = tree[0][1].AsAncestors();

            var firstEven = ancestors.First(n => n.Value % 2 == 0);
            Assert.That(firstEven.Value, Is.EqualTo(2));

            var evenNums = ancestors.Where(n => n.Value % 2 == 0).Select(n => n.Value);
            Assert.That(evenNums, Is.EqualTo(new int[] { 2 }));

            Assert.That(ancestors.Any(n => n.Value == 5), Is.False);

            Assert.That(ancestors.Any(n => n.Value == 2), Is.True);
        }
    }
}
