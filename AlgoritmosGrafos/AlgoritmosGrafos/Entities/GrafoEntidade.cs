using System;
using AlgoritmosGrafos.Entidades;


namespace ModelosDeGrafos.Modelos
{
    public class Grafo
    {
        public Dictionary<string, Aresta> ListaDeArestas { get; private set; }
        public Dictionary<int, Vertice> ListaDeVertices { get; private set; }

        // Matriz de adjacência
        private int[,] matrizAdjacencia;

        // Lista de adjacência
        private Dictionary<int, List<int>> listaAdjacencia;

        public Grafo(int quantidadeVertices)
        {
            ListaDeArestas = new Dictionary<string, Aresta>();
            ListaDeVertices = new Dictionary<int, Vertice>();

            matrizAdjacencia = new int[quantidadeVertices, quantidadeVertices];

            listaAdjacencia = new Dictionary<int, List<int>>();
        }

        public void AdicionarVertice(Vertice vertice)
        {
            ListaDeVertices[vertice.ObterId()] = vertice;

            listaAdjacencia[vertice.ObterId()] = new List<int>();
        }

        public void Conectar(int idVerticeOrigem, int idVerticeDestino, int peso)
        {
            Aresta aresta = new Aresta(idVerticeOrigem, idVerticeDestino, peso);

            var identificadorAresta = idVerticeOrigem + "_" + idVerticeDestino;
            ListaDeArestas.Add(identificadorAresta, aresta);

            matrizAdjacencia[idVerticeOrigem - 1, idVerticeDestino - 1] = peso;

            listaAdjacencia[idVerticeOrigem].Add(idVerticeDestino);
        }

        public void Desconectar(int idVerticeOrigem, int idVerticeDestino)
        {
            var identificadorAresta = idVerticeOrigem + "_" + idVerticeDestino;
            ListaDeArestas.Remove(identificadorAresta);

            matrizAdjacencia[idVerticeOrigem - 1, idVerticeDestino - 1] = 0;

            listaAdjacencia[idVerticeOrigem].Remove(idVerticeDestino);
        }

        public Vertice ObterVerticePorId(int id)
        {
            if (!ListaDeVertices.ContainsKey(id))
            {
                return null;
            }

            return ListaDeVertices[id];
        }

        public Aresta ObterArestaPorIdentificador(string identificador)
        {
            if (!ListaDeArestas.ContainsKey(identificador))
            {
                return null;
            }

            return ListaDeArestas[identificador];
        }

        public void ImprimirMatrizAdjacencia()
        {
            Console.WriteLine("Matriz de Adjacência:");
            for (int posicaoOrigem = 0; posicaoOrigem < matrizAdjacencia.GetLength(0); posicaoOrigem++)
            {
                for (int posicaoDestino = 0; posicaoDestino < matrizAdjacencia.GetLength(1); posicaoDestino++)
                {
                    var identificadorAresta = (posicaoOrigem + 1) + "_" + (posicaoDestino + 1);
                    var aresta = this.ObterArestaPorIdentificador(identificadorAresta);

                    if (aresta != null)
                    {
                        Console.Write("{" + aresta.ObterRotulo() + " - " + aresta.ObterPeso() + "} ");
                    }
                    else
                    {
                        Console.Write(matrizAdjacencia[posicaoOrigem, posicaoDestino] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void ImprimirListaAdjacencia()
        {
            Console.WriteLine("Lista de Adjacência:");
            foreach (var adjacenciaVertice in listaAdjacencia)
            {
                var vertice = this.ObterVerticePorId(adjacenciaVertice.Key);
                if (vertice != null)
                {
                    Console.Write("{" + vertice.ObterRotulo() + " - " + vertice.ObterPeso() + "}: ");
                }
                else
                {
                    Console.Write("? ");
                }

                foreach (var verticeAdjacente in adjacenciaVertice.Value)
                {
                    Console.Write(verticeAdjacente + " ");
                }
                Console.WriteLine();
            }
        }

        public int ObterGrauVertice(int idVertice)
        {
            if (!ListaDeVertices.ContainsKey(idVertice))
            {
                Console.WriteLine("O vértice informado não existe no grafo.");
                return -1;
            }
               
            // Para grafos direcionados:
            int grauSaida = listaAdjacencia[idVertice].Count;
            int grauEntrada = 0;

            foreach (var adjacencia in listaAdjacencia)
            {
                if (adjacencia.Value.Contains(idVertice))
                {
                    grauEntrada++;
                }
            }

            // Retorna o grau total para grafos não direcionados:
            return grauSaida + grauEntrada;
        }

        public bool VerificarGrafoConexo()
        {
            if (ListaDeVertices.Count == 0)
                return false;

            // Inicializa um array para verificar os vértices visitados
            var visitados = new HashSet<int>();
            int verticeInicial = ListaDeVertices.Keys.First();

            // Realiza uma busca em profundidade a partir do primeiro vértice
            DFS(verticeInicial, visitados);

            // Verifica se todos os vértices foram visitados
            return visitados.Count == ListaDeVertices.Count;
        }

        private void DFS(int verticeAtual, HashSet<int> visitados)
        {
            visitados.Add(verticeAtual);

            foreach (var vizinho in listaAdjacencia[verticeAtual])
            {
                if (!visitados.Contains(vizinho))
                {
                    DFS(vizinho, visitados);
                }
            }
        }

        public bool VerificarGrafoAciclico()
        {
            var visitados = new HashSet<int>();

            foreach (var vertice in ListaDeVertices.Keys)
            {
                if (!visitados.Contains(vertice))
                {
                    // Se encontrar um ciclo, o grafo não é acíclico
                    if (TemCiclo(vertice, -1, visitados))
                        return false;
                }
            }
            return true;
        }

        private bool TemCiclo(int verticeAtual, int pai, HashSet<int> visitados)
        {
            visitados.Add(verticeAtual);

            foreach (var vizinho in listaAdjacencia[verticeAtual])
            {
                if (!visitados.Contains(vizinho))
                {
                    if (TemCiclo(vizinho, verticeAtual, visitados))
                        return true;
                }
                else if (vizinho != pai)
                {
                    // Se o vizinho já foi visitado e não é o pai, temos um ciclo
                    return true;
                }
            }
            return false;
        }

    }
}

