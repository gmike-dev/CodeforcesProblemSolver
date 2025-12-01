package bit

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestMaxBit(t *testing.T) {
	f := NewMaxBit(5)
	arr := []int{1, 2, 5, 3, 4}
	f.Build(arr)

	assert.Equal(t, 1, f.PrefixMax(0))
	assert.Equal(t, 2, f.PrefixMax(1))
	assert.Equal(t, 5, f.PrefixMax(2))
	assert.Equal(t, 5, f.PrefixMax(3))
	assert.Equal(t, 5, f.PrefixMax(4))
}

func TestMaxBitUpdate(t *testing.T) {
	f := NewMaxBit(5)
	arr := []int{1, 2, 3, 4, 5}
	f.Build(arr)

	f.Update(2, 10)

	assert.Equal(t, 1, f.PrefixMax(0))
	assert.Equal(t, 2, f.PrefixMax(1))
	assert.Equal(t, 10, f.PrefixMax(2))
	assert.Equal(t, 10, f.PrefixMax(4))
}
