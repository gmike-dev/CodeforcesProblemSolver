using Solver.DataStructures;

namespace Solver.Graphs;

public readonly record struct Edge(int From, int To, int Weight);

/// <summary>
/// Minimum spanning tree (MST) functions.
/// https://en.wikipedia.org/wiki/Minimum_spanning_tree
/// https://e-maxx.ru/algo/mst_kruskal_with_dsu
/// </summary>
public static class Mst
{
  /// <summary>
  /// Kruskal's algorithm for finding a minimum spanning tree (MST) weight.
  /// </summary>
  public static int Kruskal(IEnumerable<Edge> edges, int vertexCount)
  {
    edges = edges.OrderBy(e => e.Weight).ToArray();
    var dsu = new UnionFind(vertexCount);
    var weight = 0;
    foreach (var edge in edges)
    {
      if (dsu.Union(edge.From, edge.To))
        weight += edge.Weight;
    }

    return dsu.Count > 1 ? -1 : weight; // -1 if graph is not connected
  }

  /// <summary>
  /// Prim's algorithm for finding a minimum spanning tree (MST) weight.
  /// </summary>
  /// <param name="g">g[x][y] - weight of edge (x, y).</param>
  public static int Prim(int[][] g)
  {
    var result = 0;
    var n = g.Length;
    var used = new bool[n];
    var min = new int[n];
    Array.Fill(min, int.MaxValue);
    min[0] = 0;
    for (var i = 0; i < n; i++)
    {
      var v = -1;
      for (var j = 0; j < n; j++)
      {
        if (!used[j] && (v == -1 || min[j] < min[v]))
          v = j;
      }

      result += min[v];
      used[v] = true;
      for (var j = 0; j < n; j++)
      {
        if (g[v][j] < min[j])
          min[j] = g[v][j];
      }
    }

    return result;
  }

  /// <summary>
  /// Prim's algorithm for finding a minimum spanning tree (MST) weight.
  /// </summary>
  public static long Prim(List<(int v, int weight)>[] g)
  {
    int n = g.Length;
    var used = new bool[n];
    var pq = new PriorityQueue<int, int>();
    pq.Enqueue(0, 0);
    long mst = 0;
    while (pq.TryDequeue(out int v, out int w))
    {
      if (used[v])
      {
        continue;
      }

      used[v] = true;
      mst += w;

      foreach (var (to, weight) in g[v])
      {
        if (!used[to])
        {
          pq.Enqueue(to, weight);
        }
      }
    }

    return mst;
  }
}
