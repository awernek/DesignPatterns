namespace DesignPatterns.AbstractFactory.Tests;

/// <summary>
/// Testes do <see cref="AutoSocorroFactorySelector"/>.
/// Mostram que o seletor retorna a fábrica CONCRETA correta para cada porte,
/// sem o cliente precisar conhecer as classes concretas (SocorroVeiculoPequenoFactory, etc.).
/// </summary>
public class AutoSocorroFactorySelectorTests
{
    [Theory]
    [InlineData(Porte.Pequeno, typeof(SocorroVeiculoPequenoFactory))]
    [InlineData(Porte.Medio, typeof(SocorroVeiculoMedioFactory))]
    [InlineData(Porte.Grande, typeof(SocorroVeiculoGrandeFactory))]
    public void ObterFactory_ParaCadaPorte_RetornaFabricaConcretaCorreta(Porte porte, Type tipoFabricaEsperada)
    {
        var selector = new AutoSocorroFactorySelector();

        IAutoSocorroFactory factory = selector.ObterFactory(porte);

        Assert.IsType(tipoFabricaEsperada, factory);
    }

    [Fact]
    public void ObterFactory_PorteInvalido_LancaArgumentException()
    {
        var selector = new AutoSocorroFactorySelector();
        var porteInvalido = (Porte)999;

        var ex = Assert.Throws<ArgumentException>(() => selector.ObterFactory(porteInvalido));

        Assert.Contains("Porte de veículo inválido", ex.Message);
        Assert.Equal("porte", ex.ParamName);
    }
}
