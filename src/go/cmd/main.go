package main

import (
	"bufio"
	"fmt"
	"io"
	"os"
)

func (sv *solver) solveCase() {
}

func (sv *solver) solve() {
	for range sv.readInt() {
		sv.solveCase()
	}
}

func (sv *solver) writelnStrArr(a []string) { writeArr(sv, a) }

func (sv *solver) writelnIntArr(a []int) { writeArr(sv, a) }

func (sv *solver) writelnInt64Arr(a []int64) { writeArr(sv, a) }

func (sv *solver) write(a ...any) { fmt.Fprint(sv.output, a...) }

func (sv *solver) writeln(a ...any) { fmt.Fprintln(sv.output, a...) }

func (sv *solver) scan(a ...any) { fmt.Fscan(sv.input, a...) }

func (sv *solver) scanln(a ...any) { fmt.Fscanln(sv.input, a...) }

func (sv *solver) readInt() int {
	var a int
	fmt.Fscan(sv.input, &a)
	return a
}

func (sv *solver) read2Int() (int, int) {
	var a, b int
	fmt.Fscan(sv.input, &a, &b)
	return a, b
}

func (sv *solver) read3Int() (int, int, int) {
	var a, b, c int
	fmt.Fscan(sv.input, &a, &b, &c)
	return a, b, c
}

func (sv *solver) readIntArray(n int) []int {
	res := make([]int, n)
	for i := 0; i < n; i++ {
		sv.scan(&res[i])
	}
	return res
}

func writeArr[T any](s *solver, a []T) {
	for i := range a {
		s.write(a[i])
		s.write(" ")
	}
	s.writeln()
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
