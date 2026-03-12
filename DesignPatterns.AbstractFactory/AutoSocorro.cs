namespace DesignPatterns.AbstractFactory;

public class AutoSocorro
{
    private readonly Veiculo _veiculo;
    private readonly Guincho _guincho;

    public AutoSocorro(IAutoSocorroFactory factory, Veiculo veiculo)
    {
        _veiculo = factory.CriarVeiculo(veiculo.Modelo, veiculo.Porte);
        _guincho = factory.CriarGuincho();
    }

    public void RealizarAtendimento() => _guincho.Socorrer(_veiculo);
}