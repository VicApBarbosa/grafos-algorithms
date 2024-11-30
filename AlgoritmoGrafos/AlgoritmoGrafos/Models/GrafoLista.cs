namespace AlgoritmoGrafos.Models;

public class GrafoLista
{
    private Dictionary<int, List<Aresta>> listaAdjacencia;

    public GrafoLista()
    {
        listaAdjacencia = new Dictionary<int, List<Aresta>>();
    }

    public void AdicionarVertice()
    {
        int novoVerticeId = listaAdjacencia.Count;
        listaAdjacencia[novoVerticeId] = new List<Aresta>();
    }

    public void AdicionarAresta(int origem, int destino, int peso = 1)
    {
        if (listaAdjacencia.ContainsKey(origem) && listaAdjacencia.ContainsKey(destino))
        {
            listaAdjacencia[origem].Add(new Aresta(origem, destino, peso));
        }
        else
        {
            Console.WriteLine("Erro: Um ou ambos os vértices não existem.");
        }
    }

    public void ExibirLista()
    {
        Console.WriteLine("\nLista de Adjacência:");
        foreach (var vertice in listaAdjacencia)
        {
            Console.Write($"Vertice {vertice.Key}: ");
            foreach (var aresta in vertice.Value)
            {
                Console.Write($" -> {aresta.VerticeDestino} (peso: {aresta.Peso})");
            }
            Console.WriteLine();
        }
    }
}