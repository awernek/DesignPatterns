namespace DesignPatterns.AbstractFactory;

/// <summary>
/// Seletor que retorna a fábrica de auto-socorro adequada ao porte do veículo,
/// desacoplando o cliente da escolha da fábrica concreta.
/// </summary>
public interface IAutoSocorroFactorySelector
{
    /// <summary>
    /// Obtém a fábrica que cria produtos (veículo + guincho) da família do porte informado.
    /// </summary>
    /// <param name="porte">Porte do veículo (Pequeno, Medio ou Grande).</param>
    /// <returns>Fábrica que cria veículo e guincho compatíveis com o porte.</returns>
    IAutoSocorroFactory ObterFactory(Porte porte);
}
