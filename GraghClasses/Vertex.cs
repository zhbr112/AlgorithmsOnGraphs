namespace AlgorithmsOnGraphs.GraghClasses;

public class Vertex
{
    public string Name { get; set; }=string.Empty;
    public List<Edge> Edges { get; set; }=[];

    public void AddEdge(Vertex to, int weight)
    {
        Edges.Add(new Edge(this, to, weight));
    }

    public Vertex(string name)
    {
        Name = name;
        Edges = new List<Edge>();
    }

    public Vertex(){}
}
