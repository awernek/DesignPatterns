using System.IO;
using System.Text;

namespace DesignPatterns.Observer.Tests;

public class ExecucaoObserverTests
{
    [Fact]
    public void Executar_SegundoPedidoCanceladoSemFidelidadeNoEstorno()
    {
        var saida = CapturarSaidaConsole(ExecucaoObserver.Executar);

        Assert.Contains("Status de pedido — Observer", saida);
        Assert.Contains("PED-2024-9871", saida);
        Assert.Contains("PED-2024-9872", saida);
        Assert.Contains("ProgramaDeFidelidade] desinscrito", saida);

        var idxCancela = saida.LastIndexOf("Cancelado", StringComparison.Ordinal);
        Assert.True(idxCancela > 0);
        var trechoAposUltimoCancelado = saida[idxCancela..];
        Assert.DoesNotContain("Estornando pontos", trechoAposUltimoCancelado);
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
