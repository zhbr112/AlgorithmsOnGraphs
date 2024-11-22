namespace AlgorithmsOnGraphs.GraghClasses;

public class Graph
{
    public List<Vertex> Vertices { get; set; }
    public Graph()
    {
        Vertices = new List<Vertex>();
    }

    public void AddEdge(string fromName, string toName, int weight)
    {
        Vertex? from = Vertices.FirstOrDefault(v => v.Name == fromName);

        if (from is null)
        {
            from = new Vertex(fromName);
            Vertices.Add(from);
        }

        Vertex? to = Vertices.FirstOrDefault(v => v.Name == toName);

        if (to is null)
        {
            to = new Vertex(toName);
            Vertices.Add(to);
        }

        from.AddEdge(to, weight);
    }
}
