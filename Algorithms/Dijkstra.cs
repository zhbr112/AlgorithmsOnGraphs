using AlgorithmsOnGraphs.GraghClasses;

namespace AlgorithmsOnGraphs.Algorithms;

public class Dijkstra
{
    public static Dictionary<Vertex, int> Algorithm(Graph graph, Vertex source)
    {
        var distances = graph.Vertices.ToDictionary(v => v, v => int.MaxValue);
        var previous = new Dictionary<Vertex, Vertex>();
        var notVisited = new HashSet<Vertex>(graph.Vertices);

        distances[source] = 0;

        while (notVisited.Any())
        {
            var nearestVertex = notVisited.OrderBy(v => distances[v]).FirstOrDefault();
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