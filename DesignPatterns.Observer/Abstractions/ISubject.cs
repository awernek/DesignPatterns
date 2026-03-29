namespace DesignPatterns.Observer;

/// <summary>Subject: contrato para registrar observers e notificar.</summary>
public interface ISubject
{
    void Inscrever(IObserver observer);

    void Desinscrever(IObserver observer);

    void Notificar();
}
