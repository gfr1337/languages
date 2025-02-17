using System;

public static class Code
{
    public static int Loops(int u)
    {
        var r = Random.Shared.Next(10_000);

        //Use span instead of array
        Span<int> a = stackalloc int[10_000];

        //using a.Length instead of 10_000 constant should give the compiler better optimization hints
        for (var i = 0; i < a.Length; i++)
        {
            for (var j = 0; j < 10_000; j++)
            {
                a[i] += j % u;
            }

            a[i] += r;
        }

        return a[r];
    }
}
