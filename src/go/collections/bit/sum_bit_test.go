package bit

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestSumBit(t *testing.T) {
	f := NewSumBit(5)
	arr := []int{1, 2, 3, 4, 5}
	f.Build(arr)

	assert.Equal(t, 1, f.Sum(0, 0))
	assert.Equal(t, 1+2+3, f.Sum(0, 2))
	assert.Equal(t, 2+3+4, f.Sum(1, 3))
	assert.Equal(t, 1+2+3+4+5, f.Sum(0, 4))
	assert.Equal(t, 4+5, f.Sum(3, 4))
}

func TestSumBitUpdate(t *testing.T) {
	f := NewSumBit(5)
	arr := []int{1, 2, 3, 4, 5}
	f.Build(arr)

	f.Update(2, 10)

	assert.Equal(t, 13, f.Sum(2, 2))
	assert.Equal(t, 2+13+4, f.Sum(1, 3))
}

func TestSumBitPrefixSum(t *testing.T) {
	f := NewSumBit(4)
	arr := []int{5, 1, 7, 3}
	f.Build(arr)

	assert.Equal(t, 5, f.PrefixSum(0))
	assert.Equal(t, 6, f.PrefixSum(1))
	assert.Equal(t, 13, f.PrefixSum(2))
	assert.Equal(t, 16, f.PrefixSum(3))
}
