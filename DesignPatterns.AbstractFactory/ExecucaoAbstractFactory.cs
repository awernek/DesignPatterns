namespace DesignPatterns.AbstractFactory;

/// <summary>
/// Ponto de entrada para demonstração do padrão Abstract Factory:
/// orquestra a criação de veículos e o atendimento de socorro por porte, usando o seletor de fábricas.
/// </summary>
public static class ExecucaoAbstractFactory
{
    /// <summary>
    /// Executa o cenário de auto-socorro para uma lista de veículos (pequeno, médio e grande),
    /// obtendo a fábrica adequada via <paramref name="factorySelector"/> e realizando o atendimento.
    /// </summary>
    /// <param name="factorySelector">Seletor que retorna a fábrica concreta conforme o porte do veículo.</param>
    public static void Executar(IAutoSocorroFactorySelector factorySelector)
    {
        var veiculosSocorro = new List<Veiculo>
        {
            VeiculoCreator.Criar("Celta", Porte.Pequeno),
            VeiculoCreator.Criar("Jetta", Porte.Medio),
            VeiculoCreator.Criar("BMW X6", Porte.Grande)
        };

        foreach (var veiculo in veiculosSocorro)
        {
            var factory = factorySelector.ObterFactory(veiculo.Porte);
            var autoSocorro = new AutoSocorro(factory, veiculo);
            autoSocorro.RealizarAtendimento();
        }
    }
}