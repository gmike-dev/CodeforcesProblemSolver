package collections

import (
	"container/heap"
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestPopPush(t *testing.T) {
	h := &MinHeap{4, 1, 2, 3, 65, 7, 2, 3, 1, 2, 3, 6, -1, 23, 0, 0, -13}
	heap.Init(h)
	assert.Equal(t, -13, heap.Pop(h))
	assert.Equal(t, -1, heap.Pop(h))
	assert.Equal(t, 0, heap.Pop(h))
	assert.Equal(t, 0, heap.Pop(h))
	assert.Equal(t, 1, heap.Pop(h))
	heap.Push(h, -10)
	assert.Equal(t, -10, heap.Pop(h))
	assert.Equal(t, 12, h.Len())
}
