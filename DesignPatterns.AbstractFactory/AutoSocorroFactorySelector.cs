namespace DesignPatterns.AbstractFactory;

/// <summary>
/// Implementação do seletor de fábricas: mapeia cada <see cref="Porte"/> para a
/// fábrica concreta correspondente (pequeno, médio ou grande).
/// </summary>
public class AutoSocorroFactorySelector : IAutoSocorroFactorySelector
{
    /// <inheritdoc />
    public IAutoSocorroFactory ObterFactory(Porte porte) => porte switch
    {
        Porte.Pequeno => new SocorroVeiculoPequenoFactory(),
        Porte.Medio => new SocorroVeiculoMedioFactory(),
        Porte.Grande => new SocorroVeiculoGrandeFactory(),
        _ => throw new ArgumentException("Porte de veículo inválido.", nameof(porte))
    };
}
