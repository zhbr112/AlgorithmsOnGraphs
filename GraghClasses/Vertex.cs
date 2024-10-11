namespace AlgorithmsOnGraphs.GraghClasses;

public class Vertex
{
    public string Name { get; }
    public List<Edge> Edges { get; }

    public void AddEdges(Vertex to, int weight)
    {
        Edges.Add(new Edge(this, to, weight));
    }

    public Vertex(string name)
    {
        Name = name;
        Edges = new List<Edge>();
    }
}
