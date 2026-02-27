using System;

using System.Collections.Generic;
using System.Data;


public class Graph

{

    // total number of vertices

    private int V;


    // total number of edges added so far

    private int E;


    // adj[v] = list of v's neighbors

    private List<int>[] adj;


    // Constructor: create V vertices, zero edges

    public Graph(int V)

    {

        this.V = V;

        this.E = 0;

        adj = new List<int>[V];

        for (int i = 0; i < V; i++)

        {

            adj[i] = new List<int>();

        }

    }


    // Add undirected edge {u, v}

    public void AddEdge(int u, int v)

    {

        adj[u].Add(v); // v appears in u's neighbor list

        adj[v].Add(u); // u appears in v's neighbor list (undirected)

        E++;

    }


    // Return neighbors of v

    public IEnumerable<int> Neighbors(int v)

    {

        return adj[v]; // O(degree(v)) iteration

    }


    public int NumVertices()

    {

        return V;

    }


    public int NumEdges()

    {

        return E;

    }
    public void BFS(int s)
    {
        Queue<int> Q = new Queue<int>();
        bool[] marked = new bool[V];
        int[] edgeTo = new int[V];
        Array.Fill(edgeTo, -1);
        int[] distTo = new int[V];
        Array.Fill(distTo, -1);

        marked[s] = true;
        distTo[s] = 0;
        Q.Enqueue(s);
        while(Q.Count > 0)
        {
            int v = Q.Dequeue();
            int[] n = Neighbors(v).ToArray();
            foreach(int w in n)
            {
                if (!marked[w])
                {
                    marked[w] = true;
                    edgeTo[w] = v;
                    distTo[w] = distTo[v] + 1;
                    Q.Enqueue(w);
                }
            }
        }

    }
    public void DFS(int s)
    {
        //
    }

}


public class Program

{

    public static void Main()

    {

        Graph G = new Graph(4);

        G.AddEdge(0, 1);  // adj[0]={1}   adj[1]={0}

        G.AddEdge(0, 2);  // adj[0]={1,2}  adj[2]={0}

        G.AddEdge(1, 2);  // adj[1]={0,2}  adj[2]={0,1}

        G.AddEdge(1, 3);  // adj[1]={0,2,3} adj[3]={1}

        G.AddEdge(2, 3);  // adj[2]={0,1,3} adj[3]={1,2}


        G.BFS(0);

    }

}