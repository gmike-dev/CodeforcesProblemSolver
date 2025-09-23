package main

import (
	"bytes"
	"strings"
	"testing"

	"github.com/stretchr/testify/assert"
)

func Test1(t *testing.T) {
	check(t, "", "")
}

func check(t *testing.T, input string, expected string) {
	reader := strings.NewReader(input)
	var buf bytes.Buffer
	s := newSolver(reader, &buf)
	s.solve()
	actual := strings.TrimSpace(buf.String())
	expected = strings.TrimRight(expected, " \r\n")
	assert.Equal(t, expected, actual)
}
