package collections

import "cmp"

func compareMax[T cmp.Ordered](x, y T) int {
	return cmp.Compare(x, y)
}

func compareMin[T cmp.Ordered](x, y T) int {
	return -cmp.Compare(x, y)
}

func BuildMaxHeap[T cmp.Ordered](a []T) {
	n := len(a)
	for i := n/2 - 1; i >= 0; i-- {
		PushDown(a, i, compareMax[T])
	}
}

func BuildMinHeap[T cmp.Ordered](a []T) {
	n := len(a)
	for i := n/2 - 1; i >= 0; i-- {
		PushDown(a, i, compareMin[T])
	}
}

func PopMax[T cmp.Ordered](a []T) (T, []T) {
	n := len(a)
	result := a[0]
	a[0], a[n-1] = a[n-1], a[0]
	a = a[:len(a)-1]
	PushDown(a, 0, compareMax[T])
	return result, a
}

func PopMin[T cmp.Ordered](a []T) (T, []T) {
	n := len(a)
	result := a[0]
	a[0], a[n-1] = a[n-1], a[0]
	a = a[:len(a)-1]
	PushDown(a, 0, compareMin[T])
	return result, a
}

func PushDown[T cmp.Ordered](a []T, i int, cmp func(T, T) int) {
	n := len(a)
	for {
		largest := i
		l := 2*i + 1
		r := l + 1
		if l < n && cmp(a[l], a[largest]) > 0 {
			largest = l
		}
		if r < n && cmp(a[r], a[largest]) > 0 {
			largest = r
		}
		if largest == i {
			break
		}
		a[largest], a[i] = a[i], a[largest]
		i = largest
	}
}
