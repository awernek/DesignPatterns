namespace DesignPatterns.AbstractFactory;

/// <summary>
/// Representa um atendimento de auto-socorro: utiliza uma fábrica abstrata para obter
/// o veículo e o guincho compatíveis (mesma família por porte) e executa o resgate.
/// </summary>
public class AutoSocorro
{
    private readonly Veiculo _veiculo;
    private readonly Guincho _guincho;

    /// <summary>
    /// Cria um atendimento de auto-socorro usando a fábrica fornecida para instanciar
    /// veículo e guincho da mesma família (porte).
    /// </summary>
    /// <param name="factory">Fábrica que cria os produtos da família (veículo + guincho).</param>
    /// <param name="veiculo">Dados do veículo a ser socorrido (modelo e porte).</param>
    public AutoSocorro(IAutoSocorroFactory factory, Veiculo veiculo)
    {
        _veiculo = factory.CriarVeiculo(veiculo.Modelo, veiculo.Porte);
        _guincho = factory.CriarGuincho();
    }

    /// <summary>
    /// Executa o atendimento, acionando o guincho para socorrer o veículo.
    /// </summary>
    public void RealizarAtendimento() => _guincho.Socorrer(_veiculo);
}
