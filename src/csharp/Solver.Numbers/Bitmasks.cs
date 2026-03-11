namespace Solver.Numbers;

public static class Bitmasks
{
  /// <summary>
  /// Number of 1 Bits.
  /// </summary>
  public static int HammingWeight(uint n)
  {
    var count = 0;
    while (n != 0)
    {
      n &= (n - 1);
      count++;
    }

    return count;
  }

  /// <summary>
  /// Number of 1 Bits.
  /// </summary>
  public static int HammingWeight2(uint n)
  {
    return BitOperations.PopCount(n);
  }
  
  /// <summary>
  /// Number of 1 Bits.
  /// </summary>
  public static int HammingWeight3(uint n)
  {
    n = (n & 0x55555555) + ((n >> 1) & 0x55555555);
    n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
    n = (n & 0x0F0F0F0F) + ((n >> 4) & 0x0F0F0F0F);
    n = (n & 0x00FF00FF) + ((n >> 8) & 0x00FF00FF);
    n = (n & 0x0000FFFF) + ((n >> 16) & 0x0000FFFF);
    return (int)n;
  }

  public static uint ReverseBits(uint n)
  {
    uint result = 0;
    for (var i = 0; i < 32; i++)
    {
      result = (result << 1) | (n & 1);
      n >>= 1;
    }

    return result;
  }

  public static uint ReverseBits2(UInt32 n)
  {
    n = ((n & 0xAAAAAAAA) >> 1) | ((n & 0x55555555) << 1);
    n = ((n & 0xCCCCCCCC) >> 2) | ((n & 0x33333333) << 2);
    n = ((n & 0xF0F0F0F0) >> 4) | ((n & 0x0F0F0F0F) << 4);
    n = ((n & 0xFF00FF00) >> 8) | ((n & 0x00FF00FF) << 8);
    n = ((n & 0xFFFF0000) >> 16) | ((n & 0x0000FFFF) << 16);
    return n;
  }

  /// <summary>
  /// Return most significant 1-bit (MSb).
  /// </summary>
  /// <remarks>
  /// e.g. Msb(101101100) = 100000000.
  /// </remarks>
  public static uint LargestPower(uint n)
  {
    const uint maxPow = 1u << 31;
    if ((n & maxPow) != 0)
      return maxPow;
    // Fill trailing zeros with ones, eg 00010010 becomes 00011111.
    n |= (n >> 1);
    n |= (n >> 2);
    n |= (n >> 4);
    n |= (n >> 8);
    n |= (n >> 16);
    return (n + 1) >> 1;
  }

  /// <summary>
  /// Return most significant 1-bit (MSb).
  /// </summary>
  /// <remarks>
  /// e.g. Msb(101101100) = 100000000.
  /// </remarks>
  public static uint LargestPower2(uint n)
  {
    return n == 0 ? 0 : 1u << BitOperations.Log2(n);
  }

  /// <summary>
  /// Return least significant 1-bit (LSb).
  /// </summary>
  /// <remarks>
  /// e.g. Lso(101101100) = 100.
  /// </remarks>
  public static int Lso(int n)
  {
    return n & -n;
  }

  /// <summary>
  /// Return least significant 1-bit (LSb).
  /// </summary>
  /// <remarks>
  /// e.g. Lso(101101100) = 100.
  /// </remarks>
  public static uint Lso(uint n)
  {
    return n & (~n + 1);
  }

  /// <summary>
  /// Return most significant 1-bit (MSb).
  /// </summary>
  /// <remarks>
  /// e.g. Msb(101101100) = 100000000.
  /// </remarks>
  public static uint Mso(uint n)
  {
    return LargestPower2(n);
  }

  /// <remarks>Same as <see cref="BitOperations.IsPow2(int)"/></remarks>
  public static bool IsPowerOfTwo(int n)
  {
    return n > 0 && (n & (n - 1)) == 0;
  }

  public static bool IsPowerOfFour(int n)
  {
    return n > 0 && (n & (n - 1)) == 0 && (n & 0x55555555) != 0;
  }

  /// <summary>
  /// Return 1 if <see cref="n"/> is not zero, 0 else.
  /// </summary>
  public static int IsNotZero(int n)
  {
    return (n | (~n + 1)) >> 31 & 1;
  }

  /// <summary>
  /// Converts an unsigned binary number to reflected binary Gray code. 
  /// </summary>
  /// <returns>Gray code for <paramref name="n"/></returns>
  /// <remarks>https://en.wikipedia.org/wiki/Gray_code</remarks>
  public static uint BinaryToGray(uint n)
  {
    return n ^ (n >> 1);
  }

  /// <summary>
  /// Convert a reflected binary Gray code number to a binary number.
  /// </summary>
  public static uint GrayToBinary(uint num)
  {
    var mask = num;
    while (mask != 0)
    {
      mask >>= 1;
      num ^= mask;
    }

    return num;
  }

  /// <summary>
  /// Invert case of ASCII character.
  /// </summary>
  public static char InvertCase(char c) => (char)(c ^ 32);
  
  /// <summary>
  /// Gosper’s hack subset enumeration.
  /// </summary>
  public static class GosperCombinations
  {
    /// <summary>
    /// Returns the next bit mask with the same number of set bits (Gosper's hack).
    /// The input mask must be non-zero and represent a valid combination.
    /// If there is no next mask within the given bit width, the result may overflow.
    /// </summary>
    public static int NextCombination(int mask)
    {
      // m: 1011100
      // c: 0000100
      // r: 1100000
      // r ^ m: 0111100
      // >> 2: 0001111
      // / c: 0000011 - division by 2^k == right shift by k (and c = 2^2)
      // | r: 1110011
      var c = mask & -mask; // least significant 1-bit (LSb)
      var r = mask + c;
      return (((r ^ mask) >> 2) / c) | r;
    }

    /// <summary>
    /// Generates all combinations C(n, k) as bit masks.
    /// Each mask has exactly k bits set among n bits.
    /// The masks are returned in increasing lexicographic order.
    /// </summary>
    public static IEnumerable<int> Generate(int n, int k)
    {
      if (k < 0 || k > n)
        yield break;

      var mask = (1 << k) - 1;
      var limit = 1 << n;

      while (mask < limit)
      {
        yield return mask;
        mask = NextCombination(mask);
      }
    }
  }
}
