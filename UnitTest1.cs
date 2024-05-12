using DAG_ConsoleApp1;
using DAG_ConsoleApp1.Models;

namespace DAG_UniTesting
{
    [TestClass]
    public class UnitTest1
    {
        private List<Nodes> graphNodes;

        [TestInitialize]
        public void Initialize()
        {
            var a = new Nodes { NodeName = "A" };
            var b = new Nodes { NodeName = "B" };
            var c = new Nodes { NodeName = "C" };
            var d = new Nodes { NodeName = "D" };
            var e = new Nodes { NodeName = "E" };
            var f = new Nodes { NodeName = "F" };
            var g = new Nodes { NodeName = "G" };
            var h = new Nodes { NodeName = "H" };
            var i = new Nodes { NodeName = "I" };

            a.NodeNeighbor.Add(b, 4);
            a.NodeNeighbor.Add(c, 6);
            b.NodeNeighbor.Add(a, 4);
            b.NodeNeighbor.Add(f, 2);
            c.NodeNeighbor.Add(a, 6);
            c.NodeNeighbor.Add(d, 8);
            d.NodeNeighbor.Add(c, 8);
            d.NodeNeighbor.Add(e, 4);
            d.NodeNeighbor.Add(g, 1);
            e.NodeNeighbor.Add(b, 2);
            e.NodeNeighbor.Add(d, 4);
            e.NodeNeighbor.Add(f, 3);
            e.NodeNeighbor.Add(i, 8);
            f.NodeNeighbor.Add(b, 2);
            f.NodeNeighbor.Add(e, 3);
            f.NodeNeighbor.Add(g, 4);
            f.NodeNeighbor.Add(h, 6);
            g.NodeNeighbor.Add(d, 1);
            g.NodeNeighbor.Add(f, 4);
            g.NodeNeighbor.Add(h, 5);
            g.NodeNeighbor.Add(i, 5);
            h.NodeNeighbor.Add(f, 6);
            h.NodeNeighbor.Add(g, 5);
            i.NodeNeighbor.Add(e, 8);
            i.NodeNeighbor.Add(g, 5);

            graphNodes = new List<Nodes> { a, b, c, d, e, f, g, h, i };
        }

        [TestMethod]
        public void TestMethod1()
        {
            var shortestPathData = Program.ShortestPathData("A", "D", graphNodes);
            var truePath = new List<string> { "A", "B", "F", "G", "D" };
            int trueDist = 11;
            Assert.AreEqual(trueDist, shortestPathData.Distance);
            CollectionAssert.AreEqual(truePath, shortestPathData.NodeNames);
        }

        [TestMethod]
        public void TestMethod2()
        {

            var shortestPathData = Program.ShortestPathData("B", "E", graphNodes);
            var truePath = new List<string> { "B", "F", "E" };
            int trueDist = 5;
            Assert.AreEqual(trueDist, shortestPathData.Distance);
            CollectionAssert.AreEqual(truePath, shortestPathData.NodeNames);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var shortestPathData = Program.ShortestPathData("G", "A", graphNodes);
            var truePath = new List<string> { "G", "F", "B", "A" };
            int trueDist = 10;
            Assert.AreEqual(trueDist, shortestPathData.Distance);
            CollectionAssert.AreEqual(truePath, shortestPathData.NodeNames);
        }


    }
}