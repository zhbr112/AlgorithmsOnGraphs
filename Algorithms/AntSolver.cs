using AlgorithmsOnGraphs.GraghClasses;

namespace AlgorithmsOnGraphs.Algorithms;

public class AntSolver(Graph graph, double alpha = 1.0, double beta = 1.0, double p = 0.5)
{
    private Graph Graph = graph;
    private double Alpha = alpha;
    private double Beta = beta;
    private double P = p;
    private List<Ant> Colony = [];
    private Dictionary<Edge, double> Pheromones = [];

    public AntPath Algorithm()
    {
        var moves_without_change = 100;
        var vertices_count = Graph.Vertices.Count + 1;
        var cur_move = 0;
        var ret = new AntPath(int.MaxValue, [], []);

        while (cur_move != moves_without_change)
        {
            foreach (var node in Graph.Vertices)
            {
                Colony.Add(new Ant(node));
            }

            cur_move++;

            foreach (var ant in Colony)
            {
                while (ant.IsMoving)
                {
                    ant.ChooseVertex(Graph, Pheromones, Alpha, Beta);
                }

                var path = ant.GetPath();

                if (path.Vertices.Count == vertices_count)
                {
                    if (path.Weight < ret.Weight)
                    {
                        ret = path;
                        cur_move = 0;
                    }

                    foreach (var edge in path.Edges)
                    {
                        if (!Pheromones.ContainsKey(edge))
                        {
                            Pheromones.Add(edge, 0.00001);
                        }
                        Pheromones[edge] = (1 - P) * Pheromones[edge] + 1 / edge.Weight;
                    }
                }
            }
        }
        
        return ret;
    }
}