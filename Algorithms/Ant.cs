using AlgorithmsOnGraphs.GraghClasses;

namespace AlgorithmsOnGraphs.Algorithms;

public class Ant(Vertex start)
{
    private readonly Vertex Start = start;
    private List<Vertex> Visited = [];
    private List<Edge> Edges = [];
    private int WayWeight = 0;
    private readonly Random Random = new ();
    public bool IsMoving = true;

    public void ChooseVertex(Dictionary<Edge, double> pheromones, double alpha, double beta)
    {
        if (Visited.Count == 0)
        {
            Visited.Add(Start);
        }

        var all_edges = Visited[^1].Edges;
        
        var NoVis = Visited.SelectMany(v => all_edges.Where(e => e.To.Name != v.Name));
        var edges = NoVis.Where(e => NoVis.Count(ed => ed == e) == Visited.Count).Distinct().ToList();


        if (edges.Count == 0)
        {
            IsMoving = false;
            var way_to_start = all_edges.FirstOrDefault(x => x.To.Name == Start.Name);

            if (way_to_start is not null)
            {
                WayWeight += way_to_start.Weight;
                Visited.Add(way_to_start.To);
            }

            return;
        }

        List<double> possibility = [];

        double all_possibility = 0;

        foreach (var edge in edges)
        {
            double pher = 0.00001;

            if (pheromones.ContainsKey(edge))
            {
                pher = pheromones[edge];
            }
            
            var p = Math.Pow(pher, alpha) * Math.Pow(edge.Weight, beta);
            possibility.Add(p);
            all_possibility += p;
        }

        for (int index = 0; index < possibility.Count; index++)
        {
            possibility[index] = possibility[index] / all_possibility;
            if (index > 0)
            {
                possibility[index] += possibility[index - 1];
            }
        }

        double rand_value = Random.NextDouble();

        int selected_index = possibility.Count - 1;

        while (rand_value > possibility[selected_index])
        {
            selected_index--;
        }

        var select_edge = edges[selected_index];

        Edges.Add(select_edge);
        WayWeight += select_edge.Weight;
        Visited.Add(select_edge.To);
    }

    public AntPath GetPath() => new (WayWeight, Visited, Edges);
}

public record AntPath(int Weight, List<Vertex> Vertices, List<Edge> Edges);