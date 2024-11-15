namespace AlgoritmosGrafos.Entities
{
    public class GraphEntity(int numVertices)
    {
        public Dictionary<string, EdgeEntity> EdgeList { get; private set; } = new Dictionary<string, EdgeEntity>();
        public Dictionary<int, VertexEntity> VertexList { get; private set; } = new Dictionary<int, VertexEntity>();

        // Matriz
        private int[,] adjacencyMatrix = new int[numVertices, numVertices];

        // Lista de adjacência
        private Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();

        public void AddVertex(VertexEntity VertexEntity)
        {
            VertexList[VertexEntity.GetId()] = VertexEntity;

            adjacencyList[VertexEntity.GetId()] = new List<int>();
        }

        public void Connect(int sourceVertexId, int targetVertexId, int weight)
        {
            EdgeEntity EdgeEntity = new EdgeEntity(sourceVertexId, targetVertexId, weight);

            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            EdgeList.Add(edgeIdentifier, EdgeEntity);

            adjacencyMatrix[sourceVertexId - 1, targetVertexId - 1] = weight;

            adjacencyList[sourceVertexId].Add(targetVertexId);
        }

        public void Disconnect(int sourceVertexId, int targetVertexId)
        {
            var edgeIdentifier = sourceVertexId + "_" + targetVertexId;
            EdgeList.Remove(edgeIdentifier);

            adjacencyMatrix[sourceVertexId - 1, targetVertexId - 1] = 0;

            adjacencyList[sourceVertexId].Remove(targetVertexId);
        }

        public VertexEntity GetVertexById(int id)
        {
            if (!VertexList.ContainsKey(id))
            {
                return null;
            }

            return VertexList[id];
        }

        public EdgeEntity GetEdgeByIdentifier(string identifier)
        {
            if (!EdgeList.ContainsKey(identifier))
            {
                return null;
            }

            return EdgeList[identifier];
        }

        public void PrintAdjacencyMatrix()
        {
            Console.WriteLine("Matriz de Adjacência:");
            for (int sourcePosition = 0; sourcePosition < adjacencyMatrix.GetLength(0); sourcePosition++)
            {
                for (int targetPosition = 0; targetPosition < adjacencyMatrix.GetLength(1); targetPosition++)
                {
                    var edgeIdentifier = (sourcePosition + 1) + "_" + (targetPosition + 1);
                    var EdgeEntity = this.GetEdgeByIdentifier(edgeIdentifier);

                    if (EdgeEntity != null)
                    {
                        Console.Write("{" + EdgeEntity.GetLabel() + " - " + EdgeEntity.GetWeight() + "}" + " ");
                    }
                    else
                    {
                        Console.Write(adjacencyMatrix[sourcePosition, targetPosition] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void PrintAdjacencyList()
        {
            Console.WriteLine("Lista de Adjacência:");
            foreach (var vertexAdjacency in adjacencyList)
            {
                var VertexEntity = this.GetVertexById(vertexAdjacency.Key);
                if (VertexEntity != null)
                {
                    Console.Write("{" + VertexEntity.GetLabel() + " - " + VertexEntity.GetWeight() + "}" + ": ");
                }
                else
                {
                    Console.Write("?" + " ");
                }

                foreach (var adjacentVertex in vertexAdjacency.Value)
                {
                    Console.Write(adjacentVertex + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
