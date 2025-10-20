package numbers

import (
	"testing"

	"github.com/stretchr/testify/assert"
)

func Test_getPrimes(t *testing.T) {
	assert.Equal(t, []int{2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97}, getPrimes(100))
	assert.Equal(t, []int{}, getPrimes(1))
	assert.Equal(t, []int{}, getPrimes(2))
	assert.Equal(t, []int{2}, getPrimes(3))
	assert.Equal(t, []int{2, 3}, getPrimes(4))
}

func Test_getPrimeDivisors(t *testing.T) {
	assert.Equal(t, []int{}, getPrimeDivisors(1))
	assert.Equal(t, []int{2}, getPrimeDivisors(2))
	assert.Equal(t, []int{3}, getPrimeDivisors(3))
	assert.Equal(t, []int{2}, getPrimeDivisors(4))
	assert.Equal(t, []int{2, 3, 5, 7, 11}, getPrimeDivisors(2*2*3*3*5*5*5*7*11))
	assert.Equal(t, []int{3, 37}, getPrimeDivisors(111))
	assert.Equal(t, []int{101}, getPrimeDivisors(101))
}
