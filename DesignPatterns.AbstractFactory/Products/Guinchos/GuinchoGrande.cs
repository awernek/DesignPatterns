namespace DesignPatterns.AbstractFactory;

/// <summary>Guincho para veículos de porte grande.</summary>
public class GuinchoGrande : Guincho
{
    public GuinchoGrande(Porte porte) : base(porte) { }

    /// <inheritdoc />
    public override void Socorrer(Veiculo veiculo) =>
        Console.WriteLine($"Socorrendo veículo {veiculo} com guincho grande.");
}
