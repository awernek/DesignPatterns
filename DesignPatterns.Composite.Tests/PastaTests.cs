using System.IO;
using System.Text;

namespace DesignPatterns.Composite.Tests;

public class PastaTests
{
    [Fact]
    public void Vazia_ObterTamanhoZero()
    {
        var sut = new Pasta("vazia");

        Assert.Equal(0, sut.ObterTamanho());
    }

    [Fact]
    public void ComFilhos_SomaTamanhos()
    {
        var sut = new Pasta("p");
        sut.Adicionar(new Arquivo("a", "x", 100));
        sut.Adicionar(new Arquivo("b", "x", 50));

        Assert.Equal(150, sut.ObterTamanho());
    }

    [Fact]
    public void Aninhada_PropagaTamanhoRecursivamente()
    {
        var interna = new Pasta("interna");
        interna.Adicionar(new Arquivo("f", "cs", 1000));

        var raiz = new Pasta("raiz");
        raiz.Adicionar(interna);
        raiz.Adicionar(new Arquivo("g", "txt", 500));

        Assert.Equal(1500, raiz.ObterTamanho());
    }

    [Fact]
    public void Adicionar_ComponenteNulo_LancaArgumentNullException()
    {
        var sut = new Pasta("p");

        Assert.Throws<ArgumentNullException>(() => sut.Adicionar(null!));
    }

    [Fact]
    public void Exibir_ListaFilhosComIndentacao()
    {
        var sut = new Pasta("docs");
        sut.Adicionar(new Arquivo("readme", "md", 200));

        var saida = CapturarSaidaConsole(() => sut.Exibir());

        Assert.Contains("+ docs/", saida);
        Assert.Contains("- readme.md", saida);
        Assert.Contains("200 B", saida);
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
