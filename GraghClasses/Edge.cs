namespace AlgorithmsOnGraphs.GraghClasses;

public class Edge
{
    public Vertex From { get; }
    public Vertex To { get; }
    public int Weight { get; }

    public Edge(Vertex from, Vertex to, int weight)
    {
        From = from;
        To = to;
        Weight = weight;
    }
}
