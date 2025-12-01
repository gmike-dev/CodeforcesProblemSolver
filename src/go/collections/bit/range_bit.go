package bit

type RangeBit []int // 1-indexed

func NewRangeBit(n int) RangeBit {
	return make(RangeBit, n+1)
}

func (bit RangeBit) internalAdd(i int, delta int) {
	for i++; i < len(bit); i += i & -i { // i += LSB(i), LSB(i) = i & (^i + 1) = i & -i
		bit[i] += delta
	}
}

func (bit RangeBit) Add(i int, delta int) {
	bit.RangeAdd(i, i, delta)
}

func (bit RangeBit) RangeAdd(l, r int, delta int) {
	bit.internalAdd(l, delta)
	bit.internalAdd(r+1, -delta)
}

func (bit RangeBit) Get(i int) int {
	result := 0
	for i++; i > 0; i -= i & -i { // i += LSB(i), LSB(i) = i & (^i + 1) = i & -i
		result += bit[i]
	}
	return result
}
