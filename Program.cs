using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> adjList; // Список смежности

    public Graph()
    {
        adjList = new Dictionary<int, List<int>>();
    }

    // Добавление ребра
    public void AddEdge(int v, int w)
    {
        if (!adjList.ContainsKey(v))
        {
            adjList[v] = new List<int>();
        }

        adjList[v].Add(w); // Добавить w в список v
    }
    // Функция, использующаяся рекурсивно DFS
    void DFSUtil(int v, Dictionary<int, bool> visited)
    {
        // Текущий узел будет отмечен как посещенный и будет выведен
        visited[v] = true;
        Console.Write(v + " ");

        // Перебрать всех соседей этого узла
        List<int> vList = adjList.ContainsKey(v) ? adjList[v] : new List<int>();

        foreach (var n in vList)
        {
            if (!visited[n])
            {
                DFSUtil(n, visited);
            }
        }
    }

    // Функция для запуска DFS
    public void DFS(int v)
    {
        // Пометить все вершины как не посещенные
        Dictionary<int, bool> visited = new Dictionary<int, bool>();
        foreach (var item in adjList)
        {
            visited[item.Key] = false;
        }

        // Вызвать рекурсивную вспомогательную функцию для печати DFS обхода
        DFSUtil(v, visited);
    }

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        Graph g = new Graph();

        // Пример графа
        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(2, 0);
        g.AddEdge(2, 3);
        g.AddEdge(3, 3);

        Console.WriteLine("Обход в глубину начиная с вершины 2:");

        g.DFS(2);
    }
}
