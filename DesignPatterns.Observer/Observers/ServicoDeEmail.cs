namespace DesignPatterns.Observer;

public class ServicoDeEmail : IObserver
{
    private readonly string _emailCliente;

    public ServicoDeEmail(string emailCliente)
    {
        ArgumentNullException.ThrowIfNull(emailCliente);
        _emailCliente = emailCliente;
    }

    public void Atualizar(string numeroPedido, StatusPedido novoStatus)
    {
        var mensagem = novoStatus switch
        {
            StatusPedido.Pago => "Pagamento confirmado! Seu pedido está sendo preparado.",
            StatusPedido.Enviado => "Seu pedido foi enviado! Acompanhe pelo código de rastreio.",
            StatusPedido.Entregue => "Pedido entregue! Avalie sua compra.",
            StatusPedido.Cancelado => "Seu pedido foi cancelado. O reembolso será processado.",
            _ => null
        };

        if (mensagem != null)
            Console.WriteLine($"  [E-mail] {_emailCliente}: \"{mensagem}\"");
    }
}
