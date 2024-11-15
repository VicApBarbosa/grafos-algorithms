namespace AlgoritmosGrafos.Entities;

public class VertexEntity(int id, object value, int weight, string label)
{
    public int Id { get; private set; } = id;
    public object Value { get; private set; } = value;
    public int Weight { get; private set; } = weight;
    public string Label { get; private set; } = label;

    public int GetId()
    {
        return Id;
    }

    public object GetValue()
    {
        return Value;
    }

    public int? GetWeight()
    {
        return Weight;
    }

    public void SetWeight(int weight)
    {
        Weight = weight;
    }

    public void SetLabel(string label)
    {
        Label = label;
    }

    public string GetLabel()
    {
        return Label;
    }
}
