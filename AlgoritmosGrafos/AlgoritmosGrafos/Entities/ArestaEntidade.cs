namespace AlgoritmosGrafos.Entidades;

public class Aresta(int origem, int destino, int peso, string rotulo = "")
{
    public int Origem { get; private set; } = origem;
    public int Destino { get; private set; } = destino;
    public int Peso { get; private set; } = peso;
    public string Rotulo { get; private set; } = rotulo;

    // Métodos para obter valores
    public int ObterOrigem()
    {
        return Origem;
    }

    public int ObterDestino()
    {
        return Destino;
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
