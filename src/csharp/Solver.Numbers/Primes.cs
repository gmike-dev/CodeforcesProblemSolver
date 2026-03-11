using Solver.DataStructures;

namespace Solver.Numbers;

public static class Primes
{
  public static bool IsPrime(int x)
  {
    if (x < 2)
      return false;
    for (var i = 2; i * i <= x; i++)
    {
      if (x % i == 0)
        return false;
    }

    return true;
  }

  /// <summary>
  /// Sieve of Eratosthenes.
  /// </summary>
  public static IReadOnlyList<int> Sieve(int n)
  {
    if (n < 2)
      return [];
    var p = new bool[n + 1];
    Array.Fill(p, true);
    p[0] = p[1] = false;
    for (int i = 2; i * i <= n; i++)
    {
      if (p[i])
      {
        for (int j = i * i; j <= n; j += i)
          p[j] = false;
      }
    }

    var result = new List<int>();
    for (int i = 2; i < n + 1; i++)
      if (p[i])
        result.Add(i);
    return result;
  }

  /// <summary>
  /// Sieve of Eratosthenes (via a bit array).
  /// </summary>
  public static IReadOnlyList<int> BitSieve(int n)
  {
    if (n < 2)
      return [];
    var p = new SimpleBitArray(n + 1, true);
    p[0] = p[1] = false;
    for (int i = 2; i * i <= n; i++)
    {
      if (p[i])
      {
        for (int j = i * i; j <= n; j += i)
          p[j] = false;
      }
    }

    var result = new List<int>();
    for (int i = 2; i < n + 1; i++)
      if (p[i])
        result.Add(i);
    return result;
  }

  /// <summary>
  /// Sieve of Eratosthenes (30% faster).
  /// </summary>
  public static IReadOnlyList<int> EnhancedSieve(int n)
  {
    if (n < 2)
      return [];
    var p = new bool[n + 1];
    Array.Fill(p, true);
    for (int i = 3; i * i <= n; i += 2)
    {
      if (p[i])
      {
        for (var j = i * i; j <= n; j += i)
          p[j] = false;
      }
    }

    var result = new List<int> { 2 };
    for (int i = 3; i <= n; i += 2)
      if (p[i])
        result.Add(i);
    return result;
  }

  /// <summary>
  /// Sieve of Eratosthenes (with linear complexity).
  /// </summary>
  public static IReadOnlyList<int> LinearSieve(int n)
  {
    var lp = new int[n + 1];
    var pr = new List<int>();
    for (int i = 2; i <= n; ++i)
    {
      if (lp[i] == 0)
      {
        lp[i] = i;
        pr.Add(i);
      }

      for (int j = 0; j < pr.Count && pr[j] <= lp[i] && i * pr[j] <= n; j++)
      {
        lp[i * pr[j]] = pr[j];
      }
    }

    return pr;
  }

  /// <summary>
  /// Euler's totient function.
  /// Counts the positive integers up to a given integer n
  /// that are relatively prime (coprime) to n.
  /// https://en.wikipedia.org/wiki/Euler%27s_totient_function
  /// </summary>
  /// <remarks>
  /// Two integers a and b are coprime, relatively prime or mutually prime
  /// if the only positive integer that is a divisor of both of them is 1.
  /// </remarks>
  public static int Phi(int n)
  {
    var result = n;
    for (var i = 2; i * i <= n; i++)
    {
      if (n % i == 0)
      {
        do
        {
          n /= i;
        }
        while (n % i == 0);

        result -= result / i;
      }
    }

    if (n > 1)
    {
      result -= result / n;
    }

    return result;
  }
}
