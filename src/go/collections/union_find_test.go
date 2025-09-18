package collections

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func TestUnionFind_Connected(t *testing.T) {
	uf := NewUnionFind(3)

	assert.True(t, uf.Connected(0, 0), "Element should be connected to itself")
	assert.False(t, uf.Connected(0, 1), "Unconnected elements should return false")

	uf.Union(0, 1)
	assert.True(t, uf.Connected(0, 1), "Connected elements should return true")
	assert.False(t, uf.Connected(0, 2), "Unconnected elements should return false")
}

func TestUnionFind_Find(t *testing.T) {
	uf := NewUnionFind(5)

	for i := 0; i < 5; i++ {
		assert.Equal(t, i, uf.Find(i), "Find should return the element itself initially")
	}

	uf.parent[1] = 0
	uf.parent[2] = 1
	uf.parent[3] = 2

	assert.Equal(t, 0, uf.Find(3), "Find should return the root")
	assert.Equal(t, 1, uf.parent[3], "Find should perform path compression")
	assert.Equal(t, 1, uf.parent[2], "Find should perform path compression")
}

func TestUnionFind_Union(t *testing.T) {
	uf := NewUnionFind(5)

	// Union 0 and 1
	uf.Union(0, 1)
	assert.Equal(t, uf.Find(0), uf.Find(1), "0 and 1 should be in the same set")
	assert.True(t, uf.Connected(0, 1), "0 and 1 should be connected")

	// Union 2 and 3
	uf.Union(2, 3)
	assert.Equal(t, uf.Find(2), uf.Find(3), "2 and 3 should be in the same set")
	assert.False(t, uf.Connected(1, 2), "1 and 2 should not be connected yet")

	// Union 1 and 2 (should merge both sets)
	uf.Union(1, 2)
	assert.Equal(t, uf.Find(0), uf.Find(3), "0 and 3 should now be in the same set")
	assert.True(t, uf.Connected(0, 3), "0 and 3 should now be connected")

	// Union already connected elements
	uf.Union(0, 3)
	assert.Equal(t, uf.Find(0), uf.Find(3), "Repeated union should not change anything")
}
