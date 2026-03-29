using System.IO;
using System.Text;

namespace DesignPatterns.Command.Tests;

public class HistoricoCarrinhoTests
{
    [Fact]
    public void Desfazer_Vazio_EscreveMensagem()
    {
        var sut = new HistoricoCarrinho();
        var saida = CapturarSaidaConsole(() => sut.Desfazer());

        Assert.Contains("Nada para desfazer", saida);
    }

    [Fact]
    public void ExecutarDepoisDesfazer_LimpaRefazerAoNovoComando()
    {
        var carrinho = new Carrinho();
        var historico = new HistoricoCarrinho();

        historico.Executar(new AdicionarItemCommand(carrinho, "A", 1, 1m));
        CapturarSaidaConsole(() => historico.Desfazer());
        Assert.Empty(carrinho.Itens);

        historico.Executar(new AdicionarItemCommand(carrinho, "B", 1, 2m));
        var saidaRefazer = CapturarSaidaConsole(() => historico.Refazer());
        Assert.Contains("Nada para refazer", saidaRefazer);
    }

    [Fact]
    public void Refazer_ReexecutaUltimoDesfeito()
    {
        var carrinho = new Carrinho();
        var historico = new HistoricoCarrinho();

        historico.Executar(new AdicionarItemCommand(carrinho, "X", 1, 10m));
        CapturarSaidaConsole(() => historico.Desfazer());
        Assert.Empty(carrinho.Itens);

        CapturarSaidaConsole(() => historico.Refazer());
        Assert.Single(carrinho.Itens);
        Assert.Equal("X", carrinho.Itens[0].Produto);
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
