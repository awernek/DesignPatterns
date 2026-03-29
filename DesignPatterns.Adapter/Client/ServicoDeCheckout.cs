namespace DesignPatterns.Adapter;

/// <summary>
/// Cliente: depende apenas de <see cref="IProcessadorPagamento"/> (DIP).
/// </summary>
public class ServicoDeCheckout
{
    private readonly IProcessadorPagamento _processador;

    public ServicoDeCheckout(IProcessadorPagamento processador)
    {
        _processador = processador;
    }

    public void FinalizarCompra(string cartao, decimal valor)
    {
        var linha = new string('-', 48);
        Console.WriteLine();
        Console.WriteLine($"  {linha}");
        Console.WriteLine($"  Finalizando compra — R$ {valor:F2}");
        Console.WriteLine($"  {linha}");

        var sucesso = _processador.ProcessarPagamento(cartao, valor, "BRL");

        if (sucesso)
        {
            Console.WriteLine("  Pagamento aprovado.");

            var status = _processador.ConsultarStatus("PS-12345");
            Console.WriteLine($"  Status da transação: {status}");
        }
        else
        {
            Console.WriteLine("  Pagamento recusado.");
        }
    }

    public void EstornarCompra(string transacaoId)
    {
        var linha = new string('-', 48);
        Console.WriteLine();
        Console.WriteLine($"  {linha}");
        Console.WriteLine($"  Solicitando estorno: {transacaoId}");
        Console.WriteLine($"  {linha}");

        var sucesso = _processador.EstornarPagamento(transacaoId);
        Console.WriteLine(sucesso ? "  Estorno aprovado." : "  Estorno recusado.");
    }
}
