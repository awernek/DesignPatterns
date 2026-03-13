namespace DesignPatterns.AbstractFactory;

/// <summary>Cria instâncias de <see cref="Veiculo"/> conforme o <see cref="Porte"/> informado.</summary>
public static class VeiculoCreator
{
    /// <summary>Cria um veículo do tipo correspondente ao porte (Pequeno, Medio ou Grande).</summary>
    /// <param name="modelo">Modelo do veículo.</param>
    /// <param name="porte">Porte que define a classe concreta retornada.</param>
    public static Veiculo Criar(string modelo, Porte porte) => porte switch
    {
        Porte.Pequeno => new VeiculoPequeno(modelo, porte),
        Porte.Medio => new VeiculoMedio(modelo, porte),
        Porte.Grande => new VeiculoGrande(modelo, porte),
        _ => throw new ArgumentException("Porte inválido.", nameof(porte))
    };
}
