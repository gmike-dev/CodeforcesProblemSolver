namespace Solver.DataStructures.Tests;

[TestFixture]
public class IndexedMaxHeapTests
{
  [Test]
  public void Test1()
  {
    var h = new IndexedMaxHeap<int, int>((x, y) => x.CompareTo(y));
    h.Push(1, 1);
    h.Push(2, 2);
    h.Push(3, 3);
    h.Push(4, 4);
    h.Push(5, 5);
    h.Top().Should().Be(5);
    h.Count.Should().Be(5);
    h.Pop().Should().Be(5);
    h.Count.Should().Be(4);
    h.PushPop(10, 10).Should().Be(4);
    h.Top().Should().Be(10);
    h.Pop().Should().Be(10);
    h.Top().Should().Be(3);
    h.Count.Should().Be(3);
    h.Remove(2);
    h.Top().Should().Be(3);
    h.Pop().Should().Be(3);
    h.Top().Should().Be(1);
    h.Count.Should().Be(1);
  }
}
