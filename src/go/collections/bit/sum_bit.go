package bit

type SumBit []int // 1-indexed

func NewSumBit(n int) SumBit {
	return make(SumBit, n+1)
}

func (bit SumBit) PrefixSum(i int) int {
	sum := 0
	for i++; i > 0; i -= i & -i { // i -= LSB(i), LSB(i) = i & (^i + 1) = i & -i
		sum += bit[i]
	}
	return sum
}

func (bit SumBit) Sum(l, r int) int {
	return bit.PrefixSum(r) - bit.PrefixSum(l-1)
}

func (bit SumBit) Add(i int, delta int) {
	for i++; i < len(bit); i += i & -i { // i += LSB(i), LSB(i) = i & (^i + 1) = i & -i
		bit[i] += delta
	}
}

func (bit SumBit) Build(a []int) {
	for i, val := range a {
		bit.Add(i, val)
	}
}
