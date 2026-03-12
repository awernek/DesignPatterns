namespace DesignPatterns.AbstractFactory;

/// <summary>Guincho para veículos de porte médio.</summary>
public class GuinchoMedio : Guincho
{
    public GuinchoMedio(Porte porte) : base(porte) { }

    /// <inheritdoc />
    public override void Socorrer(Veiculo veiculo) =>
        Console.WriteLine($"Socorrendo veículo {veiculo} com guincho médio.");
}
