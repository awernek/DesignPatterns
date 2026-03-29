using System.IO;
using System.Text;

namespace DesignPatterns.Adapter.Tests;

/// <summary>
/// Testes do <see cref="PagSeguroAdapter"/>: tradução entre <see cref="IProcessadorPagamento"/> e <see cref="PagSeguroApi"/>.
/// </summary>
public class PagSeguroAdapterTests
{
    [Fact]
    public void ProcessarPagamento_DelegaParaIniciarTransacao_RetornaTrueQuandoHaId()
    {
        var api = new PagSeguroApi();
        var sut = new PagSeguroAdapter(api);

        var ok = CapturarSaidaConsole(() =>
            sut.ProcessarPagamento("4111", 10m, "BRL"));

        Assert.True(ok);
    }

    [Fact]
    public void EstornarPagamento_DelegaParaCancelarTransacao_RetornaTrueQuandoCodigoZero()
    {
        var api = new PagSeguroApi();
        var sut = new PagSeguroAdapter(api);

        var ok = CapturarSaidaConsole(() => sut.EstornarPagamento("PS-1"));

        Assert.True(ok);
    }

    [Fact]
    public void ConsultarStatus_DelegaParaObterDetalhes_RetornaSegundoElemento()
    {
        var api = new PagSeguroApi();
        var sut = new PagSeguroAdapter(api);

        var status = CapturarSaidaConsole(() => sut.ConsultarStatus("PS-99"));

        Assert.Equal("APROVADO", status);
    }

    private static T CapturarSaidaConsole<T>(Func<T> funcao)
    {
        var originalOut = Console.Out;
        try
        {
            using var writer = new StringWriter(new StringBuilder());
            Console.SetOut(writer);
            return funcao();
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
}
