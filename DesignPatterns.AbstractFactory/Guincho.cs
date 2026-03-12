namespace DesignPatterns.AbstractFactory;

public abstract class Guincho
{
    protected Guincho(Porte porte)
    {
        Porte = porte;
    }

    public Porte Porte { get; init; }
    public abstract void Socorrer(Veiculo veiculo);
}

public class GuinchoPequeno : Guincho
{
    public GuinchoPequeno(Porte porte) : base(porte) { }

    public override void Socorrer(Veiculo veiculo) =>
        Console.WriteLine($"Socorrendo veículo {veiculo} com guincho pequeno.");
}

public class GuinchoMedio : Guincho
{
    public GuinchoMedio(Porte porte) : base(porte) { }

    public override void Socorrer(Veiculo veiculo) =>
        Console.WriteLine($"Socorrendo veículo {veiculo} com guincho médio.");
}

public class GuinchoGrande : Guincho
{
    public GuinchoGrande(Porte porte) : base(porte) { }

    public override void Socorrer(Veiculo veiculo) =>
        Console.WriteLine($"Socorrendo veículo {veiculo} com guincho grande.");
}

public static class GuinchoCreator
{
    public static Guincho Criar(Porte porte) => porte switch
    {
        Porte.Pequeno => new GuinchoPequeno(porte),
        Porte.Medio => new GuinchoMedio(porte),
        Porte.Grande => new GuinchoGrande(porte),
        _ => throw new ArgumentException("Porte desconhecido.", nameof(porte))
    };
}