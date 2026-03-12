namespace DesignPatterns.AbstractFactory;

public abstract class Veiculo
{
    protected Veiculo(string modelo, Porte porte)
    {
        Modelo = modelo;
        Porte = porte;
    }

    public string Modelo { get; init; }
    public Porte Porte { get; init; }
}

public enum Porte
{
    Pequeno,
    Medio,
    Grande
}

public class VeiculoPequeno : Veiculo
{
    public VeiculoPequeno(string modelo, Porte porte) : base(modelo, porte) { }

    public override string ToString() => $"Veículo Pequeno: {Modelo}";
}

public class VeiculoMedio : Veiculo
{
    public VeiculoMedio(string modelo, Porte porte) : base(modelo, porte) { }

    public override string ToString() => $"Veículo Médio: {Modelo}";
}

public class VeiculoGrande : Veiculo
{
    public VeiculoGrande(string modelo, Porte porte) : base(modelo, porte) { }

    public override string ToString() => $"Veículo Grande: {Modelo}";
}

public static class VeiculoCreator
{
    public static Veiculo Criar(string modelo, Porte porte) => porte switch
    {
        Porte.Pequeno => new VeiculoPequeno(modelo, porte),
        Porte.Medio => new VeiculoMedio(modelo, porte),
        Porte.Grande => new VeiculoGrande(modelo, porte),
        _ => throw new ArgumentException("Porte inválido.", nameof(porte))
    };
}
