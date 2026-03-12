namespace DesignPatterns.AbstractFactory;

/// <summary>Guincho para veículos de porte pequeno.</summary>
public class GuinchoPequeno : Guincho
{
    public GuinchoPequeno(Porte porte) : base(porte) { }

    /// <inheritdoc />
    public override void Socorrer(Veiculo veiculo) =>
        Console.WriteLine($"Socorrendo veículo {veiculo} com guincho pequeno.");
}
