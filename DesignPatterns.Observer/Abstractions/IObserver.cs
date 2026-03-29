namespace DesignPatterns.Observer;

/// <summary>Observer: reage a mudanças de status publicadas pelo subject.</summary>
public interface IObserver
{
    void Atualizar(string numeroPedido, StatusPedido novoStatus);
}
