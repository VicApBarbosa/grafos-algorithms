﻿using AlgoritmosGrafos.Entidades;
using ModelosDeGrafos.Modelos;

namespace AlgoritmosGrafos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insira o número de vértices: ");
            int quantidadeVertices;
            while (!int.TryParse(Console.ReadLine(), out quantidadeVertices) || quantidadeVertices <= 0)
            {
                Console.WriteLine("Por favor, insira um número inteiro positivo válido para o número de vértices.");
                Console.Write("Insira o número de vértices: ");
            }

            var grafo = new Grafo(quantidadeVertices);
            var vertices = new Vertice[quantidadeVertices];
            var pesoPadrao = 1;

            for (int i = 0; i < quantidadeVertices; i++)
            {
                var valor = ((char)('A' + i)).ToString();
                var vertice = new Vertice(i + 1, valor, pesoPadrao, valor);
                grafo.AdicionarVertice(vertice);
                vertices[i] = vertice;
            }

            while (true)
            {
                Console.WriteLine("\nEscolha uma ação:");
                Console.WriteLine(" (1) Adicionar uma aresta");
                Console.WriteLine(" (2) Remover uma aresta");
                Console.WriteLine(" (3) Adicionar rótulo ao vértice");
                Console.WriteLine(" (4) Adicionar peso ao vértice");
                Console.WriteLine(" (5) Adicionar rótulo à aresta");
                Console.WriteLine(" (6) Adicionar peso à aresta");
                Console.WriteLine();

                string acao = Console.ReadLine();
                switch (acao)
                {
                    case "1":
                        AdicionarAresta(grafo);
                        break;
                    case "2":
                        RemoverAresta(grafo);
                        break;
                    case "3":
                        AdicionarRotuloVertice(grafo);
                        break;
                    case "4":
                        AdicionarPesoVertice(grafo);
                        break;
                    case "5":
                        AdicionarRotuloAresta(grafo);
                        break;
                    case "6":
                        AdicionarPesoAresta(grafo);
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

                grafo.ImprimirMatrizAdjacencia();
                grafo.ImprimirListaAdjacencia();
            }
        }

        static void AdicionarAresta(Grafo grafo)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int idOrigem = int.Parse(Console.ReadLine());
            Console.Write("Insira o ID do vértice de destino: ");
            int idDestino = int.Parse(Console.ReadLine());
            Console.Write("Insira o peso: ");
            int peso = int.Parse(Console.ReadLine());

            grafo.Conectar(idOrigem, idDestino, peso);
        }

        static void RemoverAresta(Grafo grafo)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int idOrigem = int.Parse(Console.ReadLine());
            Console.Write("Insira o ID do vértice de destino: ");
            int idDestino = int.Parse(Console.ReadLine());

            grafo.Desconectar(idOrigem, idDestino);
        }

        static void AdicionarRotuloVertice(Grafo grafo)
        {
            Console.Write("Insira o ID do vértice: ");
            int idVertice = int.Parse(Console.ReadLine());
            var vertice = grafo.ObterVerticePorId(idVertice);

            if (vertice != null)
            {
                Console.Write("Insira o rótulo do vértice: ");
                string rotulo = Console.ReadLine();
                vertice.DefinirRotulo(rotulo);
            }
            else
            {
                Console.WriteLine("Vértice não encontrado.");
            }
        }

        static void AdicionarPesoVertice(Grafo grafo)
        {
            Console.Write("Insira o ID do vértice: ");
            int idVertice = int.Parse(Console.ReadLine());
            var vertice = grafo.ObterVerticePorId(idVertice);

            if (vertice != null)
            {
                Console.Write("Insira o peso do vértice: ");
                int peso = int.Parse(Console.ReadLine());
                vertice.DefinirPeso(peso);
            }
            else
            {
                Console.WriteLine("Vértice não encontrado.");
            }
        }

        static void AdicionarRotuloAresta(Grafo grafo)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int idOrigem = int.Parse(Console.ReadLine());
            Console.Write("Insira o ID do vértice de destino: ");
            int idDestino = int.Parse(Console.ReadLine());

            var identificadorAresta = idOrigem + "_" + idDestino;
            var aresta = grafo.ObterArestaPorIdentificador(identificadorAresta);

            if (aresta != null)
            {
                Console.Write("Insira o rótulo da aresta: ");
                string rotulo = Console.ReadLine();
                aresta.DefinirRotulo(rotulo);
            }
            else
            {
                Console.WriteLine("Aresta não encontrada.");
            }
        }

        static void AdicionarPesoAresta(Grafo grafo)
        {
            Console.Write("Insira o ID do vértice de origem: ");
            int idOrigem = int.Parse(Console.ReadLine());
            Console.Write("Insira o ID do vértice de destino: ");
            int idDestino = int.Parse(Console.ReadLine());

            var identificadorAresta = idOrigem + "_" + idDestino;
            var aresta = grafo.ObterArestaPorIdentificador(identificadorAresta);

            if (aresta != null)
            {
                Console.Write("Insira o peso da aresta: ");
                int peso = int.Parse(Console.ReadLine());
                aresta.DefinirPeso(peso);
            }
            else
            {
                Console.WriteLine("Aresta não encontrada.");
            }
        }
    }
}
