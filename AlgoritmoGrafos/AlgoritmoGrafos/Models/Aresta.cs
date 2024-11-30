namespace AlgoritmoGrafos.Models;

public class Aresta
{
    public int VerticeOrigem { get; set; }
    public int VerticeDestino { get; set; }
    public int Peso { get; set; }
    public string Rotulo { get; set; }

    public Aresta(int origem, int destino, int peso = 1, string rotulo = "")
    {
        VerticeOrigem = origem;
        VerticeDestino = destino;
        Peso = peso;
        Rotulo = rotulo;
    }

    public override string ToString()
    {
        return $"-> {VerticeDestino} (Rótulo: {Rotulo}, Peso: {Peso})";
    }
}
