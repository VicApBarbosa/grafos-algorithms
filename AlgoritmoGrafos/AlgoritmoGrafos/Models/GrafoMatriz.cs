namespace AlgoritmoGrafos.Models;

public class GrafoMatriz
{
    private int[,] matrizAdjacencia;
    private Vertice[] vertices;
    private string[,] rotulosArestas;
    private int quantidadeVertices;

    public GrafoMatriz()
    {
        quantidadeVertices = 0;
        matrizAdjacencia = new int[0, 0];
        vertices = new Vertice[0];
        rotulosArestas = new string[0, 0];
    }

    public void AdicionarVertice(string rotulo = "", int peso = 0)
    {
        quantidadeVertices++;
        var novaMatriz = new int[quantidadeVertices, quantidadeVertices];
        var novosRotulos = new string[quantidadeVertices, quantidadeVertices];
        var novosVertices = new Vertice[quantidadeVertices];

        // Copiar os dados anteriores
        for (int i = 0; i < quantidadeVertices - 1; i++)
        {
            for (int j = 0; j < quantidadeVertices - 1; j++)
            {
                novaMatriz[i, j] = matrizAdjacencia[i, j];
                novosRotulos[i, j] = rotulosArestas[i, j];
            }
            novosVertices[i] = vertices[i];
        }

        novosVertices[quantidadeVertices - 1] = new Vertice(quantidadeVertices - 1, rotulo, peso);
        matrizAdjacencia = novaMatriz;
        rotulosArestas = novosRotulos;
        vertices = novosVertices;
    }

    public void AdicionarAresta(int origem, int destino, int peso = 1, string rotulo = "")
    {
        if (origem < quantidadeVertices && destino < quantidadeVertices)
        {
            matrizAdjacencia[origem, destino] = peso;
            matrizAdjacencia[destino, origem] = peso; // Grafo não direcionado
            rotulosArestas[origem, destino] = rotulo;
            rotulosArestas[destino, origem] = rotulo; // Grafo não direcionado
        }
        else
        {
            Console.WriteLine("Erro: Um ou ambos os vértices não existem.");
        }
    }

    public int? ObterIdPorRotulo(string rotulo)
    {
        for (int i = 0; i < quantidadeVertices; i++)
        {
            if (vertices[i].Rotulo == rotulo)
            {
                return i;
            }
        }
        return null; 
    }

    public void ExibirMatriz()
    {
        Console.WriteLine("\nMatriz de Adjacência:");
        for (int i = 0; i < quantidadeVertices; i++)
        {
            for (int j = 0; j < quantidadeVertices; j++)
            {
                Console.Write($"{matrizAdjacencia[i, j]}({rotulosArestas[i, j] ?? "-"}) ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nVértices:");
        foreach (var vertice in vertices)
        {
            Console.WriteLine(vertice);
        }
    }
}