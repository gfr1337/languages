public static class Code
{
    public static int Fibonacci(int n) =>
        n < 2 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
}
