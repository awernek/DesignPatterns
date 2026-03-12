namespace DesignPatterns.AbstractFactory;

/// <summary>Representa um veículo a ser socorrido, com modelo e porte.</summary>
public abstract class Veiculo
{
    protected Veiculo(string modelo, Porte porte)
    {
        Modelo = modelo;
        Porte = porte;
    }

    /// <summary>Modelo do veículo.</summary>
    public string Modelo { get; init; }

    /// <summary>Porte do veículo (Pequeno, Medio ou Grande).</summary>
    public Porte Porte { get; init; }
}
