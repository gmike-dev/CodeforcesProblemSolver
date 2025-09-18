package collections

type ListNode struct {
	Val  int
	Next *ListNode
}

func ArrayToList(a []int) *ListNode {
	head := &ListNode{}
	node := head
	for _, x := range a {
		node.Next = &ListNode{Val: x}
		node = node.Next
	}
	return head.Next
}

func ListToArray(head *ListNode) []int {
	var result []int
	node := head
	for node != nil {
		result = append(result, node.Val)
		node = node.Next
	}
	return result
}
