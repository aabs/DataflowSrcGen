﻿using ActorSrcGen.Abstractions.Playground;

var actor = new MyActor();

try
{
    if (actor.Call(10))
        Console.WriteLine("Called Synchronously");

    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(5));

    var t = Task.Run(async () => await actor.ListenForReceiveDoTask1(cts.Token), cts.Token);

    while (!cts.Token.IsCancellationRequested)
    {
        var result = await actor.AcceptAsync(cts.Token);
        Console.WriteLine($"Result: {result}");
    }

    await actor.SignalAndWaitForCompletionAsync();
}
catch (OperationCanceledException operationCanceledException)
{
    Console.WriteLine("All Done!");
}

