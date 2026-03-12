namespace DesignPatterns.AbstractFactory;

public class AutoSocorroFactorySelector : IAutoSocorroFactorySelector
{
    public IAutoSocorroFactory ObterFactory(Porte porte) => porte switch
    {
        Porte.Pequeno => new SocorroVeiculoPequenoFactory(),
        Porte.Medio => new SocorroVeiculoMedioFactory(),
        Porte.Grande => new SocorroVeiculoGrandeFactory(),
        _ => throw new ArgumentException("Porte de veículo inválido.", nameof(porte))
    };
}
