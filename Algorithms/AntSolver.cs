using AlgorithmsOnGraphs.GraghClasses;
using System.Text;

namespace AlgorithmsOnGraphs.Algorithms;

public class AntSolver(Graph graph, double alpha = 1.0, double beta = 1.0, double p = 0.5)
{
    private Graph Graph = graph;
    private double Alpha = alpha;
    private double Beta = beta;
    private double P = p;
    private List<Ant> Colony = [];
    private Dictionary<Edge, double> Pheromones = [];

    void AddColony()
    {

    }
    public AntPath Algorithm()
    {
        var w=new StringBuilder();
        var moves_without_change = 20;
        var vertices_count = Graph.Vertices.Count + 1;
        var cur_move = 0;
        var ret = new AntPath(int.MaxValue, [], []);

        foreach (var i in Graph.Vertices)
        {
            foreach (var j in i.Edges)
            {
                if (!Pheromones.ContainsKey(j))
                {
                    Pheromones.Add(j, 0.1);
                }
            }
        }

        while (cur_move++ != moves_without_change)
        {
            Colony.Clear();
            Colony.AddRange(Graph.Vertices.Select(x => new Ant(x)));

            foreach (var ant in Colony)
            {
                while (ant.IsMoving)
                {
                    ant.ChooseVertex(Pheromones);
                }

                var path = ant.GetPath();

                if (path.Vertices.Count == vertices_count)
                {
                    Console.WriteLine($"{cur_move} {path.Weight}");
                    w.Append(path.Weight.ToString()+"\n");
                    if (path.Weight < ret.Weight)
                    {
                        ret = path;
                        cur_move = 0;
                    }
                }
            }
            UpdatePheromones();
        }
        File.AppendAllText("q.txt",w.ToString());
        return ret;
    }

    private void UpdatePheromones()
    {
        foreach (var i in Pheromones)
        {
            Pheromones[i.Key] = i.Value * (1 - P);
        }

        foreach (var ant in Colony)
        {
            if (ant.GetPath().Vertices.Count() == Graph.Vertices.Count() + 1)
            {
                double pheromoneDeposit = 10.0 / ant.GetPath().Edges.Sum(x => x.Weight);
                foreach (var edge in ant.GetPath().Edges)
                {
                    if (!Pheromones.ContainsKey(edge))
                    {
                        Pheromones.Add(edge, 0.00001);
                    }
                    Pheromones[edge] += pheromoneDeposit;
                }
            }
        }
    }
}