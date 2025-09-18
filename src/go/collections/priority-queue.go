package collections

type Item struct {
	value    int
	priority int
}

type PriorityQueue []*Item

func (pq *PriorityQueue) Len() int { return len(*pq) }

func (pq *PriorityQueue) Less(i, j int) bool { return (*pq)[i].priority > (*pq)[j].priority }

func (pq *PriorityQueue) Swap(i, j int) { (*pq)[i], (*pq)[j] = (*pq)[j], (*pq)[i] }

func (pq *PriorityQueue) Push(x any) { *pq = append(*pq, x.(*Item)) }

func (pq *PriorityQueue) Pop() any {
	q := *pq
	n := len(q)
	item := q[n-1]
	q[n-1] = nil
	*pq = q[0 : n-1]
	return item
}
