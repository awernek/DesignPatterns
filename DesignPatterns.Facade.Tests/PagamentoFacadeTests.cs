using System.IO;
using System.Text;

namespace DesignPatterns.Facade.Tests;

/// <summary>Testes da <see cref="PagamentoFacade"/>: roteamento por provedor e notificação.</summary>
public class PagamentoFacadeTests
{
    private static PagamentoFacade CriarFacade() =>
        new(new PayPal(), new MercadoPago(), new PicPay(), new NotificacaoPagamento());

    [Theory]
    [InlineData("paypal", "a@b.com", "[PayPal]")]
    [InlineData("PayPal", "a@b.com", "[PayPal]")]
    [InlineData("mercadopago", "000.000.000-00", "[MercadoPago]")]
    [InlineData("picpay", "user", "[PicPay]")]
    public void Pagar_ProvedorSuportado_DelegaAoSubsistemaENotifica(
        string provedor,
        string identificador,
        string trechoProvedor)
    {
        var sut = CriarFacade();

        var saida = CapturarSaidaConsole(() =>
        {
            var ok = sut.Pagar(provedor, identificador, 10m);
            Assert.True(ok);
        });

        Assert.Contains(trechoProvedor, saida);
        Assert.Contains("[Email]", saida);
        Assert.Contains("Tudo certo.", saida);
        var idxCobranca = saida.IndexOf(trechoProvedor, StringComparison.Ordinal);
        var idxEmail = saida.IndexOf("[Email]", StringComparison.Ordinal);
        Assert.True(idxCobranca >= 0 && idxEmail > idxCobranca);
    }

    [Fact]
    public void Pagar_ProvedorDesconhecido_LancaArgumentException()
    {
        var sut = CriarFacade();

        var ex = Assert.Throws<ArgumentException>(() => sut.Pagar("pix", "x", 1m));

        Assert.Contains("não suportado", ex.Message);
        Assert.Equal("provedor", ex.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Pagar_ProvedorVazio_LancaArgumentException(string provedor)
    {
        var sut = CriarFacade();

        Assert.Throws<ArgumentException>(() => sut.Pagar(provedor, "id", 1m));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Pagar_IdentificadorInvalido_LancaArgumentException(string identificador)
    {
        var sut = CriarFacade();

        Assert.Throws<ArgumentException>(() => sut.Pagar("paypal", identificador, 1m));
    }

    [Fact]
    public void PayPal_PodeSerUsadoForaDaFacade()
    {
        var paypal = new PayPal();
        var saida = CapturarSaidaConsole(() => Assert.True(paypal.Cobrar("x@y.com", 5m)));

        Assert.Contains("[PayPal]", saida);
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
