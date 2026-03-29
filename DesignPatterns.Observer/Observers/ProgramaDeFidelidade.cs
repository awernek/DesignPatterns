namespace DesignPatterns.Observer;

public class ProgramaDeFidelidade : IObserver
{
    private readonly string _cpfCliente;

    public ProgramaDeFidelidade(string cpfCliente)
    {
        ArgumentNullException.ThrowIfNull(cpfCliente);
        _cpfCliente = cpfCliente;
    }

    public void Atualizar(string numeroPedido, StatusPedido novoStatus)
    {
        switch (novoStatus)
        {
            case StatusPedido.Entregue:
                Console.WriteLine($"  [Fidelidade] Creditando pontos para CPF {_cpfCliente}");
                break;
            case StatusPedido.Cancelado:
                Console.WriteLine($"  [Fidelidade] Estornando pontos do CPF {_cpfCliente}");
                break;
        }
    }
}
