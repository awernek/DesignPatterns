namespace DesignPatterns.Composite.Tests;

public class FormatadorTamanhoBytesTests
{
    [Theory]
    [InlineData(0L, "0 B")]
    [InlineData(500L, "500 B")]
    [InlineData(1024L, "1 KB")]
    [InlineData(2_400_000L, "2 MB")]
    public void Formatar_RetornaUnidadeEsperada(long bytes, string esperado) =>
        Assert.Equal(esperado, FormatadorTamanhoBytes.Formatar(bytes));
}
