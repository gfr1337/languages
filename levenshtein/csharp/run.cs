var runMs = int.Parse(args[0]);
var warmupMs = int.Parse(args[1]);
var inputPath = args[2];

var content = File.ReadAllLines(inputPath);

Benchmark<List<int>>.Run(() => Code.Levenshtein(content), warmupMs);

var result = Benchmark<List<int>>.Run(() => Code.Levenshtein(content), runMs);

var summedResult = new BenchmarkResult<int>(
    result!.MeanMs,
    result.StdDevMs,
    result.MinMs,
    result.MaxMs,
    result.Runs,
    result.Result.Sum());

Console.WriteLine(summedResult);
