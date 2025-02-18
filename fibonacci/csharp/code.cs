public static class Code
{
    public static int Fibonacci(int n)
    {
        return n switch
        {
            <= 1 => n,
            _ => Fibonacci(n - 1) + Fibonacci(n - 2)
        };
    }
}
