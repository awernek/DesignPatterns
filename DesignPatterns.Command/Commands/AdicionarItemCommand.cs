namespace DesignPatterns.Command;

public class AdicionarItemCommand : ICommand
{
    private readonly Carrinho _carrinho;
    private readonly string _produto;
    private readonly int _quantidade;
    private readonly decimal _preco;

    public AdicionarItemCommand(Carrinho carrinho, string produto, int quantidade, decimal preco)
    {
        _carrinho = carrinho;
        _produto = produto;
        _quantidade = quantidade;
        _preco = preco;
    }

    public void Execute()
    {
        _carrinho.AdicionarItem(_produto, _quantidade, _preco);
        Console.WriteLine($"  Adicionou: {_quantidade}x {_produto} (R$ {_preco:F2}/un)");
    }

    public void Undo()
    {
        _carrinho.RemoverItem(_produto, _quantidade);
        Console.WriteLine($"  Desfez adição de {_quantidade}x {_produto}");
    }
}
