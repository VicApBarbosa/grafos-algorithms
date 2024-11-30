namespace AlgoritmoGrafos.Services;

public class GrafoChecagens
{
    private Dictionary<int, List<int>> listaAdjacencia;
    private Dictionary<int, string> rotulosVertices;

    public GrafoChecagens(Dictionary<int, List<int>> listaAdjacencia, Dictionary<int, string> rotulosVertices)
    {
        this.listaAdjacencia = listaAdjacencia;
        this.rotulosVertices = rotulosVertices;
    }

    /// <summary>
    /// Checa se o grafo é conexo usando busca em profundidade (DFS).
    /// </summary>
    public bool EhConexo()
    {
        if (listaAdjacencia.Count == 0)
            return true; // Grafo vazio é considerado conexo.

        var visitados = new HashSet<int>();
        int verticeInicial = listaAdjacencia.Keys.First();

        // Faz a busca a partir do primeiro vértice
        DFS(verticeInicial, visitados);

        // Se todos os vértices forem visitados, o grafo é conexo
        return visitados.Count == listaAdjacencia.Count;
    }

    /// <summary>
    /// Checa se o grafo é acíclico.
    /// </summary>
    public bool EhAciclico()
    {
        var visitados = new HashSet<int>();
        foreach (var vertice in listaAdjacencia.Keys)
        {
            if (!visitados.Contains(vertice))
            {
                // Verifica ciclos com DFS
                if (DFSVerificaCiclo(vertice, -1, visitados))
                {
                    return false; // Encontrou um ciclo
                }
            }
        }
        return true; // Não encontrou ciclos
    }

    /// <summary>
    /// DFS para visitar vértices e verificar conexidade.
    /// </summary>
    private void DFS(int vertice, HashSet<int> visitados)
    {
        visitados.Add(vertice);
        foreach (var vizinho in listaAdjacencia[vertice])
        {
            if (!visitados.Contains(vizinho))
            {
                DFS(vizinho, visitados);
            }
        }
    }

    /// <summary>
    /// DFS para verificar ciclos no grafo.
    /// </summary>
    private bool DFSVerificaCiclo(int vertice, int pai, HashSet<int> visitados)
    {
        visitados.Add(vertice);
        foreach (var vizinho in listaAdjacencia[vertice])
        {
            if (!visitados.Contains(vizinho))
            {
                if (DFSVerificaCiclo(vizinho, vertice, visitados))
                {
                    return true; // Ciclo encontrado
                }
            }
            else if (vizinho != pai)
            {
                return true; // Vizinho visitado e não é o pai -> ciclo
            }
        }
        return false;
    }

    /// <summary>
    /// Verifica se o grafo é regular.
    /// </summary>
    public bool EhRegular()
    {
        if (listaAdjacencia.Count == 0)
            return true; // Grafo vazio é considerado regular

        int? grauPadrao = null;
        foreach (var vertice in listaAdjacencia)
        {
            int grauAtual = vertice.Value.Count;

            if (grauPadrao == null)
            {
                grauPadrao = grauAtual; // Define o grau padrão no primeiro vértice
            }
            else if (grauAtual != grauPadrao)
            {
                return false; // Encontrou um vértice com grau diferente
            }
        }
        return true; // Todos os vértices têm o mesmo grau
    }

    /// <summary>
    /// Verifica se o grafo é Euleriano.
    /// </summary>
    public bool EhEuleriano()
    {
        if (!EhConexo())
        {
            return false; // O grafo precisa ser conexo
        }

        foreach (var vertice in listaAdjacencia)
        {
            if (vertice.Value.Count % 2 != 0)
            {
                return false; // Encontrou um vértice com grau ímpar
            }
        }
        return true; // O grafo é Euleriano
    }

    /// <summary>
    /// Calcula a menor distância de uma origem para todos os outros vértices usando o algoritmo de Dijkstra.
    /// </summary>
    /// <param name="origem">Vértice de origem.</param>
    /// <returns>Dicionário com as distâncias mínimas para cada vértice.</returns>
    public Dictionary<int, int> Dijkstra(int origem)
    {
        var distancias = new Dictionary<int, int>();
        var visitados = new HashSet<int>();
        var fila = new PriorityQueue<int, int>();

        // Inicializa as distâncias com infinito, exceto a origem
        foreach (var vertice in listaAdjacencia.Keys)
        {
            distancias[vertice] = int.MaxValue;
        }
        distancias[origem] = 0;
        fila.Enqueue(origem, 0);

        while (fila.Count > 0)
        {
            var atual = fila.Dequeue();

            if (visitados.Contains(atual)) continue;
            visitados.Add(atual);

            foreach (var vizinho in listaAdjacencia[atual])
            {
                int peso = 1; // Adapte para suportar pesos reais se necessário
                int novaDistancia = distancias[atual] + peso;

                if (novaDistancia < distancias[vizinho])
                {
                    distancias[vizinho] = novaDistancia;
                    fila.Enqueue(vizinho, novaDistancia);
                }
            }
        }

        return distancias;
    }

    /// <summary>
    /// Retorna o rótulo de um vértice dado seu ID.
    /// </summary>
    /// <param name="id">ID do vértice.</param>
    /// <returns>Rótulo do vértice, ou "Desconhecido" se não encontrado.</returns>
    public string ObterRotuloVertice(int id)
    {
        if (rotulosVertices.ContainsKey(id))
        {
            return rotulosVertices[id];
        }
        return "Desconhecido";
    }



    /// <summary>
    /// Calcula a menor distância de todos os vértices para todos os outros vértices usando o algoritmo de Floyd-Warshall.
    /// </summary>
    /// <returns>Matriz com as distâncias mínimas entre todos os pares de vértices.</returns>
    public int[,] FloydWarshall()
    {
        int n = listaAdjacencia.Count;
        int[,] distancias = new int[n, n];

        // Inicializa a matriz de distâncias com infinito, exceto para os próprios vértices
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                    distancias[i, j] = 0;
                else
                    distancias[i, j] = int.MaxValue;
            }
        }

        // Preenche as distâncias iniciais com as arestas do grafo
        foreach (var vertice in listaAdjacencia)
        {
            foreach (var vizinho in vertice.Value)
            {
                distancias[vertice.Key, vizinho] = 1; // Adapte para suportar pesos reais se necessário
            }
        }

        // Aplica o algoritmo de Floyd-Warshall
        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (distancias[i, k] != int.MaxValue && distancias[k, j] != int.MaxValue)
                    {
                        distancias[i, j] = Math.Min(distancias[i, j], distancias[i, k] + distancias[k, j]);
                    }
                }
            }
        }

        return distancias;
    }

    /// <summary>
    /// Verifica se o grafo é completo.
    /// </summary>
    /// <returns>True se o grafo for completo, caso contrário False.</returns>
    public bool EhCompleto()
    {
        int n = listaAdjacencia.Count; // Número de vértices

        // Um grafo completo deve ter n*(n-1)/2 arestas para grafos não direcionados
        foreach (var vertice in listaAdjacencia)
        {
            // Cada vértice deve estar conectado a todos os outros
            if (vertice.Value.Count != n - 1)
            {
                return false; // Encontrou um vértice que não se conecta a todos
            }
        }

        return true; // Todos os vértices têm o número correto de conexões
    }

}
