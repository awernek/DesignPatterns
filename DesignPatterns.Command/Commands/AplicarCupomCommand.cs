namespace DesignPatterns.Command;

public class AplicarCupomCommand : ICommand
{
    private readonly Carrinho _carrinho;
    private readonly string _cupom;
    private readonly decimal _desconto;

    public AplicarCupomCommand(Carrinho carrinho, string cupom, decimal desconto)
    {
        _carrinho = carrinho;
        _cupom = cupom;
        _desconto = desconto;
    }

    public void Execute()
    {
        _carrinho.AplicarCupom(_cupom, _desconto);
        Console.WriteLine($"  Cupom aplicado: {_cupom} (-R$ {_desconto:F2})");
    }

    public void Undo()
    {
        _carrinho.RemoverCupom();
        Console.WriteLine($"  Removeu cupom: {_cupom}");
    }
}
