package numbers

import (
	"math"
	"testing"

	"github.com/stretchr/testify/assert"
)

func Test_isqrt(t *testing.T) {
	for x := 0; x < 10000; x++ {
		assert.Equal(t, int(math.Sqrt(float64(x))), isqrt(x))
	}
	assert.Equal(t, int(math.Sqrt(float64(1021004521))), isqrt(1021004521))
}
