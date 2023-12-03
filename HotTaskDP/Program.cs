// See https://aka.ms/new-console-template for more information
await Main();
async System.Threading.Tasks.Task Main()
{
    var cts = new CancellationTokenSource();

    //hot task call + cancellationToken param
    var task = Task.Run(() => MyProcess(cts.Token));

    Task.Delay(3500).GetAwaiter().GetResult();

    cts.Cancel();

    try
    {
        await task;
    }
    catch (OperationCanceledException)
    {
        Console.WriteLine("Task canceled!");
    }
    catch (Exception)
    {
        Console.WriteLine("Failed!");
    }
    finally
    {
        Console.WriteLine("Try-catch finally");
    }
}

async Task MyProcess(CancellationToken cancellationToken)
{
    int i = 0;
    while (true)
    {
        cancellationToken.ThrowIfCancellationRequested();
        //throw new Exception();
        checked
        {
            Console.WriteLine($"Iteration: {i++}");
        }

        await Task.Delay(500);
    }
}