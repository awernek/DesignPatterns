using System.IO;
using System.Text;

namespace DesignPatterns.Strategy.Tests;

public class FreteStrategyTests
{
    [Fact]
    public void CorreiosPac_AcimaDe299_FreteZeroEMensagem()
    {
        var sut = new CorreiosPacStrategy();
        var saida = CapturarSaida(() =>
        {
            var f = sut.CalcularFrete(1m, 100m, 300m);
            Assert.Equal(0m, f);
        });

        Assert.Contains("Frete grátis", saida);
    }

    [Fact]
    public void CorreiosPac_AbaixoDe299_SomaTaxas()
    {
        var sut = new CorreiosPacStrategy();
        var frete = ComConsoleSilenciado(() => sut.CalcularFrete(1m, 100m, 100m));
        Assert.Equal(8.90m + 2.50m + 2.00m, frete);
    }

    [Theory]
    [InlineData(400, 5)]
    [InlineData(600, 10)]
    public void CorreiosPac_PrazoPorDistancia(int distancia, int diasEsperados)
    {
        var sut = new CorreiosPacStrategy();
        Assert.Equal(diasEsperados, sut.PrazoEmDias(distancia));
    }

    [Fact]
    public void TransportadoraExpress_FormulaPadrao()
    {
        var sut = new TransportadoraExpressStrategy();
        var frete = sut.CalcularFrete(0.3m, 150m, 89.90m);
        Assert.Equal(89.90m * 0.03m + 25.00m, frete);
    }

    [Fact]
    public void TransportadoraExpress_SobrepesoAcrescimo()
    {
        var sut = new TransportadoraExpressStrategy();
        var frete = sut.CalcularFrete(12m, 100m, 0m);
        Assert.Equal(25m + (12m - 10m) * 5m, frete);
    }

    [Fact]
    public void RetiradaEmLoja_SempreZero()
    {
        var sut = new RetiradaEmLojaStrategy();
        var saida = CapturarSaida(() =>
        {
            var f = sut.CalcularFrete(10m, 500m, 1000m);
            Assert.Equal(0m, f);
        });

        Assert.Contains("Sem custo de frete", saida);
        Assert.Equal(0, sut.PrazoEmDias(999));
    }

    private static string CapturarSaida(Action acao)
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

    private static decimal ComConsoleSilenciado(Func<decimal> funcao)
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
