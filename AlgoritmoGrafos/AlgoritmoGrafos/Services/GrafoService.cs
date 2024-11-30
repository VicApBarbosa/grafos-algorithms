using AlgoritmoGrafos.Models;

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
        grafoMatriz.AdicionarVertice();
        grafoLista.AdicionarVertice();
        Console.WriteLine("Vértice adicionado com sucesso!");
    }

    private void AdicionarAresta()
    {
        Console.Write("Origem: ");
        int origem = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Destino: ");
        int destino = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Peso: ");
        int peso = int.Parse(Console.ReadLine() ?? "1");

        grafoMatriz.AdicionarAresta(origem, destino, peso);
        grafoLista.AdicionarAresta(origem, destino, peso);

        Console.WriteLine("Aresta adicionada com sucesso!");
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
