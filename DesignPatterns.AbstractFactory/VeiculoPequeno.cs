namespace DesignPatterns.AbstractFactory;

/// <summary>Veículo de porte pequeno.</summary>
public class VeiculoPequeno : Veiculo
{
    public VeiculoPequeno(string modelo, Porte porte) : base(modelo, porte) { }

    /// <inheritdoc />
    public override string ToString() => $"Veículo Pequeno: {Modelo}";
}
