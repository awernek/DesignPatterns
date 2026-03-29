namespace DesignPatterns.Composite.Tests;

public class ArquivoTests
{
    [Fact]
    public void ObterTamanho_RetornaBytesInformados()
    {
        var sut = new Arquivo("a", "txt", 99);

        Assert.Equal(99, sut.ObterTamanho());
    }

    [Fact]
    public void Construtor_TamanhoNegativo_LancaArgumentOutOfRangeException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Arquivo("a", "txt", -1));
    }
}
