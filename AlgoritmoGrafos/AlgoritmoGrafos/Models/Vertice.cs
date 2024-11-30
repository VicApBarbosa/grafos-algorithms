namespace AlgoritmoGrafos.Models;

public class Vertice
{
    public int Id { get; set; }
    public string Rotulo { get; set; }
    public int Peso { get; set; }

    public Vertice(int id, string rotulo = "", int peso = 0)
    {
        Id = id;
        Rotulo = rotulo;
        Peso = peso;
    }

    public override string ToString()
    {
        return $"Vértice {Id} (Rótulo: {Rotulo}, Peso: {Peso})";
    }
}