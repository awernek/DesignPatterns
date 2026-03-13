namespace DesignPatterns.AbstractFactory;

/// <summary>Equipamento de guincho capaz de socorrer um <see cref="Veiculo"/> compatível com seu porte.</summary>
public abstract class Guincho
{
    protected Guincho(Porte porte)
    {
        Porte = porte;
    }

    /// <summary>Porte do guincho (deve ser compatível com o veículo a socorrer).</summary>
    public Porte Porte { get; init; }

    /// <summary>Executa o socorro do veículo informado.</summary>
    /// <param name="veiculo">Veículo a ser socorrido.</param>
    public abstract void Socorrer(Veiculo veiculo);
}
