using System.IO;
using System.Text;

namespace DesignPatterns.Adapter.Tests;

/// <summary>
/// Testes do <see cref="ServicoDeCheckout"/>: depende só de <see cref="IProcessadorPagamento"/>.
/// </summary>
public class ServicoDeCheckoutTests
{
    [Fact]
    public void FinalizarCompra_ComProcessadorQueAprova_ConsultaStatus()
    {
        var fake = new ProcessadorPagamentoFake { ProcessarRetorno = true, StatusRetorno = "APROVADO" };
        var sut = new ServicoDeCheckout(fake);

        var saida = CapturarSaidaConsole(() => sut.FinalizarCompra("4111", 100m));

        Assert.Contains("Pagamento aprovado", saida);
        Assert.Contains("Status da transação: APROVADO", saida);
        Assert.True(fake.ProcessarChamado);
        Assert.True(fake.ConsultarStatusChamado);
    }

    [Fact]
    public void FinalizarCompra_ComProcessadorQueRecusa_NaoConsultaStatus()
    {
        var fake = new ProcessadorPagamentoFake { ProcessarRetorno = false };
        var sut = new ServicoDeCheckout(fake);

        var saida = CapturarSaidaConsole(() => sut.FinalizarCompra("4111", 50m));

        Assert.Contains("Pagamento recusado", saida);
        Assert.True(fake.ProcessarChamado);
        Assert.False(fake.ConsultarStatusChamado);
    }

    [Fact]
    public void EstornarCompra_DelegaEstornoAoProcessador()
    {
        var fake = new ProcessadorPagamentoFake { EstornarRetorno = true };
        var sut = new ServicoDeCheckout(fake);

        var saida = CapturarSaidaConsole(() => sut.EstornarCompra("TX-1"));

        Assert.Contains("Estorno aprovado", saida);
        Assert.True(fake.EstornarChamado);
        Assert.Equal("TX-1", fake.UltimoTransacaoIdEstorno);
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

    private sealed class ProcessadorPagamentoFake : IProcessadorPagamento
    {
        public bool ProcessarRetorno { get; init; }
        public bool EstornarRetorno { get; init; }
        public string StatusRetorno { get; init; } = "";

        public bool ProcessarChamado { get; private set; }
        public bool ConsultarStatusChamado { get; private set; }
        public bool EstornarChamado { get; private set; }
        public string UltimoTransacaoIdEstorno { get; private set; } = "";

        public bool ProcessarPagamento(string cartao, decimal valor, string moeda)
        {
            ProcessarChamado = true;
            return ProcessarRetorno;
        }

        public bool EstornarPagamento(string transacaoId)
        {
            EstornarChamado = true;
            UltimoTransacaoIdEstorno = transacaoId;
            return EstornarRetorno;
        }

        public string ConsultarStatus(string transacaoId)
        {
            ConsultarStatusChamado = true;
            return StatusRetorno;
        }
    }
}
