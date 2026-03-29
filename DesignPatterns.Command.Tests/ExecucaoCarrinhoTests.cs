using System.IO;
using System.Text;

namespace DesignPatterns.Command.Tests;

public class ExecucaoCarrinhoTests
{
    [Fact]
    public void Executar_ProduzFluxoEsperado()
    {
        var saida = CapturarSaidaConsole(ExecucaoCarrinho.Executar);

        Assert.Contains("Carrinho — Command", saida);
        Assert.Contains("Notebook Dell", saida);
        Assert.Contains("BLACKFRIDAY20", saida);
        Assert.DoesNotContain("Desfez adição", saida);
        Assert.Contains("Restaurou quantidade", saida);
        Assert.Contains("Removeu cupom", saida);
        Assert.Contains("Cupom aplicado", saida);
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
