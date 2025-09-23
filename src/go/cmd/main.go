package main

import (
	"bufio"
	"fmt"
	"io"
	"os"
)

func (s *solver) solveCase() {
}

func (s *solver) solve() {
	var t int
	for s.scanln(&t); t > 0; t-- {
		s.solveCase()
	}
}

func (s *solver) write(a ...any) {
	fmt.Fprint(s.output, a...)
}

func (s *solver) writeln(a ...any) {
	fmt.Fprintln(s.output, a...)
}

func (s *solver) scan(a ...any) {
	fmt.Fscan(s.input, a...)
}

func (s *solver) scanln(a ...any) {
	fmt.Fscanln(s.input, a...)
}

func (s *solver) readInt() int {
	var a int
	fmt.Fscan(s.input, &a)
	return a
}

func (s *solver) read2Int() (int, int) {
	var a, b int
	fmt.Fscan(s.input, &a, &b)
	return a, b
}

func (s *solver) read3Int() (int, int, int) {
	var a, b, c int
	fmt.Fscan(s.input, &a, &b, &c)
	return a, b, c
}

type solver struct {
	input  io.Reader
	output io.Writer
}

func newSolver(input io.Reader, output io.Writer) *solver {
	return &solver{
		input:  input,
		output: output,
	}
}

func main() {
	input := bufio.NewReader(os.Stdin)
	output := bufio.NewWriter(os.Stdout)
	defer output.Flush()

	s := newSolver(input, output)
	s.solve()
}
