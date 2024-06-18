using System.Diagnostics;

// await AwaitSynchronusLoop();

await AwaitAsyncSynchronusLoop();

static async Task AwaitSynchronusLoop()
{
    // See https://aka.ms/new-console-template for more information
    Console.WriteLine("await in inside loops");

    var sw = new Stopwatch();
    sw.Start();

    var delayInMilliSeconds = 1000;
    var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    foreach (var number in numbers)
    {
        Console.WriteLine($"Processing: {number}");
        await Task.Delay(delayInMilliSeconds); // Due to this await call this process makes it in synchronus
        Console.WriteLine($"Processed: {number}");
    }

    sw.Stop();

    Console.WriteLine($"Done Processing in {sw.ElapsedMilliseconds}");
    // Output:
    /*
    await in inside loops
    Processing: 1
    Processed: 1
    Processing: 2
    Processed: 2
    Processing: 3
    Processed: 3
    Processing: 4
    Processed: 4
    Processing: 5
    Processed: 5
    Processing: 6
    Processed: 6
    Processing: 7
    Processed: 7
    Processing: 8
    Processed: 8
    Processing: 9
    Processed: 9
    Processing: 10
    Processed: 10
    Done Processing in 10116
    */
}

static async Task AwaitAsyncSynchronusLoop()
{
    // See https://aka.ms/new-console-template for more information
    Console.WriteLine("await with Task.WhenAll in inside loops");

    var sw = new Stopwatch();
    sw.Start();

    var delayInMilliSeconds = 1000;
    var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    var result = new List<Task>();

    foreach (var number in numbers)
    {
        result.Add(ProcessNumberAsync(number,delayInMilliSeconds));
    }

    await Task.WhenAll(result);
    sw.Stop();

    Console.WriteLine($"Done Processing in {sw.ElapsedMilliseconds}");
    // Output:
    /*await with Task.WhenAll in inside loops
Processing: 1
Processing: 2
Processing: 3
Processing: 4
Processing: 5
Processing: 6
Processing: 7
Processing: 8
Processing: 9
Processing: 10
Processed: 9
Processed: 8
Processed: 3
Processed: 7
Processed: 4
Processed: 6
Processed: 5
Processed: 1
Processed: 2
Done Processing in 1010
PS D:\Git Repos\csharp_small_demos> dotnet run
await with Task.WhenAll in inside loops
Processing: 1
Processing: 2
Processing: 3
Processing: 4
Processing: 5
Processing: 6
Processing: 7
Processing: 8
Processing: 9
Processing: 10
Processed: 9
Processed: 10
Processed: 8
Processed: 4
Processed: 5
Processed: 6
Processed: 7
Processed: 2
Processed: 1
Processed: 3
Done Processing in 1019
    */
}

static async Task ProcessNumberAsync(int number, int delayInMilliSeconds){
        Console.WriteLine($"Processing: {number}");
        await Task.Delay(delayInMilliSeconds); // Due to this await call this process makes it in synchronus
        Console.WriteLine($"Processed: {number}");
}