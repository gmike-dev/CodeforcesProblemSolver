package numbers

// Integer square root (https://en.wikipedia.org/wiki/Integer_square_root)
func isqrt(x int) int {
	if x < 2 {
		return x
	}
	small := isqrt(x>>2) << 1
	large := small + 1
	if large*large > x {
		return small
	}
	return large
}
