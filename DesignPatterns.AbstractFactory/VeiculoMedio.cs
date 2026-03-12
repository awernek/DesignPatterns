namespace DesignPatterns.AbstractFactory;

/// <summary>Veículo de porte médio.</summary>
public class VeiculoMedio : Veiculo
{
    public VeiculoMedio(string modelo, Porte porte) : base(modelo, porte) { }

    /// <inheritdoc />
    public override string ToString() => $"Veículo Médio: {Modelo}";
}
