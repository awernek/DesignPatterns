namespace DesignPatterns.Composite.Tests;

/// <summary>O cliente usa só <see cref="IComponente"/>; não distingue folha de composto para tamanho.</summary>
public class IComponentePolimorfismoTests
{
    [Fact]
    public void ObterTamanho_MesmaChamadaParaFolhaEComposto()
    {
        IComponente folha = new Arquivo("x", "bin", 42);
        var pasta = new Pasta("p");
        pasta.Adicionar(new Arquivo("y", "bin", 58));
        IComponente composto = pasta;

        Assert.Equal(42, folha.ObterTamanho());
        Assert.Equal(58, composto.ObterTamanho());
    }
}
