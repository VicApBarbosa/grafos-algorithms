﻿using AlgoritmoGrafos.Models;

namespace AlgoritmoGrafos.Services;

public class GrafoService
{
    private GrafoMatriz grafoMatriz;
    private GrafoLista grafoLista;

    public GrafoService()
    {
        grafoMatriz = new GrafoMatriz();
        grafoLista = new GrafoLista();
    }

    public void MenuPrincipal()
    {
        while (true)
        {
            Console.WriteLine("\n--- Menu Principal ---");
            Console.WriteLine("1. Adicionar vértice");
            Console.WriteLine("2. Adicionar aresta");
            Console.WriteLine("3. Exibir grafo");
            Console.WriteLine("4. Remover aresta");
            Console.WriteLine("5. Executar checagens");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");
            var opcao = int.Parse(Console.ReadLine() ?? "0");

            switch (opcao)
            {
                case 1:
                    AdicionarVertice();
                    break;
                case 2:
                    AdicionarAresta();
                    break;
                case 3:
                    MenuExibirGrafo();
                    break;
                case 4:
                    RemoverAresta();
                    break;
                case 5:
                    ExecutarChecagens();
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }

    private void AdicionarVertice()
    {
        Console.Write("Digite o rótulo do vértice: ");
        string rotulo = Console.ReadLine() ?? "";
        Console.Write("Digite o peso do vértice (ou deixe vazio para 0): ");
        string pesoInput = Console.ReadLine() ?? "0";
        int peso = int.TryParse(pesoInput, out int resultado) ? resultado : 0;

        grafoMatriz.AdicionarVertice(rotulo, peso);
        grafoLista.AdicionarVertice(rotulo, peso);

        Console.WriteLine($"Vértice '{rotulo}' com peso {peso} adicionado com sucesso!");
    }

    private void AdicionarAresta()
    {
        Console.Write("Origem (ID ou Rótulo): ");
        string origemInput = Console.ReadLine() ?? "";
        int origem = ObterIdVertice(origemInput);

        if (origem == -1)
        {
            Console.WriteLine($"Erro: Vértice '{origemInput}' não encontrado.");
            return;
        }

        Console.Write("Destino (ID ou Rótulo): ");
        string destinoInput = Console.ReadLine() ?? "";
        int destino = ObterIdVertice(destinoInput);

        if (destino == -1)
        {
            Console.WriteLine($"Erro: Vértice '{destinoInput}' não encontrado.");
            return;
        }

        Console.Write("Peso da aresta (ou deixe vazio para 1): ");
        string pesoInput = Console.ReadLine() ?? "1";
        int peso = int.TryParse(pesoInput, out int resultado) ? resultado : 1;

        Console.Write("Rótulo da aresta (ou deixe vazio): ");
        string rotulo = Console.ReadLine() ?? "";

        grafoMatriz.AdicionarAresta(origem, destino, peso, rotulo);
        grafoLista.AdicionarAresta(origem, destino, peso, rotulo);

        Console.WriteLine($"Aresta '{rotulo}' de {origemInput} para {destinoInput} com peso {peso} adicionada com sucesso!");
    }

    private int ObterIdVertice(string input)
    {
        if (int.TryParse(input, out int id))
        {
            return id;
        }

        int? verticeIdMatriz = grafoMatriz.ObterIdPorRotulo(input);
        if (verticeIdMatriz.HasValue)
        {
            return verticeIdMatriz.Value;
        }

        return -1; // Retorna -1 se não encontrar o vértice
    }


    private void RemoverAresta()
    {
        Console.Write("Digite o rótulo da aresta a ser removida: ");
        string rotulo = Console.ReadLine() ?? "";

        grafoMatriz.RemoverArestaPorRotulo(rotulo);
        grafoLista.RemoverArestaPorRotulo(rotulo);
    }

    private void ExecutarChecagens()
    {
        var checagens = new GrafoChecagens(grafoLista.ObterListaAdjacencia(), grafoLista.ObterRotulosVertices());

        Console.WriteLine("\n--- Checagens no Grafo ---");
        Console.WriteLine("1. Verificar se o grafo é conexo");
        Console.WriteLine("2. Verificar se o grafo é acíclico");
        Console.WriteLine("3. Verificar se o grafo é regular");
        Console.WriteLine("4. Verificar se o grafo é Euleriano");
        Console.WriteLine("5. Calcular menor distância de uma origem para todos (Dijkstra)");
        Console.WriteLine("6. Calcular menor distância de todos para todos (Floyd-Warshall)");
        Console.WriteLine("0. Voltar");
        Console.Write("Escolha uma opção: ");
        var opcao = int.Parse(Console.ReadLine() ?? "0");

        switch (opcao)
        {
            case 1:
                Console.WriteLine(checagens.EhConexo() ? "O grafo é conexo." : "O grafo não é conexo.");
                break;
            case 2:
                Console.WriteLine(checagens.EhAciclico() ? "O grafo é acíclico." : "O grafo contém ciclos.");
                break;
            case 3:
                Console.WriteLine(checagens.EhRegular() ? "O grafo é regular." : "O grafo não é regular.");
                break;
            case 4:
                Console.WriteLine(checagens.EhEuleriano() ? "O grafo é Euleriano." : "O grafo não é Euleriano.");
                break;
            case 5:
                Console.Write("Digite o vértice de origem (ID ou Rótulo): ");
                string entradaOrigem = Console.ReadLine() ?? "";
                int origemDijkstra = ObterIdVertice(entradaOrigem);

                if (origemDijkstra == -1)
                {
                    Console.WriteLine($"Erro: Vértice '{entradaOrigem}' não encontrado.");
                    break;
                }

                var distanciasDijkstra = checagens.Dijkstra(origemDijkstra);
                Console.WriteLine($"Menores distâncias a partir do vértice {entradaOrigem}:");
                foreach (var distancia in distanciasDijkstra)
                {
                    string rotuloDestino = checagens.ObterRotuloVertice(distancia.Key);
                    Console.WriteLine($"Para {rotuloDestino} (ID: {distancia.Key}): {distancia.Value}");
                }
                break;

            case 6:
                var matrizDistancias = checagens.FloydWarshall();
                Console.WriteLine("Menores distâncias entre todos os pares de vértices:");
                for (int i = 0; i < matrizDistancias.GetLength(0); i++)
                {
                    for (int j = 0; j < matrizDistancias.GetLength(1); j++)
                    {
                        if (matrizDistancias[i, j] == int.MaxValue)
                            Console.Write("∞ ");
                        else
                            Console.Write($"{matrizDistancias[i, j]} ");
                    }
                    Console.WriteLine();
                }
                break;
            case 0:
                return;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }


    private void MenuExibirGrafo()
    {
        while (true)
        {
            Console.WriteLine("\n--- Exibir Grafo ---");
            Console.WriteLine("1. Exibir por Matriz de Adjacência");
            Console.WriteLine("2. Exibir por Lista de Adjacência");
            Console.WriteLine("0. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
            var opcao = int.Parse(Console.ReadLine() ?? "0");

            switch (opcao)
            {
                case 1:
                    grafoMatriz.ExibirMatriz();
                    break;
                case 2:
                    grafoLista.ExibirLista();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}