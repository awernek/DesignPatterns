namespace DesignPatterns.Singleton.Tests;

/// <summary>
/// Testes do <see cref="Logger"/>: uma instância, acesso via <see cref="Logger.Instancia"/>,
/// histórico compartilhado e reset para isolamento entre testes.
/// </summary>
public class LoggerTests : IDisposable
{
    public LoggerTests()
    {
        Logger.ResetInstanciaParaTestes();
    }

    public void Dispose()
    {
        Logger.ResetInstanciaParaTestes();
    }

    [Fact]
    public void Instancia_AcessadaDuasVezes_RetornaMesmaReferencia()
    {
        var a = Logger.Instancia;
        var b = Logger.Instancia;

        Assert.Same(a, b);
    }

    [Fact]
    public void ResetInstanciaParaTestes_PermiteCriarNovaInstancia()
    {
        var primeira = Logger.Instancia;

        Logger.ResetInstanciaParaTestes();

        var segunda = Logger.Instancia;

        Assert.NotSame(primeira, segunda);
    }

    [Fact]
    public void MultiplosServicos_AcumulamNoMesmoHistorico()
    {
        new ServicoDeAutenticacao().Autenticar("admin");
        new ServicoDePagamento().ProcessarPagamento(10m);

        var logger = Logger.Instancia;

        Assert.True(logger.TotalDeEntradas >= 3);
        Assert.Contains(logger.EntradasDoHistorico, e => e.Contains("admin", StringComparison.Ordinal));
        Assert.Contains(logger.EntradasDoHistorico, e => e.Contains("pagamento", StringComparison.OrdinalIgnoreCase));
    }
}
