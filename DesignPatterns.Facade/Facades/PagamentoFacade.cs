namespace DesignPatterns.Facade;

/// <summary>
/// Facade: o cliente pede pagamento por nome do provedor; a fachada delega ao subsistema certo e dispara a notificação.
/// </summary>
public class PagamentoFacade
{
    private readonly PayPal _payPal;
    private readonly MercadoPago _mercadoPago;
    private readonly PicPay _picPay;
    private readonly NotificacaoPagamento _notificacao;

    public PagamentoFacade(
        PayPal payPal,
        MercadoPago mercadoPago,
        PicPay picPay,
        NotificacaoPagamento notificacao)
    {
        _payPal = payPal;
        _mercadoPago = mercadoPago;
        _picPay = picPay;
        _notificacao = notificacao;
    }

    public bool Pagar(string provedor, string identificador, decimal valor)
    {
        ArgumentNullException.ThrowIfNull(provedor);
        ArgumentNullException.ThrowIfNull(identificador);
        if (string.IsNullOrWhiteSpace(identificador))
            throw new ArgumentException("Identificador inválido.", nameof(identificador));

        var chave = provedor.Trim().ToLowerInvariant();
        if (chave.Length == 0)
            throw new ArgumentException("Provedor inválido.", nameof(provedor));

        var linha = new string('-', 44);
        Console.WriteLine();
        Console.WriteLine($"  {linha}");
        Console.WriteLine($"  Pagando R$ {valor:F2} via {provedor}");
        Console.WriteLine($"  {linha}");

        var sucesso = chave switch
        {
            "paypal" => _payPal.Cobrar(identificador, valor),
            "mercadopago" => _mercadoPago.RealizarCobranca(identificador, valor),
            "picpay" => _picPay.EfetuarPagamento(identificador, valor),
            _ => throw new ArgumentException($"Provedor '{provedor}' não suportado.", nameof(provedor))
        };

        if (sucesso)
            _notificacao.Confirmar(identificador, valor, provedor);

        Console.WriteLine(sucesso ? "\n  Tudo certo." : "\n  Falha no pagamento.");
        return sucesso;
    }
}
