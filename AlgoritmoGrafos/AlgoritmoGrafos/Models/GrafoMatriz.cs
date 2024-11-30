namespace AlgoritmoGrafos.Models;

public class GrafoMatriz
{
    private int[,] matrizAdjacencia;
    private int quantidadeVertices;

    public GrafoMatriz()
    {
        quantidadeVertices = 0;
        matrizAdjacencia = new int[0, 0];
    }

    public void AdicionarVertice()
    {
        quantidadeVertices++;
        var novaMatriz = new int[quantidadeVertices, quantidadeVertices];
        for (int i = 0; i < quantidadeVertices - 1; i++)
            for (int j = 0; j < quantidadeVertices - 1; j++)
                novaMatriz[i, j] = matrizAdjacencia[i, j];

        matrizAdjacencia = novaMatriz;
    }

    public void AdicionarAresta(int origem, int destino, int peso = 1)
    {
        if (origem < quantidadeVertices && destino < quantidadeVertices)
            matrizAdjacencia[origem, destino] = peso;
        else
            Console.WriteLine("Erro: Um ou ambos os vértices não existem.");
    }

    public void ExibirMatriz()
    {
        Console.WriteLine("\nMatriz de Adjacência:");
        for (int i = 0; i < quantidadeVertices; i++)
        {
            for (int j = 0; j < quantidadeVertices; j++)
            {
                Console.Write(matrizAdjacencia[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
