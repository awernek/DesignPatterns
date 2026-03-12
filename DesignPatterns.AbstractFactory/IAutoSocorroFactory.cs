namespace DesignPatterns.AbstractFactory;

/// <summary>
/// Abstração da fábrica que cria produtos da mesma família: guincho e veículo
/// compatíveis entre si (Abstract Factory).
/// </summary>
public interface IAutoSocorroFactory
{
    /// <summary>Cria um guincho da família desta fábrica.</summary>
    Guincho CriarGuincho();

    /// <summary>Cria um veículo da família desta fábrica.</summary>
    /// <param name="modelo">Modelo do veículo.</param>
    /// <param name="porte">Porte do veículo (deve ser consistente com a família da fábrica).</param>
    Veiculo CriarVeiculo(string modelo, Porte porte);
}
