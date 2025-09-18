package collections

import (
	"math"
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestBuildMaxHeap1(t *testing.T) {
	heap := []int{1, 2, 3}
	BuildMaxHeap(heap)
	assert.Equal(t, []int{3, 2, 1}, heap)
}

func TestBuildMaxHeap2(t *testing.T) {
	heap := []int{4, 1, 2, 3, 65, 7, 2, 3, 1, 2, 3, 6, -1, 23, 0, 0, -13}
	BuildMaxHeap(heap)
	assert.Equal(t, []int{65, 4, 23, 3, 3, 7, 2, 3, 1, 2, 1, 6, -1, 2, 0, 0, -13}, heap)
}

func TestBuildMinHeap1(t *testing.T) {
	heap := []int{1, 2, 3}
	BuildMinHeap(heap)
	assert.Equal(t, []int{1, 2, 3}, heap)
}

func TestBuildMinHeap2(t *testing.T) {
	heap := []int{4, 1, 2, 3, 65, 7, 2, 3, 1, 2, 3, 6, -1, 23, 0, 0, -13}
	BuildMinHeap(heap)
	assert.Equal(t, []int{-13, 0, -1, 1, 2, 2, 0, 3, 1, 65, 3, 6, 7, 23, 2, 4, 3}, heap)
}

func TestPopMax(t *testing.T) {
	heap := []int{4, 1, 2, 3, 65, 7, 2, 3, 1, 2, 3, 6, -1, 23, 0, 0, -13}
	BuildMaxHeap(heap)

	n := len(heap)
	for i := 0; i < n; i++ {
		var actual, expected int
		expected = getMax(heap)
		actual, heap = PopMax(heap)
		assert.Equal(t, expected, actual)
	}
}

func TestPopMin(t *testing.T) {
	heap := []int{4, 1, 2, 3, 65, 7, 2, 3, 1, 2, 3, 6, -1, 23, 0, 0, -13}
	BuildMinHeap(heap)

	n := len(heap)
	for i := 0; i < n; i++ {
		var actual, expected int
		expected = getMin(heap)
		actual, heap = PopMin(heap)
		assert.Equal(t, expected, actual)
	}
}

func getMax(a []int) int {
	result := math.MinInt
	for _, val := range a {
		result = max(result, val)
	}
	return result
}

func getMin(a []int) int {
	result := math.MaxInt
	for _, val := range a {
		result = min(result, val)
	}
	return result
}
