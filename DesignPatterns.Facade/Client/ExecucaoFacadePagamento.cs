namespace DesignPatterns.Facade;

/// <summary>Demonstração: o cliente só usa <see cref="PagamentoFacade.Pagar"/>.</summary>
public static class ExecucaoFacadePagamento
{
    public static void Executar()
    {
        Console.WriteLine();
        Console.WriteLine("Pagamentos — Facade");

        var facade = new PagamentoFacade(
            new PayPal(),
            new MercadoPago(),
            new PicPay(),
            new NotificacaoPagamento());

        facade.Pagar("paypal", "joao@email.com", 350.00m);
        facade.Pagar("mercadopago", "123.456.789-00", 89.90m);
        facade.Pagar("picpay", "joaosilva", 25.00m);
    }
}
