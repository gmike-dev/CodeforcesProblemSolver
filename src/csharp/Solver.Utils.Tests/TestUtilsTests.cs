namespace Solver.Utils.Tests;

[TestFixture]
public class TestUtilsTests
{
  [Test]
  public void ToArrayTest()
  {
    "[]".Array().Should().BeEmpty();
    "[1]".Array().Should().BeEquivalentTo([1]);
    "[1,-2,3]".Array().Should().BeEquivalentTo([1, -2, 3], o => o.WithStrictOrdering());
  }

  [Test]
  public void ToArray2Test()
  {
    "[]".Array2().Should().BeEmpty();
    "[[]]".Array2().Should().BeEquivalentTo((int[][])[[]]);
    "[[1]]".Array2().Should().BeEquivalentTo((int[][])[[1]]);
    "[[],[1],[1,-2,22]]".Array2().Should().BeEquivalentTo((int[][])[[], [1], [1, -2, 22]]);
    "[[],[]]".Array2().Should().BeEquivalentTo((int[][])[[], []]);
    """
        [ [1,2],
          [3,4] ]
      """.Array2().Should().BeEquivalentTo((int[][])[[1, 2], [3, 4]]);
  }

  [Test]
  public void ArrayToStringTest()
  {
    Array.Empty<int>().String().Should().Be("[]");
    new[] { 1 }.String().Should().Be("[1]");
    new[] { 1, -2, 3 }.String().Should().Be("[1,-2,3]");
  }

  [Test]
  public void ArrayOfLongToStringTest()
  {
    Array.Empty<long>().String().Should().Be("[]");
    new[] { 1L }.String().Should().Be("[1]");
    new[] { 1L, -2L, 3L }.String().Should().Be("[1,-2,3]");
  }

  [Test]
  public void Array2ToStringTest()
  {
    ((int[][])[]).String().Should().Be("[]");
    ((int[][])[[]]).String().Should().Be("[[]]");
    ((int[][])[[1]]).String().Should().Be("[[1]]");
    ((int[][])[[], [1], [1, -2, 22]]).String().Should().Be("[[],[1],[1,-2,22]]");
    ((int[][])[[], []]).String().Should().Be("[[],[]]");
  }

  [Test]
  public void Array2OfLongToStringTest()
  {
    ((long[][])[]).String().Should().Be("[]");
    ((long[][])[[]]).String().Should().Be("[[]]");
    ((long[][])[[1L]]).String().Should().Be("[[1]]");
    ((long[][])[[], [1L], [1L, -2L, 22L]]).String().Should().Be("[[],[1],[1,-2,22]]");
    ((long[][])[[], []]).String().Should().Be("[[],[]]");
  }
}
