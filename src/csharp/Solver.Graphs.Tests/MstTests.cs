namespace Solver.Graphs.Tests;

[TestFixture]
public class MstTests
{
  [Test]
  public void KruskalTest()
  {
    Mst.Kruskal(
    [
      new Edge(0, 1, 4),
      new Edge(0, 2, 13),
      new Edge(0, 3, 7),
      new Edge(0, 4, 7),
      new Edge(1, 2, 9),
      new Edge(1, 3, 3),
      new Edge(1, 4, 7),
      new Edge(2, 3, 10),
      new Edge(2, 4, 14),
      new Edge(3, 4, 4)
    ], 5).Should().Be(20);
    Mst.Kruskal([new Edge(0, 1, 12), new Edge(0, 2, 18), new Edge(1, 2, 6)], 3).Should().Be(18);
  }

  [Test]
  public void PrimTest()
  {
    Mst.Prim([
      [0, 4, 13, 7, 7],
      [4, 0, 9, 3, 7],
      [13, 9, 0, 10, 14],
      [7, 3, 10, 0, 4],
      [7, 7, 14, 4, 0]
    ]).Should().Be(20);
    Mst.Prim([[0, 12, 18], [12, 0, 6], [18, 6, 0]]).Should().Be(18);
  }

  [Test]
  public void Prim2Test()
  {
    Mst.Prim([
      [(1, 4), (2, 13), (3, 7), (4, 7)],
      [(0, 4), (2, 9), (3, 3), (4, 7)],
      [(0, 13), (1, 9), (3, 10), (4, 14)],
      [(0, 7), (1, 3), (2, 10), (4, 4)],
      [(0, 7), (1, 7), (2, 14), (3, 4)]
    ]).Should().Be(20);
    Mst.Prim([
      [(1, 12), (2, 18)],
      [(0, 12), (2, 6)],
      [(0, 18), (1, 6)]
    ]).Should().Be(18);
  }
}
