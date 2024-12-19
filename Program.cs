using AlgorithmsOnGraphs.GraghClasses;
using AlgorithmsOnGraphs.Algorithms;

static void DijkstraTest()
{
    var graph = new Graph();

    graph.Vertices.AddRange([new Vertex("1"),new Vertex("2"),new Vertex("3"),new Vertex("4"),
        new Vertex("5"),new Vertex("6"),new Vertex("7"),new Vertex("8"),new Vertex("9")]);

    graph.AddEdge("1", "2", 10);
    graph.AddEdge("1", "3", 6);
    graph.AddEdge("1", "4", 8);

    graph.AddEdge("2", "4", 5);
    graph.AddEdge("2", "6", 11);

    graph.AddEdge("3", "5", 3);

    graph.AddEdge("4", "3", 2);
    graph.AddEdge("4", "5", 5);
    graph.AddEdge("4", "6", 7);
    graph.AddEdge("4", "7", 12);

    graph.AddEdge("5", "6", 9);
    graph.AddEdge("5", "9", 12);

    graph.AddEdge("6", "8", 8);
    graph.AddEdge("6", "9", 10);

    graph.AddEdge("7", "6", 4);
    graph.AddEdge("7", "8", 6);

    graph.AddEdge("8", "9", 15);

    var dijkstra = new Dijkstra(graph);
    var shortestPaths = dijkstra.Algorithm("1");

    foreach (var path in shortestPaths)
    {
        Console.WriteLine($"Shortest path to {path.Key.Name}: {path.Value}");
    }
}

void AntSolverTest()
{
    var gr_tst = new Graph();

    gr_tst.Vertices.AddRange([new Vertex("A"), new Vertex("B"), new Vertex("C"), new Vertex("D"), new Vertex("F"), new Vertex("G")]);

    gr_tst.AddEdge("A", "B", 3);
    gr_tst.AddEdge("A", "F", 1);

    gr_tst.AddEdge("B", "A", 3);
    gr_tst.AddEdge("B", "G", 3);
    gr_tst.AddEdge("B", "C", 8);

    gr_tst.AddEdge("C", "B", 3);
    gr_tst.AddEdge("C", "G", 1);
    gr_tst.AddEdge("C", "D", 1);

    gr_tst.AddEdge("D", "C", 8);
    gr_tst.AddEdge("D", "F", 1);

    gr_tst.AddEdge("F", "A", 3);
    gr_tst.AddEdge("F", "D", 3);

    gr_tst.AddEdge("G", "A", 3);
    gr_tst.AddEdge("G", "B", 3);
    gr_tst.AddEdge("G", "C", 3);
    gr_tst.AddEdge("G", "D", 5);
    gr_tst.AddEdge("G", "F", 4);

    var solver = new AntSolver(gr_tst);

    var path = solver.Algorithm();

    Console.WriteLine($"answer: {path.Weight}");

    foreach (var Vertex in path.Vertices)
    {
        Console.WriteLine(Vertex.Name);
    }
}

void AntSolverFromFile()
{
    var gr_tst = new Graph();

    StreamReader reader = File.OpenText("1000.txt");
    var line = reader.ReadLine();
    line = reader.ReadLine();
    while (line != null)
    {
        var data = line.Split('\t');
        gr_tst.AddEdge(int.Parse(data[0]).ToString(), int.Parse(data[1]).ToString(), int.Parse(data[2]));
        line = reader.ReadLine();
    }
    var solver = new AntSolver(gr_tst);

    var path = solver.Algorithm();

    Console.WriteLine($"answer: {path.Weight}");

    foreach (var Vertex in path.Vertices)
    {
        Console.WriteLine(Vertex.Name);
    }
}

//DijkstraTest();
AntSolverTest();
//AntSolverFromFile();