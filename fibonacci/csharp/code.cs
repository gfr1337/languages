public static class Code
{
    public static int Fibonacci(int n) =>
        n <= 1 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
}
