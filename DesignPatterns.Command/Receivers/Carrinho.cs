namespace DesignPatterns.Command;

/// <summary>Receiver: regras do carrinho; não gerencia undo/redo.</summary>
public class Carrinho
{
    private readonly List<ItemCarrinho> _itens = new();
    private string? _cupom;
    private decimal _desconto;

    public IReadOnlyList<ItemCarrinho> Itens => _itens;

    public string? CupomAplicado => _cupom;

    public decimal DescontoCupom => _desconto;

    public void AdicionarItem(string produto, int quantidade, decimal preco)
    {
        ArgumentNullException.ThrowIfNull(produto);
        if (quantidade <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantidade));
        if (preco < 0)
            throw new ArgumentOutOfRangeException(nameof(preco));

        var existente = _itens.FirstOrDefault(i => i.Produto == produto);

        if (existente != null)
            existente.Quantidade += quantidade;
        else
            _itens.Add(new ItemCarrinho { Produto = produto, Quantidade = quantidade, PrecoUnit = preco });
    }

    public void RemoverItem(string produto, int quantidade)
    {
        ArgumentNullException.ThrowIfNull(produto);
        if (quantidade <= 0)
            return;

        var item = _itens.FirstOrDefault(i => i.Produto == produto);
        if (item == null)
            return;

        item.Quantidade -= quantidade;
        if (item.Quantidade <= 0)
            _itens.Remove(item);
    }

    public void AlterarQuantidade(string produto, int novaQuantidade)
    {
        ArgumentNullException.ThrowIfNull(produto);

        var item = _itens.FirstOrDefault(i => i.Produto == produto);
        if (item != null)
            item.Quantidade = novaQuantidade;
    }

    public void AplicarCupom(string cupom, decimal desconto)
    {
        ArgumentNullException.ThrowIfNull(cupom);
        if (desconto < 0)
            throw new ArgumentOutOfRangeException(nameof(desconto));

        _cupom = cupom;
        _desconto = desconto;
    }

    public void RemoverCupom()
    {
        _cupom = null;
        _desconto = 0;
    }

    public void Exibir()
    {
        var linha = new string('-', 46);
        Console.WriteLine();
        Console.WriteLine($"  {linha}");
        Console.WriteLine("  Carrinho atual:");

        if (!_itens.Any())
        {
            Console.WriteLine("  (vazio)");
            Console.WriteLine($"  {linha}");
            return;
        }

        foreach (var item in _itens)
            Console.WriteLine($"  - {item.Produto,-22} {item.Quantidade}x  R$ {item.Total:F2}");

        var subtotal = _itens.Sum(i => i.Total);
        Console.WriteLine($"  {linha}");

        if (_cupom != null)
        {
            Console.WriteLine($"  Subtotal                        R$ {subtotal:F2}");
            Console.WriteLine($"  Cupom [{_cupom}]            -R$ {_desconto:F2}");
            Console.WriteLine($"  Total                           R$ {subtotal - _desconto:F2}");
        }
        else
        {
            Console.WriteLine($"  Total                           R$ {subtotal:F2}");
        }

        Console.WriteLine($"  {linha}");
    }
}
