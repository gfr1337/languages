var runMs = int.Parse(args[0]);
var warmupMs = int.Parse(args[1]);
var n = int.Parse(args[2]);

Benchmark<int>.Run(() => Code.Fibonacci(n), warmupMs);

var result = Benchmark<int>.Run(() => Code.Fibonacci(n), runMs);
Console.WriteLine(result);
