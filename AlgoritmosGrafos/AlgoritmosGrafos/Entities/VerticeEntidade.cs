namespace AlgoritmosGrafos.Entidades;

public class Vertice(int id, object valor, int peso, string rotulo)
{
    public int Id { get; private set; } = id;
    public object Valor { get; private set; } = valor;
    public int Peso { get; private set; } = peso;
    public string Rotulo { get; private set; } = rotulo;

    // Métodos para obter valores
    public int ObterId()
    {
        return Id;
    }

    public object ObterValor()
    {
        return Valor;
    }

    public int? ObterPeso()
    {
        return Peso;
    }

    public string ObterRotulo()
    {
        return Rotulo;
    }

    // Métodos para definir valores
    public void DefinirPeso(int peso)
    {
        Peso = peso;
    }

    public void DefinirRotulo(string rotulo)
    {
        Rotulo = rotulo;
    }
}
