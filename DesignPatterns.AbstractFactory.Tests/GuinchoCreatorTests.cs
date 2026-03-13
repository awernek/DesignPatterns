namespace DesignPatterns.AbstractFactory.Tests;

/// <summary>
/// Testes do <see cref="GuinchoCreator"/>.
/// Assim como o VeiculoCreator, encapsula a criação do tipo concreto de guincho
/// conforme o porte, mantendo o cliente desacoplado das implementações.
/// </summary>
public class GuinchoCreatorTests
{
    [Theory]
    [InlineData(Porte.Pequeno, typeof(GuinchoPequeno))]
    [InlineData(Porte.Medio, typeof(GuinchoMedio))]
    [InlineData(Porte.Grande, typeof(GuinchoGrande))]
    public void Criar_PorPorte_RetornaTipoConcretoCorreto(Porte porte, Type tipoEsperado)
    {
        var guincho = GuinchoCreator.Criar(porte);

        Assert.IsType(tipoEsperado, guincho);
        Assert.Equal(porte, guincho.Porte);
    }

    [Fact]
    public void Criar_PorteInvalido_LancaArgumentException()
    {
        var porteInvalido = (Porte)100;

        var ex = Assert.Throws<ArgumentException>(() => GuinchoCreator.Criar(porteInvalido));

        Assert.Contains("Porte desconhecido", ex.Message);
    }
}
