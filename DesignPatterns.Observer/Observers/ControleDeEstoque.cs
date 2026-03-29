namespace DesignPatterns.Observer;

public class ControleDeEstoque : IObserver
{
    public void Atualizar(string numeroPedido, StatusPedido novoStatus)
    {
        switch (novoStatus)
        {
            case StatusPedido.Pago:
                Console.WriteLine($"  [Estoque] Reservando itens do pedido {numeroPedido}...");
                break;
            case StatusPedido.EmSeparacao:
                Console.WriteLine($"  [Estoque] Baixando itens do inventário — pedido {numeroPedido}");
                break;
            case StatusPedido.Cancelado:
                Console.WriteLine($"  [Estoque] Devolvendo itens ao inventário — pedido {numeroPedido}");
                break;
        }
    }
}
