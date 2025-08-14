package main
import (
    "fmt"
    "strconv"
    "os"
)

func fibonacci(n int) int {
  if n == 0 { return 0 }
  if n == 1 { return 1 }
  return fibonacci(n-1) + fibonacci(n-2)
}

func main() {
  input, e := strconv.Atoi(os.Args[1])
  if e != nil { panic(e) }
  u := int(input)
  r := 0
  for i := 0; i < u; i++ {
    r += fibonacci(i)
  }
  fmt.Println(r)
}
