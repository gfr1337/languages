using System.Diagnostics;

public static class Benchmark<T>
{
    public static BenchmarkResult<T>? Run(Func<T> func, int runMs)
    {
        if (runMs == 0)
        {
            return null;
        }

        if (runMs > 1)
        {
            Console.Error.Write('.');
        }

        var runNs = runMs * 1_000_000L;
        var totalElapsed = 0L;

        var elapsedTime = new List<long>();
        T lastResult = default!;

        var lastTime = Stopwatch.GetTimestamp();

        while (totalElapsed < runNs)
        {
            var startTime = Stopwatch.GetTimestamp();
            lastResult = func();
            var endTime = Stopwatch.GetTimestamp();

            var elapsed = endTime - startTime;
            totalElapsed += elapsed;
            elapsedTime.Add(elapsed);

            if (runMs > 1 && (startTime - lastTime) > Stopwatch.Frequency)
            {
                lastTime = endTime;
                Console.Error.Write('.');
            }
        }

        if (runMs > 1)
        {
            Console.Error.WriteLine();
        }

        var meanTicks = elapsedTime.Average();
        var variance = elapsedTime.Select(x => Math.Pow(x - meanTicks, 2)).Average();
        var stdDevTicks = Math.Sqrt(variance);
        double minTicks = elapsedTime.Min();
        double maxTicks = elapsedTime.Max();

        var ticksToMs = 1000D / Stopwatch.Frequency;

        return new BenchmarkResult<T>(
            meanTicks * ticksToMs,
            stdDevTicks * ticksToMs,
            minTicks * ticksToMs,
            maxTicks * ticksToMs,
            elapsedTime.Count,
            lastResult);
    }
}


public record BenchmarkResult<T>(
    double MeanMs,
    double StdDevMs,
    double MinMs,
    double MaxMs,
    int Runs,
    T Result)
{
    public override string ToString()
    {
        return $"{MeanMs:F6},{StdDevMs:F6},{MinMs:F6},{MaxMs:F6},{Runs},{Result}";
    }
};
