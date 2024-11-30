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
                case 4:
                    RemoverAresta();
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