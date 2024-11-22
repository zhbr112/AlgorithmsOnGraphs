﻿namespace AlgorithmsOnGraphs.GraghClasses;

public class Edge
{
    public Vertex From { get; set; }
    public Vertex To { get; set; }
    public int Weight { get; set; }

    public Edge(Vertex from, Vertex to, int weight)
    {
        From = from;
        To = to;
        Weight = weight;
    }
}
