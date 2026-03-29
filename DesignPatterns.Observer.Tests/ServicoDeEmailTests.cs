using System.IO;
using System.Text;

namespace DesignPatterns.Observer.Tests;

public class ServicoDeEmailTests
{
    [Fact]
    public void Atualizar_Pago_GeraCorpo()
    {
        var sut = new ServicoDeEmail("a@b.com");
        var saida = CapturarSaidaConsole(() => sut.Atualizar("X", StatusPedido.Pago));

        Assert.Contains("[E-mail]", saida);
        Assert.Contains("Pagamento confirmado", saida);
    }

    [Fact]
    public void Atualizar_Aguardando_NaoEnvia()
    {
        var sut = new ServicoDeEmail("a@b.com");
        var saida = CapturarSaidaConsole(() => sut.Atualizar("X", StatusPedido.Aguardando));

        Assert.DoesNotContain("[E-mail]", saida);
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
