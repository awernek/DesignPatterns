using System.IO;
using System.Text;

namespace DesignPatterns.Command.Tests;

public class ConcreteCommandTests
{
    [Fact]
    public void AdicionarItemCommand_Undo_RemoveEfeito()
    {
        var carrinho = new Carrinho();
        var cmd = new AdicionarItemCommand(carrinho, "Teclado", 1, 100m);

        CapturarSaidaConsole(() => cmd.Execute());
        Assert.Single(carrinho.Itens);

        CapturarSaidaConsole(() => cmd.Undo());
        Assert.Empty(carrinho.Itens);
    }

    [Fact]
    public void AlterarQuantidadeCommand_Undo_RestauraValorAnterior()
    {
        var carrinho = new Carrinho();
        carrinho.AdicionarItem("Mouse", 2, 50m);
        var cmd = new AlterarQuantidadeCommand(carrinho, "Mouse", 5);

        CapturarSaidaConsole(() => cmd.Execute());
        Assert.Equal(5, carrinho.Itens[0].Quantidade);

        CapturarSaidaConsole(() => cmd.Undo());
        Assert.Equal(2, carrinho.Itens[0].Quantidade);
    }

    [Fact]
    public void AplicarCupomCommand_Undo_RemoveCupom()
    {
        var carrinho = new Carrinho();
        var cmd = new AplicarCupomCommand(carrinho, "BF", 50m);

        CapturarSaidaConsole(() => cmd.Execute());
        Assert.NotNull(carrinho.CupomAplicado);

        CapturarSaidaConsole(() => cmd.Undo());
        Assert.Null(carrinho.CupomAplicado);
    }

    private static void CapturarSaidaConsole(Action acao)
    {
        var originalOut = Console.Out;
        try
        {
            using var writer = new StringWriter(new StringBuilder());
            Console.SetOut(writer);
            acao();
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }
}
