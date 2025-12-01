package bit

import "math"

type MaxBit []int // 1-indexed

func NewMaxBit(n int) MaxBit {
	bit := make(MaxBit, n+1)
	for i := range bit {
		bit[i] = math.MinInt
	}
	return bit
}

// lsb Least significant 1-bit
func lsb(i int) int {
	return i & -i // LSB(i) = i & (^i + 1) = i & -i
}

func (bit MaxBit) PrefixMax(i int) int {
	result := math.MinInt
	for i++; i > 0; i -= lsb(i) {
		result = max(result, bit[i])
	}
	return result
}

// Update Only increasing values allowed!
func (bit MaxBit) Update(i int, value int) {
	for i++; i < len(bit); i += lsb(i) {
		bit[i] = max(bit[i], value)
	}
}

func (bit MaxBit) Build(a []int) {
	for i, val := range a {
		bit.Update(i, val)
	}
}
