using AlgorithmsOnGraphs.GraghClasses;

namespace AlgorithmsOnGraphs.Algorithms;

public class Dijkstra(Graph graph)
{
    private Graph Graph = graph;

    public Dictionary<Vertex, int> Algorithm(string sourceName)
    {
        var source = Graph.Vertices.FirstOrDefault(v => v.Name == sourceName);

        if (source is null) throw new Exception("Такой вершины не существует");

        var distances = Graph.Vertices.ToDictionary(v => v, v => int.MaxValue);
        var previous = new Dictionary<Vertex, Vertex>();
        var notVisited = new HashSet<Vertex>(Graph.Vertices);

        distances[source] = 0;

        while (notVisited.Any())
        {
            var nearestVertex = notVisited.OrderBy(v => distances[v]).First();
            notVisited.Remove(nearestVertex);

            foreach (var edge in nearestVertex.Edges)
            {
                var neighbor = edge.To;
                if (notVisited.Contains(neighbor))
                {
                    var currentDistance = distances[nearestVertex] + edge.Weight;
                    if (currentDistance < distances[neighbor])
                    {
                        distances[neighbor] = currentDistance;
                        previous[neighbor] = nearestVertex;
                    }
                }
            }
        }

        return distances;
    }
}