using Solver.Utils;

namespace Solver.DataStructures.Tests;

[TestFixture]
public class MatrixTests
{
  [TestCase(
    """
    [ [1,2],
      [3,4] ]
    """,
    """
    [ [3,1],
      [4,2] ]
    """)]
  [TestCase("[[1,2]]", "[[1],[2]]")]
  [TestCase(
    """
    [ [1,2,3],
      [4,5,6] ]
    """,
    """
    [ [4,1],
      [5,2],
      [6,3] ]
    """)]
  public void Rotate90ClockwiseTests(string matrix, string expected)
  {
    Matrix.Rotate90Clockwise(matrix.Array2())
      .Should()
      .BeEquivalentTo(expected.Array2(), o => o.WithStrictOrdering());
  }

  [TestCase(
    """
    [ [1,2],
      [3,4] ]
    """,
    """
    [ [3,1],
      [4,2] ]
    """)]
  [TestCase(
    """
    [ [1,2,3],
      [4,5,6],
      [7,8,9] ]
    """,
    """
    [ [7,4,1],
      [8,5,2],
      [9,6,3] ]
    """)]
  [TestCase("[ [1] ]", "[ [1] ]")]
  public void Rotate90ClockwiseInPlaceTests(string matrixStr, string expected)
  {
    int[][] matrix = matrixStr.Array2();
    Matrix.Rotate90ClockwiseInPlace(matrix);
    matrix
      .Should()
      .BeEquivalentTo(expected.Array2(), o => o.WithStrictOrdering());
  }

  [TestCase(
    """
    [ [1,2],
      [3,4] ]
    """,
    """
    [ [3,1],
      [4,2] ]
    """)]
  [TestCase(
    """
    [ [1,2,3],
      [4,5,6],
      [7,8,9] ]
    """,
    """
    [ [7,4,1],
      [8,5,2],
      [9,6,3] ]
    """)]
  [TestCase("[ [1] ]", "[ [1] ]")]
  public void Rotate90ClockwiseInPlace2Tests(string matrixStr, string expected)
  {
    int[][] matrix = matrixStr.Array2();
    Matrix.Rotate90ClockwiseInPlace2(matrix);
    matrix
      .Should()
      .BeEquivalentTo(expected.Array2(), o => o.WithStrictOrdering());
  }

  [TestCase(
    """
    [ [1,2],
      [3,4] ]
    """,
    """
    [ [1,3],
      [2,4] ]
    """)]
  [TestCase(
    """
    [ [1,2,3],
      [4,5,6],
      [7,8,9] ]
    """,
    """
    [ [1,4,7],
      [2,5,8],
      [3,6,9] ]
    """)]
  [TestCase("[ [1] ]", "[ [1] ]")]
  public void TransposeTests(string matrixStr, string expected)
  {
    int[][] matrix = matrixStr.Array2();
    Matrix.Transpose(matrix);
    matrix
      .Should()
      .BeEquivalentTo(expected.Array2(), o => o.WithStrictOrdering());
  }
}
