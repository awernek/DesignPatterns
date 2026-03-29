using System.IO;
using System.Text;

namespace DesignPatterns.Facade.Tests;

/// <summary>Testes da demonstração <see cref="ExecucaoFacadePagamento"/>.</summary>
public class ExecucaoFacadePagamentoTests
{
    [Fact]
    public void Executar_ProcessaTresProvedores()
    {
        var saida = CapturarSaidaConsole(ExecucaoFacadePagamento.Executar);

        Assert.Contains("Pagamentos — Facade", saida);
        Assert.Contains("joao@email.com", saida);
        Assert.Contains("[MercadoPago]", saida);
        Assert.Contains("[PicPay]", saida);
        Assert.Contains("joaosilva", saida);
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
