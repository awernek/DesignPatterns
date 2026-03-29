namespace DesignPatterns.Observer;

/// <summary>Concrete subject: mantém status e notifica inscritos sem conhecê-los.</summary>
public class Pedido : ISubject
{
    private readonly List<IObserver> _observers = new();
    private StatusPedido _status = StatusPedido.Aguardando;

    public Pedido(string numeroPedido)
    {
        ArgumentNullException.ThrowIfNull(numeroPedido);

        NumeroPedido = numeroPedido;
        Console.WriteLine();
        Console.WriteLine($"  Pedido {NumeroPedido} criado — status: {_status}");
    }

    public string NumeroPedido { get; }

    public StatusPedido Status => _status;

    public void Inscrever(IObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);

        _observers.Add(observer);
        Console.WriteLine($"  [{observer.GetType().Name}] inscrito no pedido {NumeroPedido}");
    }

    public void Desinscrever(IObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);

        _observers.Remove(observer);
        Console.WriteLine($"  [{observer.GetType().Name}] desinscrito do pedido {NumeroPedido}");
    }

    public void Notificar()
    {
        foreach (var observer in _observers)
            observer.Atualizar(NumeroPedido, _status);
    }

    public void AtualizarStatus(StatusPedido novoStatus)
    {
        var linha = new string('-', 50);
        Console.WriteLine();
        Console.WriteLine($"  {linha}");
        Console.WriteLine($"  Pedido {NumeroPedido}: {_status} → {novoStatus}");
        Console.WriteLine($"  {linha}");

        _status = novoStatus;
        Notificar();
    }
}
