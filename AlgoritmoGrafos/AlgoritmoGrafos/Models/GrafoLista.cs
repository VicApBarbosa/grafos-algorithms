﻿namespace AlgoritmoGrafos.Models;

public class GrafoLista
{
    private Dictionary<int, Vertice> vertices;
    private Dictionary<int, List<Aresta>> listaAdjacencia;

    public GrafoLista()
    {
        vertices = new Dictionary<int, Vertice>();
        listaAdjacencia = new Dictionary<int, List<Aresta>>();
    }

    public void AdicionarVertice(string rotulo = "", int peso = 0)
    {
        int novoVerticeId = vertices.Count;
        var vertice = new Vertice(novoVerticeId, rotulo, peso);
        vertices[novoVerticeId] = vertice;
        listaAdjacencia[novoVerticeId] = new List<Aresta>();
    }

    public void AtualizarVertice(int id, string novoRotulo, int novoPeso)
    {
        if (vertices.ContainsKey(id))
        {
            vertices[id].Rotulo = novoRotulo;
            vertices[id].Peso = novoPeso;
        }
        else
        {
            Console.WriteLine("Erro: Vértice não encontrado.");
        }
    }

    public void AdicionarAresta(int origem, int destino, int peso = 1, string rotulo = "")
    {
        if (listaAdjacencia.ContainsKey(origem) && listaAdjacencia.ContainsKey(destino))
        {
            listaAdjacencia[origem].Add(new Aresta(origem, destino, peso, rotulo));
            listaAdjacencia[destino].Add(new Aresta(destino, origem, peso, rotulo)); // Grafo não direcionado
        }
        else
        {
            Console.WriteLine("Erro: Um ou ambos os vértices não existem.");
        }
    }

    public void AtualizarAresta(int origem, int destino, string novoRotulo, int novoPeso)
    {
        if (listaAdjacencia.ContainsKey(origem))
        {
            foreach (var aresta in listaAdjacencia[origem])
            {
                if (aresta.VerticeDestino == destino)
                {
                    aresta.Rotulo = novoRotulo;
                    aresta.Peso = novoPeso;
                    break;
                }
            }

            foreach (var aresta in listaAdjacencia[destino])
            {
                if (aresta.VerticeDestino == origem) // Aresta reversa
                {
                    aresta.Rotulo = novoRotulo;
                    aresta.Peso = novoPeso;
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("Erro: Aresta não encontrada.");
        }
    }

    public int? ObterIdPorRotulo(string rotulo)
    {
        foreach (var vertice in vertices)
        {
            if (vertice.Value.Rotulo == rotulo)
            {
                return vertice.Key;
            }
        }
        return null;
    }

    public void ExibirLista()
    {
        Console.WriteLine("\nLista de Adjacência:");
        foreach (var vertice in vertices)
        {
            Console.WriteLine($"Vértice {vertice.Key} (Rótulo: {vertice.Value.Rotulo}, Peso: {vertice.Value.Peso})");

            foreach (var aresta in listaAdjacencia[vertice.Key])
            {
                var destino = vertices[aresta.VerticeDestino];
                Console.WriteLine($"  -> Vértice {aresta.VerticeDestino} (Rótulo: {destino.Rotulo}, Peso: {destino.Peso}) - Aresta (Rótulo: {aresta.Rotulo}, Peso: {aresta.Peso})");
            }

            if (listaAdjacencia[vertice.Key].Count == 0)
            {
                Console.WriteLine("  Não possui vizinhos.");
            }
        }
    }
}