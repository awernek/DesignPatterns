using System.IO;
using System.Text;

namespace DesignPatterns.Observer.Tests;

public class PedidoSubjectTests
{
    [Fact]
    public void Inscrever_Nulo_LancaArgumentNullException()
    {
        var pedido = new Pedido("P-1");
        Assert.Throws<ArgumentNullException>(() => pedido.Inscrever(null!));
    }

    [Fact]
    public void AtualizarStatus_NotificaTodosInscritos()
    {
        var saida = CapturarSaidaConsole(() =>
        {
            var pedido = new Pedido("P-2");
            var a = new ContadorObserver();
            var b = new ContadorObserver();
            pedido.Inscrever(a);
            pedido.Inscrever(b);
            pedido.AtualizarStatus(StatusPedido.Pago);
            Assert.Equal(1, a.Vezes);
            Assert.Equal(1, b.Vezes);
        });

        Assert.Contains("Pago", saida);
    }

    [Fact]
    public void Desinscrever_NaoRecebeMaisNotificacoes()
    {
        var pedido = new Pedido("P-3");
        var obs = new ContadorObserver();
        pedido.Inscrever(obs);
        CapturarSaidaConsole(() => pedido.AtualizarStatus(StatusPedido.Pago));
        Assert.Equal(1, obs.Vezes);

        pedido.Desinscrever(obs);
        CapturarSaidaConsole(() => pedido.AtualizarStatus(StatusPedido.Enviado));
        Assert.Equal(1, obs.Vezes);
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

    private sealed class ContadorObserver : IObserver
    {
        public int Vezes { get; private set; }

        public void Atualizar(string numeroPedido, StatusPedido novoStatus) => Vezes++;
    }
}
