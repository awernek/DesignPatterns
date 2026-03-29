using System.IO;
using System.Text;

namespace DesignPatterns.Strategy.Tests;

public class ExecucaoStrategyTests
{
    [Fact]
    public void Executar_CobreTresModalidadesEComparacao()
    {
        var saida = CapturarSaidaConsole(ExecucaoStrategy.Executar);

        Assert.Contains("Cálculo de frete — Strategy", saida);
        Assert.Contains("Comparação de modalidades", saida);
        Assert.Contains("Correios PAC", saida);
        Assert.Contains("Transportadora Express", saida);
        Assert.Contains("Retirada em Loja", saida);
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
