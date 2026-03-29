namespace DesignPatterns.Command.Tests;

public class CarrinhoTests
{
    [Fact]
    public void AdicionarItem_MesmoProduto_SomaQuantidade()
    {
        var sut = new Carrinho();
        sut.AdicionarItem("Mouse", 1, 10m);
        sut.AdicionarItem("Mouse", 2, 10m);

        var item = Assert.Single(sut.Itens);
        Assert.Equal(3, item.Quantidade);
    }

    [Fact]
    public void RemoverItem_QuantidadeZero_RemoveLinha()
    {
        var sut = new Carrinho();
        sut.AdicionarItem("X", 1, 5m);
        sut.RemoverItem("X", 1);

        Assert.Empty(sut.Itens);
    }

    [Fact]
    public void AplicarCupomERemover_ExpoeEstado()
    {
        var sut = new Carrinho();
        sut.AplicarCupom("PROMO", 15m);
        Assert.Equal("PROMO", sut.CupomAplicado);
        Assert.Equal(15m, sut.DescontoCupom);

        sut.RemoverCupom();
        Assert.Null(sut.CupomAplicado);
        Assert.Equal(0m, sut.DescontoCupom);
    }
}
