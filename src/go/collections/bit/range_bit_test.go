package bit

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestRangeBit(t *testing.T) {
	bit := NewRangeBit(10)
	bit.Add(0, 1)
	bit.Add(1, 2)
	bit.Add(2, 3)
	bit.Add(3, 4)
	bit.Add(4, 5)
	// [1,2,3,4,5]
	assert.Equal(t, 1, bit.Get(0))
	assert.Equal(t, 2, bit.Get(1))
	assert.Equal(t, 3, bit.Get(2))
	assert.Equal(t, 4, bit.Get(3))
	assert.Equal(t, 5, bit.Get(4))
	bit.RangeAdd(0, 2, 1)
	// [2,3,4,4,5]
	assert.Equal(t, 2, bit.Get(0))
	assert.Equal(t, 3, bit.Get(1))
	assert.Equal(t, 4, bit.Get(2))
	assert.Equal(t, 4, bit.Get(3))
	assert.Equal(t, 5, bit.Get(4))
}
