package numbers

func getPrimes(maxNum int) []int {
	if maxNum < 3 {
		return []int{}
	}
	isPrime := make([]bool, maxNum)
	for i := range isPrime {
		isPrime[i] = true
	}
	isPrime[0] = false
	isPrime[1] = false
	count := 0
	for i := 2; i*i < maxNum; i++ {
		if isPrime[i] {
			count++
			for j := i + i; j < maxNum; j += i {
				isPrime[j] = false
			}
		}
	}
	primes := make([]int, 0, count)
	for i := range isPrime {
		if isPrime[i] {
			primes = append(primes, i)
		}
	}
	return primes
}

func getPrimeDivisors(x int) []int {
	if x < 2 {
		return []int{}
	}
	primes := getPrimes(isqrt(x) + 1)
	var res []int
	for _, p := range primes {
		if p*p > x {
			break
		}
		if x%p == 0 {
			res = append(res, p)
			for x%p == 0 {
				x /= p
			}
		}
	}
	if x != 1 {
		res = append(res, x)
	}
	return res
}
