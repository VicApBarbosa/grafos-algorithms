namespace AlgoritmoGrafos.Models;

public class Vertice
{
    public int Id { get; set; }
    public string Rotulo { get; set; }

    public Vertice(int id, string rotulo)
    {
        Id = id;
        Rotulo = rotulo;
    }
}