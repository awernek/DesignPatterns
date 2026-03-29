namespace DesignPatterns.Command;

/// <summary>Demonstração: carrinho + histórico com undo/redo.</summary>
public static class ExecucaoCarrinho
{
    public static void Executar()
    {
        Console.WriteLine();
        Console.WriteLine("Carrinho — Command");

        var carrinho = new Carrinho();
        var historico = new HistoricoCarrinho();

        Console.WriteLine();
        Console.WriteLine("— Adicionando itens —");
        historico.Executar(new AdicionarItemCommand(carrinho, "Notebook Dell", 1, 3499.90m));
        historico.Executar(new AdicionarItemCommand(carrinho, "Mouse Logitech", 2, 89.90m));
        historico.Executar(new AdicionarItemCommand(carrinho, "Teclado Mecânico", 1, 259.90m));
        carrinho.Exibir();

        Console.WriteLine();
        Console.WriteLine("— Aplicando cupom —");
        historico.Executar(new AplicarCupomCommand(carrinho, "BLACKFRIDAY20", 200.00m));
        carrinho.Exibir();

        Console.WriteLine();
        Console.WriteLine("— Alterando quantidade do Mouse —");
        historico.Executar(new AlterarQuantidadeCommand(carrinho, "Mouse Logitech", 4));
        carrinho.Exibir();

        Console.WriteLine();
        Console.WriteLine("— Desfazendo alteração de quantidade —");
        historico.Desfazer();
        carrinho.Exibir();

        Console.WriteLine();
        Console.WriteLine("— Removendo cupom (desfazer) —");
        historico.Desfazer();
        carrinho.Exibir();

        Console.WriteLine();
        Console.WriteLine("— Reaplicando cupom (refazer) —");
        historico.Refazer();
        carrinho.Exibir();
    }
}
