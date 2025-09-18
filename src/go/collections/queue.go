package collections

type Queue struct {
	queue []any
}

func New() *Queue {
	queue := &Queue{}
	queue.queue = make([]any, 0)

	return queue
}

func (q *Queue) Len() int {
	return len(q.queue)
}

func (q *Queue) IsEmpty() bool {
	return len(q.queue) == 0
}

func (q *Queue) Pop() (item any) {
	item, q.queue = q.queue[0], q.queue[1:]
	return
}

func (q *Queue) Push(item any) {
	q.queue = append(q.queue, item)
}

func (q *Queue) Peek() any {
	return q.queue[0]
}
