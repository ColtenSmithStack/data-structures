using System;

using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Timers;


namespace Algorithms

{

  // Represents a weighted edge between two nodes

  public class Edge

  {

    public int Source { get; set; }

    public int Destination { get; set; }

    public int Weight { get; set; }

  }


  // Disjoint Set Union (DSU) to manage connected components

  public class UnionFind

  {

    private int[] parent;

    private int[] rank;


    public UnionFind(int n)

    {

      parent = new int[n];

      rank = new int[n];

      for (int i = 0; i < n; i++)

      {

        parent[i] = i;

        rank[i] = 0;

      }

    }


    // Find the root of the component containing 'i' (with path compression)

    public int Find(int i)

    {

      if (parent[i] == i)

        return i;

       

      return parent[i] = Find(parent[i]); 

    }


    // Merge two components (using union by rank)

    public void Unite(int i, int j)

    {

      int rootI = Find(i);

      int rootJ = Find(j);


      if (rootI != rootJ)

      {

        if (rank[rootI] < rank[rootJ])

        {

          parent[rootI] = rootJ;

        }

        else if (rank[rootI] > rank[rootJ])

        {

          parent[rootJ] = rootI;

        }

        else

        {

          parent[rootI] = rootJ;

          rank[rootJ]++;

        }

      }

    }

  }


  public class KruskalAlgorithm

  {

    public static List<Edge> GetMST(int vertexCount, List<Edge> edges)

    {
        List<Edge> mst = new List<Edge>();

      // Step 1: Sort edges by weight (cheapest first)
       edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));
       
      // Step 2: Process edges in sorted order
        foreach(Edge e in edges)
      {
        //Check if tree is complete
        if (mst.Count >= vertexCount - 1)
        {
          break;
        }

        // ! Check if edge would create a cycle, if so, skip it
        if (true)
        {
          // If not, add it
          mst.Add(e);
        }
      }
      
        return mst;

    }

  }


  class Program

  {

    static void Main()

    {

      int vertices = 4;

      var edges = new List<Edge>

      {

        new Edge { Source = 0, Destination = 1, Weight = 10 },

        new Edge { Source = 0, Destination = 2, Weight = 6 },

        new Edge { Source = 0, Destination = 3, Weight = 5 },

        new Edge { Source = 1, Destination = 3, Weight = 15 },

        new Edge { Source = 2, Destination = 3, Weight = 4 }

      };


      var result = KruskalAlgorithm.GetMST(vertices, edges);


      Console.WriteLine("Edges in the MST:");

      foreach (var e in result)

      {

        Console.WriteLine($"{e.Source} -- {e.Destination} == {e.Weight}");

      }

    }

  }

}