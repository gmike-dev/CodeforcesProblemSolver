namespace Solver.Strings;

/// <summary>
/// Rabin-Karp
/// </summary>
/// <remarks>https://en.wikipedia.org/wiki/Rabin%E2%80%93Karp_algorithm</remarks>
public static class RabinKarp
{
    public static int SingleHash(string t, string s)
    {
        const ulong p = 91138233; // or 31, 131, 127, 257
        const ulong mod = 1_000_000_007; // or 91138233

        int n = s.Length;
        if (n == 0 || n > t.Length)
        {
            return -1;
        }

        ulong powN = 1;
        for (int i = 1; i < n; i++)
        {
            powN = powN * p % mod;
        }

        ulong hs = 0;
        for (int i = 0; i < n; i++)
        {
            hs = (hs * p + s[i]) % mod;
        }

        ulong ht = 0;
        for (int i = 0; i < n; i++)
        {
            ht = (ht * p + t[i]) % mod;
        }

        if (ht == hs)
        {
            return 0;
        }

        for (int i = n; i < t.Length; i++)
        {
            // Rolling hash (remove prev symbol and add next)
            ht = (ht + mod - t[i - n] * powN % mod) % mod;
            ht = (ht * p + t[i]) % mod;
            if (ht == hs)
            {
                return i - n + 1;
            }
        }

        return -1;
    }

    public static int DoubleHash(string t, string s)
    {
        const ulong p = 91138233; // or 31, 131, 127, 257
        const ulong mod1 = 1_000_000_007; // or 91138233
        const ulong mod2 = 1_000_000_009; // or 97266353

        int n = s.Length;
        if (n == 0 || n > t.Length)
        {
            return -1;
        }

        ulong powN1 = 1;
        ulong powN2 = 1;
        for (int i = 0; i < n; i++)
        {
            powN1 = powN1 * p % mod1;
            powN2 = powN2 * p % mod2;
        }

        ulong hs1 = 0;
        ulong hs2 = 0;
        for (int i = 0; i < n; i++)
        {
            hs1 = (hs1 * p + s[i]) % mod1;
            hs2 = (hs2 * p + s[i]) % mod2;
        }

        ulong ht1 = 0;
        ulong ht2 = 0;
        for (int i = 0; i < n; i++)
        {
            ht1 = (ht1 * p + t[i]) % mod1;
            ht2 = (ht2 * p + t[i]) % mod2;
        }

        if (ht1 == hs1 && ht2 == hs2)
        {
            return 0;
        }

        for (int i = n; i < t.Length; i++)
        {
            // Rolling hash (remove prev symbol and add next)
            ht1 = ((ht1 * p + t[i]) % mod1 + mod1 - t[i - n] * powN1 % mod1) % mod1;
            ht2 = ((ht2 * p + t[i]) % mod2 + mod2 - t[i - n] * powN2 % mod2) % mod2;

            if (ht1 == hs1 && ht2 == hs2)
            {
                return i - n + 1;
            }
        }

        return -1;
    }
}
