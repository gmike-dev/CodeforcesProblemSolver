package collections

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestQueue(t *testing.T) {
	q := new(Queue)
	assert.True(t, q.IsEmpty())
	q.Push(1)
	assert.Equal(t, 1, q.Peek())
	assert.False(t, q.IsEmpty())
	q.Push(2)
	assert.Equal(t, 1, q.Peek())
	assert.False(t, q.IsEmpty())
	assert.Equal(t, 1, q.Pop())
	assert.Equal(t, 2, q.Peek())
	assert.Equal(t, 2, q.Pop())
	assert.True(t, q.IsEmpty())
}
