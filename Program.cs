using AlgorithmsOnGraphs.GraghClasses;
using AlgorithmsOnGraphs.Algorithms;

var graph = new Graph();

var vertex1 = new Vertex("1");
var vertex2 = new Vertex("2");
var vertex3 = new Vertex("3");
var vertex4 = new Vertex("4");
var vertex5 = new Vertex("5");
var vertex6 = new Vertex("6");
var vertex7 = new Vertex("7");
var vertex8 = new Vertex("8");
var vertex9 = new Vertex("9");


// Добавление остальных вершин...

graph.Vertices.AddRange([vertex1, vertex2, vertex3, vertex4, vertex5, vertex6, vertex7, vertex8, vertex9]);

vertex1.AddEdges(vertex2, 10);
vertex1.AddEdges(vertex3, 6);
vertex1.AddEdges(vertex4, 8);

vertex2.AddEdges(vertex4, 5);
vertex2.AddEdges(vertex6, 11);

vertex3.AddEdges(vertex5, 3);

vertex4.AddEdges(vertex3, 2);
vertex4.AddEdges(vertex5, 5);
vertex4.AddEdges(vertex6, 7);
vertex4.AddEdges(vertex7, 12);

vertex5.AddEdges(vertex6, 9);
vertex5.AddEdges(vertex9, 12);

vertex6.AddEdges(vertex8, 8);
vertex6.AddEdges(vertex9, 10);

vertex7.AddEdges(vertex6, 4);
vertex7.AddEdges(vertex8, 6);

vertex8.AddEdges(vertex9, 15);

// Добавление остальных ребер...

var shortestPaths = Dijkstra.Algorithm(graph, vertex1);

foreach (var path in shortestPaths)
{
    Console.WriteLine($"Shortest path to {path.Key.Name}: {path.Value}");
}