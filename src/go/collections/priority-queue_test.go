package collections

import (
	"container/heap"
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestPriorityQueue(t *testing.T) {
	q := make(PriorityQueue, 3)
	q[0] = &Item{
		value:    1,
		priority: 1,
	}
	q[1] = &Item{
		value:    3,
		priority: 3,
	}
	q[2] = &Item{
		value:    2,
		priority: 2,
	}
	heap.Init(&q)

	heap.Push(&q, &Item{
		value:    5,
		priority: 5,
	})

	assert.Equal(t, &Item{5, 5}, heap.Pop(&q).(*Item))
	assert.Equal(t, &Item{3, 3}, heap.Pop(&q).(*Item))
	assert.Equal(t, &Item{2, 2}, heap.Pop(&q).(*Item))

	heap.Push(&q, &Item{
		value:    0,
		priority: 0,
	})

	assert.Equal(t, &Item{1, 1}, heap.Pop(&q).(*Item))
	assert.Equal(t, &Item{0, 0}, heap.Pop(&q).(*Item))
	assert.Equal(t, 0, len(q))
}
