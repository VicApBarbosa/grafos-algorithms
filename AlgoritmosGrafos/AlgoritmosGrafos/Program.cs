using AlgoritmosGrafos.Entities;

namespace AlgoritmosGrafos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insira o número de vértices: ");
            int numVertices;
            while (!int.TryParse(Console.ReadLine(), out numVertices) || numVertices <= 0)
            {
                Console.WriteLine("Por favor, insira um número inteiro positivo válido para o número de vértices.");
                Console.Write("Insira o número de vértices: ");
            }

            var GraphEntity = new GraphEntity(numVertices);
            var vertices = new VertexEntity[numVertices];

            var defaultWeight = 1;
            for (int i = 0; i < numVertices; i++)
            {
                var value = ((char)('A' + i)).ToString();
                var VertexEntity = new VertexEntity(i + 1, value, defaultWeight, value);
                GraphEntity.AddVertex(VertexEntity);
                vertices[i] = VertexEntity;
            }

            while (true)
            {
                Console.WriteLine("\nVocê gostaria de:");
                Console.WriteLine("\n (1) Adicionar uma aresta?");
                Console.WriteLine("\n (2) Remover uma aresta?");
                Console.WriteLine("\n (3) Adicionar um rótulo ao vértice?");
                Console.WriteLine("\n (4) Adicionar peso ao vértice?");
                Console.WriteLine("\n (5) Adicionar rótulo à aresta?");
                Console.WriteLine("\n (6) Adicionar peso à aresta?");
                Console.WriteLine("\n");
                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        AddEdge(GraphEntity);
                        break;
                    case "2":
                        RemoveEdge(GraphEntity);
                        break;
                    case "3":
                        AddVertexLabel(GraphEntity);
                        break;
                    case "4":
                        AddVertexWeight(GraphEntity);
                        break;
                    case "5":
                        AddEdgeLabel(GraphEntity);
                        break;
                    case "6":
                        AddEdgeWeight(GraphEntity);
                        break;
                    default:
                        // Não fazer nada
                        break;
                }

                GraphEntity.PrintAdjacencyMatrix();
                GraphEntity.PrintAdjacencyList();
            }
        }

        static void AddEdge(GraphEntity GraphEntity)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetId = int.Parse(Console.ReadLine());

            Console.Write("Insira o peso: ");
            int weight = int.Parse(Console.ReadLine());

            GraphEntity.Connect(sourceId, targetId, weight);
        }

        static void RemoveEdge(GraphEntity GraphEntity)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetId = int.Parse(Console.ReadLine());

            GraphEntity.Disconnect(sourceId, targetId);
        }

        static void AddVertexLabel(GraphEntity GraphEntity)
        {
            Console.Write("Insira o ID do vértice: ");
            int vertexId = int.Parse(Console.ReadLine());
            var VertexEntity = GraphEntity.GetVertexById(vertexId);

            if (VertexEntity != null)
            {
                Console.Write("Insira o rótulo do vértice: ");
                string label = Console.ReadLine();

                VertexEntity.SetLabel(label);
            }
            else
            {
                Console.WriteLine("Vértice não encontrado.");
            }
        }

        static void AddVertexWeight(GraphEntity GraphEntity)
        {
            Console.Write("Insira o ID do vértice: ");
            int vertexId = int.Parse(Console.ReadLine());
            var VertexEntity = GraphEntity.GetVertexById(vertexId);

            if (VertexEntity != null)
            {
                Console.Write("Insira o peso do vértice: ");
                int weight = int.Parse(Console.ReadLine());

                VertexEntity.SetWeight(weight);
            }
            else
            {
                Console.WriteLine("Vértice não encontrado.");
            }
        }

        static void AddEdgeLabel(GraphEntity GraphEntity)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetVertexId = int.Parse(Console.ReadLine());

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            var EdgeEntity = GraphEntity.GetEdgeByIdentifier(edgeIdentifier);

            if (EdgeEntity != null)
            {
                Console.Write("Insira o rótulo da aresta: ");
                string label = Console.ReadLine();

                EdgeEntity.SetLabel(label);
            }
            else
            {
                Console.WriteLine("Aresta não encontrada.");
            }
        }

        static void AddEdgeWeight(GraphEntity GraphEntity)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int sourceVertexId = int.Parse(Console.ReadLine());

            Console.Write("Insira o ID do vértice de destino: ");
            int targetVertexId = int.Parse(Console.ReadLine());

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            var EdgeEntity = GraphEntity.GetEdgeByIdentifier(edgeIdentifier);

            if (EdgeEntity != null)
            {
                Console.Write("Insira o peso da aresta: ");
                int weight = int.Parse(Console.ReadLine());

                EdgeEntity.SetWeight(weight);
            }
            else
            {
                Console.WriteLine("Aresta não encontrada.");
            }
        }
    }
}
