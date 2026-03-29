namespace DesignPatterns.Observer;

public class SistemaDeRastreio : IObserver
{
    public void Atualizar(string numeroPedido, StatusPedido novoStatus)
    {
        switch (novoStatus)
        {
            case StatusPedido.EmSeparacao:
                Console.WriteLine($"  [Rastreio] Pedido {numeroPedido} em separação no CD");
                break;
            case StatusPedido.Enviado:
                Console.WriteLine($"  [Rastreio] Código gerado — pedido {numeroPedido} a caminho");
                break;
            case StatusPedido.Entregue:
                Console.WriteLine($"  [Rastreio] Pedido {numeroPedido} finalizado");
                break;
        }
    }
}
