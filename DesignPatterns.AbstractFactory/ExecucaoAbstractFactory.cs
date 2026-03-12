namespace DesignPatterns.AbstractFactory;

public static class ExecucaoAbstractFactory
{
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