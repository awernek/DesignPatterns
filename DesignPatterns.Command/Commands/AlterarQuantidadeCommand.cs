namespace DesignPatterns.Command;

public class AlterarQuantidadeCommand : ICommand
{
    private readonly Carrinho _carrinho;
    private readonly string _produto;
    private readonly int _novaQuantidade;
    private int _quantidadeAnterior;

    public AlterarQuantidadeCommand(Carrinho carrinho, string produto, int novaQuantidade)
    {
        _carrinho = carrinho;
        _produto = produto;
        _novaQuantidade = novaQuantidade;
    }

    public void Execute()
    {
        var item = _carrinho.Itens.FirstOrDefault(i => i.Produto == _produto);
        _quantidadeAnterior = item?.Quantidade ?? 0;

        _carrinho.AlterarQuantidade(_produto, _novaQuantidade);
        Console.WriteLine($"  Alterou quantidade de {_produto}: {_quantidadeAnterior} → {_novaQuantidade}");
    }

    public void Undo()
    {
        _carrinho.AlterarQuantidade(_produto, _quantidadeAnterior);
        Console.WriteLine($"  Restaurou quantidade de {_produto}: {_novaQuantidade} → {_quantidadeAnterior}");
    }
}
