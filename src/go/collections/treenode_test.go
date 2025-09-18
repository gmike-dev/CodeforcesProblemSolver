package collections

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestTreeToStr(t *testing.T) {
	assert.Equal(t, "", TreeToStr(nil))
	assert.Equal(t, "1", TreeToStr(&TreeNode{Val: 1}))
	assert.Equal(t, "1,2", TreeToStr(&TreeNode{Val: 1, Left: &TreeNode{Val: 2}}))
	assert.Equal(t, "1,null,2", TreeToStr(&TreeNode{Val: 1, Right: &TreeNode{Val: 2}}))
	assert.Equal(t, "2,1,3,null,null,0,1", TreeToStr(
		&TreeNode{
			Val: 2,
			Left: &TreeNode{
				Val: 1,
			},
			Right: &TreeNode{
				Val: 3,
				Left: &TreeNode{
					Val: 0,
				},
				Right: &TreeNode{
					Val: 1,
				},
			}}))
}

func TestStrToTree(t *testing.T) {
	assert.Equal(t, (*TreeNode)(nil), StrToTree(""))
	assert.Equal(t, &TreeNode{Val: 1}, StrToTree("1"))
	assert.Equal(t, &TreeNode{Val: 1, Left: &TreeNode{Val: 2}}, StrToTree("1,2"))
	assert.Equal(t, &TreeNode{Val: 1, Right: &TreeNode{Val: 2}}, StrToTree("1,null,2"))
	assert.Equal(t, &TreeNode{
		Val: 2,
		Left: &TreeNode{
			Val: 1,
		},
		Right: &TreeNode{
			Val: 3,
			Left: &TreeNode{
				Val: 0,
			},
			Right: &TreeNode{
				Val: 1,
			},
		}}, StrToTree("2,1,3,null,null,0,1"))
}
