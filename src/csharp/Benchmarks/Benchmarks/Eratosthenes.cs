using BenchmarkDotNet.Attributes;
using Solver.Numbers;

namespace Benchmarks.Benchmarks;

[MemoryDiagnoser]
public class Eratosthenes
{
  [Params(1000, 1000000)]
  public int N { get; set; }
  
  [Benchmark(Baseline = true)]
  public IReadOnlyList<int> Sieve()
  {
    return Primes.Sieve(N);
  }
  
  [Benchmark]
  public IReadOnlyList<int> BitSieve()
  {
    return Primes.BitSieve(N);
  }
  
  [Benchmark]
  public IReadOnlyList<int> EnhancedSieve()
  {
    return Primes.EnhancedSieve(N);
  }
  
  [Benchmark]
  public IReadOnlyList<int> LinearSieve()
  {
    return Primes.LinearSieve(N);
  }
}
