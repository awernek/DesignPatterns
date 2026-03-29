namespace DesignPatterns.Observer;

/// <summary>Demonstração: subject notifica vários observers ao mudar o status.</summary>
public static class ExecucaoObserver
{
    public static void Executar()
    {
        Console.WriteLine();
        Console.WriteLine("Status de pedido — Observer");

        var pedido = new Pedido("PED-2024-9871");

        Console.WriteLine();
        Console.WriteLine("— Inscrevendo serviços —");
        pedido.Inscrever(new ServicoDeEmail("joao@email.com"));
        pedido.Inscrever(new ControleDeEstoque());
        pedido.Inscrever(new ProgramaDeFidelidade("123.456.789-00"));
        pedido.Inscrever(new SistemaDeRastreio());

        pedido.AtualizarStatus(StatusPedido.Pago);
        pedido.AtualizarStatus(StatusPedido.EmSeparacao);
        pedido.AtualizarStatus(StatusPedido.Enviado);
        pedido.AtualizarStatus(StatusPedido.Entregue);

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("— Pedido cancelado (fidelidade desinscrita antes) —");
        var pedido2 = new Pedido("PED-2024-9872");
        var fidelidade = new ProgramaDeFidelidade("987.654.321-00");

        pedido2.Inscrever(new ServicoDeEmail("maria@email.com"));
        pedido2.Inscrever(new ControleDeEstoque());
        pedido2.Inscrever(fidelidade);

        pedido2.AtualizarStatus(StatusPedido.Pago);

        pedido2.Desinscrever(fidelidade);
        pedido2.AtualizarStatus(StatusPedido.Cancelado);
    }
}
