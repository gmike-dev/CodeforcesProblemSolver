namespace Solver.DataStructures;

public static class Matrix
{
  public static int[][] Rotate90Clockwise(int[][] matrix)
  {
    int n = matrix.Length;
    int m = matrix[0].Length;
    int[][] result = new int[m][];
    for (int i = 0; i < m; i++)
    {
      result[i] = new int[n];
      for (int j = 0; j < n; j++)
      {
        result[i][j] = matrix[n - j - 1][i];
      }
    }

    return result;
  }

  public static void Rotate90ClockwiseInPlace(int[][] matrix)
  {
    int n = matrix.Length;
    for (int i = 0; i < n / 2; i++)
    {
      for (int j = 0; j < (n + 1) / 2; j++)
      {
        (matrix[i][j], matrix[j][n - i - 1], matrix[n - i - 1][n - j - 1], matrix[n - j - 1][i]) =
          (matrix[n - j - 1][i], matrix[i][j], matrix[j][n - i - 1], matrix[n - i - 1][n - j - 1]);
      }
    }
  }

  public static void Rotate90ClockwiseInPlace2(int[][] matrix)
  {
    Array.Reverse(matrix);
    Transpose(matrix);
  }

  public static void Transpose(int[][] matrix)
  {
    int n = matrix.Length;
    for (int i = 0; i < n - 1; i++)
    for (int j = i + 1; j < n; j++)
    {
      (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
    }
  }
  
  public static int[][] Rotate180(int[][] matrix)
  {
    if (matrix == null || matrix.Length == 0)
      return matrix;

    int rows = matrix.Length;
    int cols = matrix[0].Length;
    int[][] result = new int[rows][];

    for (int i = 0; i < rows; i++)
    {
      result[i] = new int[cols];
      for (int j = 0; j < cols; j++)
      {
        result[i][j] = matrix[rows - 1 - i][cols - 1 - j];
      }
    }

    return result;
  }
}
