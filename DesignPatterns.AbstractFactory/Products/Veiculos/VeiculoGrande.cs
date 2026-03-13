namespace DesignPatterns.AbstractFactory;

/// <summary>Veículo de porte grande.</summary>
public class VeiculoGrande : Veiculo
{
    public VeiculoGrande(string modelo, Porte porte) : base(modelo, porte) { }

    /// <inheritdoc />
    public override string ToString() => $"Veículo Grande: {Modelo}";
}
