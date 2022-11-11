// See https://aka.ms/new-console-template for more information
using mitoSoft.Workflows.AdvancedStateMachines;
using mitoSoft.Workflows;

Console.WriteLine("Hello, World!");

new BuildableStateMachine()
    .AddNode(new State("Start", () => Console.WriteLine("Start")))
    .AddEdge("Start", "Middle")
    .AddNode(new State("Middle", () => Console.WriteLine("Middle")))
    .AddEdge("Middle", "End")
    .AddNode(new State("End", () => Console.WriteLine("End")))
    .Build()
    .Invoke();

Console.WriteLine("Next");

new TransitionalStateMachine()
    .AddNode(new State("Start", () => Console.WriteLine("Start")))
    .AddEdge("Start", "Middle")
    .AddNode(new State("Middle", () => Console.WriteLine("Middle")))
    .AddEdge("Middle", "End")
    .AddNode(new State("End", () => Console.WriteLine("End")))
    .Build()
    .Invoke();

Console.WriteLine("Next");

new TransitionalStateMachine()
    .AddNode(new State("Start", () => Console.WriteLine("Start")))
    .AddEdge("Start", "T1")
    .AddTransition("T1", (sender, transition) =>
    {
        int _i = 0;
        transition.Action = () =>
        {
            _i = (new Random(DateTime.Now.Second)).Next(0, 2);
            Console.WriteLine($"It should got to path {_i + 1}");
        };
        transition.AddCondition(() => { return _i == 0; }, "Path1");
        transition.AddCondition(() => { return _i == 1; }, "Path2");
    })
    .AddNode(new State("Path1", () => Console.WriteLine("Path1")))
    .AddEdge("Path1", "Path1End", () => { return true; })
    .AddNode(new State("Path1End"))
    .AddNode(new State("Path2", () => Console.WriteLine("Path2")))
    .AddEdge("Path2", "Path2End")
    .AddNode(new State("Path2End"))
    .Build()
    .Invoke();

Console.WriteLine("Next");

Console.WriteLine("Done");