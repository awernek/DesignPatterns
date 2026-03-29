using System.IO;
using System.Text;

namespace DesignPatterns.Strategy.Tests;

public class PedidoTests
{
    [Fact]
    public void TrocarStrategy_Nulo_LancaArgumentNullException()
    {
        var pedido = new Pedido("X", 1m, 1m, 10m, new RetiradaEmLojaStrategy());

        Assert.Throws<ArgumentNullException>(() => pedido.TrocarStrategy(null!));
    }

    [Fact]
    public void ExibirResumo_DelegaParaStrategyAtual()
    {
        var pedido = new Pedido("Item", 0.3m, 150m, 89.90m, new CorreiosPacStrategy());
        var saida = CapturarSaidaConsole(() => pedido.ExibirResumo());

        Assert.Contains("Correios PAC", saida);
        Assert.Contains("Item", saida);
        Assert.Contains("Produtos", saida);
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
