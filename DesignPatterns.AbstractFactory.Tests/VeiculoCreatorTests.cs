namespace DesignPatterns.AbstractFactory.Tests;

/// <summary>
/// Testes do <see cref="VeiculoCreator"/>.
/// O creator encapsula a lógica "qual classe concreta instanciar para este porte?"
/// assim o cliente não depende de VeiculoPequeno, VeiculoMedio, VeiculoGrande.
/// </summary>
public class VeiculoCreatorTests
{
    [Theory]
    [InlineData(Porte.Pequeno, typeof(VeiculoPequeno))]
    [InlineData(Porte.Medio, typeof(VeiculoMedio))]
    [InlineData(Porte.Grande, typeof(VeiculoGrande))]
    public void Criar_PorPorte_RetornaTipoConcretoCorreto(Porte porte, Type tipoEsperado)
    {
        var veiculo = VeiculoCreator.Criar("Teste", porte);

        Assert.IsType(tipoEsperado, veiculo);
        Assert.Equal(porte, veiculo.Porte);
        Assert.Equal("Teste", veiculo.Modelo);
    }

    [Fact]
    public void Criar_PorteInvalido_LancaArgumentException()
    {
        var porteInvalido = (Porte)42;

        var ex = Assert.Throws<ArgumentException>(() => VeiculoCreator.Criar("X", porteInvalido));

        Assert.Contains("Porte inválido", ex.Message);
    }
}
