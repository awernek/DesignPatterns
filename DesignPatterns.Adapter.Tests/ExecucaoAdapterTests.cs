using System.IO;
using System.Text;

namespace DesignPatterns.Adapter.Tests;

/// <summary>Testes da demonstração <see cref="ExecucaoAdapter"/>.</summary>
public class ExecucaoAdapterTests
{
    [Fact]
    public void Executar_ProduzFluxoAdapterEPagSeguro()
    {
        var saida = CapturarSaidaConsole(ExecucaoAdapter.Executar);

        Assert.Contains("[Adapter]", saida);
        Assert.Contains("[PagSeguro]", saida);
        Assert.Contains("Pagamento aprovado", saida);
        Assert.Contains("Estorno aprovado", saida);
    }

    private static string CapturarSaidaConsole(Action acao)
    {
        var originalOut = Console.Out;
        try
        {
            using var writer = new StringWriter(new StringBuilder());
            Console.SetOut(writer);
            acao();
            return writer.ToString();
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
}
