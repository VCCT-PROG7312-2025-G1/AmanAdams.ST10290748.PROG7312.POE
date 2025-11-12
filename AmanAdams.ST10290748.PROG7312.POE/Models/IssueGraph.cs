using System;
using System.Collections.Generic;


//Aman Adams
//ST10290748
//PROG7312
//POE PART 3

namespace AmanAdams.ST10290748.PROG7312.POE.Models
{
    public class IssueGraph
    {
        // Adjacency list structure for storing graph connections
        private readonly Dictionary<string, List<string>> _adjacencyList = new();

        // Add a vertex (node) to the graph
        public void AddVertex(string requestId)
        {
            if (!_adjacencyList.ContainsKey(requestId))
            {
                _adjacencyList[requestId] = new List<string>();
            }
        }

        // Add an edge (connection) between two nodes
        public void AddEdge(string fromRequestId, string toRequestId)
        {
            if (!_adjacencyList.ContainsKey(fromRequestId))
                AddVertex(fromRequestId);

            if (!_adjacencyList.ContainsKey(toRequestId))
                AddVertex(toRequestId);

            if (!_adjacencyList[fromRequestId].Contains(toRequestId))
                _adjacencyList[fromRequestId].Add(toRequestId);

            // Optional: make it bidirectional
            if (!_adjacencyList[toRequestId].Contains(fromRequestId))
                _adjacencyList[toRequestId].Add(fromRequestId);
        }

        // Return the entire adjacency list
        public Dictionary<string, List<string>> GetAdjacencyList()
        {
            return _adjacencyList;
        }

        // Optional: For debugging,print graph to console
        public void PrintGraph()
        {
            foreach (var kvp in _adjacencyList)
            {
                Console.WriteLine($"{kvp.Key} → {string.Join(", ", kvp.Value)}");
            }
        }
    }
}

//-------------------------------------------------------------END OF FILE-----------------------------------------------------------------//
