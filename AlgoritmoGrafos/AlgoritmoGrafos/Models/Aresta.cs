namespace AlgoritmoGrafos.Models;

public class Aresta
{
    public int VerticeOrigem { get; set; }
    public int VerticeDestino { get; set; }
    public int Peso { get; set; }

    public Aresta(int origem, int destino, int peso = 1)
    {
        VerticeOrigem = origem;
        VerticeDestino = destino;
        Peso = peso;
    }
}
