namespace Solver.Utils;

public static class TestUtils
{
  public static int[] Array(this string s)
  {
    const string itemPattern = @"[^,\[\]]+";
    Regex itemsRegex = new(itemPattern, RegexOptions.Compiled);
    List<int> result = [];
    foreach (Match match in itemsRegex.Matches(s))
    {
      result.Add(int.Parse(match.Value.Trim()));
    }

    return result.ToArray();
  }

  public static int[][] Array2(this string s)
  {
    const string contentPattern = @"\[(.*)\]";
    Regex contentRegex = new(contentPattern, RegexOptions.Compiled | RegexOptions.Singleline);
    Match m = contentRegex.Match(s);
    if (!m.Success)
    {
      throw new FormatException();
    }

    s = m.Groups[1].Value;
    const string rowPattern = @"\[[^\[\]]*\]";
    Regex rowsRegex = new(rowPattern, RegexOptions.Compiled | RegexOptions.Singleline);
    List<int[]> result = [];
    foreach (Match match in rowsRegex.Matches(s))
    {
      result.Add(match.Value.Array());
    }

    return result.ToArray();
  }

  public static string String(this int[] a)
  {
    return $"[{string.Join(",", a)}]";
  }

  public static string String(this long[] a)
  {
    return $"[{string.Join(",", a)}]";
  }

  public static string String(this int[][] a)
  {
    return $"[{string.Join(",", a.Select(aa => aa.String()))}]";
  }

  public static string String(this long[][] a)
  {
    return $"[{string.Join(",", a.Select(aa => aa.String()))}]";
  }
}
