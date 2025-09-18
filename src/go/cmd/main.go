package main

import (
	"bufio"
	"fmt"
	"os"
)

var (
	reader = bufio.NewReader(os.Stdin)
	writer = bufio.NewWriter(os.Stdout)
)

func solveCase() {

}

func solve() {
	var t int
	for fmt.Fscan(reader, &t); t >= 0; t-- {
		solveCase()
	}
}

func main() {
	defer writer.Flush()

	solve()
}
