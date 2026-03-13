namespace DesignPatterns.AbstractFactory.Tests;

/// <summary>
/// Testes que ilustram o conceito central do Abstract Factory: cada fábrica concreta
/// cria uma FAMÍLIA de produtos compatíveis entre si (veículo + guincho do MESMO porte).
/// O cliente usa apenas a interface da fábrica e recebe produtos que "combinam".
/// </summary>
public class AbstractFactoryFamiliaTests
{
    [Theory]
    [InlineData(Porte.Pequeno, typeof(VeiculoPequeno), typeof(GuinchoPequeno))]
    [InlineData(Porte.Medio, typeof(VeiculoMedio), typeof(GuinchoMedio))]
    [InlineData(Porte.Grande, typeof(VeiculoGrande), typeof(GuinchoGrande))]
    public void Fabrica_CriaVeiculoEGuincho_DoMesmoPorte(Porte porte, Type tipoVeiculoEsperado, Type tipoGuinchoEsperado)
    {
        var selector = new AutoSocorroFactorySelector();
        IAutoSocorroFactory factory = selector.ObterFactory(porte);

        var veiculo = factory.CriarVeiculo("Modelo Teste", porte);
        var guincho = factory.CriarGuincho();

        Assert.IsType(tipoVeiculoEsperado, veiculo);
        Assert.IsType(tipoGuinchoEsperado, guincho);
        Assert.Equal(porte, veiculo.Porte);
        Assert.Equal(porte, guincho.Porte);
    }

    [Fact]
    public void VariasFabricas_CriamProdutosIndependentes_CadaFamiliaConsistente()
    {
        var selector = new AutoSocorroFactorySelector();

        var fabPequeno = selector.ObterFactory(Porte.Pequeno);
        var fabGrande = selector.ObterFactory(Porte.Grande);

        var veiculoPequeno = fabPequeno.CriarVeiculo("Celta", Porte.Pequeno);
        var guinchoPequeno = fabPequeno.CriarGuincho();
        var veiculoGrande = fabGrande.CriarVeiculo("BMW X6", Porte.Grande);
        var guinchoGrande = fabGrande.CriarGuincho();

        Assert.Equal(Porte.Pequeno, veiculoPequeno.Porte);
        Assert.Equal(Porte.Pequeno, guinchoPequeno.Porte);
        Assert.Equal(Porte.Grande, veiculoGrande.Porte);
        Assert.Equal(Porte.Grande, guinchoGrande.Porte);
    }
}
