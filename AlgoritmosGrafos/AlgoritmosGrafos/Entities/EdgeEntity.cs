namespace AlgoritmosGrafos.Entities;

public class EdgeEntity(int source, int target, int weight, string label = "")
{
    public int Source { get; private set; } = source;
    public int Target { get; private set; } = target;
    public int Weight { get; private set; } = weight;
    public string Label { get; private set; } = label;

    public int GetSource()
    {
        return Source;
    }

    public int GetTarget()
    {
        return Target;
    }

    public int? GetWeight()
    {
        return Weight;
    }

    public string GetLabel()
    {
        return Label;
    }

    public void SetWeight(int weight)
    {
        Weight = weight;
    }

    public void SetLabel(string label)
    {
        Label = label;
    }
}
